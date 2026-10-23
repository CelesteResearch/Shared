using System.Diagnostics;
using Celeste.Game.Audio.Mixing;
using Celeste.Core.Components;
using Celeste.Core.Scheduling;
using Celeste.Everest.Content.Textures;
using Celeste.Everest.Runtime;
using Celeste.Everest.Modules.Settings;
using Celeste.Everest.Runtime.Threading;
using Celeste.Input.Gameplay;
using Celeste.Game.Menus.Loading;
using Celeste.Game.Execution.ProcessState;
using Celeste.Scene.Scenes;
using Celeste.Framework.Diagnostics.Commands;

namespace Celeste.Everest.Runtime.Startup
{
// The installed wrapper owns the same inherited source fields and components.
// GetNextScene and selected construction are the remaining source cohort.
    public partial class EverestGameLoaderScene : GameLoaderScene
    {
        private SimulationCoroutine introRoutine;

        public EverestGameLoaderScene(ISourceEngineContext engine, ISourceGameInput input,
            IGameLoaderSourceResources resources) : base(engine, input, resources)
        {
        }

        public override void Begin()
        {
            base.Begin();
            using (var enumerator = handler.Components.GetEnumerator())
            {
                if (enumerator.MoveNext())
                    introRoutine = (SimulationCoroutine)enumerator.Current;
            }

            if ((((IEverestCurrentCoreSettingsEnvironment)EngineContext).CurrentCoreSettings.LaunchWithoutIntro
                 || ((IEverestHeadlessEnvironment)EngineContext).IsHeadless) && introRoutine != null)
                skipped = true;
            global::Celeste.Core.Scheduling.SourceRuntimeExtensions
                .Get<IEverestGameLoaderSourceHooksEnvironment>(EngineContext)?.SourceLoaderBeginCompleted?.Invoke(this);
        }

        public override void Update()
        {
            if (!ready)
            {
                bool disabled = EngineContext.InputDisabled;
                EngineContext.InputDisabled = false;
                if (input[GameAction.Pause].Pressed || input[GameAction.Escape].Pressed)
                {
                    if (input[GameAction.MenuDown].Check)
                    {
                        CelesteRuntimeState.PlayMode = CelestePlayMode.Debug;
                        ((ISourceCommandsProcessEnvironment)EngineContext).Commands.Enabled = true;
                    }

                    skipped = true;
                }

                EngineContext.InputDisabled = disabled;
            }

            base.Update();
        }

        protected override void LoadThread()
        {
            EngineContext.InputDisabled = true;
            ((ISourceEverestMainThreadEnvironment)EngineContext).MainThreadProcess.Boost = 25;
            var timer = Stopwatch.StartNew();
            resources.Audio.InitializeSource(resources.FmodLiveUpdate);
            resources.Audio.Banks.Master = resources.Audio.Banks.Load(resources.ContentDirectory, "Master Bank", true);
            resources.Audio.Banks.Music = resources.Audio.Banks.Load(resources.ContentDirectory, "music", false);
            resources.Audio.Banks.Sfxs = resources.Audio.Banks.Load(resources.ContentDirectory, "sfx", false);
            resources.Audio.Banks.UI = resources.Audio.Banks.Load(resources.ContentDirectory, "ui", false);
            resources.Audio.Banks.DlcMusic = resources.Audio.Banks.Load(resources.ContentDirectory, "dlc_music", false);
            resources.Audio.Banks.DlcSfxs = resources.Audio.Banks.Load(resources.ContentDirectory, "dlc_sfx", false);
            if (!((IEverestHeadlessEnvironment)EngineContext).IsHeadless)
                resources.Audio.Runtime.ApplyVolumes(resources.MusicVolume, resources.SfxVolume);
            audioLoaded = true;
            ((global::Celeste.Everest.Diagnostics.Logging.IEverestLoggerEnvironment)EngineContext).ConsoleWriter
                .WriteLine(" - AUDIO LOAD: " + timer.ElapsedMilliseconds + "ms");
            timer.Stop();
            resources.GraphicsResources.LoadGraphics(resources, resources.SpriteRandomContext,
                resources.ParticleTypes, resources, EngineContext);
            resources.MountainResources.Load(resources);
            resources.GraphicsResources.LoadGraphicsData(resources.LoadContentXml,
                ((global::Celeste.Core.Randomness.ISourceRandomProxyEnvironment)EngineContext).RandomProxy,
                EngineContext);
            resources.MountainResources.LoadData(
                (global::Celeste.Graphics.Rendering.Devices.ISourceGraphicsDeviceEnvironment)EngineContext);
            timer = Stopwatch.StartNew();
            resources.Text.PrepareFonts();
            resources.SettingsLanguage = resources.Text.LoadDialog(resources.SettingsLanguage);
            resources.Text.LoadLanguageFont("english");
            resources.Text.LoadLanguageFont(resources.SettingsLanguage);
            dialogLoaded = true;
            ((global::Celeste.Everest.Diagnostics.Logging.IEverestLoggerEnvironment)EngineContext).ConsoleWriter
                .WriteLine(" - DIA/FONT LOAD: " + timer.ElapsedMilliseconds + "ms");
            timer.Stop();
            EngineContext.InputDisabled = false;
            timer = Stopwatch.StartNew();
            resources.LoadAreas();
            ((global::Celeste.Everest.Diagnostics.Logging.IEverestLoggerEnvironment)EngineContext).ConsoleWriter
                .WriteLine(" - LEVELS LOAD: " + timer.ElapsedMilliseconds + "ms");
            timer.Stop();
            timer = Stopwatch.StartNew();
            var mainThread = ((ISourceEverestMainThreadEnvironment)EngineContext).MainThreadProcess;
            mainThread.Boost = 50;
            ((IEverestFastTextureLoadingEnvironment)EngineContext).FastLoading.WaitFinish(
                mainThread.IsMainThread ? mainThread.PumpPendingWork : null);
            ((ISourceEverestMainThreadEnvironment)EngineContext).MainThreadProcess.Schedule(() =>
                ((ISourceEverestMainThreadEnvironment)EngineContext).MainThreadProcess.Boost = 0).AsTask().Wait();
            ((global::Celeste.Everest.Diagnostics.Logging.IEverestLoggerEnvironment)EngineContext).ConsoleWriter
                .WriteLine(" - FASTTEXTURELOADING LOAD: " + timer.ElapsedMilliseconds + "ms");
            timer.Stop();
            ((IEverestGameLoaderEventsEnvironment)EngineContext).GameLoaderEvents.LoadThread();
            ((global::Celeste.Everest.Diagnostics.Logging.IEverestLoggerEnvironment)EngineContext).ConsoleWriter
                .WriteLine(
                    "DONE LOADING (in " + resources.ProcessTiming.LoadTimer.ElapsedMilliseconds + "ms)");
            resources.ProcessTiming.LoadTimer.Stop();
            resources.ProcessTiming.LoadTimer = null;
            loaded = true;
        }

        // Required next partial: the actual installed backup/update source algorithm.
        protected override SourceSceneState CreateNextScene() => GetNextScene(Snow);
    }
}
