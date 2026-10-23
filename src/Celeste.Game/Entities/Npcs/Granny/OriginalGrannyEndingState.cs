using System.Collections;
using System.Numerics;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Components.Talking;
using Celeste.Game.Content.Dialogs;
using Celeste.Game.Entities.Hahaha;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Stories.Farewell.Effects;
using Celeste.Game.UI.Dialogue.Textboxes;
using Celeste.Graphics.Content;
using Celeste.Scene.Tracking;
using Celeste.Simulation;

namespace Celeste.Game.Entities.Npcs.Granny
{
    public class OriginalGrannyEndingState : OriginalNpcState
    {
        public OriginalHahahaState Hahaha;

        public OriginalGrannyLaughSfxState LaughSfx;

        private RoomPlayerSession player;

        private readonly OriginalTalkComponent talker;

        private SimulationCoroutine talkRoutine;

        private int conversation;

        private readonly bool ch9EasterEgg;

        public OriginalGrannyEndingState(ISourceEngineContext engine, EntityData data, Vector2 offset,
            bool ch9EasterEgg = false)
            : base(engine, data.Position + offset)
        {
            OwnedComponents.Add(Sprite =
                ((ISourceGameGraphicsEnvironment)Engine).GameGraphics.SpriteFactory.Create("granny"));
            Sprite.Play("idle");
            Sprite.Scale.X = -1f;
            OwnedComponents.Add(LaughSfx = new(Engine, Sprite));
            OwnedComponents.Add(talker = new((IOriginalTalkProcess)Engine,
                new(-20, -8, 40, 8), new(0f, -24f), OnTalk));
            MoveAnim = "walk";
            Maxspeed = 40f;
            this.ch9EasterEgg = ch9EasterEgg;
        }

        public override void Added(object scene)
        {
            base.Added(scene);
            ((ISourceScene)scene).SourceScene.QueueSourceEntity(Hahaha =
                new(Engine, Position + new Vector2(8f, -4f)));
            Hahaha.Enabled = false;
        }

        public override void Update()
        {
            Hahaha.Enabled = Sprite.CurrentAnimationID == "laugh";
            base.Update();
        }

        private void OnTalk(RoomPlayerSession player)
        {
            this.player = player;
            (Scene as OriginalLevelSceneRoot).StartCutscene(EndTalking);
            OwnedComponents.Add(talkRoutine = new(Engine, TalkRoutine(player)));
        }

        private IEnumerator TalkRoutine(RoomPlayerSession player)
        {
            player.Machine.State = 11;
            player.ForceCameraUpdate = true;
            while (!player.OnGround()) yield return null;

            yield return player.DummyWalkToExact((int)X - 16);
            player.Data.Facing = 1;
            if (ch9EasterEgg)
            {
                yield return 0.5f;
                yield return Level.ZoomTo(Position - Level.Camera.Position + new Vector2(0f, -32f), 2f, 0.5f);
                ((IOriginalGameTextEnvironment)Engine).Text.Dialog.Language.Dialog["CH10_GRANNY_EASTEREGG"] =
                    GetDebugModeDialog("{portrait GRANNY right mock} I see you have discovered Debug Mode.");
                yield return TextboxState.Say("CH10_GRANNY_EASTEREGG", Engine);
                talker.Enabled = false;
            }
            else if (conversation == 0)
            {
                yield return 0.5f;
                yield return Level.ZoomTo(Position - Level.Camera.Position + new Vector2(0f, -32f), 2f, 0.5f);
                yield return TextboxState.Say("CH7_CSIDE_OLDLADY", Engine, StartLaughing, StopLaughing);
            }
            else if (conversation == 1)
            {
                yield return 0.5f;
                yield return Level.ZoomTo(Position - Level.Camera.Position + new Vector2(0f, -32f), 2f, 0.5f);
                yield return TextboxState.Say("CH7_CSIDE_OLDLADY_B", Engine, StartLaughing, StopLaughing);
                talker.Enabled = false;
            }

            yield return Level.ZoomBack(0.5f);
            Level.EndCutscene();
            EndTalking(Level);
        }

        private IEnumerator StartLaughing()
        {
            Sprite.Play("laugh");
            yield return null;
        }

        private IEnumerator StopLaughing()
        {
            Sprite.Play("idle");
            yield return null;
        }

        private void EndTalking(OriginalLevelSceneRoot level)
        {
            if (player != null)
            {
                player.Machine.State = 0;
                player.ForceCameraUpdate = false;
            }

            conversation++;
            if (talkRoutine != null)
            {
                talkRoutine.RemoveSelf();
                talkRoutine = null;
            }

            Sprite.Play("idle");
        }

        protected virtual string GetDebugModeDialog(string vanillaDialog)
        {
            return vanillaDialog;
        }
    }
}
