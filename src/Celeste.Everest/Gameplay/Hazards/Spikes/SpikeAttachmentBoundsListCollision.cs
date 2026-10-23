using System;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using Celeste.Game.Execution.Levels;
using Celeste.Physics.Collision.Shapes;
using Celeste.Scene.Entities;
using Mono.Cecil.Cil;
using MonoMod.Cil;
using MonoMod.RuntimeDetour;

namespace Celeste.Everest.Gameplay.Hazards.Spikes
{
    internal sealed partial class SpikeAttachmentBounds
    {
        private MethodDetourInfo colliderListCollision;
        private MethodDetourInfo[] colliderListProtectedMethods;
        private int colliderListValidatedRevision = -1;
        private bool colliderListEligible;
        private ILHook colliderListHook;

        private void InitializeColliderList()
        {
            const BindingFlags flags = BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public |
                                       BindingFlags.NonPublic;
            colliderListCollision = DetourManager.GetDetourInfo(typeof(ColliderListGeometry)
                .GetMethod(nameof(ColliderListGeometry.Collide), [typeof(HitboxColliderGeometry)]));
            colliderListProtectedMethods =
            [
                .. typeof(SpikeAttachmentBounds).GetMethods(flags)
                    .Where(method =>
                        method.DeclaringType == typeof(SpikeAttachmentBounds) && method.GetMethodBody() != null).Concat(
                        new MethodBase[]
                        {
                            typeof(ColliderListGeometry).GetProperty(nameof(ColliderListGeometry.colliders)).GetMethod,
                            typeof(object).GetMethod(nameof(GetType)),
                        }).Select(DetourManager.GetDetourInfo),
            ];
        }

        private bool CanUseColliderList(out int observedRevision)
        {
            observedRevision = Volatile.Read(ref revision);
            if (Volatile.Read(ref disposed)) return false;
            if (observedRevision != colliderListValidatedRevision)
            {
                colliderListEligible = false;
                try
                {
                    var patch = typeof(SpikeAttachmentBounds).GetMethod(nameof(PatchColliderList),
                        BindingFlags.Instance | BindingFlags.NonPublic);
                    colliderListEligible = colliderListProtectedMethods.All(method => !method.IsDetoured) &&
                                           colliderListCollision.ILHooks.All(hook =>
                                               hook.ManipulatorMethod.MethodHandle.Equals(patch.MethodHandle));
                }
                catch (Exception error) when (error is ArgumentException or InvalidOperationException
                                                  or NotSupportedException)
                {
                }

                colliderListValidatedRevision = observedRevision;
            }

            // Check helper hooks before calling the existing guard: an unfamiliar helper
            // callback must not be invoked an extra time by this optimization.
            return colliderListEligible && CanReject(out var currentRevision) &&
                   currentRevision == observedRevision && observedRevision == Volatile.Read(ref revision);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static float ColliderListAdd(float first, float second)
        {
            return first + second;
        }

        // 0 means use the original method; 1/2 are the original false/true results.
        private int TryColliderList(ColliderListGeometry list, HitboxColliderGeometry other)
        {
            if (!CanUseColliderList(out var observedRevision)) return 0;
            if (list.GetType() != typeof(ColliderListGeometry) || other == null ||
                list.Entity is not SceneEntityState owner || other.Entity is not SceneEntityState second ||
                owner.Scene is not OriginalLevelSceneRoot level ||
                level.GetType() != typeof(OriginalLevelSceneRoot) ||
                !ReferenceEquals(level.EngineContext, engine) ||
                !PureSolid(owner.GetType(), observedRevision) ||
                !PureSolid(second.GetType(), observedRevision)) return 0;

            var parts = list.colliders;
            if (parts == null || parts.Length < 2) return 0;
            for (var i = 0; i < parts.Length; i++)
                if (parts[i] is not HitboxColliderGeometry part || !ReferenceEquals(part.Entity, owner))
                    return 0;

            // All methods that could supply callbacks are guarded. No position or shape
            // snapshot survives this call, so mutations between collision checks remain visible.
            var position = owner.Position;
            var otherPosition = second.Position;
            var left = ColliderListAdd(other.Position.X, otherPosition.X);
            var right = ColliderListAdd(ColliderListAdd(other.Position.X, other.HitboxWidth), otherPosition.X);
            var top = ColliderListAdd(other.Position.Y, otherPosition.Y);
            var bottom = ColliderListAdd(ColliderListAdd(other.Position.Y, other.HitboxHeight), otherPosition.Y);
            var result = false;
            for (var i = 0; i < parts.Length; i++)
            {
                var part = (HitboxColliderGeometry)parts[i];
                // Keep the rounding boundaries of the original float-returning getters.
                if (ColliderListAdd(part.Position.X, position.X) < right &&
                    ColliderListAdd(ColliderListAdd(part.Position.X, part.HitboxWidth), position.X) > left &&
                    ColliderListAdd(ColliderListAdd(part.Position.Y, part.HitboxHeight), position.Y) > top &&
                    ColliderListAdd(part.Position.Y, position.Y) < bottom)
                {
                    result = true;
                    break;
                }
            }

            if (Volatile.Read(ref disposed) || observedRevision != Volatile.Read(ref revision)) return 0;
            return result ? 2 : 1;
        }

        private void PatchColliderList(ILContext il)
        {
            var result = new VariableDefinition(il.Method.Module.TypeSystem.Int32);
            il.Body.Variables.Add(result);
            il.Body.InitLocals = true;
            var cursor = new ILCursor(il);
            var original = il.DefineLabel(cursor.Next);
            cursor.Emit(OpCodes.Ldarg_0);
            cursor.Emit(OpCodes.Ldarg_1);
            cursor.EmitDelegate(TryColliderList);
            cursor.Emit(OpCodes.Stloc, result);
            cursor.Emit(OpCodes.Ldloc, result);
            cursor.Emit(OpCodes.Brfalse, original);
            cursor.Emit(OpCodes.Ldloc, result);
            cursor.Emit(OpCodes.Ldc_I4_2);
            cursor.Emit(OpCodes.Ceq);
            cursor.Emit(OpCodes.Ret);
        }
    }
}
