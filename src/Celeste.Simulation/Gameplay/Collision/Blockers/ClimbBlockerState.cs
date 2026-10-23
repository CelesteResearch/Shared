using System.Numerics;
using Celeste.Core.Components;
using Celeste.Physics.Collision;
using Celeste.Scene.Tracking;

namespace Celeste.Simulation.Gameplay.Collision.Blockers
{
    public sealed class ClimbBlockerState : SourceComponentState
    {
        public bool Blocking = true;
        public bool Edge;

        public ClimbBlockerState(bool edge) : base(false, false)
        {
            Edge = edge;
        }

        public static bool Check(object scene, ISourceEntityCollider entity, Vector2 at)
        {
            var positioned = (ISourceMutableEntityPosition)entity;
            var position = positioned.Position;
            positioned.Position = at;
            var result = Check(scene, entity);
            positioned.Position = position;
            return result;
        }

        public static bool Check(object scene, ISourceEntityCollider entity)
        {
            foreach (var actual in
                     ((ISourceScene)scene).SourceScene.Components.GetTrackedComponents("Celeste.ClimbBlocker"))
            {
                var component = (ClimbBlockerState)actual;
                if (component.Blocking && SourceEntityCollision.Check(entity, (ISourceEntityCollider)component.Entity))
                    return true;
            }

            return false;
        }

        public static bool EdgeCheck(object scene, ISourceEntityCollider entity, int direction)
        {
            return EdgeCheckOffset(scene, entity, Vector2.UnitX * direction);
        }

        public static bool EdgeCheckOffset(object scene, ISourceEntityCollider entity, Vector2 offset)
        {
            foreach (var actual in
                     ((ISourceScene)scene).SourceScene.Components.GetTrackedComponents("Celeste.ClimbBlocker"))
            {
                var component = (ClimbBlockerState)actual;
                if (component.Blocking && component.Edge && SourceEntityCollision.CheckAt(entity,
                        (ISourceEntityCollider)component.Entity, entity.Position + offset))
                    return true;
            }

            return false;
        }
    }
}
