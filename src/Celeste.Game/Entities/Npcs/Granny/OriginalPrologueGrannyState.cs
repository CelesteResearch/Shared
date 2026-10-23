using System;
using System.Numerics;
using Celeste.Core.Scheduling;
using Celeste.Game.Entities.Hahaha;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Stories.Farewell.Effects;
using Celeste.Graphics.Content;
using Celeste.Scene.Tracking;
using Celeste.Simulation;

namespace Celeste.Game.Entities.Npcs.Granny
{
    public class OriginalPrologueGrannyState : OriginalNpcState
    {
        public OriginalHahahaState Hahaha;

        public OriginalGrannyLaughSfxState LaughSfx;

        private bool talking;

        public OriginalPrologueGrannyState(ISourceEngineContext engine, Vector2 position)
            : base(engine, position)
        {
            OwnedComponents.Add(Sprite =
                ((ISourceGameGraphicsEnvironment)Engine).GameGraphics.SpriteFactory.Create("granny"));
            Sprite.Play("idle");
            OwnedComponents.Add(LaughSfx = new(Engine, Sprite));
        }

        public override void Added(object scene)
        {
            base.Added(scene);
            if ((scene as OriginalLevelSceneRoot).Session.GetFlag("granny")) Sprite.Play("laugh");

            ((ISourceScene)scene).SourceScene.QueueSourceEntity(Hahaha =
                new(Engine, Position + new Vector2(8f, -4f)));
            Hahaha.Enabled = false;
        }

        public override void Update()
        {
            var entity =
                Level.Scheduler.Entities.GetTrackedEntity<RoomPlayerSession>(
                    typeof(RoomPlayerSession).FullName);
            if (entity != null && !Session.GetFlag("granny") && !talking)
            {
                var num = Level.Bounds.Left + 96;
                if (entity.OnGround() && entity.X >= num && entity.X <= X + 16f &&
                    Math.Abs(entity.Y - Y) < 4f && entity.Data.Facing == Math.Sign(X - entity.X))
                {
                    talking = true;
                    ((ISourceScene)Scene).SourceScene.QueueSourceEntity(
                        new OriginalPrologueGrannyCutscene(Engine, this, entity));
                }
            }

            Hahaha.Enabled = Sprite.CurrentAnimationID == "laugh";
            base.Update();
        }
    }
}
