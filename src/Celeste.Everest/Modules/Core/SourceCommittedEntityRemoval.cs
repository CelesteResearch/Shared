using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Threading;
using Celeste.Core.Scheduling;
using Celeste.Scene.Scheduling;
using Celeste.Scene.Tracking;
using MonoMod.RuntimeDetour;

namespace Celeste.Everest.Modules.Core
{
    // Each Removed callback still observes the list immediately after its own removal.
    internal sealed partial class SourceCommittedEntityRemoval : IDisposable
    {
        private sealed class IdentityComparer : IEqualityComparer<object>
        {
            internal static readonly IdentityComparer Instance = new();
            public new bool Equals(object a, object b) => ReferenceEquals(a, b);
            public int GetHashCode(object value) => RuntimeHelpers.GetHashCode(value);
        }

        private sealed class RemovalScope
        {
            internal readonly Dictionary<object, int> Indices = new(IdentityComparer.Instance);
            internal SourceCommittedEntityRemoval Owner;
            internal List<object> Items;
            internal bool Built, Valid;
            internal int BaseCount, Removed, Last, Version, Rebuilds, HookRevision;

            internal void Clear()
            {
                Indices.Clear();
                Items = null;
                Owner = null;
                Built = Valid = false;
                BaseCount = Removed = Version = Rebuilds = 0;
                Last = -1;
            }
        }

        private delegate void CommitOriginal(SceneUpdateScheduler scheduler);

        [ThreadStatic] private static RemovalScope currentScope;
        private static readonly Func<List<object>, int> ReadVersion = CreateVersionReader();

        private static readonly RuntimeMethodHandle ObjectEquals = typeof(object)
            .GetMethod(nameof(object.Equals), new[] { typeof(object) }).MethodHandle;

        private readonly ISourceEngineContext engine;
        private readonly System.Collections.Concurrent.ConcurrentStack<RemovalScope> available = new();

        private readonly System.Collections.Concurrent.ConcurrentDictionary<Type, (int Revision, bool Pure)>
            equalityTypes = new();

        private readonly object hookValidation = new();
        private readonly MethodDetourInfo[] protectedMethods;
        private readonly MethodDetourInfo commitInfo, removalInfo;
        private readonly MethodInfo patchMethod;
        private Hook commitHook;
        private ILHook removalHook;
        private int revision, validatedRevision = -1;
        private bool eligible;
        private volatile bool disposed;

        internal SourceCommittedEntityRemoval(ISourceEngineContext engine)
        {
            this.engine = engine;
            const BindingFlags flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance |
                                       BindingFlags.Static;
            commitInfo =
                DetourManager.GetDetourInfo(
                    typeof(SceneUpdateScheduler).GetMethod(nameof(SceneUpdateScheduler.CommitQueuedEntityLists)));
            removalInfo = DetourManager.GetDetourInfo(typeof(SceneEntityRegistry).GetMethod("RemoveCommitted", flags));
            patchMethod = GetType().GetMethod(nameof(Patch), flags);
            var methods = new List<MethodBase>();
            methods.AddRange(typeof(List<object>).GetMethods(flags)
                .Where(m => m.Name is "Remove" or "RemoveAt" or "IndexOf"));
            methods.Add(typeof(object).GetMethod(nameof(object.Equals), new[] { typeof(object) }));
            methods.Add(
                typeof(EqualityComparer<object>).GetProperty(nameof(EqualityComparer<object>.Default)).GetMethod);
            methods.AddRange(EqualityComparer<object>.Default.GetType().GetMethods(flags)
                .Where(m => m.Name is "Equals" or "IndexOf"));
            methods.AddRange(typeof(Array).GetMethods(flags)
                .Where(m => m.Name == "IndexOf" && m.IsGenericMethodDefinition)
                .Select(m => m.MakeGenericMethod(typeof(object))));
            // A hook that changes type metadata must not make an overridden Equals look pure.
            methods.AddRange(typeof(Type).GetMethods(flags)
                .Where(m => m.Name == "GetMethod" && !m.ContainsGenericParameters));
            methods.AddRange(typeof(object).GetType().GetMethods(flags)
                .Where(m => m.Name is "GetMethodImpl" or "GetMethod"));
            protectedMethods = methods.Distinct().Select(DetourManager.GetDetourInfo).ToArray();
        }

