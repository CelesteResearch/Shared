using System.Collections;
using System.Numerics;
using Celeste.Core.Scheduling;
using Celeste.Game.Components.Talking;
using Celeste.Game.Entities.Hahaha;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Stories.Farewell.Effects;
using Celeste.Game.UI.Dialogue.Textboxes;
using Celeste.Graphics.Content;
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
                new(Engine, Position + new Vector2(8f, -4f)));
            Hahaha.Enabled = false;
            if (Session.GetFlag("granny_1") && !Session.GetFlag("granny_2")) Sprite.Play("laugh");

            if (!!Session.GetFlag("granny_3"))
                return;
            OwnedComponents.Add(Talker = new((IOriginalTalkProcess)Engine,
                new(-20, -16, 40, 16), new(0f, -24f), OnTalk));
            if (!Session.GetFlag("granny_1")) Talker.Enabled = false;
        }

        public override void Update()
        {
            var entity =
                Level.Scheduler.Entities.GetTrackedEntity<RoomPlayerSession>(
                    typeof(RoomPlayerSession).FullName);
            if (entity != null && !Session.GetFlag("granny_1") && !cutscene && entity.X > X - 40f)
            {
                cutscene = true;
                ((ISourceScene)Scene).SourceScene.QueueSourceEntity(
                    new OriginalCliffsideGrannyCutscene(Engine, this, entity));
                if (Talker != null) Talker.Enabled = true;
            }

            Hahaha.Enabled = Sprite.CurrentAnimationID == "laugh";
            base.Update();
        }

        private void OnTalk(RoomPlayerSession player)
        {
            Level.StartCutscene(TalkEnd);
            OwnedComponents.Add(talkRoutine = new(Engine, TalkRoutine(player)));
        }

        private IEnumerator TalkRoutine(RoomPlayerSession player)
        {
            Sprite.Play("idle");
            player.ForceCameraUpdate = true;
            yield return PlayerApproachLeftSide(player, true, 20f);
            yield return Level.ZoomTo(new((player.X + X) / 2f - Level.Camera.X, 116f), 2f, 0.5f);
            if (!Session.GetFlag("granny_2"))
                yield return TextboxState.Say("CH4_GRANNY_2", Engine);
            else
                yield return TextboxState.Say("CH4_GRANNY_3", Engine);

            yield return Level.ZoomBack(0.5f);
            Level.EndCutscene();
            TalkEnd(Level);
        }

        private void TalkEnd(OriginalLevelSceneRoot level)
        {
            if (!Session.GetFlag("granny_2"))
            {
                Session.SetFlag("granny_2");
            }
            else if (!Session.GetFlag("granny_3"))
            {
                Session.SetFlag("granny_3");
                OwnedComponents.Remove(Talker);
            }

            if (talkRoutine != null)
            {
                talkRoutine.RemoveSelf();
                talkRoutine = null;
            }

            var entity =
                Level.Scheduler.Entities.GetTrackedEntity<RoomPlayerSession>(
                    typeof(RoomPlayerSession).FullName);
            if (!(entity != null))
                return;
            entity.Machine.Locked = false;
            entity.Machine.State = 0;
            entity.ForceCameraUpdate = false;
        }
    }
}
