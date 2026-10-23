using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using Celeste.Core.Components;
using Celeste.Core.Scheduling;
using Celeste.Game.Execution.Levels;
using Celeste.Physics.Collision;
using Celeste.Physics.Collision.Shapes;
using Celeste.Scene.Entities;
using Celeste.Simulation.Gameplay.Hazards.Spikes;
using Celeste.Simulation.Gameplay.Platforms.Foundation;
using Mono.Cecil;
using Mono.Cecil.Cil;
using MonoMod.Cil;
using MonoMod.RuntimeDetour;
using MonoMod.Utils;
using MethodImplAttributes = System.Reflection.MethodImplAttributes;

namespace Celeste.Everest.Gameplay.Hazards.Spikes
{
    internal sealed partial class SpikeAttachmentBounds : IDisposable
    {
        private static readonly ConditionalWeakTable<ISourceEngineContext, SpikeAttachmentBounds> Owners = new();
        private readonly ISourceEngineContext engine;
        private readonly MethodDetourInfo collision;
        private readonly MethodDetourInfo[] protectedMethods;
        private int revision;
        private int validatedRevision = -1;
        private bool eligible;
        private bool disposed;

        private readonly ConcurrentDictionary<Type, (int Revision, bool Eligible)>
            geometryTypes = new();

        private readonly MethodDetourInfo riding;
        private ILHook ridingHook;

        internal static SpikeAttachmentBounds For(ISourceEngineContext engine)
        {
            return Owners.GetValue(engine, static owner => new(owner));
        }

        private SpikeAttachmentBounds(ISourceEngineContext engine)
        {
            this.engine = engine;
            collision = DetourManager.GetDetourInfo(
                typeof(SourceEntityCollision).GetMethod(nameof(SourceEntityCollision.Check)));
            const BindingFlags flags = BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public |
                                       BindingFlags.NonPublic;
            var methods = new List<MethodBase>();
            foreach (var name in new[]
                     {
                         nameof(SceneEntityState.Position), nameof(SceneEntityState.Collider),
                         nameof(SceneEntityState.Collidable),
                     })
            {
                var property = typeof(SceneEntityState).GetProperty(name);
                methods.Add(property.GetMethod);
                if (name == nameof(SceneEntityState.Position)) methods.Add(property.SetMethod);
            }

            methods.AddRange(typeof(SourceEntityCollision).GetMethods(flags).Where(method =>
                method.DeclaringType == typeof(SourceEntityCollision) &&
                method.Name == nameof(SourceEntityCollision.CheckAt)));
            foreach (var type in new[] { typeof(ColliderGeometry), typeof(HitboxColliderGeometry) })
                methods.AddRange(type.GetMethods(flags).Where(method => method.DeclaringType == type &&
                                                                        (method.Name.StartsWith("get_",
                                                                             StringComparison.Ordinal) ||
                                                                         method.Name ==
                                                                         nameof(ColliderGeometry.Collide))));
            methods.AddRange(typeof(Vector2).GetMethods(flags).Where(method =>
                method.DeclaringType == typeof(Vector2) && method.IsStatic &&
                (method.Name.StartsWith("op_", StringComparison.Ordinal) || method.Name == "get_Zero" ||
                 method.Name == "get_UnitX" || method.Name == "get_UnitY")));
            methods.Add(typeof(SpikesState).GetMethod("CheckAt", flags));
            riding = DetourManager.GetDetourInfo(typeof(SpikesState).GetMethod("IsRiding", flags, null,
                [typeof(SourceSolidEntityState)], null));
            methods.Add(typeof(SceneEntityState).GetProperty(nameof(SceneEntityState.Scene)).GetMethod);
            methods.Add(typeof(OriginalLevelSceneRoot).GetProperty("EngineContext")
                .GetMethod);
            methods.Add(typeof(object).GetType().GetMethod("GetInterfaceMap", [typeof(Type)]));
            protectedMethods = [.. methods.Distinct().Select(DetourManager.GetDetourInfo)];
            InitializeColliderList();
            InitializeStaticMoverLoop();
            DetourManager.DetourApplied += Changed;
            DetourManager.DetourUndone += Changed;
            DetourManager.ILHookApplied += Changed;
            DetourManager.ILHookUndone += Changed;
        }

        private void Changed(DetourInfo _)
        {
            Interlocked.Increment(ref revision);
        }

        private void Changed(ILHookInfo _)
        {
            Interlocked.Increment(ref revision);
        }