        private static Func<List<object>, int> CreateVersionReader()
        {
            try
            {
                var field = typeof(List<object>).GetField("_version", BindingFlags.Instance | BindingFlags.NonPublic);
                if (field == null || field.FieldType != typeof(int)) return null;
                var method = new DynamicMethod("ReadCommittedEntityListVersion", typeof(int),
                    new[] { typeof(List<object>) },
                    typeof(SourceCommittedEntityRemoval), true);
                var il = method.GetILGenerator();
                il.Emit(OpCodes.Ldarg_0);
                il.Emit(OpCodes.Ldfld, field);
                il.Emit(OpCodes.Ret);
                var read = (Func<List<object>, int>)method.CreateDelegate(typeof(Func<List<object>, int>));
                var test = new List<object>();
                int before = read(test);
                test.Add(new object());
                return read(test) != before ? read : null;
            }
            catch (Exception e) when (e is ArgumentException or MemberAccessException or NotSupportedException)
            {
                return null;
            }
        }

        private void Changed(DetourInfo _) => Interlocked.Increment(ref revision);
        private void Changed(ILHookInfo _) => Interlocked.Increment(ref revision);

        private bool CanLocate()
        {
            if (disposed || ReadVersion == null) return false;
            int observed = Volatile.Read(ref revision);
            if (observed != Volatile.Read(ref validatedRevision))
            {
                lock (hookValidation)
                {
                    eligible = false;
                    try
                    {
                        // Commit/RemoveCommitted wrappers still execute normally. Only the inner
                        // List.Remove call is replaced; its equality behavior and mutation are guarded.
                        eligible = protectedMethods.All(m => !m.IsDetoured) &&
                                   removalInfo.ILHooks.All(h =>
                                       h.ManipulatorMethod.MethodHandle.Equals(patchMethod.MethodHandle));
                    }
                    catch (Exception e) when (e is ArgumentException or InvalidOperationException
                                                  or NotSupportedException)
                    {
                    }

                    equalityTypes.Clear();
                    Volatile.Write(ref validatedRevision, observed);
                }
            }

            return eligible && observed == Volatile.Read(ref revision);
        }

        private bool PureEquality(Type type)
        {
            int observed = Volatile.Read(ref revision);
            if (equalityTypes.TryGetValue(type, out var known) && known.Revision == observed) return known.Pure;
            // The complete TAS encounters more types than one room. Evict cached metadata
            // instead of permanently disabling every later, otherwise eligible batch.
            if (equalityTypes.Count >= 256) equalityTypes.Clear();
            bool pure = false;
            try
            {
                var method = type.GetMethod(nameof(object.Equals), new[] { typeof(object) });
                pure = method != null && method.MethodHandle.Equals(ObjectEquals);
            }
            catch (Exception e) when (e is AmbiguousMatchException or ArgumentException or NotSupportedException)
            {
            }

            if (observed == Volatile.Read(ref revision)) equalityTypes[type] = (observed, pure);
            return pure;
        }

        private void Build(RemovalScope scope)
        {
            scope.Built = true;
            scope.Valid = true;
            scope.Removed = 0;
            scope.Last = -1;
            scope.BaseCount = scope.Items.Count;
            scope.Version = ReadVersion(scope.Items);
            scope.HookRevision = Volatile.Read(ref revision);
            scope.Indices.Clear();
            for (int i = 0; i < scope.Items.Count; i++)
            {
                var item = scope.Items[i];
                if (item == null || !PureEquality(item.GetType()) || !scope.Indices.TryAdd(item, i))
                {
                    scope.Valid = false;
                    break;
                }
            }
        }

        private static bool Remove(List<object> items, object entity)
        {
            var scope = currentScope;
            if (scope == null || !ReferenceEquals(scope.Items, items) || !scope.Owner.CanLocate())
                return Fallback(scope, items, entity);
            if (!scope.Built) scope.Owner.Build(scope);
            if (!scope.Valid) return Fallback(scope, items, entity);
            if (scope.HookRevision != Volatile.Read(ref scope.Owner.revision) ||
                ReadVersion(items) != scope.Version || items.Count != scope.BaseCount - scope.Removed)
            {
                scope.Valid = false;
                return Fallback(scope, items, entity);
            }

            if (entity == null || !scope.Indices.TryGetValue(entity, out int originalIndex))
            {
                scope.Valid = false;
                return Fallback(scope, items, entity);
            }

            if (originalIndex < scope.Last && scope.Rebuilds < 2)
            {
                scope.Rebuilds++;
                scope.Owner.Build(scope);
                if (!scope.Valid || !scope.Indices.TryGetValue(entity, out originalIndex))
                {
                    scope.Valid = false;
                    return Fallback(scope, items, entity);
                }
            }

            int index = originalIndex - scope.Removed;
            if (originalIndex < scope.Last || index < 0 || index >= items.Count ||
                !ReferenceEquals(items[index], entity) ||
                !scope.Owner.CanLocate() || scope.HookRevision != Volatile.Read(ref scope.Owner.revision))
            {
                scope.Valid = false;
                return Fallback(scope, items, entity);
            }

            items.RemoveAt(index);
            // Do not retain removed objects through later Awake callbacks after toRemove clears.
            scope.Indices.Remove(entity);
            scope.Removed++;
            scope.Last = originalIndex;
            scope.Version = ReadVersion(items);
            return true;
        }

