using System;
using System.Linq;
using System.Reflection;
using System.Threading;
using Celeste.Game.Execution.Levels;
using Celeste.Scene.Entities;
using Celeste.Physics.Collision.Shapes;
using Celeste.Simulation.Gameplay.Hazards.Spikes;
using Celeste.Simulation.Gameplay.Platforms.Foundation;
using Celeste.Simulation.Gameplay.Platforms.StaticMovers;
using Mono.Cecil.Cil;
using MonoMod.Cil;
using MonoMod.RuntimeDetour;

namespace Celeste.Everest.Gameplay.Hazards.Spikes
{
    internal sealed partial class SpikeAttachmentBounds
    {
        private struct StaticMoverContext
        {
            internal SpikeAttachmentBounds Owner;
            internal SourceSolidEntityState Solid;
            internal object Scene;
            internal bool Eligible;
            internal bool ListEligible;
            internal int Revision;
        }

        [ThreadStatic] private static StaticMoverContext currentStaticMover;
        private MethodDetourInfo[] staticMoverProtectedMethods;
        private int staticMoverValidatedRevision = -1;
        private bool staticMoverEligible;
        private Hook staticMoverAwakeHook;
        private ILHook staticMoverLoopHook;

        private void InitializeStaticMoverLoop()
        {
            const BindingFlags flags = BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public |
                                       BindingFlags.NonPublic;
            staticMoverProtectedMethods = typeof(SpikeAttachmentBounds).GetMethods(flags)
                .Where(method =>
                    method.DeclaringType == typeof(SpikeAttachmentBounds) && method.GetMethodBody() != null)
                .Cast<MethodBase>().Concat(typeof(SpikesState).GetConstructors()).Concat(new MethodBase[]
                {
                    typeof(SpikesState).GetMethod(nameof(SpikesState.IsOriginalSolidChecker)),
                    typeof(SourceStaticMoverState).GetMethod(nameof(SourceStaticMoverState.IsRiding),
                        new[] { typeof(SourceSolidEntityState) }),
                    typeof(Func<SourceSolidEntityState, bool>).GetMethod("Invoke"),
                    typeof(Delegate).GetProperty(nameof(Delegate.Target)).GetMethod,
                    typeof(ColliderListGeometry).GetProperty(nameof(ColliderListGeometry.colliders)).GetMethod,
                    typeof(object).GetMethod(nameof(GetType))
                }).Select(DetourManager.GetDetourInfo).ToArray();
        }

        private bool CanUseStaticMoverLoop(out int observedRevision)
        {
            observedRevision = Volatile.Read(ref revision);
            if (Volatile.Read(ref disposed)) return false;
            if (observedRevision != staticMoverValidatedRevision)
            {
                staticMoverEligible = false;
                try
                {
                    staticMoverEligible = staticMoverProtectedMethods.All(method => !method.IsDetoured);
                }
                catch (Exception error) when (error is ArgumentException or InvalidOperationException
                                                  or NotSupportedException)
                {
                }

                staticMoverValidatedRevision = observedRevision;
            }

            return staticMoverEligible && CanReject(out int currentRevision) &&
                   currentRevision == observedRevision && observedRevision == Volatile.Read(ref revision);
        }

        private void AroundStaticMoverAwake(Action<SourceSolidEntityState, object> original,
            SourceSolidEntityState solid, object scene)
        {
            var saved = currentStaticMover;
            bool trusted = CanUseStaticMoverLoop(out int observedRevision);
            bool ownScene = false;
            if (trusted && scene is OriginalLevelSceneRoot level)
            {
                ownScene = ReferenceEquals(level.EngineContext, engine);
                // Another engine's scope owns this invocation; leave its context intact.
                if (!ownScene)
                {
                    original(solid, scene);
                    return;
                }
            }

            bool allowed = trusted && ownScene &&
                           PureSolid(solid.GetType(), observedRevision);
            bool listAllowed = allowed && solid.Collider is ColliderListGeometry &&
                               CanUseColliderList(out int listRevision) && listRevision == observedRevision &&
                               !colliderListCollision.Detours.Any();
            currentStaticMover = new StaticMoverContext
            {
                Owner = this, Solid = solid, Scene = scene, Eligible = allowed, ListEligible = listAllowed,
                Revision = observedRevision
            };
            try
            {
                original(solid, scene);
            }
            finally
            {
                currentStaticMover = saved;
            }
        }

        private static bool CheckStaticMoverCurrent(SourceStaticMoverState mover, SourceSolidEntityState solid)
        {
            var context = currentStaticMover;
            if (context.Owner is { } owner && context.Eligible && ReferenceEquals(context.Solid, solid) &&
                context.Revision == Volatile.Read(ref owner.revision) &&
                mover.GetType() == typeof(SourceStaticMoverState) && mover.SolidChecker is { } callback &&
                callback.Target is SpikesState spike && spike.GetType() == typeof(SpikesState) &&
                spike.IsOriginalSolidChecker(callback) &&
                owner.TryRejectStaticMover(spike, solid, context.Scene, context.Revision)) return false;
            return mover.IsRiding(solid);
        }

