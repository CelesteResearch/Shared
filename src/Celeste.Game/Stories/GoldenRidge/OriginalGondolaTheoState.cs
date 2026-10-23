using System.Numerics;
using Celeste.Core.Scheduling;
using Celeste.Game.Entities.Npcs;
using Celeste.Game.Entities.Gondolas;
using Celeste.Game.Execution.Levels;
using Celeste.Graphics.Content;
using Celeste.Simulation;

namespace Celeste.Game.Stories.GoldenRidge
{
    public class OriginalGondolaTheoState : OriginalNpcState
    {
        private bool started;

        public OriginalGondolaTheoState(ISourceEngineContext engine, Vector2 position)
            : base(engine, position)
        {
            OwnedComponents.Add(Sprite =
                ((ISourceGameGraphicsEnvironment)engine).GameGraphics.SpriteFactory.Create("theo"));
            IdleAnim = "idle";
            MoveAnim = "walk";
            Visible = false;
            Maxspeed = 48f;
            SetupTheoSpriteSounds();
        }

        public override void Update()
        {
            base.Update();
            if (!started)
            {
                OriginalGondolaState gondola =
                    ((OriginalLevelSceneRoot)Scene).Scheduler.Entities.FindFirst<OriginalGondolaState>();
                RoomPlayerSession entity =
                    ((OriginalLevelSceneRoot)Scene).Scheduler.Entities
                    .GetTrackedEntity<RoomPlayerSession>(typeof(global::Celeste.Simulation.RoomPlayerSession).FullName);

                if (gondola != null && entity != null && entity.X > gondola.Left - 16f)
                {
                    started = true;
                    ((OriginalLevelSceneRoot)Scene).Scheduler.QueueSourceEntity(
                        new OriginalGondolaCutsceneState(Engine, this, gondola, entity));
                }
            }
        }
    }
}