        private static bool Fallback(RemovalScope scope, List<object> items, object entity)
        {
            if (scope != null && ReferenceEquals(scope.Items, items))
            {
                scope.Valid = false;
                scope.Indices.Clear();
            }

            return items.Remove(entity);
        }

        private void AroundCommit(CommitOriginal original, SceneUpdateScheduler scheduler)
        {
            if (!(scheduler.ActualSceneIdentity is ISourceEngineContextScene owner) ||
                !ReferenceEquals(owner.EngineContext, engine))
            {
                original(scheduler);
                return;
            }

            var previous = currentScope;
            RemovalScope scope = null;
            if (scheduler.GetToRemove().Count >= 64 && CanLocate() &&
                scheduler.Entities.Entities is List<object> items)
            {
                if (!available.TryPop(out scope)) scope = new RemovalScope();
                scope.Owner = this;
                scope.Items = items;
            }

            currentScope = scope;
            try
            {
                original(scheduler);
            }
            finally
            {
                currentScope = previous;
                if (scope != null)
                {
                    scope.Clear();
                    if (!disposed) available.Push(scope);
                }
            }
        }

        private void Patch(MonoMod.Cil.ILContext body)
        {
            int count = 0;
            foreach (var call in body.Body.Instructions)
            {
                if (call.OpCode == Mono.Cecil.Cil.OpCodes.Call && call.Operand is Mono.Cecil.MethodReference own &&
                    own.Name == nameof(Remove) &&
                    own.DeclaringType.FullName == typeof(SourceCommittedEntityRemoval).FullName)
                {
                    count++;
                    continue;
                }

                if ((call.OpCode == Mono.Cecil.Cil.OpCodes.Call || call.OpCode == Mono.Cecil.Cil.OpCodes.Callvirt) &&
                    call.Operand is Mono.Cecil.MethodReference method && method.Name == "Remove" &&
                    method.DeclaringType.FullName.StartsWith("System.Collections.Generic.List`1",
                        StringComparison.Ordinal))
                {
                    call.OpCode = Mono.Cecil.Cil.OpCodes.Call;
                    call.Operand = body.Import(typeof(SourceCommittedEntityRemoval).GetMethod(nameof(Remove),
                        BindingFlags.Static | BindingFlags.NonPublic));
                    count++;
                }
            }

            if (count != 1) throw new InvalidOperationException("Expected one committed entity list removal.");
        }

        internal void Install()
        {
            if (disposed) throw new ObjectDisposedException(nameof(SourceCommittedEntityRemoval));
            if (commitHook != null) return;
            DetourManager.DetourApplied += Changed;
            DetourManager.DetourUndone += Changed;
            DetourManager.ILHookApplied += Changed;
            DetourManager.ILHookUndone += Changed;
            try
            {
                commitHook = new Hook(commitInfo.Method, (Action<CommitOriginal, SceneUpdateScheduler>)AroundCommit);
                removalHook = new ILHook(removalInfo.Method, Patch);
            }
            catch
            {
                Dispose();
                throw;
            }
        }

        public void Dispose()
        {
            if (disposed) return;
            disposed = true;
            try
            {
                removalHook?.Dispose();
            }
            finally
            {
                try
                {
                    commitHook?.Dispose();
                }
                finally
                {
                    removalHook = null;
                    commitHook = null;
                    DetourManager.DetourApplied -= Changed;
                    DetourManager.DetourUndone -= Changed;
                    DetourManager.ILHookApplied -= Changed;
                    DetourManager.ILHookUndone -= Changed;
                    available.Clear();
                    equalityTypes.Clear();
                }
            }
        }
    }
}
