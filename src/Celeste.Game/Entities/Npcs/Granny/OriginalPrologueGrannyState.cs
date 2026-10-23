using System;
using System.Collections;
using System.Numerics;
using Celeste.Core.Scheduling;
using Celeste.Core.Geometry;
using Celeste.Core.Mathematics;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Entities.Npcs;
using Celeste.Game.Entities.Hahaha;
using Celeste.Game.Components.Talking;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Levels.Cutscenes;
using Celeste.Game.Content.Dialogs;
using Celeste.Game.UI.Dialogue.Textboxes;
using Celeste.Game.Stories.Farewell.Effects;
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
            OwnedComponents.Add(LaughSfx = new OriginalGrannyLaughSfxState(Engine, Sprite));
        }

        public override void Added(object scene)
        {
            base.Added(scene);
            if ((scene as OriginalLevelSceneRoot).Session.GetFlag("granny"))
            {
                Sprite.Play("laugh");
            }

            ((ISourceScene)scene).SourceScene.QueueSourceEntity(Hahaha =
                new OriginalHahahaState(Engine, Position + new Vector2(8f, -4f)));
            Hahaha.Enabled = false;
        }

        public override void Update()
        {
            RoomPlayerSession entity =
                Level.Scheduler.Entities.GetTrackedEntity<RoomPlayerSession>(
                    typeof(global::Celeste.Simulation.RoomPlayerSession).FullName);
            if (entity != null && !base.Session.GetFlag("granny") && !talking)
            {
                int num = Level.Bounds.Left + 96;
                if (entity.OnGround() && entity.X >= (float)num && entity.X <= base.X + 16f &&
                    Math.Abs(entity.Y - base.Y) < 4f && entity.Data.Facing == Math.Sign(base.X - entity.X))
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
