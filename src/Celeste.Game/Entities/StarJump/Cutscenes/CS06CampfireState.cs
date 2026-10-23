using Celeste.Core.Display;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Components.Timing;
using Celeste.Core.Scheduling;
using Celeste.Core.Rendering;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Mathematics.Easing;
using Celeste.Input.Gameplay;
using Celeste.Input.Gameplay.Feedback;
using Celeste.Scene.Components.Oscillation;
using Celeste.Game.Entities.Npcs;
using Celeste.Game.Content.Dialogs;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Levels.Cutscenes;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Execution.Startup;
using Celeste.Game.UI.Dialogue.Textboxes;
using Celeste.Formats.Graphics.Xml;
using Celeste.Simulation;
using Celeste.Simulation.Dialogs.Nodes;
using Celeste.Simulation.Presentation.Scene.Transitions;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Display;
using Celeste.Graphics.Text.RichText.Layout;
using Celeste.Graphics.Text.RichText.Nodes;
using Celeste.Graphics.Text.RichText.Drawing;
using Celeste.Graphics.Rendering;
using Facing = System.Int32;

namespace Celeste.Game.Entities.StarJump.Cutscenes
{
    public class CS06CampfireState : OriginalCutsceneEntityState
    {
        private class Option
        {
            public Question Question;

            public string Goto;

            public List<Question> OnlyAppearIfAsked;

            public List<Question> DoNotAppearIfAsked;

            public bool CanRepeat;

            public float Highlight;

            public const float Width = 1400f;

            public const float Height = 140f;

            public const float Padding = 20f;

            public const float TextScale = 0.7f;

            public Option(Question question, string go)
            {
                Question = question;
                Goto = go;
            }

            public Option Require(params Question[] onlyAppearIfAsked)
            {
                OnlyAppearIfAsked = new List<Question>(onlyAppearIfAsked);
                return this;
            }

            public Option ExcludedBy(params Question[] doNotAppearIfAsked)
            {
                DoNotAppearIfAsked = new List<Question>(doNotAppearIfAsked);
                return this;
            }

            public Option Repeatable()
            {
                CanRepeat = true;
                return this;
            }

            public bool CanAsk(HashSet<Question> asked)
            {
                if (!CanRepeat && asked.Contains(Question))
                {
                    return false;
                }

                if (OnlyAppearIfAsked != null)
                {
                    foreach (Question item in OnlyAppearIfAsked)
                    {
                        if (!asked.Contains(item))
                        {
                            return false;
                        }
                    }
                }

                if (DoNotAppearIfAsked != null)
                {
                    bool flag = true;
                    foreach (Question item2 in DoNotAppearIfAsked)
                    {
                        if (!asked.Contains(item2))
                        {
                            flag = false;
                            break;
                        }
                    }

                    if (flag)
                    {
                        return false;
                    }
                }

                return true;
            }

            public void Update()
            {
                Question.Portrait.Update();
            }

            public void Render(ISourceRenderContext context, CS06CampfireState owner, ISourceEngineContext engine,
                Vector2 position, float ease)
            {
                float num = ((ISourceEasingEnvironment)engine).EasingArithmetic.CubeOut(ease);
                float num2 = ((ISourceEasingEnvironment)engine).EasingArithmetic.CubeInOut(Highlight);
                position.Y += -32f * (1f - num);
                position.X += num2 * 32f;
                PackedColor color = PackedColor.Lerp(PackedColor.Gray, PackedColor.White, num2) * num;
                float alpha = ScalarMath.Lerp(0.6f, 1f, num2, ((ISourceScalarEnvironment)engine).ScalarArithmetic) *
                              num;
                PackedColor color2 = PackedColor.White * (0.5f + num2 * 0.5f);
                SourceAtlasDrawing.Draw(context, owner,
                    ((IOriginalFancyTextProcess)engine).Graphics.PortraitsAtlas[Question.Textbox], position,
                    Vector2.Zero,
                    color);
                Facing facings = Question.PortraitSide;
                if (((IOriginalGameplayProcess)engine).SaveContext.CurrentSave != null &&
                    ((IOriginalGameplayProcess)engine).SaveContext.CurrentSave.Assists.MirrorMode)
                {
                    facings = (Facing)(0 - facings);
                }

                float num3 = 100f;
                Question.Portrait.Scale = Vector2.One * (num3 / Question.PortraitSize);
                if (facings == 1)
                {
                    Question.Portrait.Position = position + new Vector2(1380f - num3 * 0.5f, 70f);
                    Question.Portrait.Scale.X *= -1f;
                }
                else
                {
                    Question.Portrait.Position = position + new Vector2(20f + num3 * 0.5f, 70f);
                }

                Question.Portrait.Color = color2 * num;
                Question.Portrait.Render(context);
                float num4 = (140f - ((IOriginalFancyTextProcess)engine).Text.ActiveFont.LineHeight * 0.7f) / 2f;
                Vector2 position2 = new Vector2(0f, position.Y + 70f);
                Vector2 justify = new Vector2(0f, 0.5f);
                if (facings == 1)
                {
                    justify.X = 1f;
                    position2.X = position.X + 1400f - 20f - num4 - num3;
                }
                else
                {
                    position2.X = position.X + 20f + num4 + num3;
                }

                Question.AskText.Draw(context, owner, (ISourceRichTextDrawProcess)engine, position2, justify,
                    Vector2.One * 0.7f, alpha);
            }
        }

