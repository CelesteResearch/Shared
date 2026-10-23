using Celeste.Core.Display;
using Celeste.Game.UI.Dialogue.Textboxes;
using System;
using System.Collections;
using System.Numerics;
using Celeste.Graphics.Display;
using Celeste.Core.Components;
using Celeste.Core.Geometry;
using Celeste.Core.Scheduling;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
using Celeste.Simulation;
using Celeste.Simulation.Presentation.Lighting;
using Celeste.Graphics.Content;
using Celeste.Graphics.Content.Atlas;
using Celeste.Game.Entities.Npcs;
using Celeste.Game.Components.Talking;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Settings;
using Celeste.Game.Audio;
using Celeste.Game.Stories.CelestialResort.Cutscenes;
using Celeste.Formats.Map.Entities.Structure;

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
                new VertexLightState(engine, -Vector2.UnitY * 16f, PackedColor.White, 1f, 32, 64));
            OwnedComponents.Add(Talker = new OriginalTalkComponent((IOriginalTalkProcess)engine,
                new IntRect(-16, -8, 32, 8), new Vector2(0f, -24f), OnTalk));
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
            if (!base.Session.GetFlag("oshiro_resort_suite"))
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
            int conversation = base.Session.GetCounter("oshiroSuiteSadConversation");
            yield return PlayerApproach(player, turnToFace: false, 12f);
            yield return global::Celeste.Game.UI.Dialogue.Textboxes.TextboxState.Say(
                "CH3_OSHIRO_SUITE_SAD" + conversation, Engine);
            yield return PlayerLeave(player);
            EndTalking(Level);
        }

        private void EndTalking(OriginalLevelSceneRoot level)
        {
            RoomPlayerSession player = Level.SourceScene.Entities.FindFirst<RoomPlayerSession>();
            if (player != null)
            {
                player.Machine.Locked = false;
                player.Machine.State = 0;
            }

            if (!finishedTalking)
            {
                int counter = base.Session.GetCounter("oshiroSuiteSadConversation");
                counter++;
                counter %= 7;
                if (counter == 0)
                {
                    counter++;
                }

                base.Session.SetCounter("oshiroSuiteSadConversation", counter);
                finishedTalking = true;
            }
        }
    }
}
