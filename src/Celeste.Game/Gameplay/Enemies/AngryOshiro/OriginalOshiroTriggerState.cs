using System.Numerics;
using Celeste.Core.Scheduling;
using Celeste.Core.Components;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Game.Execution.Levels;
using Celeste.Scene.Tracking;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Triggers.Foundation;

namespace Celeste.Game.Gameplay.Enemies.AngryOshiro
{
    public sealed class OriginalOshiroTriggerState : SourceTriggerEntityState
    {
        public bool State;

        public OriginalOshiroTriggerState(Vector2 position, float width, float height, bool state,
            ISourceEngineContext engine)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration,
                position, width, height, ((ISourceExtremaEnvironment)engine).ExtremaArithmetic)
        {
            State = state;
        }

        public override void OnEnter(RoomPlayerSession player)
        {
            base.OnEnter(player);
            if (State)
            {
                var level = Scene as OriginalLevelSceneRoot;
                var position = new Vector2(level.Bounds.Left - 32, level.Bounds.Top + level.Bounds.Height / 2);
                var actualScene = (ISourceScene)Scene;
                var process = (IOriginalAngryOshiroProcess)((ISourceEngineContextScene)Scene).EngineContext;
                actualScene.SourceScene.QueueSourceEntity(
                    ((IOriginalAngryOshiroConstructorEnvironment)process).AngryOshiroConstructors.Create(position,
                        false,
                        process));
                RemoveSelf();
            }
            else
            {
                var entities = ((ISourceScene)Scene).SourceScene.Entities.GetTrackedEntities("Celeste.AngryOshiro");
                var oshiro = entities.Count == 0 ? null : entities[0] as OriginalAngryOshiroState;
                oshiro?.Leave();
                RemoveSelf();
            }
        }
    }
}
