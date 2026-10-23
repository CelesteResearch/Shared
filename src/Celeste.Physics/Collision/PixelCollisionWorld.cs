using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Physics.Collision.Vertical;
using Bounds = Celeste.Core.Geometry.Bounds;

namespace Celeste.Physics.Collision
{
// The generic list retains the exact tracked-entity order and direct concrete calls.
// The interface bridge only runs on actor queries, which already used an interface.
    public class PixelCollisionWorld<TPlatform> : IDetailedCollisionWorld, ISourceActorCollisionWorld,
        IVerticalOneWayCollisionWorld
        where TPlatform : PixelPlatform
    {
        public VerticalOneWayCollisionPolicy VerticalCollisionPolicy { get; set; }

        public List<TPlatform> Platforms { get; } = [];
        public IPixelPlatformSource<TPlatform> PlatformSource { get; set; }
        private IReadOnlyList<TPlatform> Solids => Platforms;
        private IReadOnlyList<TPlatform> JumpThrus => Platforms;

        public TPlatform FirstSolidAt(PixelActor actor, Vector2 at)
        {
            if (PlatformSource == null)
            {
                var position = actor.Position;
                actor.Position = at;
                TPlatform result = null;
                foreach (var platform in Solids)
                    if (!platform.IsJumpThru &&
                        SourceEntityCollision.Check(actor.SourceColliderOwner, ActualCollider(platform)))
                    {
                        result = platform;
                        break;
                    }

                actor.Position = position;
                return result;
            }
            else
            {
                var position = actor.Position;
                actor.Position = at;
                TPlatform result = null;
                foreach (var actualEntity in PlatformSource.GetSolids())
                {
                    var platform = ((ISourcePixelPlatformEntity<TPlatform>)actualEntity).Platform;
                    if (!platform.IsJumpThru &&
                        SourceEntityCollision.Check(actor.SourceColliderOwner, ActualCollider(platform)))
                    {
                        result = platform;
                        break;
                    }
                }

                actor.Position = position;
                return result;
            }
        }

        public TPlatform FirstJumpThruAt(PixelActor actor, Vector2 at)
        {
            if (PlatformSource == null)
            {
                var position = actor.Position;
                actor.Position = at;
                TPlatform result = null;
                foreach (var platform in JumpThrus)
                    if (platform.IsJumpThru &&
                        SourceEntityCollision.Check(actor.SourceColliderOwner, ActualCollider(platform)))
                    {
                        result = platform;
                        break;
                    }

                actor.Position = position;
                return result;
            }
            else
            {
                var position = actor.Position;
                actor.Position = at;
                TPlatform result = null;
                foreach (var actualEntity in PlatformSource.GetJumpThrus())
                {
                    var platform = ((ISourcePixelPlatformEntity<TPlatform>)actualEntity).Platform;
                    if (platform.IsJumpThru &&
                        SourceEntityCollision.Check(actor.SourceColliderOwner, ActualCollider(platform)))
                    {
                        result = platform;
                        break;
                    }
                }

                actor.Position = position;
                return result;
            }
        }

        public TPlatform FirstJumpThruOutside(PixelActor actor, Vector2 at)
        {
            if (PlatformSource == null)
            {
                foreach (var platform in JumpThrus)
                {
                    if (!platform.IsJumpThru) continue;
                    var other = ActualCollider(platform);
                    if (!SourceEntityCollision.Check(actor.SourceColliderOwner, other) &&
                        SourceActorCollision.CheckAt(actor, other, at)) return platform;
                }

                return null;
            }

            foreach (var actualEntity in PlatformSource.GetJumpThrus())
            {
                var platform = ((ISourcePixelPlatformEntity<TPlatform>)actualEntity).Platform;
                {
                    if (!platform.IsJumpThru) continue;
                    var other = ActualCollider(platform);
                    if (!SourceEntityCollision.Check(actor.SourceColliderOwner, other) &&
                        SourceActorCollision.CheckAt(actor, other, at)) return platform;
                }
            }

            return null;
        }

        private static ISourceEntityCollider ActualCollider(PixelPlatform platform)
        {
            return platform.SourceEntityOwner ?? throw new InvalidOperationException(
                "The source platform has no actual entity Collider producer.");
        }

        PixelPlatform ISourceActorCollisionWorld.FirstSolidAt(PixelActor actor, Vector2 at)
        {
            return FirstSolidAt(actor, at);
        }

        PixelPlatform ISourceActorCollisionWorld.FirstJumpThruAt(PixelActor actor, Vector2 at)
        {
            return FirstJumpThruAt(actor, at);
        }

        PixelPlatform ISourceActorCollisionWorld.FirstJumpThruOutside(PixelActor actor, Vector2 at)
        {
            return FirstJumpThruOutside(actor, at);
        }

        public TPlatform FirstSolidAt(Bounds bounds)
        {
            if (PlatformSource == null)
            {
                foreach (var platform in Solids)
                    if (!platform.IsJumpThru && platform.Intersects(bounds))
                        return platform;
                return null;
            }

            foreach (var actualEntity in PlatformSource.GetSolids())
            {
                var platform = ((ISourcePixelPlatformEntity<TPlatform>)actualEntity).Platform;
                if (!platform.IsJumpThru && platform.Intersects(bounds)) return platform;
            }

            return null;
        }

        public TPlatform FirstJumpThruAt(Bounds bounds)
        {
            if (PlatformSource == null)
            {
                foreach (var platform in JumpThrus)
                    if (platform.IsJumpThru && platform.Intersects(bounds))
                        return platform;
                return null;
            }

            foreach (var actualEntity in PlatformSource.GetJumpThrus())
            {
                var platform = ((ISourcePixelPlatformEntity<TPlatform>)actualEntity).Platform;
                if (platform.IsJumpThru && platform.Intersects(bounds)) return platform;
            }

            return null;
        }

        public TPlatform FirstJumpThruOutside(Bounds bounds, Bounds previous)
        {
            if (PlatformSource == null)
            {
                foreach (var platform in JumpThrus)
                    if (platform.IsJumpThru && !platform.Intersects(previous) && platform.Intersects(bounds))
                        return platform;
                return null;
            }

            foreach (var actualEntity in PlatformSource.GetJumpThrus())
            {
                var platform = ((ISourcePixelPlatformEntity<TPlatform>)actualEntity).Platform;
                if (platform.IsJumpThru && !platform.Intersects(previous) && platform.Intersects(bounds))
                    return platform;
            }

            return null;
        }

        PixelPlatform IDetailedCollisionWorld.FirstSolidAt(Bounds bounds)
        {
            return FirstSolidAt(bounds);
        }

        PixelPlatform IDetailedCollisionWorld.FirstJumpThruAt(Bounds bounds)
        {
            return FirstJumpThruAt(bounds);
        }

        PixelPlatform IDetailedCollisionWorld.FirstJumpThruOutside(Bounds bounds, Bounds previous)
        {
            return FirstJumpThruOutside(bounds, previous);
        }

        public bool SolidAt(Bounds bounds)
        {
            return FirstSolidAt(bounds) != null;
        }

        public bool SolidAt(Vector2 point)
        {
            if (PlatformSource == null)
            {
                foreach (var platform in Solids)
                    if (!platform.IsJumpThru && platform.Contains(point))
                        return true;
                return false;
            }

            foreach (var actualEntity in PlatformSource.GetSolids())
            {
                var platform = ((ISourcePixelPlatformEntity<TPlatform>)actualEntity).Platform;
                if (!platform.IsJumpThru && platform.Contains(point)) return true;
            }

            return false;
        }

        public bool JumpThruAt(Bounds bounds)
        {
            return FirstJumpThruAt(bounds) != null;
        }

        public bool JumpThruAt(Bounds bounds, Bounds previous)
        {
            return FirstJumpThruOutside(bounds, previous) != null;
        }
    }
}
