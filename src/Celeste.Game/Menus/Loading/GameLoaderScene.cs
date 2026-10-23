using Celeste.Core.Display;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using System.Threading;
using Celeste.Core.Components;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Input.Gameplay;
using Celeste.Game.Audio.Mixing;
using Celeste.Game.Entities;
using Celeste.Game.Execution.Engine.Commands;
using Celeste.Game.Execution.Engine.Update;
using Celeste.Scene.Entities;
using Celeste.Scene.Scenes;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Graphics.Rendering;
using Celeste.Scene.Rendering;
using Celeste.Scene.Scheduling;
using Celeste.Scene.Tracking;
using Celeste.Game.Presentation.Environment;
using Celeste.Game.Presentation.Hud;
using Celeste.Simulation.Presentation.Scene.Transitions;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Display;

namespace Celeste.Game.Menus.Loading
{
    public class GameLoaderScene : SourceSceneState, IOriginalEngineDashAssistScene
    {
        protected readonly IGameLoaderSourceResources resources;
        protected readonly ISourceGameInput input;
        private readonly AtlasData opening;
        protected bool loaded;
        protected bool audioLoaded;
        private bool audioStarted;
        protected bool dialogLoaded;
        protected bool skipped;
        protected bool ready;
        protected SceneEntityState handler;
        private Thread activeThread;
        private List<AtlasEntry> loadingTextures;
        private float loadingFrame;
        private float loadingAlpha;

        public bool SourceLoaded => loaded;
        public void SkipIntro() => skipped = true;
        public HiresSnowState Snow { get; }

        public GameLoaderScene(ISourceEngineContext engine, ISourceGameInput input,
            IGameLoaderSourceResources resources)
            : base(engine, ((ISourceSceneCatalogEnvironment)engine).SceneCatalog,
                ((global::Celeste.Scene.Scheduling.ISourceSceneUpdatePolicyEnvironment)engine).PlainScenePolicy)
        {
            this.input = input ?? throw new ArgumentNullException(nameof(input));
            this.resources = resources ?? throw new ArgumentNullException(nameof(resources));
            Console.WriteLine("GAME DISPLAYED (in " + resources.ProcessTiming.LoadTimer.ElapsedMilliseconds + "ms)");
            Snow = new HiresSnowState(EngineContext);
            opening = global::Celeste.Formats.Graphics.Atlas.SourceAtlasLoader.FromAtlas(
                System.IO.Path.Combine("Graphics", "Atlases", "Opening"),
                global::Celeste.Formats.Graphics.Atlas.AtlasDataFormat.PackerNoAtlas, resources);
        }

        public override void Begin()
        {
            // GameLoader.Begin intentionally does not call Scene.Begin.
            Renderers.Add(new HudRendererState());
            Renderers.Add(Snow);
            _ = new FadeWipePresentation(this, true);
            Renderers.UpdateLists();
            handler = new SceneEntityState(
                ((global::Celeste.Core.Components.ISourceEntitySourceDataEnvironment)EngineContext)
                .EntitySourceDataRegistration);
            SourceScene.QueueSourceEntity(handler);
            handler.Tags = ((global::Celeste.Game.Execution.Startup.IOriginalGameTagsEnvironment)EngineContext).Tags
                .HUD.Value;
            handler.Components.Add(new SimulationCoroutine(EngineContext, IntroRoutine()));
            activeThread = Thread.CurrentThread;
            resources.Threads.SetHostThreadPriority(activeThread, ThreadPriority.Lowest);
            resources.Threads.Start(LoadThread, "GAME_LOADER", true);
        }


        public override void Update()
        {
            if (audioLoaded && !audioStarted)
            {
                resources.Audio.SetAmbience("event:/env/amb/worldmap");
                audioStarted = true;
            }

            if (!ready)
            {
                bool wasDisabled = EngineContext.InputDisabled;
                EngineContext.InputDisabled = false;
                if (input[GameAction.MenuConfirm].Pressed) skipped = true;
                EngineContext.InputDisabled = wasDisabled;
            }

            base.Update();
        }

        public void UpdateFirstTrackedDashAssist()
            => OriginalEngineDashAssistSceneBody.UpdateFirstTrackedDashAssist(SourceScene, EngineContext);

        public void CommitEntityLists() => OriginalEngineDashAssistSceneBody.CommitEntityLists(SourceScene);

