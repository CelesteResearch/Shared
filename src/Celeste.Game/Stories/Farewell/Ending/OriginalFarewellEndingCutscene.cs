using Celeste.Core.Display;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using EventInstance = Celeste.Audio.Fmod.Events.FmodEventReference;
using System.Numerics;
using Celeste.Core.Scheduling;
using Celeste.Core.Components.Timing;
using Celeste.Core.Rendering;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Input.Gameplay;
using Celeste.Input.Gameplay.Feedback;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Display;
using Celeste.Graphics.Rendering;
using Celeste.Formats.Graphics.Atlas;
using Celeste.Game.Execution.Levels.Cutscenes;
using Celeste.Game.Settings;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Execution.Startup;
using Celeste.Game.Content.Dialogs;
using Celeste.Game.Presentation.Hud.Speedrun;
using Celeste.Game.Presentation.Formatting;
using Celeste.Game.Chapters.Flow;
using Celeste.Game.UI.Dialogue.Textboxes;
using Celeste.Simulation.Presentation.Scene.Transitions;
using Player = Celeste.Simulation.RoomPlayerSession;
using Level = Celeste.Game.Execution.Levels.OriginalLevelSceneRoot;
using Coroutine = Celeste.Core.Scheduling.SimulationCoroutine;
using Color = Celeste.Core.Display.PackedColor;
using Image = Celeste.Graphics.Animation.SpriteImage;
using MTexture = Celeste.Graphics.Content.Atlas.AtlasEntry;
using global::Celeste.Game.Execution;

namespace Celeste.Game.Stories.Farewell.Ending
{
    public class OriginalFarewellEndingCutscene : OriginalCutsceneEntityState
    {
        private const int FPS = 12;

        private const float DELAY = 1f / 12f;

        private AtlasData Atlas;

        private List<MTexture> Frames;

        private int frame;

        private float fade = 1f;

        private float zoom = 1f;

        private float computerFade;

        private Coroutine talkingLoop;

        private Vector2 center = GameRuntime.TargetCenter;

        private Coroutine cutscene;

        private Color fadeColor = Color.White;

        private Image attachment;

        private Image cursor;

        private Image ok;

        private Image picture;

        private const float PictureIdleScale = 0.9f;

        private float speedrunTimerEase;

        private string speedrunTimerChapterString;

        private string speedrunTimerFileString;

        private string chapterSpeedrunText;

        private string version;

        private bool showTimer;

        private EventInstance endAmbience;

        private EventInstance cinIntro;

        private bool counting;

        private float timer;

        protected readonly ISourceEngineContext engine;

        private Celeste.Game.Audio.Runtime.OriginalGameAudioSession Audio =>
            ((IOriginalGameplayProcess)engine).AudioSession;

        protected OriginalAreaCompleteInfoState Info => ((IOriginalAreaCompleteInfoEnvironment)engine).AreaCompleteInfo;

        public OriginalFarewellEndingCutscene(ISourceEngineContext engine, Player player)
            : base(engine, fadeInOnSkip: false, endingChapterAfter: true)
        {
            this.engine = engine;
            chapterSpeedrunText =
                ((IOriginalGameTextEnvironment)engine).Text.Dialog.Get("OPTIONS_SPEEDRUN_CHAPTER") + ":";
            version = GameRuntime.Instance.Version.ToString();
            Tags = ((IOriginalGameTagsEnvironment)engine).Tags.HUD.Value;
            player.Machine.State = 11;
            player.Dummy.AutoAnimate = false;
            player.Sprite.Rate = 0f;
            RemoveOnSkipped = false;
            OwnedComponents.Add(
                new global::Celeste.Scene.Lifecycle.LevelEndingHookState(delegate { Audio.Stop(cinIntro); }));
        }

        public override void Awake(object scene)
        {
            base.Awake(scene);
            Level obj = scene as Level;
            obj.TimerStopped = true;
            obj.TimerHidden = true;
            obj.SaveQuitDisabled = true;
            obj.PauseLock = true;
            obj.AllowHudHide = false;
        }