        private bool CanReject(out int observedRevision)
        {
            observedRevision = Volatile.Read(ref revision);
            if (disposed) return false;
            if (observedRevision != validatedRevision)
            {
                eligible = false;
                try
                {
                    eligible = !protectedMethods.Any(method => method.IsDetoured) && !collision.ILHooks.Any() &&
                               collision.Detours.All(TransparentWhenFalse) && !riding.Detours.Any() &&
                               riding.ILHooks.All(h => h.ManipulatorMethod.MethodHandle.Equals(
                                   GetType().GetMethod(nameof(Patch), BindingFlags.Instance | BindingFlags.NonPublic)
                                       .MethodHandle));
                }
                catch (Exception error) when (error is ArgumentException or InvalidOperationException
                                                  or NotSupportedException)
                {
                    // An unfamiliar hook body is an ordinary fallback, never a loading failure.
                }

                validatedRevision = observedRevision;
            }

            return eligible && observedRevision == Volatile.Read(ref revision);
        }

        private static bool LoadsArgument(Instruction instruction, int index)
        {
            return index switch
            {
                0 => instruction.OpCode == OpCodes.Ldarg_0,
                1 => instruction.OpCode == OpCodes.Ldarg_1,
                2 => instruction.OpCode == OpCodes.Ldarg_2,
                3 => instruction.OpCode == OpCodes.Ldarg_3,
                _ => false,
            };
        }

        private static bool TransparentWhenFalse(DetourInfo detour)
        {
            if (detour.Entry is not MethodInfo method || method.DeclaringType == null ||
                method.ContainsGenericParameters ||
                (method.MethodImplementationFlags & MethodImplAttributes.Synchronized) != 0 ||
                DetourManager.GetDetourInfo(method).IsDetoured) return false;
            var parameters = method.GetParameters();
            if (parameters.Length != 3 || method.ReturnType != typeof(bool) ||
                parameters[1].ParameterType != typeof(ISourceEntityCollider) ||
                parameters[2].ParameterType != typeof(ISourceEntityCollider) ||
                !typeof(MulticastDelegate).IsAssignableFrom(parameters[0].ParameterType)) return false;
            var invoke = parameters[0].ParameterType.GetMethod("Invoke");
            if (invoke == null || invoke.ReturnType != typeof(bool) ||
                !invoke.GetParameters().Select(parameter => parameter.ParameterType).SequenceEqual(
                    (Type[])[typeof(ISourceEntityCollider), typeof(ISourceEntityCollider)]) ||
                DetourManager.GetDetourInfo(invoke).IsDetoured ||
                (method.IsStatic && method.DeclaringType.TypeInitializer != null)) return false;

            using var definition = new DynamicMethodDefinition(method);
            var body = definition.Definition.Body;
            if (body.ExceptionHandlers.Count != 0 || body.Instructions.Count < 8) return false;
            var instructions = body.Instructions;
            var first = method.IsStatic ? 0 : 1;
            // Accept only: orig(a,b); if (result) goto filtering; return false.
            // No owner, field or additional callback is evaluated on this false path.
            return LoadsArgument(instructions[0], first) && LoadsArgument(instructions[1], first + 1) &&
                   LoadsArgument(instructions[2], first + 2) && instructions[3].OpCode == OpCodes.Callvirt &&
                   instructions[3].Operand is MethodReference call && call.Name == "Invoke" &&
                   call.DeclaringType.FullName == parameters[0].ParameterType.FullName.Replace('+', '/') &&
                   (instructions[4].OpCode == OpCodes.Brtrue || instructions[4].OpCode == OpCodes.Brtrue_S) &&
                   ReferenceEquals(instructions[4].Operand, instructions[7]) &&
                   instructions[5].OpCode == OpCodes.Ldc_I4_0 && instructions[6].OpCode == OpCodes.Ret;
        }

