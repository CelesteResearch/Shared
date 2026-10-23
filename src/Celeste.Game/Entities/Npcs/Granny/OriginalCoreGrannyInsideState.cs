using System;
using System.Collections;
using System.Numerics;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Structure;
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
    public class OriginalCoreGrannyInsideState : OriginalNpcState
    {
        public const string DoorConversationAvailable = "granny_door";

        private const string DoorConversationDone = "granny_door_done";

        private const string CounterFlag = "granny";

        private int conversation;

        private const int MaxConversation = 4;

        public OriginalHahahaState Hahaha;

        public OriginalGrannyLaughSfxState LaughSfx;

        private RoomPlayerSession player;

        private readonly OriginalTalkComponent talker;

        private bool talking;

        private SimulationCoroutine talkRoutine;

        private bool HasDoorConversation
        {
            get
            {
                if (Level.Session.GetFlag("granny_door")) return !Level.Session.GetFlag("granny_door_done");

                return false;
            }
        }

        private bool talkerEnabled
        {
            get
            {
                if (conversation <= 0 || conversation >= 4) return HasDoorConversation;

                return true;
            }
        }

        public OriginalCoreGrannyInsideState(ISourceEngineContext engine, EntityData data, Vector2 offset)
            : base(engine, data.Position + offset)
        {
            OwnedComponents.Add(Sprite =
                ((ISourceGameGraphicsEnvironment)Engine).GameGraphics.SpriteFactory.Create("granny"));
            Sprite.Play("idle");
            OwnedComponents.Add(LaughSfx = new(Engine, Sprite));
            MoveAnim = "walk";
            Maxspeed = 40f;
            OwnedComponents.Add(talker = new((IOriginalTalkProcess)Engine,
                new(-20, -8, 40, 8), new(0f, -24f), OnTalk));
            talker.Enabled = false;
        }

        public override void Added(object scene)
        {
            base.Added(scene);
            conversation = Level.Session.GetCounter("granny");
            ((ISourceScene)scene).SourceScene.QueueSourceEntity(Hahaha =
                new(Engine, Position + new Vector2(8f, -4f)));
            Hahaha.Enabled = false;
        }

        public override void Update()
        {
            if (!talking && conversation == 0)
            {
                player = Level.Scheduler.Entities.GetTrackedEntity<RoomPlayerSession>(
                    typeof(RoomPlayerSession).FullName);
                if (player != null && Math.Abs(player.X - X) < 48f) OnTalk(player);
            }

            talker.Enabled = talkerEnabled;
            Hahaha.Enabled = Sprite.CurrentAnimationID == "laugh";
            base.Update();
        }

        private void OnTalk(RoomPlayerSession player)
        {
            this.player = player;
            (Scene as OriginalLevelSceneRoot).StartCutscene(EndTalking);
            OwnedComponents.Add(talkRoutine = new(Engine, TalkRoutine(player)));
            talking = true;
        }

        private IEnumerator TalkRoutine(RoomPlayerSession player)
        {
            player.Machine.State = 11;
            player.Data.Dashes = 1;
            player.ForceCameraUpdate = true;
            while (!player.OnGround()) yield return null;

            yield return player.DummyWalkToExact((int)X - 16);
            player.Data.Facing = 1;
            player.ForceCameraUpdate = false;
            var zoomPoint = new Vector2(X - 8f - Level.Camera.X, 110f);
            if (HasDoorConversation)
            {
                Sprite.Scale.X = -1f;
                yield return Level.ZoomTo(zoomPoint, 2f, 0.5f);
                yield return TextboxState.Say("APP_OLDLADY_LOCKED", Engine);
            }
            else if (conversation == 0)
            {
                yield return 0.5f;
                Sprite.Scale.X = -1f;
                yield return 0.25f;
                yield return Level.ZoomTo(zoomPoint, 2f, 0.5f);
                yield return TextboxState.Say("APP_OLDLADY_B", Engine, StartLaughing, StopLaughing);
            }
            else if (conversation == 1)
            {
                Sprite.Scale.X = -1f;
                yield return Level.ZoomTo(zoomPoint, 2f, 0.5f);
                yield return TextboxState.Say("APP_OLDLADY_C", Engine, StartLaughing, StopLaughing);
            }
            else if (conversation == 2)
            {
                Sprite.Scale.X = -1f;
                yield return Level.ZoomTo(zoomPoint, 2f, 0.5f);
                yield return TextboxState.Say("APP_OLDLADY_D", Engine, StartLaughing, StopLaughing);
            }
            else if (conversation == 3)
            {
                Sprite.Scale.X = -1f;
                yield return Level.ZoomTo(zoomPoint, 2f, 0.5f);
                yield return TextboxState.Say("APP_OLDLADY_E", Engine, StartLaughing, StopLaughing);
            }

            talker.Enabled = talkerEnabled;
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

            if (HasDoorConversation)
            {
                Level.Session.SetFlag("granny_door_done");
            }
            else
            {
                Level.Session.IncrementCounter("granny");
                conversation++;
            }

            if (talkRoutine != null)
            {
                talkRoutine.RemoveSelf();
                talkRoutine = null;
            }

            Sprite.Play("idle");
            talking = false;
        }
    }
}