        private class Question
        {
            public string Ask;

            public string Answer;

            public string Textbox;

            public RichTextLayout AskText;

            public Sprite Portrait;

            public Facing PortraitSide;

            public float PortraitSize;

            public Question(string id, ISourceEngineContext engine)
            {
                int maxLineWidth = 1828;
                Ask = "ch6_theo_ask_" + id;
                Answer = "ch6_theo_say_" + id;
                AskText = OriginalFancyTextParser.Parse(((IOriginalFancyTextProcess)engine).Text.Dialog.Get(Ask),
                    maxLineWidth, -1, context: OriginalFancyTextContext.Create((IOriginalFancyTextProcess)engine));
                foreach (RichTextNode node in AskText.Nodes)
                {
                    if (node is DialogPortrait)
                    {
                        DialogPortrait portrait = node as DialogPortrait;
                        Portrait =
                            ((IOriginalFancyTextProcess)engine).Graphics.PortraitsSpriteBank.Create(portrait.SpriteId);
                        Portrait.Play(portrait.IdleAnimation);
                        PortraitSide = (Facing)portrait.Side;
                        Textbox = "textbox/" + portrait.Sprite + "_ask";
                        XmlElement xML = ((IOriginalFancyTextProcess)engine).Graphics.PortraitsSpriteBank
                            .SpriteData[portrait.SpriteId].Sources[0].XML;
                        if (xML != null)
                        {
                            PortraitSize =
                                global::Celeste.Core.Serialization.Xml.SourceXmlAttributes.AttrInt(xML, "size", 160);
                        }

                        break;
                    }
                }
            }
        }

        public const string Flag = "campfire_chat";

        public const string DuskBackgroundFlag = "duskbg";

        public const string StarsBackgrundFlag = "starsbg";

        private readonly ISourceEngineContext engine;
        private IOriginalGameplayProcess Process => (IOriginalGameplayProcess)engine;
        private OriginalNpcState theo;

        private RoomPlayerSession player;

        private OriginalBonfireState bonfire;

        private OriginalPlateauState plateau;

        private Vector2 cameraStart;

        private Vector2 playerCampfirePosition;

        private Vector2 theoCampfirePosition;

        private OriginalSelfieState selfie;

        private float optionEase;

        private Dictionary<string, Option[]> nodes = new Dictionary<string, Option[]>();

        private HashSet<Question> asked = new HashSet<Question>();

        private List<Option> currentOptions = new List<Option>();

        private int currentOptionIndex;

