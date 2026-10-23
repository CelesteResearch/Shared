using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Numerics;
using System.Xml;
using Celeste.Core.Components;
using Celeste.Core.Mathematics;
using Celeste.Core.Randomness;
using Celeste.Core.Scheduling;
using Celeste.Game.Content.Dialogs;
using Celeste.Game.Execution.Graphics;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Execution.Startup;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Animation.Portraits;
using Celeste.Graphics.Content;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Text.BitmapFonts;
using Celeste.Graphics.Text.RichText.Layout;
using Celeste.Graphics.Text.RichText.Nodes;
using Celeste.Input.Gameplay;
using Celeste.Localization.Languages;
using Celeste.Scene.Components.Oscillation;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
using Celeste.Simulation.Audio.Sources;
using Celeste.Simulation.Dialogs.Nodes;

namespace Celeste.Game.UI.Dialogue.Textboxes
{
    public sealed partial class TextboxState : SceneEntityState,
        IPortraitAnimation
    {
        private readonly ISourceEngineContext engine;

        private IOriginalGameplayProcess Process
            => (IOriginalGameplayProcess)engine;

        private OriginalGameGraphicsResources Graphics
            => (OriginalGameGraphicsResources)
                ((ISourceGameGraphicsEnvironment)engine).GameGraphics;

        private OriginalGameTextProcess TextProcess
            => ((IOriginalGameTextEnvironment)engine).Text;

        private ISourceRandom Random
            => ((ISourceRandomEnvironment)engine).Random;

        private ISourceSoundSourceFactory Sounds
            => ((ISourceSoundSourceEnvironment)engine).SoundSources;

        private AtlasEntry textbox, textboxOverlay;
        private readonly SourcePixelFont font;
        private readonly float innerTextPadding, maxLineWidthNoPortrait, maxLineWidth, lineHeight;
        private readonly int linesPerPage;

        private float ease;
        private float timer;

        private float gradientFade;
        private readonly Func<IEnumerator>[] events;

        private readonly SimulationCoroutine runRoutine, skipRoutine;

        private TextAnchorPosition anchor;

        private DialogPortrait portrait;

        private int index;
        private int shakeSeed;

        private bool waitingForInput;
        private bool disableInput;

        private bool isInTrigger;

        private bool easingClose;

        private bool easingOpen;

        public bool AutoPressContinue { get; set; }

        private bool canSkip = true;

        private char lastChar;
        private bool portraitExists, portraitIdling, isPortraitGlitchy;
        private float portraitScale = 1.5f;
        private readonly WigglerComponent portraitWiggle;

        private Sprite portraitGlitchy;

        private readonly Dictionary<string, SoundSourceComponentState>
            talkers = new();

        private SoundSourceComponentState activeTalker;
        private readonly SoundSourceComponentState phonestatic;
        public Vector2 RenderOffset;
        public bool Opened { get; private set; } = true;
        public int Page { get; private set; }
        public int Start { get; private set; }

        // ReSharper disable once ConvertToAutoPropertyWithPrivateSetter
        public int Index => index;

        // ReSharper disable once ConvertToAutoPropertyWithPrivateSetter
        public float Ease => ease;

        // ReSharper disable once ConvertToAutoPropertyWithPrivateSetter
        public TextAnchorPosition Anchor => anchor;

        // ReSharper disable once ConvertToAutoPropertyWithPrivateSetter
        public float GradientFade => gradientFade;

        // ReSharper disable once ConvertToAutoPropertyWithPrivateSetter
        public bool WaitingForInput => waitingForInput;

        // ReSharper disable once ConvertToAutoPropertyWithPrivateSetter
        public bool InTrigger => isInTrigger;

        // ReSharper disable once ConvertToAutoPropertyWithPrivateSetter
        public bool CanSkip => canSkip;
        public RichTextLayout Text { get; }

        public List<RichTextNode> Nodes => Text.Nodes;
        public Sprite PortraitSprite { get; }

        // ReSharper disable once ConvertToAutoPropertyWithPrivateSetter
        public Sprite PortraitGlitchy => portraitGlitchy;
        public OscillationPulseState Wiggle => portraitWiggle;
        public string PortraitName => portrait == null || portrait.Sprite == null ? "" : portrait.Sprite;
        public string PortraitAnimation => portrait == null || portrait.Sprite == null ? "" : portrait.Animation;

        public bool UseRawDeltaTime
        {
            get => runRoutine.UseRawDeltaTime;
            set => runRoutine.UseRawDeltaTime = value;
        }

        public TextboxState(string dialog, ISourceEngineContext engine,
            DialogLanguage language = null, params Func<IEnumerator>[] events)
            : this(dialog, engine, language, events,
                new(engine),
                new(engine))
        {
        }

        private TextboxState(string dialog, ISourceEngineContext engine,
            DialogLanguage language, Func<IEnumerator>[] events,
            SimulationCoroutine runRoutine,
            SimulationCoroutine skipRoutine, string layoutFontFace = null)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration)
        {
            this.runRoutine = runRoutine;
            this.skipRoutine = skipRoutine;
            this.engine = engine ?? throw new ArgumentNullException(nameof(engine));
            Tags = ((IOriginalGameTagsEnvironment)engine).Tags.PauseUpdate
                .Value | ((IOriginalGameTagsEnvironment)engine).Tags.HUD
                .Value;
            this.events = events;
            textbox = Graphics.PortraitsAtlas["textbox/default"];
            PortraitSprite = new(engine, null, null)
                { UseRawDeltaTime = true };
            font = TextProcess.Fonts.Get(TextProcess.Dialog.Language.FontFace);
            lineHeight = font.Get(TextProcess.Dialog.Language.FontFaceSize).LineHeight - 1;
            portraitWiggle = ((ISourceWigglerPoolScope)engine)
                .WigglerPool.Create(.4f, 4f);
            Components.Add(portraitWiggle);
            linesPerPage = (int)(240f / lineHeight);
            innerTextPadding = (272 - lineHeight * linesPerPage) / 2;
            maxLineWidthNoPortrait = 1688 - innerTextPadding * 2;
            maxLineWidth = maxLineWidthNoPortrait - 240 - 32;
            var context = OriginalFancyTextContext.Create(
                (IOriginalFancyTextProcess)engine, language, layoutFontFace);
            Text = OriginalFancyTextParser.Parse(
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

        private void AddSound(SoundSourceComponentState source)
        {
            Components.Add(source);
        }

        public void SetStart(int value)
        {
            Start = index = value;
        }

        public override void Update()
        {
            UpdateCurrentFrame();
        }

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

        public int PortraitSide(DialogPortrait value)
        {
            return Process.SaveContext.CurrentSave != null && Process.SaveContext.CurrentSave.Assists.MirrorMode
                ? -value.Side
                : value.Side;
        }

        public static IEnumerator Say(string dialog, ISourceEngineContext engine,
            params Func<IEnumerator>[] events)
        {
            var box = new TextboxState(dialog, engine, null, events);
            ((ISourceScene)engine.Frame.Scenes.CurrentScene)
                .SourceScene.QueueSourceEntity(box);
            while (box.Opened) yield return null;
        }

        public static IEnumerator SayWithLayoutFont(string dialog, ISourceEngineContext engine,
            string fontFace, params Func<IEnumerator>[] events)
        {
            var box = new TextboxState(dialog, engine, null, events,
                new(engine),
                new(engine), fontFace);
            ((ISourceScene)engine.Frame.Scenes.CurrentScene)
                .SourceScene.QueueSourceEntity(box);
            while (box.Opened) yield return null;
        }

        public static IEnumerator SayWhileFrozen(string dialog, ISourceEngineContext engine,
            params Func<IEnumerator>[] events)
        {
            var box = new TextboxState(dialog, engine, null, events);
            box.Tags |= ((IOriginalGameTagsEnvironment)engine).Tags
                .FrozenUpdate.Value;
            ((ISourceScene)engine.Frame.Scenes.CurrentScene)
                .SourceScene.QueueSourceEntity(box);
            while (box.Opened) yield return null;
        }

        private static float Clamp(float value, float min, float max)
        {
            return ScalarMath.Clamp(value, min, max);
        }

        private IEnumerator RunRoutine()
        {
            RichTextNode last = null;
            var delayBuildup = 0f;
            while (Index < Nodes.Count)
            {
                var current = Nodes[Index];
                var delay = 0f;
                if (current is RichTextAnchor)
                {
                    if (RenderOffset == Vector2.Zero)
                    {
                        var next =
                            (current as RichTextAnchor).Position;
                        if (Ease >= 1f && next != Anchor) yield return EaseClose(false);

                        anchor = next;
                    }
                }
                else if (current is DialogPortrait)
                {
                    var next2 =
                        current as DialogPortrait;
                    phonestatic.Stop();
                    if (Ease >= 1f && (this.portrait == null || next2.Sprite != this.portrait.Sprite ||
                                       next2.Side != this.portrait.Side))
                        yield return EaseClose(false);

                    textbox = Graphics.PortraitsAtlas["textbox/default"];
                    textboxOverlay = null;
                    portraitExists = false;
                    activeTalker = null;
                    isPortraitGlitchy = false;
                    XmlElement metadata = null;
                    if (!string.IsNullOrEmpty(next2.Sprite))
                    {
                        if (Graphics.PortraitsSpriteBank.Has(next2.SpriteId))
                            metadata = Graphics.PortraitsSpriteBank.SpriteData[next2.SpriteId].Sources[0].XML;

                        portraitExists = metadata != null;
                        isPortraitGlitchy = next2.Glitchy;
                        if (isPortraitGlitchy && PortraitGlitchy == null)
                        {
                            portraitGlitchy = AtlasSpriteFactory.Create(
                                engine, Graphics.PortraitsAtlas, "noise/");
                            PortraitGlitchy.AddLoop("noise", "", .1f);
                            PortraitGlitchy.Play("noise");
                        }
                    }

                    if (portraitExists)
                    {
                        if (this.portrait == null || next2.Sprite != this.portrait.Sprite)
                        {
                            Graphics.PortraitsSpriteBank.CreateOn(PortraitSprite, next2.SpriteId);
                            portraitScale = 240f / (metadata.HasAttribute("size")
                                ? int.Parse(metadata.GetAttribute("size"),
                                    CultureInfo.InvariantCulture)
                                : 160);
                            if (!talkers.ContainsKey(next2.SfxEvent))
                            {
                                var soundSource =
                                    Sounds.Create().Play(next2.SfxEvent);
                                talkers.Add(next2.SfxEvent, soundSource);
                                AddSound(soundSource);
                            }
                        }

                        if (talkers.ContainsKey(next2.SfxEvent)) activeTalker = talkers[next2.SfxEvent];

                        var text = "textbox/" + (metadata.HasAttribute("textbox")
                            ? metadata.GetAttribute("textbox")
                            : "default");
                        textbox = Graphics.PortraitsAtlas[text];
                        if (Graphics.PortraitsAtlas.Entries.ContainsKey(text + "_overlay"))
                            textboxOverlay = Graphics.PortraitsAtlas[text + "_overlay"];

                        var text2 = metadata.GetAttribute("phonestatic");
                        if (!string.IsNullOrEmpty(text2))
                        {
                            if (text2 == "ex")
                                phonestatic.Play("event:/char/dialogue/sfx_support/phone_static_ex");
                            else if (text2 == "mom")
                                phonestatic.Play("event:/char/dialogue/sfx_support/phone_static_mom");
                        }

                        canSkip = false;
                        var portrait = this.portrait;
                        this.portrait = next2;
                        if (next2.Pop) portraitWiggle.Start();

                        if (portrait == null || portrait.Sprite != next2.Sprite ||
                            portrait.Animation != next2.Animation)
                        {
                            if (PortraitSprite.Has(next2.BeginAnimation))
                            {
                                PortraitSprite.Play(next2.BeginAnimation, true);
                                yield return EaseOpen();
                                while (PortraitSprite.CurrentAnimationID == next2.BeginAnimation &&
                                       PortraitSprite.Animating)
                                    yield return null;
                            }

                            if (PortraitSprite.Has(next2.IdleAnimation))
                            {
                                portraitIdling = true;
                                PortraitSprite.Play(next2.IdleAnimation, true);
                            }
                        }

                        yield return EaseOpen();
                        canSkip = true;
                    }
                    else
                    {
                        portrait = null;
                        yield return EaseOpen();
                    }
                }
                else if (current is RichTextPageBreak)
                {
                    PlayIdleAnimation();
                    if (Ease >= 1f)
                    {
                        waitingForInput = true;
                        yield return 0.1f;
                        while (!ContinuePressed()) yield return null;

                        waitingForInput = false;
                    }

                    Start = Index + 1;
                    Page++;
                }
                else if (current is RichTextPause)
                {
                    PlayIdleAnimation();
                    delay = (current as RichTextPause).Duration;
                }
                else if (current is DialogTrigger)
                {
                    isInTrigger = true;
                    PlayIdleAnimation();
                    var trigger =
                        current as DialogTrigger;
                    if (!trigger.Silent) yield return EaseClose(false);

                    var num = trigger.Index;
                    if (events != null && num >= 0 && num < events.Length) yield return events[num]();

                    isInTrigger = false;
                }
                else if (current is RichTextGlyph)
                {
                    var ch =
                        current as RichTextGlyph;
                    lastChar = (char)ch.Character;
                    if (Ease < 1f) yield return EaseOpen();

                    var flag = false;
                    if (Index - 5 > Start)
                        for (var i = Index; i < Math.Min(Index + 4, Nodes.Count); i++)
                            if (Nodes[i] is RichTextPageBreak)
                            {
                                flag = true;
                                PlayIdleAnimation();
                            }

                    if (!flag && !ch.IsPunctuation) PlayTalkAnimation();

                    if (last != null && last is RichTextPageBreak)
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
                if (delay > 0.5f) PlayIdleAnimation();

                yield return delay;
            }

            PlayIdleAnimation();
            if (Ease > 0f)
            {
                waitingForInput = true;
                while (!ContinuePressed()) yield return null;

                waitingForInput = false;
                Start = Nodes.Count;
                yield return EaseClose(true);
            }

            Close();
        }

        private void PlayIdleAnimation()
        {
            StopTalker();
            if (!portraitIdling && PortraitSprite != null && portrait != null &&
                PortraitSprite.Has(portrait.IdleAnimation))
            {
                PortraitSprite.Play(portrait.IdleAnimation);
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
            if (portraitIdling && PortraitSprite != null && portrait != null &&
                PortraitSprite.Has(portrait.TalkAnimation))
            {
                PortraitSprite.Play(portrait.TalkAnimation);
                portraitIdling = false;
            }
        }

        private void StartTalker()
        {
            if (activeTalker != null)
            {
                activeTalker.Param("dialogue_portrait", portrait == null ? 1 : portrait.SfxExpression);
                activeTalker.Param("dialogue_end", 0f);
            }
        }

        private IEnumerator EaseOpen()
        {
            if (Ease < 1f)
            {
                easingOpen = true;
                if (portrait != null &&
                    portrait.Sprite.IndexOf("madeline", StringComparison.InvariantCultureIgnoreCase) >= 0)
                    Process.AudioSession.Play("event:/ui/game/textbox_madeline_in");
                else
                    Process.AudioSession.Play("event:/ui/game/textbox_other_in");

                while ((ease += (runRoutine.UseRawDeltaTime ? engine.Frame.RawDeltaTime : engine.Frame.DeltaTime) /
                                0.4f) < 1f)
                {
                    gradientFade = Math.Max(GradientFade, Ease);
                    yield return null;
                }

                ease = gradientFade = 1f;
                easingOpen = false;
            }
        }

        private IEnumerator EaseClose(bool final)
        {
            easingClose = true;
            if (portrait != null &&
                portrait.Sprite.IndexOf("madeline", StringComparison.InvariantCultureIgnoreCase) >= 0)
                Process.AudioSession.Play("event:/ui/game/textbox_madeline_out");
            else
                Process.AudioSession.Play("event:/ui/game/textbox_other_out");

            while ((ease -= (runRoutine.UseRawDeltaTime ? engine.Frame.RawDeltaTime : engine.Frame.DeltaTime) / 0.4f) >
                   0f)
            {
                if (final) gradientFade = Ease;

                yield return null;
            }

            ease = 0f;
            easingClose = false;
        }

        private IEnumerator SkipDialog()
        {
            while (true)
            {
                if (!WaitingForInput && CanSkip && !easingOpen && !easingClose && ContinuePressed())
                {
                    StopTalker();
                    disableInput = true;
                    while (!WaitingForInput && CanSkip && !easingOpen && !easingClose && !InTrigger &&
                           !runRoutine.Finished)
                        runRoutine.Update();
                }

                yield return null;
                disableInput = false;
            }
        }

        public bool SkipToPage(int page)
        {
            AutoPressContinue = true;
            while (Page != page && !runRoutine.Finished) UpdateCurrentFrame();

            AutoPressContinue = false;
            UpdateCurrentFrame();
            while (Opened && Ease < 1f) UpdateCurrentFrame();

            if (Page == page) return Opened;

            return false;
        }

        public void Close()
        {
            Opened = false;
            RemoveSelf();
        }

        private bool ContinuePressed()
        {
            if (!AutoPressContinue)
            {
                if (((IGameInputEnvironment)engine)
                    .Input[GameAction.MenuConfirm].Pressed ||
                    ((IGameInputEnvironment)engine)
                    .Input[GameAction.MenuCancel].Pressed)
                    return !disableInput;

                return false;
            }

            return true;
        }

        private void UpdateCurrentFrame()
        {
            if (Scene is OriginalLevelSceneRoot level &&
                (level.FrozenOrPaused || level.RetryPlayerCorpse != null))
                return;

            if (!AutoPressContinue) skipRoutine.Update();

            runRoutine.Update();
            if (Scene != null &&
                ((ISourceScene)Scene).SourceScene.Clock.OnInterval(0.05f, engine))
                shakeSeed = Random.Next();

            if (PortraitSprite != null && Ease >= 1f) PortraitSprite.Update();

            if (PortraitGlitchy != null && Ease >= 1f) PortraitGlitchy.Update();

            timer += engine.Frame.DeltaTime;
            portraitWiggle.Update();
            var num = Math.Min(Index, Nodes.Count);
            for (var i = Start; i < num; i++)
                if (Nodes[i] is RichTextGlyph)
                {
                    var obj =
                        Nodes[i] as RichTextGlyph;
                    if (obj.Fade < 1f) obj.Fade = Clamp(obj.Fade + 8f * engine.Frame.DeltaTime, 0f, 1f);
                }
        }
    }
}