        public override void OnBegin(Level level)
        {
            Audio.SetAmbience(null);
            level.AutoSave();
            speedrunTimerChapterString = SpeedrunTimerState.ShortGameplayFormat(level.Session.Time);
            speedrunTimerFileString =
                ((IOriginalGameTextEnvironment)engine).Text.FileTime(((IOriginalGameplayProcess)engine).SaveContext
                    .CurrentSave.Time);
            SpeedrunTimerState.CalculateBaseSizes(engine);
            OwnedComponents.Add(cutscene = new Coroutine(engine, Cutscene(level)));
        }

        private IEnumerator Cutscene(Level level)
        {
            if (level.Wipe != null)
            {
                level.Wipe.Cancel();
            }

            while (level.IsAutoSaving())
            {
                yield return null;
            }

            yield return 1f;
            Atlas = SourceAtlasLoader.FromAtlas(Path.Combine("Graphics", "Atlases", "Farewell"),
                AtlasDataFormat.PackerNoAtlas, (ISourceAtlasLoaderEnvironment)engine);
            Frames = Atlas.GetAtlasSubtextures("");
            OwnedComponents.Add(attachment = new Image(Atlas["21-window"]));
            OwnedComponents.Add(picture = new Image(Atlas["21-picture"]));
            OwnedComponents.Add(ok = new Image(Atlas["21-button"]));
            OwnedComponents.Add(cursor = new Image(Atlas["21-cursor"]));
            attachment.Visible = false;
            picture.Visible = false;
            ok.Visible = false;
            cursor.Visible = false;
            level.PauseLock = false;
            yield return 2f;
            cinIntro = Audio.Play("event:/new_content/music/lvl10/cinematic/end_intro");
            Audio.SetAmbience(null);
            counting = true;
            OwnedComponents.Add(new Coroutine(engine, Fade(1f, 0f, 4f)));
            OwnedComponents.Add(new Coroutine(engine, Zoom(1.38f, 1.2f, 4f)));
            yield return Loop("0", 2f);
            ((ISourceRumbleEnvironment)engine).RumbleSession.Rumble(3, 4);
            yield return Loop("0,1,1,0,0,1,1,0*8", 2f);
            ((ISourceRumbleEnvironment)engine).RumbleSession.Rumble(2, 0);
            Audio.SetMusic("event:/new_content/music/lvl10/cinematic/end", startPlaying: true, allowFadeOut: false);
            endAmbience = Audio.Play("event:/new_content/env/10_endscene");
            OwnedComponents.Add(new Coroutine(engine,
                Zoom(1.2f, 1.05f, 0.06f, ((ISourceEasingEnvironment)engine).EasingArithmetic.CubeOut)));
            yield return Play("2-7");
            yield return Loop("7", 1.5f);
            yield return Play("8-10,10*20");
            List<int> frameData = GetFrameData("10-13,13*16,14*28,14-17,14*24");
            float num = (float)(frameData.Count + 3) * (1f / 12f);
            fadeColor = Color.Black;
            OwnedComponents.Add(new Coroutine(engine,
                Zoom(1.05f, 1f, num, ((ISourceEasingEnvironment)engine).EasingArithmetic.Linear)));
            OwnedComponents.Add(new Coroutine(engine, Fade(0f, 1f, num * 0.1f, num * 0.85f)));
            OwnedComponents.Add(SourceAlarmState.Create(engine.AlarmPool, SourceAlarmState.AlarmMode.Oneshot,
                delegate { Audio.Play("event:/new_content/game/10_farewell/endscene_dial_theo"); }, num, start: true));
            yield return Play(frameData);
            frame = 18;
            fade = 1f;
            yield return 0.5f;
            yield return Fade(1f, 0f, 1.2f);
            OwnedComponents.Add(talkingLoop = new Coroutine(engine, Loop("18*24,19,19,18*6,20,20")));
            yield return 1f;
            yield return TextboxState.Say("CH9_END_CINEMATIC", engine, ShowPicture);
            Audio.SetMusicParam("end", 1f);
            Audio.Play("event:/new_content/game/10_farewell/endscene_photo_zoom");
            for (float p = 0f; p < 1f; p += engine.DeltaTime / 4f)
            {
                Audio.SetParameter(endAmbience, "fade", 1f - p);
                computerFade = p;
                picture.Scale = Vector2.One * (0.9f + 0.100000024f * p);
                yield return null;
            }

            EndCutscene(level, removeSelf: false);
        }

