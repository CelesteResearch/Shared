using System.Collections;
using System.Numerics;
using Celeste.Core.Audio;
using Celeste.Core.Scheduling;
using Celeste.Game.Components.Talking;
using Celeste.Game.Execution.Graphics;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Processes;
using Celeste.Game.UI.Dialogue.Textboxes;
using Celeste.Graphics.Content;
using Celeste.Scene.Tracking;
using Celeste.Simulation;

namespace Celeste.Game.Entities.Npcs.Theo
{
    public class OriginalCityTheoState : OriginalNpcState
    {
        private readonly ISourceEngineContext engine;


        private const string DoneTalking = "theoDoneTalking";

        private int currentConversation;

        private SimulationCoroutine talkRoutine;

        public OriginalCityTheoState(ISourceEngineContext engine, Vector2 position)
            : base(engine, position)
        {
            this.engine = engine;
            OwnedComponents.Add(Sprite =
                ((OriginalGameGraphicsResources)((ISourceGameGraphicsEnvironment)engine).GameGraphics).SpriteBank
                .Create("theo"));
            Sprite.Play("idle");
        }

        public override void Added(object scene)
        {
            base.Added(scene);
            currentConversation = Session.GetCounter("theo");
            if (!Session.GetFlag("theoDoneTalking"))
                OwnedComponents.Add(Talker = new((IOriginalTalkProcess)engine,
                    new(-8, -8, 88, 8), new(0f, -24f), OnTalk));
        }

        private void OnTalk(RoomPlayerSession player)
        {
            Level.StartCutscene(OnTalkEnd);
            OwnedComponents.Add(talkRoutine = new(engine, Talk(player)));
        }

        private IEnumerator Talk(RoomPlayerSession player)
        {
            if (currentConversation == 0)
            {
                yield return PlayerApproachRightSide(player);
                yield return TextboxState.Say("CH1_THEO_A", engine, PlayerApproach48px);
            }
            else if (currentConversation == 1)
            {
                yield return PlayerApproachRightSide(player);
                yield return 0.2f;
                yield return PlayerApproach(player, true, 48f);
                yield return TextboxState.Say("CH1_THEO_B", engine);
            }
            else if (currentConversation == 2)
            {
                yield return PlayerApproachRightSide(player, true, 48f);
                yield return TextboxState.Say("CH1_THEO_C", engine);
            }
            else if (currentConversation == 3)
            {
                yield return PlayerApproachRightSide(player, true, 48f);
                yield return TextboxState.Say("CH1_THEO_D", engine);
            }
            else if (currentConversation == 4)
            {
                yield return PlayerApproachRightSide(player, true, 48f);
                yield return TextboxState.Say("CH1_THEO_E", engine);
            }
            else if (currentConversation == 5)
            {
                yield return PlayerApproachRightSide(player, true, 48f);
                yield return TextboxState.Say("CH1_THEO_F", engine, Yolo);
                Sprite.Play("yoloEnd");
                Remove(Talker);
                yield return Level.ZoomBack(0.5f);
            }

            Level.EndCutscene();
            OnTalkEnd(Level);
        }

        private void OnTalkEnd(OriginalLevelSceneRoot level)
        {
            if (currentConversation == 0)
            {
                ((IOriginalGameplayProcess)engine).SaveContext.CurrentSave.SetFlag("MetTheo");
            }
            else if (currentConversation == 1)
            {
                ((IOriginalGameplayProcess)engine).SaveContext.CurrentSave.SetFlag("TheoKnowsName");
            }
            else if (currentConversation == 5)
            {
                Session.SetFlag("theoDoneTalking");
                Remove(Talker);
            }

            var entity =
                ((ISourceScene)Scene).SourceScene.Entities.GetTrackedEntity<RoomPlayerSession>(
                    typeof(RoomPlayerSession).FullName);
            if (entity != null)
            {
                entity.Machine.Locked = false;
                entity.Machine.State = 0;
            }

            Session.IncrementCounter("theo");
            currentConversation++;
            talkRoutine.Cancel();
            talkRoutine.RemoveSelf();
            Sprite.Play("idle");
        }

        private IEnumerator Yolo()
        {
            yield return Level.ZoomTo(new(128f, 128f), 2f, 0.5f);
            yield return 0.2f;
            ((ISourceSpatialAudioEnvironment)engine).SpatialAudio.Play("event:/char/theo/yolo_fist", Position);
            Sprite.Play("yolo");
            yield return 0.1f;
            Level.DirectionalShake(-Vector2.UnitY);
            Level.ParticlesFG.Emit(((IOriginalGameplayProcess)engine).ParticleTypes.NPC01_Theo.P_YOLO, 6,
                Position + new Vector2(-3f, -24f), Vector2.One * 4f);
            yield return 0.5f;
        }
    }
}
