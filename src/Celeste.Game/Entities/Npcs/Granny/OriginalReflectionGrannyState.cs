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
    public class OriginalReflectionGrannyState : OriginalNpcState
    {
        public OriginalHahahaState Hahaha;

        private int cutsceneIndex;

        public OriginalReflectionGrannyState(ISourceEngineContext engine, EntityData data, Vector2 position)
            : base(engine, data.Position + position)
        {
            OwnedComponents.Add(Sprite =
                ((ISourceGameGraphicsEnvironment)Engine).GameGraphics.SpriteFactory.Create("granny"));
            Sprite.Scale.X = -1f;
            Sprite.Play("idle");
            OwnedComponents.Add(new OriginalGrannyLaughSfxState(Engine, Sprite));
        }

        public override void Added(object scene)
        {
            base.Added(scene);
            ((ISourceScene)scene).SourceScene.QueueSourceEntity(Hahaha =
                new OriginalHahahaState(Engine, Position + new Vector2(8f, -4f)));
            Hahaha.Enabled = false;
            while (base.Session.GetFlag("granny_" + cutsceneIndex))
            {
                cutsceneIndex++;
            }

            OwnedComponents.Add(Talker = new OriginalTalkComponent((IOriginalTalkProcess)Engine,
                new IntRect(-20, -8, 30, 8), new Vector2(0f, -24f), OnTalk));
            Talker.Enabled = cutsceneIndex > 0 && cutsceneIndex < 3;
        }

        public override void Update()
        {
            if (cutsceneIndex == 0)
            {
                RoomPlayerSession entity =
                    Level.Scheduler.Entities.GetTrackedEntity<RoomPlayerSession>(
                        typeof(global::Celeste.Simulation.RoomPlayerSession).FullName);
                if (entity != null && entity.X > base.X - 60f)
                {
                    OnTalk(entity);
                }
            }

            Hahaha.Enabled = Sprite.CurrentAnimationID == "laugh";
            base.Update();
        }

        private void OnTalk(RoomPlayerSession player)
        {
            ((ISourceScene)Scene).SourceScene.QueueSourceEntity(
                new OriginalReflectionGrannyCutscene(Engine, this, player, cutsceneIndex));
            cutsceneIndex++;
            Talker.Enabled = cutsceneIndex > 0 && cutsceneIndex < 3;
        }
    }
}
