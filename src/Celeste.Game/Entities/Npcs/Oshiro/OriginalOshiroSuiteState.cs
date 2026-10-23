using System.Collections;
using System.Numerics;
using Celeste.Core.Display;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Components.Talking;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Stories.CelestialResort.Cutscenes;
using Celeste.Game.UI.Dialogue.Textboxes;
using Celeste.Simulation;

namespace Celeste.Game.Entities.Npcs.Oshiro
{
    public class OriginalOshiroSuiteState : OriginalNpcState
    {
        private const string ConversationCounter = "oshiroSuiteSadConversation";

        private bool finishedTalking;

        public OriginalOshiroSuiteState(ISourceEngineContext engine, Vector2 position)
            : base(engine, position)
        {
            OwnedComponents.Add(Sprite = new OshiroSpriteState(engine, 1));
            OwnedComponents.Add(Light =
                new(engine, -Vector2.UnitY * 16f, PackedColor.White, 1f, 32, 64));
            OwnedComponents.Add(Talker = new((IOriginalTalkProcess)engine,
                new(-16, -8, 32, 8), new(0f, -24f), OnTalk));
            Talker.Enabled = false;
            MoveAnim = "move";
            IdleAnim = "idle";
        }

        public OriginalOshiroSuiteState(EntityData data, Vector2 offset, ISourceEngineContext engine) : this(
            engine, data.Position + offset)
        {
        }

        public override void Added(object scene)
        {
            base.Added(scene);
            if (!Session.GetFlag("oshiro_resort_suite"))
            {
                Level.Scheduler.QueueSourceEntity(new CS03OshiroMasterSuiteState(Engine, this));
                return;
            }

            Sprite.Play("idle_ground");
            Talker.Enabled = true;
        }

        private void OnTalk(RoomPlayerSession player)
        {
            finishedTalking = false;
            Level.StartCutscene(EndTalking);
            OwnedComponents.Add(new SimulationCoroutine(Engine, Talk(player)));
        }

        private IEnumerator Talk(RoomPlayerSession player)
        {
            var conversation = Session.GetCounter("oshiroSuiteSadConversation");
            yield return PlayerApproach(player, false, 12f);
            yield return TextboxState.Say(
                "CH3_OSHIRO_SUITE_SAD" + conversation, Engine);
            yield return PlayerLeave(player);
            EndTalking(Level);
        }

        private void EndTalking(OriginalLevelSceneRoot level)
        {
            var player = Level.SourceScene.Entities.FindFirst<RoomPlayerSession>();
            if (player != null)
            {
                player.Machine.Locked = false;
                player.Machine.State = 0;
            }

            if (!!finishedTalking)
                return;
            var counter = Session.GetCounter("oshiroSuiteSadConversation");
            counter++;
            counter %= 7;
            if (counter == 0) counter++;

            Session.SetCounter("oshiroSuiteSadConversation", counter);
            finishedTalking = true;
        }
    }
}