        public CS06CampfireState(OriginalNpcState theo, RoomPlayerSession player, ISourceEngineContext engine) :
            base(engine)
        {
            this.engine = engine;
            Tags = ((IOriginalGameTagsEnvironment)engine).Tags.HUD.Value;
            this.theo = theo;
            this.player = player;
            Question question = new Question("outfor", engine);
            Question question2 = new Question("temple", engine);
            Question question3 = new Question("explain", engine);
            Question question4 = new Question("thankyou", engine);
            Question question5 = new Question("why", engine);
            Question question6 = new Question("depression", engine);
            Question question7 = new Question("defense", engine);
            Question question8 = new Question("vacation", engine);
            Question question9 = new Question("trust", engine);
            Question question10 = new Question("family", engine);
            Question question11 = new Question("grandpa", engine);
            Question question12 = new Question("tips", engine);
            Question question13 = new Question("selfie", engine);
            Question question14 = new Question("sleep", engine);
            Question question15 = new Question("sleep_confirm", engine);
            Question question16 = new Question("sleep_cancel", engine);
            nodes.Add("start", new Option[14]
            {
                new Option(question, "start").ExcludedBy(question5),
                new Option(question2, "start").Require(question9),
                new Option(question9, "start").Require(question3),
                new Option(question10, "start").Require(question9, question5),
                new Option(question11, "start").Require(question10, question7),
                new Option(question12, "start").Require(question11),
                new Option(question3, "start"),
                new Option(question4, "start").Require(question3),
                new Option(question5, "start").Require(question3, question9),
                new Option(question6, "start").Require(question5),
                new Option(question7, "start").Require(question6),
                new Option(question8, "start").Require(question6),
                new Option(question13, "").Require(question7, question11),
                new Option(question14, "sleep").Require(question5).ExcludedBy(question7, question11).Repeatable()
            });
            nodes.Add("sleep", new Option[2]
            {
                new Option(question16, "start").Repeatable(),
                new Option(question15, "")
            });
        }

        public override void OnBegin(OriginalLevelSceneRoot level)
        {
            Process.AudioSession.SetMusic(null, startPlaying: false, allowFadeOut: false);
            level.SnapColorGrade(null);
            level.Bloom.Base = 0f;
            level.Session.SetFlag("duskbg");
            plateau = Level.SourceScene.Entities.FindFirst<OriginalPlateauState>();
            bonfire = Level.Scheduler.Entities.GetTrackedEntity<OriginalBonfireState>("Celeste.Bonfire");
            level.Camera.Position = new Vector2(level.Bounds.Left, bonfire.Y - 144f);
            level.ZoomSnap(new Vector2(80f, 120f), 2f);
            cameraStart = level.Camera.Position;
            theo.X = level.Camera.X - 48f;
            theoCampfirePosition = new Vector2(bonfire.X - 16f, bonfire.Y);
            player.Light.Alpha = 0f;
            player.X = level.Bounds.Left - 40;
            player.Machine.State = 11;
            player.Machine.Locked = true;
            playerCampfirePosition = new Vector2(bonfire.X + 20f, bonfire.Y);
            if (level.Session.GetFlag("campfire_chat"))
            {
                WasSkipped = true;
                level.ResetZoom();
                level.EndCutscene();
                EndCutscene(level);
            }
            else
            {
                OwnedComponents.Add(new SimulationCoroutine(engine, Cutscene(level)));
            }
        }