        protected virtual void LoadThread()
        {
            EngineContext.InputDisabled = true;
            var timer = Stopwatch.StartNew();
            resources.Audio.InitializeSource(resources.FmodLiveUpdate);
            resources.Audio.Banks.Master = resources.Audio.Banks.Load(resources.ContentDirectory, "Master Bank", true);
            resources.Audio.Banks.Music = resources.Audio.Banks.Load(resources.ContentDirectory, "music", false);
            resources.Audio.Banks.Sfxs = resources.Audio.Banks.Load(resources.ContentDirectory, "sfx", false);
            resources.Audio.Banks.UI = resources.Audio.Banks.Load(resources.ContentDirectory, "ui", false);
            resources.Audio.Banks.DlcMusic = resources.Audio.Banks.Load(resources.ContentDirectory, "dlc_music", false);
            resources.Audio.Banks.DlcSfxs = resources.Audio.Banks.Load(resources.ContentDirectory, "dlc_sfx", false);
            resources.Audio.Runtime.ApplyVolumes(resources.MusicVolume, resources.SfxVolume);
            audioLoaded = true;
            Console.WriteLine(" - AUDIO LOAD: " + timer.ElapsedMilliseconds + "ms");
            resources.GraphicsResources.LoadGraphics(resources, resources.SpriteRandomContext, resources.ParticleTypes,
                resources, EngineContext);
            resources.MountainResources.Load(resources);
            resources.GraphicsResources.LoadGraphicsData(resources.LoadContentXml,
                resources.Random,
                EngineContext);
            resources.MountainResources.LoadData(
                (global::Celeste.Graphics.Rendering.Devices.ISourceGraphicsDeviceEnvironment)EngineContext);
            var fontsTimer = Stopwatch.StartNew();
            resources.Text.PrepareFonts();
            resources.SettingsLanguage = resources.Text.LoadDialog(resources.SettingsLanguage);
            resources.Text.LoadLanguageFont("english");
            resources.Text.LoadLanguageFont(resources.SettingsLanguage);
            dialogLoaded = true;
            Console.WriteLine(" - DIA/FONT LOAD: " + fontsTimer.ElapsedMilliseconds + "ms");
            EngineContext.InputDisabled = false;
            var areasTimer = Stopwatch.StartNew();
            resources.LoadAreas();
            Console.WriteLine(" - LEVELS LOAD: " + areasTimer.ElapsedMilliseconds + "ms");
            Console.WriteLine("DONE LOADING (in " + resources.ProcessTiming.LoadTimer.ElapsedMilliseconds + "ms)");
            resources.ProcessTiming.LoadTimer.Stop();
            resources.ProcessTiming.LoadTimer = null;
            loaded = true;
        }

        private IEnumerator IntroRoutine()
        {
            if (!global::Celeste.Game.Execution.ProcessState.CelesteRuntimeState.DebugPlayMode)
            {
                // The original p = 0; p > 1 loop never executes.
                if (!skipped) yield return FadeInOut(new SpriteImage(opening["presentedby"]));
                if (!skipped) yield return FadeInOut(new SpriteImage(opening["gameby"]));
                if (!skipped)
                {
                    while (!dialogLoaded) yield return null;
                    var notice = new AutoSavingNoticeRenderer(resources);
                    Renderers.Add(notice);
                    for (float p = 0; p < 1; p += DeltaTime)
                    {
                        if (skipped) break;
                        yield return null;
                    }

                    notice.Display = false;
                    while (notice.StillVisible)
                    {
                        notice.ForceClose = skipped;
                        yield return null;
                    }

                    Renderers.Remove(notice);
                }
            }

            ready = true;
            if (!loaded)
            {
                loadingTextures = resources.OverworldAtlas.GetAtlasSubtextures("loading/");
                var image = new SpriteImage(loadingTextures[0]);
                image.CenterOrigin();
                image.Scale = Vector2.One * .5f;
                handler.Components.Add(image);
                while (!loaded || loadingAlpha > 0)
                {
                    loadingFrame += DeltaTime * 10;
                    loadingAlpha = global::Celeste.Core.Mathematics.ScalarMath.Approach(loadingAlpha, loaded ? 0 : 1,
                        DeltaTime * 4,
                        ((ISourceExtremaEnvironment)EngineContext).ExtremaArithmetic);
                    image.Texture = loadingTextures[(int)(loadingFrame % loadingTextures.Count)];
                    image.Color = PackedColor.White *
                                  ((ISourceEasingEnvironment)EngineContext).EasingArithmetic.CubeOut(loadingAlpha);
                    image.Position = new Vector2(1792,
                        1080 - 128 * ((ISourceEasingEnvironment)EngineContext).EasingArithmetic.CubeOut(loadingAlpha));
                    yield return null;
                }
            }

            opening.Dispose();
            resources.Threads.SetHostThreadPriority(activeThread, ThreadPriority.Normal);
            EngineContext.InputDisabled = false;
            EngineContext.Frame.Scenes.NextScene = CreateNextScene();
        }

        protected virtual SourceSceneState CreateNextScene() => resources.CreateTitlescreenLoader(Snow);

        private IEnumerator FadeInOut(SpriteImage image)
        {
            float alpha = 0;
            image.Color = PackedColor.Transparent;
            handler.Components.Add(image);
            for (float i = 0; i < 4.5f; i += DeltaTime)
            {
                if (skipped) break;
                alpha = ((ISourceEasingEnvironment)EngineContext).EasingArithmetic.CubeOut(
                    ((ISourceExtremaEnvironment)EngineContext).ExtremaArithmetic.Min(i, 1f));
                image.Color = PackedColor.White * alpha;
                yield return null;
            }

            while (alpha > 0)
            {
                alpha -= DeltaTime * (skipped ? 8 : 1);
                image.Color = PackedColor.White * alpha;
                yield return null;
            }
            // Original Images remain in handler.Components after becoming transparent.
        }
    }
}