        private IEnumerator ShowPicture()
        {
            center = new Vector2(1230f, 312f);
            OwnedComponents.Add(new Coroutine(engine, Fade(0f, 1f, 0.25f)));
            OwnedComponents.Add(new Coroutine(engine, Zoom(1f, 1.1f, 0.25f)));
            yield return 0.25f;
            if (talkingLoop != null)
            {
                talkingLoop.RemoveSelf();
            }

            talkingLoop = null;
            yield return null;
            frame = 21;
            cursor.Visible = true;
            center = GameRuntime.TargetCenter;
            OwnedComponents.Add(new Coroutine(engine, Fade(1f, 0f, 0.25f)));
            OwnedComponents.Add(new Coroutine(engine, Zoom(1.1f, 1f, 0.25f)));
            yield return 0.25f;
            Audio.Play("event:/new_content/game/10_farewell/endscene_attachment_notify");
            attachment.Origin = GameRuntime.TargetCenter;
            attachment.Position = GameRuntime.TargetCenter;
            attachment.Visible = true;
            attachment.Scale = Vector2.Zero;
            for (float p = 0f; p < 1f; p += engine.DeltaTime / 0.3f)
            {
                attachment.Scale.Y = 0.25f + 0.75f * ((ISourceEasingEnvironment)engine).EasingArithmetic.BigBackOut(p);
                attachment.Scale.X = 1.5f - 0.5f * ((ISourceEasingEnvironment)engine).EasingArithmetic.BigBackOut(p);
                yield return null;
            }

            yield return 0.25f;
            ok.Position = new Vector2(1208f, 620f);
            ok.Origin = ok.Position;
            ok.Visible = true;
            for (float p = 0f; p < 1f; p += engine.DeltaTime / 0.25f)
            {
                ok.Scale.Y = 0.25f + 0.75f * ((ISourceEasingEnvironment)engine).EasingArithmetic.BigBackOut(p);
                ok.Scale.X = 1.5f - 0.5f * ((ISourceEasingEnvironment)engine).EasingArithmetic.BigBackOut(p);
                yield return null;
            }

            yield return 0.8f;
            Vector2 from = cursor.Position;
            Vector2 to = from + new Vector2(-160f, -190f);
            for (float p = 0f; p < 1f; p += engine.DeltaTime / 0.5f)
            {
                cursor.Position = from + (to - from) * ((ISourceEasingEnvironment)engine).EasingArithmetic.CubeInOut(p);
                yield return null;
            }

            yield return 0.2f;
            Audio.Play("event:/new_content/game/10_farewell/endscene_attachment_click");
            for (float p = 0f; p < 1f; p += engine.DeltaTime / 0.25f)
            {
                ok.Scale.Y = 1f - ((ISourceEasingEnvironment)engine).EasingArithmetic.BigBackIn(p);
                ok.Scale.X = 1f - ((ISourceEasingEnvironment)engine).EasingArithmetic.BigBackIn(p);
                yield return null;
            }

            ok.Visible = false;
            yield return 0.1f;
            picture.Origin = GameRuntime.TargetCenter;
            picture.Position = GameRuntime.TargetCenter;
            picture.Visible = true;
            for (float p = 0f; p < 1f; p += engine.DeltaTime / 0.4f)
            {
                picture.Scale.Y = (0.9f + 0.1f * ((ISourceEasingEnvironment)engine).EasingArithmetic.BigBackOut(p)) *
                                  0.9f;
                picture.Scale.X = (1.1f - 0.1f * ((ISourceEasingEnvironment)engine).EasingArithmetic.BigBackOut(p)) *
                                  0.9f;
                picture.Position = GameRuntime.TargetCenter + Vector2.UnitY * 120f *
                    (1f - ((ISourceEasingEnvironment)engine).EasingArithmetic.CubeOut(p));
                picture.Color = Color.White * p;
                yield return null;
            }

            picture.Position = GameRuntime.TargetCenter;
            attachment.Visible = false;
            to = cursor.Position;
            from = new Vector2(120f, 30f);
            for (float p = 0f; p < 1f; p += engine.DeltaTime / 0.5f)
            {
                cursor.Position = to + (from - to) * ((ISourceEasingEnvironment)engine).EasingArithmetic.CubeInOut(p);
                yield return null;
            }

            cursor.Visible = false;
            yield return 2f;
        }