        private IEnumerator PlayerLightApproach()
        {
            while (player.Light.Alpha < 1f)
            {
                player.Light.Alpha = ScalarMath.Approach(player.Light.Alpha, 1f, engine.DeltaTime * 2f,
                    ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
                yield return null;
            }
        }

        private IEnumerator Cutscene(OriginalLevelSceneRoot level)
        {
            yield return 0.1f;
            OwnedComponents.Add(new SimulationCoroutine(engine, PlayerLightApproach()));
            CS06CampfireState cS06_Campfire = this;
            SimulationCoroutine component;
            SimulationCoroutine camTo = (component = new SimulationCoroutine(engine,
                OriginalCutsceneEntityState.CameraTo(engine, new Vector2(level.Camera.X + 90f, level.Camera.Y), 6f,
                    ((ISourceEasingEnvironment)engine).EasingArithmetic.CubeIn)));
            cS06_Campfire.OwnedComponents.Add(component);
            player.Dummy.AutoAnimate = false;
            player.Sprite.Play("carryTheoWalk");
            for (float p = 0f; p < 3.5f; p += engine.DeltaTime)
            {
                ((ISourceScreenWipeEnvironment)engine).ProcessWipe.SpotlightFocusPoint = new Vector2(40f, 120f);
                player.NaiveMove(new Vector2(32f * engine.DeltaTime, 0f));
                yield return null;
            }

            player.Sprite.Play("carryTheoCollapse");
            Process.AudioSession.Play("event:/char/madeline/theo_collapse", player.Position, Process.SaveContext);
            yield return 0.3f;
            ((ISourceRumbleEnvironment)engine).RumbleSession.Rumble(2, 1);
            Vector2 position = player.Position + new Vector2(16f, 1f);
            Level.ParticlesFG.Emit(Process.ParticleTypes.Payphone.P_Snow, 2, position, Vector2.UnitX * 4f);
            Level.ParticlesFG.Emit(Process.ParticleTypes.Payphone.P_SnowB, 12, position, Vector2.UnitX * 10f);
            yield return 0.7f;
            FadeWipePresentation fade = new FadeWipePresentation(level, wipeIn: false)
            {
                Duration = 1.5f,
                EndTimer = 2.5f
            };
            yield return fade.Wait();
            bonfire.SetMode(OriginalBonfireState.Mode.Lit);
            yield return 2.45f;
            camTo.Cancel();
            theo.Position = theoCampfirePosition;
            theo.Sprite.Play("sleep");
            theo.Sprite.SetAnimationFrame(theo.Sprite.CurrentAnimationTotalFrames - 1);
            player.Position = playerCampfirePosition;
            player.Data.Facing = -1;
            player.Sprite.Play("asleep");
            level.Session.SetFlag("starsbg");
            level.Session.SetFlag("duskbg", setTo: false);
            fade.EndTimer = 0f;
            new FadeWipePresentation(level, wipeIn: true);
            yield return null;
            level.ResetZoom();
            level.Camera.Position = new Vector2(bonfire.X - 160f, bonfire.Y - 140f);
            yield return 3f;
            Process.AudioSession.SetMusic("event:/music/lvl6/madeline_and_theo");
            yield return 1.5f;
            OwnedComponents.Add(((ISourceWigglerPoolScope)engine).WigglerPool.Create(0.6f, 3f,
                delegate(float v) { theo.Sprite.Scale = Vector2.One * (1f + 0.1f * v); }, start: true,
                removeSelfOnFinish: true));
            Level.Particles.Emit(Process.ParticleTypes.NPC01_Theo.P_YOLO, 4, theo.Position + new Vector2(-4f, -14f),
                Vector2.One * 3f);
            yield return 0.5f;
            theo.Sprite.Play("wakeup");
            yield return 1f;
            player.Sprite.Play("halfWakeUp");
            yield return 0.25f;
            yield return TextboxState.Say("ch6_theo_intro", engine);
            string text = "start";
            while (!string.IsNullOrEmpty(text) && nodes.ContainsKey(text))
            {
                currentOptionIndex = 0;
                currentOptions = new List<Option>();
                Option[] array = nodes[text];
                foreach (Option option in array)
                {
                    if (option.CanAsk(asked))
                    {
                        currentOptions.Add(option);
                    }
                }

                if (currentOptions.Count <= 0)
                {
                    break;
                }

                Process.AudioSession.Play("event:/ui/game/chatoptions_appear");
                while ((optionEase += engine.DeltaTime * 4f) < 1f)
                {
                    yield return null;
                }

                optionEase = 1f;
                yield return 0.25f;
                while (!((ISourceGameInputEnvironment)engine).Input.MenuConfirm.Pressed)
                {
                    if (((ISourceGameInputEnvironment)engine).Input.MenuUp.Pressed && currentOptionIndex > 0)
                    {
                        Process.AudioSession.Play("event:/ui/game/chatoptions_roll_up");
                        currentOptionIndex--;
                    }
                    else if (((ISourceGameInputEnvironment)engine).Input.MenuDown.Pressed &&
                             currentOptionIndex < currentOptions.Count - 1)
                    {
                        Process.AudioSession.Play("event:/ui/game/chatoptions_roll_down");
                        currentOptionIndex++;
                    }

                    yield return null;
                }

                Process.AudioSession.Play("event:/ui/game/chatoptions_select");
                while ((optionEase -= engine.DeltaTime * 4f) > 0f)
                {
                    yield return null;
                }

                Option selected = currentOptions[currentOptionIndex];
                asked.Add(selected.Question);
                currentOptions = null;
                yield return TextboxState.Say(selected.Question.Answer, engine, WaitABit, SelfieSequence, BeerSequence);
                text = selected.Goto;
                if (string.IsNullOrEmpty(text))
                {
                    break;
                }
            }

            FadeWipePresentation fadeWipe = new FadeWipePresentation(level, wipeIn: false);
            fadeWipe.Duration = 3f;
            yield return fadeWipe.Wait();
            EndCutscene(level);
        }

        private IEnumerator WaitABit()
        {
            yield return 0.8f;
        }

        private IEnumerator SelfieSequence()
        {
            OwnedComponents.Add(new SimulationCoroutine(engine, Level.ZoomTo(new Vector2(160f, 105f), 2f, 0.5f)));
            yield return 0.1f;
            theo.Sprite.Play("idle");
            OwnedComponents.Add(SourceAlarmState.Create(engine.AlarmPool, SourceAlarmState.AlarmMode.Oneshot,
                delegate { theo.Sprite.Scale.X = -1f; }, 0.25f, start: true));
            player.Dummy.AutoAnimate = true;
            yield return player.DummyWalkToExact((int)(theo.X + 5f), walkBackwards: false, 0.7f);
            yield return 0.2f;
            Process.AudioSession.Play("event:/game/02_old_site/theoselfie_foley", theo.Position, Process.SaveContext);
            theo.Sprite.Play("takeSelfie");
            yield return 1f;
            selfie = new OriginalSelfieState((OriginalLevelSceneRoot)Scene);
            Level.Scheduler.QueueSourceEntity(selfie);
            yield return selfie.PictureRoutine("selfieCampfire");
            selfie = null;
            yield return 0.5f;
            yield return Level.ZoomBack(0.5f);
            yield return 0.2f;
            theo.Sprite.Scale.X = 1f;
            yield return player.DummyWalkToExact((int)playerCampfirePosition.X, walkBackwards: false, 0.7f);
            theo.Sprite.Play("wakeup");
            yield return 0.1;
            player.Dummy.AutoAnimate = false;
            player.Data.Facing = -1;
            player.Sprite.Play("sleep");
            yield return 2f;
            player.Sprite.Play("halfWakeUp");
        }

        private IEnumerator BeerSequence()
        {
            yield return 0.5f;
        }

        public override void OnEnd(OriginalLevelSceneRoot level)
        {
            if (!WasSkipped)
            {
                level.ZoomSnap(new Vector2(160f, 120f), 2f);
                FadeWipePresentation fadeWipe = new FadeWipePresentation(level, wipeIn: true);
                fadeWipe.Duration = 3f;
                SimulationCoroutine zoom = new SimulationCoroutine(engine, level.ZoomBack(fadeWipe.Duration));
                fadeWipe.OnUpdate = delegate { zoom.Update(); };
            }

            if (selfie != null)
            {
                selfie.RemoveSelf();
            }

            level.Session.SetFlag("campfire_chat");
            level.Session.SetFlag("starsbg", setTo: false);
            level.Session.SetFlag("duskbg", setTo: false);
            level.Session.Dreaming = true;
            level.Scheduler.QueueSourceEntity(new OriginalStarJumpControllerState(engine));
            level.Scheduler.QueueSourceEntity(new CS06StarJumpEndState(theo, player, playerCampfirePosition,
                cameraStart,
                engine));
            level.Scheduler.QueueSourceEntity(new OriginalFlyFeatherState(level.LevelOffset + new Vector2(272f, 2616f),
                shielded: false, singleUse: false, engine: engine));
            SetBloom(1f);
            bonfire.Activated = false;
            bonfire.SetMode(OriginalBonfireState.Mode.Lit);
            theo.Sprite.Play("sleep");
            theo.Sprite.SetAnimationFrame(theo.Sprite.CurrentAnimationTotalFrames - 1);
            theo.Sprite.Scale.X = 1f;
            theo.Position = theoCampfirePosition;
            player.Sprite.Play("asleep");
            player.Position = playerCampfirePosition;
            player.Machine.Locked = false;
            player.Machine.State = 15;
            player.Data.Motion.Normal.Speed = Vector2.Zero;
            player.Data.Facing = -1;
            level.Camera.Position = player.CameraTarget;
            if (WasSkipped)
            {
                player.Machine.State = 0;
            }

            RemoveSelf();
        }

        private void SetBloom(float add)
        {
            Level.Session.BloomBaseAdd = add;
            Level.Bloom.Base = Level.AreaData.BloomBase + add;
        }

        public override void Update()
        {
            if (currentOptions != null)
            {
                for (int i = 0; i < currentOptions.Count; i++)
                {
                    currentOptions[i].Update();
                    currentOptions[i].Highlight = ScalarMath.Approach(currentOptions[i].Highlight,
                        (currentOptionIndex == i) ? 1 : 0, engine.DeltaTime * 4f,
                        ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
                }
            }

            base.Update();
        }

        public override void Render(ISourceRenderContext context)
        {
            if (Level.Paused || currentOptions == null)
            {
                return;
            }

            int num = 0;
            foreach (Option currentOption in currentOptions)
            {
                Vector2 position = new Vector2(260f, 120f + 160f * (float)num);
                currentOption.Render(context, this, engine, position, optionEase);
                num++;
            }
        }
    }
}
