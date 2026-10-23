using System;
using System.Numerics;
using System.Runtime.InteropServices;

namespace Celeste.Simulation.Diagnostics.Frames
{
    // All scalar data is copied from the shared simulation. The collision mask
    // describes pure geometry probes at the end of this tick; it is not a record
    // of the collision callback(s) that happened during the tick.
    public readonly struct FrameSnapshot
    {
        public readonly FrameSnapshotKey Key;
        public readonly int EngineFrame, PlayerState;
        public readonly global::Celeste.Simulation.Runtime.FramePacing.RoomEngineFrameResult Result;
        public readonly int PositionXBits, PositionYBits, RemainderXBits, RemainderYBits;
        public readonly int NormalSpeedXBits, NormalSpeedYBits;
        public readonly int HitboxXBits, HitboxYBits, HitboxWidthBits, HitboxHeightBits;
        public readonly int AbsoluteLeftBits, AbsoluteTopBits, AbsoluteRightBits, AbsoluteBottomBits;
        public readonly global::Celeste.Simulation.Diagnostics.Collision.CollisionProbeBits Collision;

        public readonly int FirstSolidHere,
            FirstSolidLeft,
            FirstSolidRight,
            FirstSolidAbove,
            FirstSolidBelow,
            FirstJumpThruBelow;

        public readonly int PlatformCount;
        public readonly RngSnapshot Rng;

        private FrameSnapshot(FrameSnapshotKey key, RoomPlayerSession player, RngSnapshot rng)
        {
            Key = key;
            Rng = rng;
            EngineFrame = player.EngineFrame;
            Result = player.LastEngineFrameResult;
            PlayerState = player.Machine.State;
            var body = player.Body;
            PositionXBits = global::Celeste.Simulation.Diagnostics.Frames.SnapshotFloatBits.Of(body.Position.X);
            PositionYBits = global::Celeste.Simulation.Diagnostics.Frames.SnapshotFloatBits.Of(body.Position.Y);
            RemainderXBits = global::Celeste.Simulation.Diagnostics.Frames.SnapshotFloatBits.Of(body.Remainder.X);
            RemainderYBits = global::Celeste.Simulation.Diagnostics.Frames.SnapshotFloatBits.Of(body.Remainder.Y);
            NormalSpeedXBits =
                global::Celeste.Simulation.Diagnostics.Frames.SnapshotFloatBits.Of(player.Data.Motion.Normal.Speed.X);
            NormalSpeedYBits =
                global::Celeste.Simulation.Diagnostics.Frames.SnapshotFloatBits.Of(player.Data.Motion.Normal.Speed.Y);
            var collider = player.Collider;
            HitboxXBits = SnapshotFloatBits.Of(collider.Left);
            HitboxYBits = SnapshotFloatBits.Of(collider.Top);
            HitboxWidthBits = SnapshotFloatBits.Of(collider.Width);
            HitboxHeightBits = SnapshotFloatBits.Of(collider.Height);
            AbsoluteLeftBits = SnapshotFloatBits.Of(collider.AbsoluteLeft);
            AbsoluteTopBits = SnapshotFloatBits.Of(collider.AbsoluteTop);
            AbsoluteRightBits = SnapshotFloatBits.Of(collider.AbsoluteRight);
            AbsoluteBottomBits = SnapshotFloatBits.Of(collider.AbsoluteBottom);
            var registry = ((global::Celeste.Scene.Tracking.ISourceScene)player.Scene).SourceScene.Entities;
            var platforms = registry.GetTrackedEntities("Celeste.Platform");
            PlatformCount = platforms.Count;
            Vector2 observationPosition = body.Position;
            try
            {
                FirstSolidHere = IndexOf(platforms,
                    global::Celeste.Scene.Entities.SourceTrackedEntityCollision.First<object>(registry, "Celeste.Solid",
                        player));
                FirstSolidLeft = IndexOf(platforms,
                    global::Celeste.Scene.Entities.SourceTrackedEntityCollision.FirstAt<object>(registry,
                        "Celeste.Solid", player, body.Position - Vector2.UnitX));
                FirstSolidRight = IndexOf(platforms,
                    global::Celeste.Scene.Entities.SourceTrackedEntityCollision.FirstAt<object>(registry,
                        "Celeste.Solid", player, body.Position + Vector2.UnitX));
                FirstSolidAbove = IndexOf(platforms,
                    global::Celeste.Scene.Entities.SourceTrackedEntityCollision.FirstAt<object>(registry,
                        "Celeste.Solid", player, body.Position - Vector2.UnitY));
                FirstSolidBelow = IndexOf(platforms,
                    global::Celeste.Scene.Entities.SourceTrackedEntityCollision.FirstAt<object>(registry,
                        "Celeste.Solid", player, body.Position + Vector2.UnitY));
                FirstJumpThruBelow = IndexOf(platforms,
                    global::Celeste.Scene.Entities.SourceTrackedEntityCollision
                        .FirstOutsideAt<object, RoomPlayerSession>(registry, "Celeste.JumpThru", player,
                            body.Position + Vector2.UnitY));
            }
            finally
            {
                // Observation must restore pose even when a source geometry probe throws.
                // PixelActor.Position is the sole raw field; no Move/Commit/callback is invoked.
                body.Position = observationPosition;
            }

            Collision = (FirstSolidHere >= 0
                            ? global::Celeste.Simulation.Diagnostics.Collision.CollisionProbeBits.SolidHere
                            : 0) |
                        (FirstSolidLeft >= 0
                            ? global::Celeste.Simulation.Diagnostics.Collision.CollisionProbeBits.SolidLeft
                            : 0) |
                        (FirstSolidRight >= 0
                            ? global::Celeste.Simulation.Diagnostics.Collision.CollisionProbeBits.SolidRight
                            : 0) |
                        (FirstSolidAbove >= 0
                            ? global::Celeste.Simulation.Diagnostics.Collision.CollisionProbeBits.SolidAbove
                            : 0) |
                        (FirstSolidBelow >= 0
                            ? global::Celeste.Simulation.Diagnostics.Collision.CollisionProbeBits.SolidBelow
                            : 0) |
                        (FirstJumpThruBelow >= 0
                            ? global::Celeste.Simulation.Diagnostics.Collision.CollisionProbeBits.JumpThruBelow
                            : 0) |
                        (body.IgnoreJumpThrus
                            ? global::Celeste.Simulation.Diagnostics.Collision.CollisionProbeBits.IgnoreJumpThrus
                            : 0) |
                        (player.Dead
                            ? global::Celeste.Simulation.Diagnostics.Collision.CollisionProbeBits.PlayerDead
                            : 0) |
                        (player.Active
                            ? global::Celeste.Simulation.Diagnostics.Collision.CollisionProbeBits.PlayerActive
                            : 0);
        }

        private static int IndexOf(System.Collections.Generic.List<object> platforms, object hit)
        {
            if (hit == null) return -1;
            for (int i = 0; i < platforms.Count; i++)
                if (ReferenceEquals(platforms[i], hit))
                    return i;
            throw new InvalidOperationException("Tracked collision entity is absent from actual Platform tracker");
        }

        public static FrameSnapshot Capture(FrameSnapshotKey key, RoomPlayerSession player, RngSnapshot rng)
        {
            if (player == null) throw new ArgumentNullException(nameof(player));
            return new FrameSnapshot(key, player, rng);
        }
    }
}