        public override void OnEnd(Level level)
        {
            ((ISourceScreenWipeEnvironment)engine).ProcessWipe.WipeColor = Color.Black;
            if (Audio.CurrentMusicEventInstance == null)
            {
                Audio.SetMusic("event:/new_content/music/lvl10/cinematic/end");
            }

            Audio.SetMusicParam("end", 1f);
            frame = 21;
            zoom = 1f;
            fade = 0f;
            fadeColor = Color.Black;
            center = GameRuntime.TargetCenter;
            picture.Scale = Vector2.One;
            picture.Visible = true;
            picture.Position = GameRuntime.TargetCenter;
            picture.Origin = GameRuntime.TargetCenter;
            computerFade = 1f;
            attachment.Visible = false;
            cursor.Visible = false;
            ok.Visible = false;
            Audio.Stop(cinIntro);
            cinIntro = null;
            Audio.Stop(endAmbience);
            endAmbience = null;
            List<Coroutine> list = new List<Coroutine>();
            foreach (Coroutine item in OwnedComponents.GetAll<Coroutine>())
            {
                list.Add(item);
            }

            foreach (Coroutine item2 in list)
            {
                item2.RemoveSelf();
            }

            ((Level)Scene).Scheduler.Entities.FindFirst<TextboxState>()?.RemoveSelf();
            Level.InCutscene = true;
            Level.PauseLock = true;
            Level.TimerHidden = true;
            OwnedComponents.Add(new Coroutine(engine, EndingRoutine()));
        }

        protected virtual IEnumerator EndingRoutine()
        {
            Level.InCutscene = true;
            Level.PauseLock = true;
            Level.TimerHidden = true;
            yield return 0.5f;
            if (((ISettingsContext)engine).Settings.SpeedrunClock != 0)
            {
                showTimer = true;
            }

            while (!((ISourceGameInputEnvironment)engine).Input.MenuConfirm.Pressed)
            {
                yield return null;
            }

            Audio.Play("event:/new_content/game/10_farewell/endscene_final_input");
            showTimer = false;
            OwnedComponents.Add(new Coroutine(engine,
                Zoom(1f, 0.75f, 5f, ((ISourceEasingEnvironment)engine).EasingArithmetic.CubeIn)));
            OwnedComponents.Add(new Coroutine(engine, Fade(0f, 1f, 5f)));
            yield return 4f;
            for (float p = 0f; p < 1f; p += engine.DeltaTime / 3f)
            {
                Audio.SetMusicParam("fade", 1f - p);
                yield return null;
            }

            Audio.SetMusic(null);
            yield return 1f;
            if (Atlas != null)
            {
                Atlas.Dispose();
            }

            Atlas = null;
            Level.CompleteArea(spotlightWipe: false, skipScreenWipe: true, skipCompleteScreen: true);
        }