        private bool TryRejectStaticMover(SpikesState spike, SourceSolidEntityState solid, object scene,
            int observedRevision)
        {
            if (Volatile.Read(ref disposed) || observedRevision != Volatile.Read(ref revision) ||
                !ReferenceEquals(spike.Scene, scene)) return false;
            if (spike.Collider is not HitboxColliderGeometry a || !ReferenceEquals(a.Entity, spike)) return false;
            var solidCollider = solid.Collider;
            if (solidCollider is ColliderListGeometry list)
                return TryRejectStaticMoverList(spike, solid, a, list, observedRevision);
            if (solidCollider is not HitboxColliderGeometry b || !ReferenceEquals(b.Entity, solid)) return false;
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
            bool separated = ax + aw + 4 < bx || bx + bw + 4 < ax || ay + ah + 4 < by || by + bh + 4 < ay;
            return separated && !Volatile.Read(ref disposed) && observedRevision == Volatile.Read(ref revision);
        }

        private void PatchStaticMoverLoop(ILContext il)
        {
            var calls = il.Body.Instructions.Where(instruction =>
                (instruction.OpCode == OpCodes.Call || instruction.OpCode == OpCodes.Callvirt) &&
                instruction.Operand is Mono.Cecil.MethodReference method &&
                method.DeclaringType.FullName == typeof(SourceStaticMoverState).FullName &&
                method.Name == nameof(SourceStaticMoverState.IsRiding) && method.Parameters.Count == 1 &&
                method.Parameters[0].ParameterType.FullName == typeof(SourceSolidEntityState).FullName).ToArray();
            if (calls.Length == 0)
            {
                // Each engine installs a scoped wrapper. A preceding instance may already
                // have routed the same source calls; detour-chain rebuilds reapply this patch.
                int routed = il.Body.Instructions.Count(instruction => instruction.OpCode == OpCodes.Call &&
                                                                       instruction.Operand is Mono.Cecil.MethodReference
                                                                           method &&
                                                                       method.DeclaringType.FullName ==
                                                                       typeof(SpikeAttachmentBounds).FullName &&
                                                                       method.Name == nameof(CheckStaticMoverCurrent) &&
                                                                       method.Parameters.Count == 2);
                if (routed is >= 1 and <= 2) return;
            }

            if (calls.Length < 1 || calls.Length > 2)
                throw new InvalidOperationException("The source static mover attachment loop changed.");
            foreach (var call in calls)
            {
                call.OpCode = OpCodes.Call;
                call.Operand = il.Import(typeof(SpikeAttachmentBounds).GetMethod(nameof(CheckStaticMoverCurrent),
                    BindingFlags.Static | BindingFlags.NonPublic));
            }
        }

        private void InstallStaticMoverLoop()
        {
            var method = typeof(SourceSolidEntityState).GetMethod(nameof(SourceSolidEntityState.Awake));
            staticMoverLoopHook = new ILHook(method, PatchStaticMoverLoop);
            staticMoverAwakeHook = new Hook(method,
                (Action<Action<SourceSolidEntityState, object>, SourceSolidEntityState, object>)AroundStaticMoverAwake);
        }

        private void DisposeStaticMoverLoop()
        {
            var awake = staticMoverAwakeHook;
            var loop = staticMoverLoopHook;
            staticMoverAwakeHook = null;
            staticMoverLoopHook = null;
            try
            {
                awake?.Dispose();
            }
            finally
            {
                loop?.Dispose();
            }
        }

        private bool TryRejectStaticMoverList(SpikesState spike, SourceSolidEntityState solid,
            HitboxColliderGeometry a, ColliderListGeometry list, int observedRevision)
        {
            if (!currentStaticMover.ListEligible || list.GetType() != typeof(ColliderListGeometry) ||
                !ReferenceEquals(list.Entity, solid)) return false;
            var parts = list.colliders;
            if (parts == null || parts.Length == 0) return false;
            var p = spike.Position;
            var q = solid.Position;
            var ap = a.Position;
            float aw = a.HitboxWidth, ah = a.HitboxHeight;
            if (!Bounded(p.X) || !Bounded(p.Y) || !Bounded(q.X) || !Bounded(q.Y) ||
                !Bounded(ap.X) || !Bounded(ap.Y) ||
                !(aw >= 0 && aw <= 1000000 && ah >= 0 && ah <= 1000000)) return false;
            double ax = (double)p.X + ap.X, ay = (double)p.Y + ap.Y;
            // No geometry snapshot survives a checker call. Every part must be a
            // currently owned hitbox, safely separated even after the spike's 1px probe.
            for (int i = 0; i < parts.Length; i++)
            {
                if (parts[i] is not HitboxColliderGeometry b || !ReferenceEquals(b.Entity, solid)) return false;
                var bp = b.Position;
                float bw = b.HitboxWidth, bh = b.HitboxHeight;
                if (!Bounded(bp.X) || !Bounded(bp.Y) ||
                    !(bw >= 0 && bw <= 1000000 && bh >= 0 && bh <= 1000000)) return false;
                double bx = (double)q.X + bp.X, by = (double)q.Y + bp.Y;
                if (!(ax + aw + 4 < bx || bx + bw + 4 < ax || ay + ah + 4 < by || by + bh + 4 < ay))
                    return false;
            }

            return !Volatile.Read(ref disposed) && observedRevision == Volatile.Read(ref revision);
        }
    }
}
