using System;
using Celeste.Core.Framework.Startup;
using Celeste.Core.Framework.Timing;
using Celeste.Core.Scheduling;
using Celeste.Framework.Startup;
using Celeste.Game.Platform.Statistics;
using Celeste.Game.Settings;
using Celeste.Graphics.Content.Compiled;
using Celeste.Graphics.Rendering.Devices;
using Celeste.Input.Bindings;
using Celeste.Input.Runtime;

namespace Celeste.Game.Execution
{
    public partial class GameRuntime : EngineRuntime
    {
        public enum PlayModes
        {
            Normal,
            Debug,
            Event,
            Demo,
        }

        public const int GameWidth = 320;
        public const int GameHeight = 180;
        public const int TargetWidth = 1920;
        public const int TargetHeight = 1080;
        public static PlayModes PlayMode = PlayModes.Normal;
        public new static GameRuntime Instance;

        public GameRuntime(ISettingsContext settings,
            ISourceEngineContext process, ISourceCommandLineDevice commandLine,
            SourceContentProcessState contentProcess, ISourceGameWindowPlatform windows,
            SourceFnaInputProcess input, SourceFnaTextInputBindings textBindings,
            SourceFrameworkDispatcherProcess dispatcher, ISourceRuntimeErrorDevice runtimeErrors,
            SourceGraphicsAdapterProcess adapters, ISourceGraphicsDeviceIO graphicsIO,
            ISourceGraphicsDeviceInputMetrics deviceInput, OriginalPlatformStatisticsProcess statistics,
            ISourceGameTickDevice tickDevice, ISourceGameTimerStartDevice timer, ISourceGameRunPlatform runPlatform,
            ISourceGameBeforeLoopPolicy beforeLoopPolicy)
            : base(1920, 1080, 960, 540, "Celeste", settings.Settings.Fullscreen, settings.Settings.VSync,
                process, commandLine, contentProcess, windows, input, textBindings, dispatcher,
                runtimeErrors, adapters, graphicsIO, deviceInput, tickDevice, timer, runPlatform, beforeLoopPolicy)
        {
            Version = new(1, 4, 0, 0);
            Instance = this;
            ExitOnEscapeKeypress = false;
            Timing.IsFixedTimeStep = true;
            statistics.MakeRequest();
            statistics.MakeStadiaRequest();
            Console.WriteLine("CELESTE : " + Version);
        }
    }
}