        public override void Update()
        {
            if (counting)
            {
                timer += engine.DeltaTime;
            }

            speedrunTimerEase = ScalarMath.Approach(speedrunTimerEase, showTimer ? 1f : 0f, engine.DeltaTime * 4f,
                ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
            base.Update();
        }

        public override void Render(ISourceRenderContext context)
        {
            SourcePrimitiveDrawing.Rect(context, this, -100f, -100f, 2120f, 1280f, Color.Black);
            if (Atlas != null && Frames != null && frame < Frames.Count)
            {
                MTexture mTexture = Frames[frame];
                MTexture linkedTexture = Atlas.GetLinkedTexture(mTexture.AtlasPath);
                if (linkedTexture != null)
                    SourceAtlasDrawing.DrawJustified(context, this, linkedTexture, center,
                        new Vector2(center.X / (float)linkedTexture.FrameWidth,
                            center.Y / (float)linkedTexture.FrameHeight), Color.White, zoom);
                SourceAtlasDrawing.DrawJustified(context, this, mTexture, center,
                    new Vector2(center.X / (float)mTexture.FrameWidth, center.Y / (float)mTexture.FrameHeight),
                    Color.White,
                    zoom);
                if (computerFade > 0f)
                {
                    SourcePrimitiveDrawing.Rect(context, this, 0f, 0f, 1920f, 1080f, Color.Black * computerFade);
                }

                base.Render(context);
                Info.Info(context, this, speedrunTimerEase, speedrunTimerChapterString, speedrunTimerFileString,
                    chapterSpeedrunText, version);
            }

            SourcePrimitiveDrawing.Rect(context, this, 0f, 0f, 1920f, 1080f, fadeColor * fade);
            if ((base.Scene as Level).Paused)
            {
                SourcePrimitiveDrawing.Rect(context, this, 0f, 0f, 1920f, 1080f, Color.Black * 0.5f);
            }
        }

        private List<int> GetFrameData(string data)
        {
            List<int> list = new List<int>();
            string[] array = data.Split(',');
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].Contains('*'))
                {
                    string[] array2 = array[i].Split('*');
                    int item = int.Parse(array2[0]);
                    int num = int.Parse(array2[1]);
                    for (int j = 0; j < num; j++)
                    {
                        list.Add(item);
                    }
                }
                else if (array[i].Contains('-'))
                {
                    string[] array3 = array[i].Split('-');
                    int num2 = int.Parse(array3[0]);
                    int num3 = int.Parse(array3[1]);
                    for (int k = num2; k <= num3; k++)
                    {
                        list.Add(k);
                    }
                }
                else
                {
                    list.Add(int.Parse(array[i]));
                }
            }

            return list;
        }

        private IEnumerator Zoom(float from, float to, float duration, Func<float, float> ease = null)
        {
            if (ease == null)
            {
                ease = ((ISourceEasingEnvironment)engine).EasingArithmetic.Linear;
            }

            zoom = from;
            for (float p = 0f; p < 1f; p += engine.DeltaTime / duration)
            {
                zoom = from + (to - from) * ease(p);
                if (picture != null)
                {
                    picture.Scale = Vector2.One * zoom;
                }

                yield return null;
            }

            zoom = to;
        }

        private IEnumerator Play(string data)
        {
            return Play(GetFrameData(data));
        }

        private IEnumerator Play(List<int> frames)
        {
            for (int i = 0; i < frames.Count; i++)
            {
                frame = frames[i];
                yield return 1f / 12f;
            }
        }

        private IEnumerator Loop(string data, float duration = -1f)
        {
            List<int> frames = GetFrameData(data);
            float time = 0f;
            while (time < duration || duration < 0f)
            {
                frame = frames[(int)(time / (1f / 12f)) % frames.Count];
                time += engine.DeltaTime;
                yield return null;
            }
        }

        private IEnumerator Fade(float from, float to, float duration, float delay = 0f)
        {
            fade = from;
            yield return delay;
            for (float p = 0f; p < 1f; p += engine.DeltaTime / duration)
            {
                fade = from + (to - from) * p;
                yield return null;
            }

            fade = to;
        }
    }
}
