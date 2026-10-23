using Celeste.Graphics.Text.BitmapFonts;
using Celeste.Scene.Scheduling;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Simulation.Rendering;
using Celeste.Simulation;

namespace Celeste.Game.UI.Dialogue.Textboxes
{
    public sealed partial class TextboxState : Celeste.Scene.Entities.SceneEntityState,
        Celeste.Graphics.Animation.Portraits.IPortraitAnimation
    {
        private readonly Celeste.Core.Scheduling.ISourceEngineContext engine;

        private Celeste.Game.Execution.Processes.IOriginalGameplayProcess Process
            => (Celeste.Game.Execution.Processes.IOriginalGameplayProcess)engine;

        private Celeste.Game.Execution.Graphics.OriginalGameGraphicsResources Graphics
            => (Celeste.Game.Execution.Graphics.OriginalGameGraphicsResources)
                ((Celeste.Graphics.Content.ISourceGameGraphicsEnvironment)engine).GameGraphics;

        private Celeste.Game.Content.Dialogs.OriginalGameTextProcess TextProcess
            => ((Celeste.Game.Content.Dialogs.IOriginalGameTextEnvironment)engine).Text;

        private Celeste.Core.Randomness.ISourceRandom Random
            => ((Celeste.Core.Randomness.ISourceRandomEnvironment)engine).Random;

        private Celeste.Simulation.Audio.Sources.ISourceSoundSourceFactory Sounds
            => ((Celeste.Simulation.Audio.Sources.ISourceSoundSourceEnvironment)engine).SoundSources;

        private global::Celeste.Graphics.Content.Atlas.AtlasEntry textbox, textboxOverlay;
        private Celeste.Graphics.Text.BitmapFonts.SourcePixelFont font;
        private readonly float innerTextPadding, maxLineWidthNoPortrait, maxLineWidth, lineHeight;
        private readonly int linesPerPage;
        private float ease, timer, gradientFade;
        private readonly global::Celeste.Graphics.Text.RichText.Layout.RichTextLayout text;
        private readonly Func<IEnumerator>[] events;

        private readonly global::Celeste.Core.Scheduling.SimulationCoroutine runRoutine, skipRoutine;

        private global::Celeste.Graphics.Text.RichText.Nodes.TextAnchorPosition anchor;
        private global::Celeste.Simulation.Dialogs.Nodes.DialogPortrait portrait;
        private int index, shakeSeed;
        private bool waitingForInput, disableInput, isInTrigger, easingClose, easingOpen, autoPressContinue;

        public bool AutoPressContinue
        {
            get => autoPressContinue;
            set => autoPressContinue = value;
        }

        private bool canSkip = true;
        private char lastChar;
        private readonly global::Celeste.Graphics.Animation.Sprite portraitSprite;
        private bool portraitExists, portraitIdling, isPortraitGlitchy;
        private float portraitScale = 1.5f;
        private readonly Celeste.Scene.Components.Oscillation.WigglerComponent portraitWiggle;
        private global::Celeste.Graphics.Animation.Sprite portraitGlitchy;

        private readonly Dictionary<string, global::Celeste.Simulation.Audio.Sources.SoundSourceComponentState>
            talkers = new Dictionary<string, global::Celeste.Simulation.Audio.Sources.SoundSourceComponentState>();

        private global::Celeste.Simulation.Audio.Sources.SoundSourceComponentState activeTalker, phonestatic;
        public Vector2 RenderOffset;
        public bool Opened { get; private set; } = true;
        public int Page { get; private set; }
        public int Start { get; private set; }
        public int Index => index;
        public float Ease => ease;
        public global::Celeste.Graphics.Text.RichText.Nodes.TextAnchorPosition Anchor => anchor;
        public float GradientFade => gradientFade;
        public bool WaitingForInput => waitingForInput;
        public bool InTrigger => isInTrigger;
        public bool CanSkip => canSkip;
        public global::Celeste.Graphics.Text.RichText.Layout.RichTextLayout Text => text;
        public List<global::Celeste.Graphics.Text.RichText.Nodes.RichTextNode> Nodes => text.Nodes;
        public global::Celeste.Graphics.Animation.Sprite PortraitSprite => portraitSprite;
        public global::Celeste.Graphics.Animation.Sprite PortraitGlitchy => portraitGlitchy;
        public global::Celeste.Scene.Components.Oscillation.OscillationPulseState Wiggle => portraitWiggle;
        public string PortraitName => portrait == null || portrait.Sprite == null ? "" : portrait.Sprite;
        public string PortraitAnimation => portrait == null || portrait.Sprite == null ? "" : portrait.Animation;

        public bool UseRawDeltaTime
        {
            get => runRoutine.UseRawDeltaTime;
            set => runRoutine.UseRawDeltaTime = value;
        }

        public TextboxState(string dialog, Celeste.Core.Scheduling.ISourceEngineContext engine,
            Celeste.Localization.Languages.DialogLanguage language = null, params Func<IEnumerator>[] events)
            : this(dialog, engine, language, events,
                new global::Celeste.Core.Scheduling.SimulationCoroutine(engine),
                new global::Celeste.Core.Scheduling.SimulationCoroutine(engine))
        {
        }

        private TextboxState(string dialog, Celeste.Core.Scheduling.ISourceEngineContext engine,
            Celeste.Localization.Languages.DialogLanguage language, Func<IEnumerator>[] events,
            global::Celeste.Core.Scheduling.SimulationCoroutine runRoutine,
            global::Celeste.Core.Scheduling.SimulationCoroutine skipRoutine, string layoutFontFace = null)
            : base(((Celeste.Core.Components.ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration)
        {
            this.runRoutine = runRoutine;
            this.skipRoutine = skipRoutine;
            this.engine = engine ?? throw new ArgumentNullException(nameof(engine));
            Tags = ((global::Celeste.Game.Execution.Startup.IOriginalGameTagsEnvironment)engine).Tags.PauseUpdate
                .Value | ((global::Celeste.Game.Execution.Startup.IOriginalGameTagsEnvironment)engine).Tags.HUD
                .Value;
            this.events = events;
            textbox = Graphics.PortraitsAtlas["textbox/default"];
            portraitSprite = new Celeste.Graphics.Animation.Sprite(engine, null, null)
                { UseRawDeltaTime = true };
            font = TextProcess.Fonts.Get(TextProcess.Dialog.Language.FontFace);
            lineHeight = font.Get(TextProcess.Dialog.Language.FontFaceSize).LineHeight - 1;
            portraitWiggle = ((Celeste.Scene.Components.Oscillation.ISourceWigglerPoolScope)engine)
                .WigglerPool.Create(.4f, 4f);
            Components.Add(portraitWiggle);
            linesPerPage = (int)(240f / lineHeight);
            innerTextPadding = (272 - lineHeight * linesPerPage) / 2;
            maxLineWidthNoPortrait = 1688 - innerTextPadding * 2;
            maxLineWidth = maxLineWidthNoPortrait - 240 - 32;
            var context = Celeste.Game.Content.Dialogs.OriginalFancyTextContext.Create(
                (Celeste.Game.Content.Dialogs.IOriginalFancyTextProcess)engine, language, layoutFontFace);
            text = Celeste.Game.Content.Dialogs.OriginalFancyTextParser.Parse(
                TextProcess.Dialog.Get(dialog, language), (int)maxLineWidth, linesPerPage, 0f, null, context);
            skipRoutine.Replace(SkipDialog());
            runRoutine.Replace(RunRoutine());
            runRoutine.UseRawDeltaTime = true;
            if (Process.AudioSession.DialogSnapshot == null)
                Process.AudioSession.DialogSnapshot = Process.AudioSession.CreateSnapshot(
                    "snapshot:/dialogue_in_progress", false);
            Process.AudioSession.ResumeSnapshot(Process.AudioSession.DialogSnapshot);
            phonestatic = Sounds.Create();
            AddSound(phonestatic);
        }

        private void AddSound(global::Celeste.Simulation.Audio.Sources.SoundSourceComponentState source)
        {
            Components.Add(source);
        }

        public void SetStart(int value)
        {
            Start = index = value;
        }

        public override void Update() => UpdateCurrentFrame();

        public override void Removed(object actualScene)
        {
            Process.AudioSession.EndSnapshot(Process.AudioSession.DialogSnapshot);
            base.Removed(actualScene);
        }

        public override void SceneEnd(object actualScene)
        {
            Process.AudioSession.EndSnapshot(Process.AudioSession.DialogSnapshot);
            base.SceneEnd(actualScene);
        }

        public int PortraitSide(Celeste.Simulation.Dialogs.Nodes.DialogPortrait value)
            => Process.SaveContext.CurrentSave != null && Process.SaveContext.CurrentSave.Assists.MirrorMode
                ? -value.Side
                : value.Side;

        public static IEnumerator Say(string dialog, Celeste.Core.Scheduling.ISourceEngineContext engine,
            params Func<IEnumerator>[] events)
        {
            var box = new TextboxState(dialog, engine, null, events);
            ((Celeste.Scene.Tracking.ISourceScene)engine.Frame.Scenes.CurrentScene)
                .SourceScene.QueueSourceEntity(box);
            while (box.Opened) yield return null;
        }

        public static IEnumerator SayWithLayoutFont(string dialog, Celeste.Core.Scheduling.ISourceEngineContext engine,
            string fontFace, params Func<IEnumerator>[] events)
        {
            var box = new TextboxState(dialog, engine, null, events,
                new global::Celeste.Core.Scheduling.SimulationCoroutine(engine),
                new global::Celeste.Core.Scheduling.SimulationCoroutine(engine), fontFace);
            ((Celeste.Scene.Tracking.ISourceScene)engine.Frame.Scenes.CurrentScene)
                .SourceScene.QueueSourceEntity(box);
            while (box.Opened) yield return null;
        }

        public static IEnumerator SayWhileFrozen(string dialog, Celeste.Core.Scheduling.ISourceEngineContext engine,
            params Func<IEnumerator>[] events)
        {
            var box = new TextboxState(dialog, engine, null, events);
            box.Tags |= ((global::Celeste.Game.Execution.Startup.IOriginalGameTagsEnvironment)engine).Tags
                .FrozenUpdate.Value;
            ((Celeste.Scene.Tracking.ISourceScene)engine.Frame.Scenes.CurrentScene)
                .SourceScene.QueueSourceEntity(box);
            while (box.Opened) yield return null;
        }

        private static float Clamp(float value, float min, float max) =>
            Celeste.Core.Mathematics.ScalarMath.Clamp(value, min, max);

        private IEnumerator RunRoutine()
        {
            global::Celeste.Graphics.Text.RichText.Nodes.RichTextNode last = null;
            float delayBuildup = 0f;
            while (index < Nodes.Count)
            {
                global::Celeste.Graphics.Text.RichText.Nodes.RichTextNode current = Nodes[index];
                float delay = 0f;
                if (current is global::Celeste.Graphics.Text.RichText.Nodes.RichTextAnchor)
                {
                    if (RenderOffset == Vector2.Zero)
                    {
                        global::Celeste.Graphics.Text.RichText.Nodes.TextAnchorPosition next =
                            (current as global::Celeste.Graphics.Text.RichText.Nodes.RichTextAnchor).Position;
                        if (ease >= 1f && next != anchor)
                        {
                            yield return EaseClose(final: false);
                        }

                        anchor = next;
                    }
                }
                else if (current is global::Celeste.Simulation.Dialogs.Nodes.DialogPortrait)
                {
                    global::Celeste.Simulation.Dialogs.Nodes.DialogPortrait next2 =
                        current as global::Celeste.Simulation.Dialogs.Nodes.DialogPortrait;
                    phonestatic.Stop();
                    if (ease >= 1f && (this.portrait == null || next2.Sprite != this.portrait.Sprite ||
                                       next2.Side != this.portrait.Side))
                    {
                        yield return EaseClose(final: false);
                    }

                    textbox = Graphics.PortraitsAtlas["textbox/default"];
                    textboxOverlay = null;
                    portraitExists = false;
                    activeTalker = null;
                    isPortraitGlitchy = false;
                    System.Xml.XmlElement metadata = null;
                    if (!string.IsNullOrEmpty(next2.Sprite))
                    {
                        if (Graphics.PortraitsSpriteBank.Has(next2.SpriteId))
                        {
                            metadata = Graphics.PortraitsSpriteBank.SpriteData[next2.SpriteId].Sources[0].XML;
                        }

                        portraitExists = metadata != null;
                        isPortraitGlitchy = next2.Glitchy;
                        if (isPortraitGlitchy && portraitGlitchy == null)
                        {
                            portraitGlitchy = Celeste.Graphics.Animation.AtlasSpriteFactory.Create(
                                engine, Graphics.PortraitsAtlas, "noise/");
                            portraitGlitchy.AddLoop("noise", "", .1f);
                            portraitGlitchy.Play("noise");
                        }
                    }

                    if (portraitExists)
                    {
                        if (this.portrait == null || next2.Sprite != this.portrait.Sprite)
                        {
                            Graphics.PortraitsSpriteBank.CreateOn(portraitSprite, next2.SpriteId);
                            portraitScale = 240f / (metadata.HasAttribute("size")
                                ? int.Parse(metadata.GetAttribute("size"),
                                    System.Globalization.CultureInfo.InvariantCulture)
                                : 160);
                            if (!talkers.ContainsKey(next2.SfxEvent))
                            {
                                global::Celeste.Simulation.Audio.Sources.SoundSourceComponentState soundSource =
                                    Sounds.Create().Play(next2.SfxEvent);
                                talkers.Add(next2.SfxEvent, soundSource);
                                AddSound(soundSource);
                            }
                        }

                        if (talkers.ContainsKey(next2.SfxEvent))
                        {
                            activeTalker = talkers[next2.SfxEvent];
                        }

                        string text = "textbox/" + (metadata.HasAttribute("textbox")
                            ? metadata.GetAttribute("textbox")
                            : "default");
                        textbox = Graphics.PortraitsAtlas[text];
                        if (Graphics.PortraitsAtlas.Entries.ContainsKey(text + "_overlay"))
                        {
                            textboxOverlay = Graphics.PortraitsAtlas[text + "_overlay"];
                        }

                        string text2 = metadata.GetAttribute("phonestatic");
                        if (!string.IsNullOrEmpty(text2))
                        {
                            if (text2 == "ex")
                            {
                                phonestatic.Play("event:/char/dialogue/sfx_support/phone_static_ex");
                            }
                            else if (text2 == "mom")
                            {
                                phonestatic.Play("event:/char/dialogue/sfx_support/phone_static_mom");
                            }
                        }

                        canSkip = false;
                        global::Celeste.Simulation.Dialogs.Nodes.DialogPortrait portrait = this.portrait;
                        this.portrait = next2;
                        if (next2.Pop)
                        {
                            portraitWiggle.Start();
                        }

                        if (portrait == null || portrait.Sprite != next2.Sprite ||
                            portrait.Animation != next2.Animation)
                        {
                            if (portraitSprite.Has(next2.BeginAnimation))
                            {
                                portraitSprite.Play(next2.BeginAnimation, restart: true);
                                yield return EaseOpen();
                                while (portraitSprite.CurrentAnimationID == next2.BeginAnimation &&
                                       portraitSprite.Animating)
                                {
                                    yield return null;
                                }
                            }

                            if (portraitSprite.Has(next2.IdleAnimation))
                            {
                                portraitIdling = true;
                                portraitSprite.Play(next2.IdleAnimation, restart: true);
                            }
                        }

                        yield return EaseOpen();
                        canSkip = true;
                    }
                    else
                    {
                        this.portrait = null;
                        yield return EaseOpen();
                    }
                }
                else if (current is global::Celeste.Graphics.Text.RichText.Nodes.RichTextPageBreak)
                {
                    PlayIdleAnimation();
                    if (ease >= 1f)
                    {
                        waitingForInput = true;
                        yield return 0.1f;
                        while (!ContinuePressed())
                        {
                            yield return null;
                        }

                        waitingForInput = false;
                    }

                    Start = index + 1;
                    Page++;
                }
                else if (current is global::Celeste.Graphics.Text.RichText.Nodes.RichTextPause)
                {
                    PlayIdleAnimation();
                    delay = (current as global::Celeste.Graphics.Text.RichText.Nodes.RichTextPause).Duration;
                }
                else if (current is global::Celeste.Simulation.Dialogs.Nodes.DialogTrigger)
                {
                    isInTrigger = true;
                    PlayIdleAnimation();
                    global::Celeste.Simulation.Dialogs.Nodes.DialogTrigger trigger =
                        current as global::Celeste.Simulation.Dialogs.Nodes.DialogTrigger;
                    if (!trigger.Silent)
                    {
                        yield return EaseClose(final: false);
                    }

                    int num = trigger.Index;
                    if (events != null && num >= 0 && num < events.Length)
                    {
                        yield return events[num]();
                    }

                    isInTrigger = false;
                }
                else if (current is global::Celeste.Graphics.Text.RichText.Nodes.RichTextGlyph)
                {
                    global::Celeste.Graphics.Text.RichText.Nodes.RichTextGlyph ch =
                        current as global::Celeste.Graphics.Text.RichText.Nodes.RichTextGlyph;
                    lastChar = (char)ch.Character;
                    if (ease < 1f)
                    {
                        yield return EaseOpen();
                    }

                    bool flag = false;
                    if (index - 5 > Start)
                    {
                        for (int i = index; i < Math.Min(index + 4, Nodes.Count); i++)
                        {
                            if (Nodes[i] is global::Celeste.Graphics.Text.RichText.Nodes.RichTextPageBreak)
                            {
                                flag = true;
                                PlayIdleAnimation();
                            }
                        }
                    }

                    if (!flag && !ch.IsPunctuation)
                    {
                        PlayTalkAnimation();
                    }

                    if (last != null && last is global::Celeste.Graphics.Text.RichText.Nodes.RichTextPageBreak)
                    {
                        index--;
                        yield return 0.2f;
                        index++;
                    }

                    delay = ch.Delay + delayBuildup;
                }

                last = current;
                index++;
                if (delay < 0.016f)
                {
                    delayBuildup += delay;
                    continue;
                }

                delayBuildup = 0f;
                if (delay > 0.5f)
                {
                    PlayIdleAnimation();
                }

                yield return delay;
            }

            PlayIdleAnimation();
            if (ease > 0f)
            {
                waitingForInput = true;
                while (!ContinuePressed())
                {
                    yield return null;
                }

                waitingForInput = false;
                Start = Nodes.Count;
                yield return EaseClose(final: true);
            }

            Close();
        }

        private void PlayIdleAnimation()
        {
            StopTalker();
            if (!portraitIdling && portraitSprite != null && portrait != null &&
                portraitSprite.Has(portrait.IdleAnimation))
            {
                portraitSprite.Play(portrait.IdleAnimation);
                portraitIdling = true;
            }
        }

        private void StopTalker()
        {
            if (activeTalker != null)
            {
                activeTalker.Param("dialogue_portrait", 0f);
                activeTalker.Param("dialogue_end", 1f);
            }
        }

        private void PlayTalkAnimation()
        {
            StartTalker();
            if (portraitIdling && portraitSprite != null && portrait != null &&
                portraitSprite.Has(portrait.TalkAnimation))
            {
                portraitSprite.Play(portrait.TalkAnimation);
                portraitIdling = false;
            }
        }

        private void StartTalker()
        {
            if (activeTalker != null)
            {
                activeTalker.Param("dialogue_portrait", (portrait == null) ? 1 : portrait.SfxExpression);
                activeTalker.Param("dialogue_end", 0f);
            }
        }

        private IEnumerator EaseOpen()
        {
            if (ease < 1f)
            {
                easingOpen = true;
                if (portrait != null &&
                    portrait.Sprite.IndexOf("madeline", StringComparison.InvariantCultureIgnoreCase) >= 0)
                {
                    Process.AudioSession.Play("event:/ui/game/textbox_madeline_in");
                }
                else
                {
                    Process.AudioSession.Play("event:/ui/game/textbox_other_in");
                }

                while ((ease += (runRoutine.UseRawDeltaTime ? engine.Frame.RawDeltaTime : engine.Frame.DeltaTime) /
                                0.4f) < 1f)
                {
                    gradientFade = Math.Max(gradientFade, ease);
                    yield return null;
                }

                ease = (gradientFade = 1f);
                easingOpen = false;
            }
        }

        private IEnumerator EaseClose(bool final)
        {
            easingClose = true;
            if (portrait != null &&
                portrait.Sprite.IndexOf("madeline", StringComparison.InvariantCultureIgnoreCase) >= 0)
            {
                Process.AudioSession.Play("event:/ui/game/textbox_madeline_out");
            }
            else
            {
                Process.AudioSession.Play("event:/ui/game/textbox_other_out");
            }

            while ((ease -= (runRoutine.UseRawDeltaTime ? engine.Frame.RawDeltaTime : engine.Frame.DeltaTime) / 0.4f) >
                   0f)
            {
                if (final)
                {
                    gradientFade = ease;
                }

                yield return null;
            }

            ease = 0f;
            easingClose = false;
        }

        private IEnumerator SkipDialog()
        {
            while (true)
            {
                if (!waitingForInput && canSkip && !easingOpen && !easingClose && ContinuePressed())
                {
                    StopTalker();
                    disableInput = true;
                    while (!waitingForInput && canSkip && !easingOpen && !easingClose && !isInTrigger &&
                           !runRoutine.Finished)
                    {
                        runRoutine.Update();
                    }
                }

                yield return null;
                disableInput = false;
            }
        }

        public bool SkipToPage(int page)
        {
            autoPressContinue = true;
            while (Page != page && !runRoutine.Finished)
            {
                UpdateCurrentFrame();
            }

            autoPressContinue = false;
            UpdateCurrentFrame();
            while (Opened && ease < 1f)
            {
                UpdateCurrentFrame();
            }

            if (Page == page)
            {
                return Opened;
            }

            return false;
        }

        public void Close()
        {
            Opened = false;
            RemoveSelf();
        }

        private bool ContinuePressed()
        {
            if (!autoPressContinue)
            {
                if (((Celeste.Input.Gameplay.IGameInputEnvironment)engine)
                    .Input[Celeste.Input.Gameplay.GameAction.MenuConfirm].Pressed ||
                    ((Celeste.Input.Gameplay.IGameInputEnvironment)engine)
                    .Input[Celeste.Input.Gameplay.GameAction.MenuCancel].Pressed)
                {
                    return !disableInput;
                }

                return false;
            }

            return true;
        }

        private void UpdateCurrentFrame()
        {
            if (Scene is Celeste.Game.Execution.Levels.OriginalLevelSceneRoot level &&
                (level.FrozenOrPaused || level.RetryPlayerCorpse != null))
            {
                return;
            }

            if (!autoPressContinue)
            {
                skipRoutine.Update();
            }

            runRoutine.Update();
            if (Scene != null &&
                ((Celeste.Scene.Tracking.ISourceScene)Scene).SourceScene.Clock.OnInterval(0.05f, engine))
            {
                shakeSeed = Random.Next();
            }

            if (portraitSprite != null && ease >= 1f)
            {
                portraitSprite.Update();
            }

            if (portraitGlitchy != null && ease >= 1f)
            {
                portraitGlitchy.Update();
            }

            timer += engine.Frame.DeltaTime;
            portraitWiggle.Update();
            int num = Math.Min(index, Nodes.Count);
            for (int i = Start; i < num; i++)
            {
                if (Nodes[i] is global::Celeste.Graphics.Text.RichText.Nodes.RichTextGlyph)
                {
                    global::Celeste.Graphics.Text.RichText.Nodes.RichTextGlyph obj =
                        Nodes[i] as global::Celeste.Graphics.Text.RichText.Nodes.RichTextGlyph;
                    if (obj.Fade < 1f)
                    {
                        obj.Fade = Clamp(obj.Fade + 8f * engine.Frame.DeltaTime, 0f, 1f);
                    }
                }
            }
        }
    }
}
