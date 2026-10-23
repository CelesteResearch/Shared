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
    public class OriginalCliffsideGrannyState : OriginalNpcState
    {
        public OriginalHahahaState Hahaha;

        private bool cutscene;

        private SimulationCoroutine talkRoutine;

        private const string talkedFlagA = "granny_2";

        private const string talkedFlagB = "granny_3";

        public OriginalCliffsideGrannyState(ISourceEngineContext engine, Vector2 position)
            : base(engine, position)
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
            if (base.Session.GetFlag("granny_1") && !base.Session.GetFlag("granny_2"))
            {
                Sprite.Play("laugh");
            }

            if (!base.Session.GetFlag("granny_3"))
            {
                OwnedComponents.Add(Talker = new OriginalTalkComponent((IOriginalTalkProcess)Engine,
                    new IntRect(-20, -16, 40, 16), new Vector2(0f, -24f), OnTalk));
                if (!base.Session.GetFlag("granny_1"))
                {
                    Talker.Enabled = false;
                }
            }
        }

        public override void Update()
        {
            RoomPlayerSession entity =
                Level.Scheduler.Entities.GetTrackedEntity<RoomPlayerSession>(
                    typeof(global::Celeste.Simulation.RoomPlayerSession).FullName);
            if (entity != null && !base.Session.GetFlag("granny_1") && !cutscene && entity.X > base.X - 40f)
            {
                cutscene = true;
                ((ISourceScene)Scene).SourceScene.QueueSourceEntity(
                    new OriginalCliffsideGrannyCutscene(Engine, this, entity));
                if (Talker != null)
                {
                    Talker.Enabled = true;
                }
            }

            Hahaha.Enabled = Sprite.CurrentAnimationID == "laugh";
            base.Update();
        }

        private void OnTalk(RoomPlayerSession player)
        {
            Level.StartCutscene(TalkEnd);
            OwnedComponents.Add(talkRoutine = new SimulationCoroutine(Engine, TalkRoutine(player)));
        }

        private IEnumerator TalkRoutine(RoomPlayerSession player)
        {
            Sprite.Play("idle");
            player.ForceCameraUpdate = true;
            yield return PlayerApproachLeftSide(player, turnToFace: true, 20f);
            yield return Level.ZoomTo(new Vector2((player.X + base.X) / 2f - Level.Camera.X, 116f), 2f, 0.5f);
            if (!base.Session.GetFlag("granny_2"))
            {
                yield return TextboxState.Say("CH4_GRANNY_2", Engine);
            }
            else
            {
                yield return TextboxState.Say("CH4_GRANNY_3", Engine);
            }

            yield return Level.ZoomBack(0.5f);
            Level.EndCutscene();
            TalkEnd(Level);
        }

        private void TalkEnd(OriginalLevelSceneRoot level)
        {
            if (!base.Session.GetFlag("granny_2"))
            {
                base.Session.SetFlag("granny_2");
            }
            else if (!base.Session.GetFlag("granny_3"))
            {
                base.Session.SetFlag("granny_3");
                OwnedComponents.Remove(Talker);
            }

            if (talkRoutine != null)
            {
                talkRoutine.RemoveSelf();
                talkRoutine = null;
            }

            RoomPlayerSession entity =
                Level.Scheduler.Entities.GetTrackedEntity<RoomPlayerSession>(
                    typeof(global::Celeste.Simulation.RoomPlayerSession).FullName);
            if (entity != null)
            {
                entity.Machine.Locked = false;
                entity.Machine.State = 0;
                entity.ForceCameraUpdate = false;
            }
        }
    }
}
