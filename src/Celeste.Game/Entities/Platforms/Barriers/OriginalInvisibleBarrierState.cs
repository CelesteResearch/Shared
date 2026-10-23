using System.Numerics;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Startup;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Collision.Blockers;
using Celeste.Simulation.Gameplay.Platforms.Foundation;

namespace Celeste.Game.Entities.Platforms.Barriers
{
    public sealed class OriginalInvisibleBarrierState : SourceSolidEntityState
    {
        public OriginalInvisibleBarrierState(ISourceEngineContext engine, Vector2 position, float width,
            float height, ISourceSolidWorldFactory worlds)
            : base(position, width, height, true, worlds.Create(position, true))
        {
            Tags = ((IOriginalGameTagsEnvironment)engine).Tags.TransitionUpdate.Value;
            Collidable = false;
            Visible = false;
            OwnedComponents.Add(new ClimbBlockerState(true));
            SurfaceSoundIndex = 33;
        }

        public static OriginalInvisibleBarrierState CreateFromMapData(EntityData data,
            Vector2 offset, OriginalLevelSceneRoot actualLevel)
        {
            return new(actualLevel.EngineContext, data.Position + offset, data.Width, data.Height,
                actualLevel.SolidWorldFactory);
        }

        public override void Update()
        {
            Collidable = true;
            if (SourceTrackedEntityCollision.Check(((ISourceScene)Scene).SourceScene.Entities,
                    typeof(RoomPlayerSession).FullName, this))

                Collidable = false;
            if (!Collidable)
                Active = false;
        }
    }
}
