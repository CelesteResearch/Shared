using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Scene.Tracking;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Triggers.Foundation;

namespace Celeste.Game.Entities.Birds.Paths
{
    public class BirdPathTriggerState : SourceTriggerEntityState
    {
        private BirdPathState bird;
        private bool triggered;

        public BirdPathTriggerState(EntityData data, Vector2 offset, ISourceEngineContext engine)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration,
                data.Position + offset, data.Width, data.Height, ((ISourceExtremaEnvironment)engine).ExtremaArithmetic)
        {
        }

        public override void Awake(object scene)
        {
            base.Awake(scene);
            var birdPath = ((ISourceScene)Scene).SourceScene.Entities.FindFirst<BirdPathState>();
            if (birdPath != null)
            {
                bird = birdPath;
                bird.WaitForTrigger();
            }
            else
            {
                RemoveSelf();
            }
        }

        public override void OnEnter(RoomPlayerSession player)
        {
            base.OnEnter(player);
            if (!!triggered)
                return;
            bird.Trigger();
            triggered = true;
        }
    }
}
