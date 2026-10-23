using System;
using System.Collections;
using System.Numerics;
using Celeste.Core.Audio;
using Celeste.Core.Components;
using Celeste.Core.Geometry;
using Celeste.Core.Scheduling;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
using Celeste.Scene.Scenes;
using Celeste.Simulation;
using Celeste.Simulation.Presentation.Lighting;
using Celeste.Simulation.Presentation.Effects.Mirrors;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content;
using Celeste.Graphics.Display;
using Celeste.Game.Components.Talking;
using Celeste.Game.Entities.Npcs;
using Celeste.Game.Entities.StarJump;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Levels.Cutscenes;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Execution.Graphics;
using Celeste.Game.UI.Dialogue.Textboxes;
using Celeste.Simulation.Presentation.Scene.Transitions;

namespace Celeste.Game.Entities.Npcs.Theo
{
    public class OriginalOldSiteTheoState : OriginalNpcState
    {
        private readonly ISourceEngineContext engine;
        private const string DoneTalking = "theoDoneTalking";

        private const string HadntMetAtStart = "hadntMetTheoAtStart";

        private SimulationCoroutine talkRoutine;

        private OriginalSelfieState selfie;

        private int CurrentConversation
        {
            get { return base.Session.GetCounter("theo"); }
            set { base.Session.SetCounter("theo", value); }
        }

        public OriginalOldSiteTheoState(ISourceEngineContext engine, Vector2 position)
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
            if (!base.Session.GetFlag("theoDoneTalking"))
            {
                OwnedComponents.Add(Talker = new OriginalTalkComponent((IOriginalTalkProcess)engine,
                    new IntRect(-20, -8, 100, 8), new Vector2(0f, -24f), OnTalk));
            }
        }

        private void OnTalk(RoomPlayerSession player)
        {
            if (!((IOriginalGameplayProcess)engine).SaveContext.CurrentSave.HasFlag("MetTheo") ||
                !((IOriginalGameplayProcess)engine).SaveContext.CurrentSave.HasFlag("TheoKnowsName"))
            {
                CurrentConversation = -1;
            }

            Level.StartCutscene(OnTalkEnd);
            OwnedComponents.Add(talkRoutine = new SimulationCoroutine(engine, Talk(player)));
        }

        private IEnumerator Talk(RoomPlayerSession player)
        {
            if (!((IOriginalGameplayProcess)engine).SaveContext.CurrentSave.HasFlag("MetTheo"))
            {
                base.Session.SetFlag("hadntMetTheoAtStart");
                ((IOriginalGameplayProcess)engine).SaveContext.CurrentSave.SetFlag("MetTheo");
                yield return PlayerApproachRightSide(player, turnToFace: true, 48f);
                yield return TextboxState.Say("CH2_THEO_INTRO_NEVER_MET", engine);
            }
            else if (!((IOriginalGameplayProcess)engine).SaveContext.CurrentSave.HasFlag("TheoKnowsName"))
            {
                base.Session.SetFlag("hadntMetTheoAtStart");
                ((IOriginalGameplayProcess)engine).SaveContext.CurrentSave.SetFlag("TheoKnowsName");
                yield return PlayerApproachRightSide(player, turnToFace: true, 48f);
                yield return TextboxState.Say("CH2_THEO_INTRO_NEVER_INTRODUCED", engine);
            }
            else if (CurrentConversation <= 0)
            {
                yield return PlayerApproachRightSide(player);
                yield return 0.2f;
                if (base.Session.GetFlag("hadntMetTheoAtStart"))
                {
                    yield return PlayerApproach48px();
                    yield return TextboxState.Say("CH2_THEO_A", engine, ShowPhotos, HidePhotos, Selfie);
                }
                else
                {
                    yield return TextboxState.Say("CH2_THEO_A_EXT", engine, ShowPhotos, HidePhotos, Selfie,
                        base.PlayerApproach48px);
                }
            }
            else if (CurrentConversation == 1)
            {
                yield return PlayerApproachRightSide(player, turnToFace: true, 48f);
                yield return TextboxState.Say("CH2_THEO_B", engine, SelfieFiltered);
            }
            else if (CurrentConversation == 2)
            {
                yield return PlayerApproachRightSide(player, turnToFace: true, 48f);
                yield return TextboxState.Say("CH2_THEO_C", engine);
            }
            else if (CurrentConversation == 3)
            {
                yield return PlayerApproachRightSide(player, turnToFace: true, 48f);
                yield return TextboxState.Say("CH2_THEO_D", engine);
            }
            else if (CurrentConversation == 4)
            {
                yield return PlayerApproachRightSide(player, turnToFace: true, 48f);
                yield return TextboxState.Say("CH2_THEO_E", engine);
            }

            Level.EndCutscene();
            OnTalkEnd(Level);
        }

        private void OnTalkEnd(OriginalLevelSceneRoot level)
        {
            if (CurrentConversation == 4)
            {
                base.Session.SetFlag("theoDoneTalking");
                Remove(Talker);
            }

            RoomPlayerSession entity =
                ((ISourceScene)Scene).SourceScene.Entities.GetTrackedEntity<RoomPlayerSession>(
                    typeof(global::Celeste.Simulation.RoomPlayerSession).FullName);
            if (entity != null)
            {
                entity.Machine.Locked = false;
                entity.Machine.State = 0;
                if (level.SkippingCutscene)
                {
                    entity.X = (int)(base.X + 48f);
                    entity.Data.Facing = -1;
                }
            }

            Sprite.Scale.X = 1f;
            if (selfie != null)
            {
                selfie.RemoveSelf();
            }

            CurrentConversation++;
            talkRoutine.Cancel();
            talkRoutine.RemoveSelf();
        }

        private IEnumerator ShowPhotos()
        {
            RoomPlayerSession entity =
                ((ISourceScene)Scene).SourceScene.Entities.GetTrackedEntity<RoomPlayerSession>(
                    typeof(global::Celeste.Simulation.RoomPlayerSession).FullName);
            yield return PlayerApproach(entity, turnToFace: true, 10f);
            Sprite.Play("getPhone");
            yield return 2f;
        }

        private IEnumerator HidePhotos()
        {
            Sprite.Play("idle");
            yield return 0.5f;
        }

        private IEnumerator Selfie()
        {
            yield return 0.5f;
            ((ISourceSpatialAudioEnvironment)engine).SpatialAudio.Play("event:/game/02_old_site/theoselfie_foley",
                Position);
            Sprite.Scale.X = 0f - Sprite.Scale.X;
            Sprite.Play("takeSelfie");
            yield return 1f;
            ((ISourceScene)Scene).SourceScene.QueueSourceEntity(selfie =
                new OriginalSelfieState((OriginalLevelSceneRoot)Scene));
            yield return selfie.PictureRoutine();
            selfie = null;
            Sprite.Scale.X = 0f - Sprite.Scale.X;
        }

        private IEnumerator SelfieFiltered()
        {
            ((ISourceScene)Scene).SourceScene.QueueSourceEntity(selfie =
                new OriginalSelfieState((OriginalLevelSceneRoot)Scene));
            yield return selfie.FilterRoutine();
            selfie = null;
        }
    }
}