        private bool PureSolid(Type type, int observedRevision)
        {
            var known = geometryTypes.TryGetValue(type, out var cached);
            if (known && cached.Revision == observedRevision) return cached.Eligible;
            if (!known && geometryTypes.Count >= 256) return false;
            var result = type.GetType() == typeof(object).GetType();
            try
            {
                result &= type.GetProperty(nameof(SceneEntityState.Position)).GetMethod.MethodHandle.Equals(
                    typeof(SceneEntityState).GetProperty(nameof(SceneEntityState.Position)).GetMethod.MethodHandle);
                foreach (var contract in new[]
                             { typeof(ISourceEntityCollider), typeof(ISourceEntityPosition) })
                {
                    var expected = typeof(SourceSolidEntityState).GetInterfaceMap(contract);
                    var actual = type.GetInterfaceMap(contract);
                    result &= actual.TargetMethods.Length == expected.TargetMethods.Length && actual.TargetMethods
                        .Select((method, index) =>
                            method.MethodHandle.Equals(expected.TargetMethods[index].MethodHandle)).All(equal => equal);
                }
            }
            catch (Exception e) when (e is ArgumentException or InvalidOperationException or NotSupportedException
                                          or AmbiguousMatchException)
            {
                result = false;
            }

            if ((known || geometryTypes.Count < 256) && observedRevision == Volatile.Read(ref revision))
                geometryTypes[type] = (observedRevision, result);
            return result;
        }

        private static bool Bounded(float value)
        {
            return value >= -1000000f && value <= 1000000f;
        }

        internal bool TryReject(SpikesState spike, SourceSolidEntityState solid)
        {
            if (spike.GetType() != typeof(SpikesState) || solid == null || !CanReject(out var observedRevision) ||
                !(spike.Scene is OriginalLevelSceneRoot level) ||
                !ReferenceEquals(level.EngineContext, engine) ||
                !PureSolid(solid.GetType(), observedRevision)) return false;
            if (spike.Collider is not HitboxColliderGeometry a || solid.Collider is not HitboxColliderGeometry b ||
                !ReferenceEquals(a.Entity, spike) || !ReferenceEquals(b.Entity, solid)) return false;
            var p = spike.Position;
            var q = solid.Position;
            var ap = a.Position;
            var bp = b.Position;
            float aw = a.HitboxWidth, ah = a.HitboxHeight, bw = b.HitboxWidth, bh = b.HitboxHeight;
            if (!Bounded(p.X) || !Bounded(p.Y) || !Bounded(q.X) || !Bounded(q.Y) ||
                !Bounded(ap.X) || !Bounded(ap.Y) || !Bounded(bp.X) || !Bounded(bp.Y) ||
                !(aw >= 0 && aw <= 1000000 && ah >= 0 && ah <= 1000000 &&
                  bw >= 0 && bw <= 1000000 && bh >= 0 && bh <= 1000000)) return false;
            double ax = (double)p.X + ap.X, ay = (double)p.Y + ap.Y;
            double bx = (double)q.X + bp.X, by = (double)q.Y + bp.Y;
            // Four pixels cover the one-pixel riding offset and rounding at these bounds.
            var separated = ax + aw + 4 < bx || bx + bw + 4 < ax || ay + ah + 4 < by || by + bh + 4 < ay;
            return separated && observedRevision == Volatile.Read(ref revision);
        }

        internal void Install()
        {
            if (disposed) throw new ObjectDisposedException(nameof(SpikeAttachmentBounds));
            if (ridingHook != null) return;
            ridingHook = new(riding.Method, Patch);
            colliderListHook = new(colliderListCollision.Method, PatchColliderList);
            InstallStaticMoverLoop();
        }

        private void Patch(ILContext il)
        {
            var cursor = new ILCursor(il);
            var original = il.DefineLabel(cursor.Next);
            cursor.Emit(OpCodes.Ldarg_0);
            cursor.Emit(OpCodes.Ldarg_1);
            cursor.EmitDelegate(TryReject);
            cursor.Emit(OpCodes.Brfalse, original);
            cursor.Emit(OpCodes.Ldc_I4_0);
            cursor.Emit(OpCodes.Ret);
        }

        public void Dispose()
        {
            if (disposed) return;
            disposed = true;
            var hook = ridingHook;
            ridingHook = null;
            var listHook = colliderListHook;
            colliderListHook = null;
            try
            {
                hook?.Dispose();
            }
            finally
            {
                try
                {
                    listHook?.Dispose();
                }
                finally
                {
                    try
                    {
                        DisposeStaticMoverLoop();
                    }
                    finally
                    {
                        DetourManager.DetourApplied -= Changed;
                        DetourManager.DetourUndone -= Changed;
                        DetourManager.ILHookApplied -= Changed;
                        DetourManager.ILHookUndone -= Changed;
                        geometryTypes.Clear();
                        Owners.Remove(engine);
                    }
                }
            }
        }
    }
}
