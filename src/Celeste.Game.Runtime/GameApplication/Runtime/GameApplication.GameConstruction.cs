using System;
using Celeste.Core.Framework.Startup;
using Celeste.Game.Platform.Statistics;
using Celeste.Game.Profiles;
using Celeste.Game.Execution.Startup;
using Celeste.Framework.Startup;
using Celeste.Graphics.Rendering.Devices;
using Celeste.Everest.Framework.Startup;
using global::Celeste.Game.Execution;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : IOriginalPlatformStatisticsEnvironment,
        global::Celeste.Everest.UI.Shutdown.IEverestApplicationExitEnvironment
    {
        global::Celeste.Core.Framework.Timing.SourceGameLoopState
            global::Celeste.Everest.UI.Shutdown.IEverestApplicationExitEnvironment.ApplicationLoop =>
            ActualGame.GameLoop;

        private OriginalPlatformStatisticsProcess sourceStatistics;
        private SourceHostWindowPlatform sourceWindowPlatform;
        private ISourceGameBeforeLoopPolicy sourceBeforeLoopPolicy;
        private ISourceGameRunPlatform sourceRunPlatform;

        public OriginalPlatformStatisticsProcess Statistics => sourceStatistics ??
                                                               throw new InvalidOperationException(
                                                                   "The actual statistics process is not constructed.");

        public void ConstructSourceGame()
        {
            if (actualGame != null) throw new InvalidOperationException("The actual Game is already constructed.");
            sourceStatistics = new OriginalPlatformStatisticsProcess(PhysicalIO.StatisticsOutput, this,
                SourceProfile == GameProfile.Original
                    ? (IOriginalPlatformAchievementFactory)OriginalPlatformAchievementFactory.Shared
                    : new Celeste.Everest.Platform.Statistics.EverestPlatformAchievementFactory(this));
            sourceWindowPlatform = new SourceHostWindowPlatform(PhysicalIO.Window, FnaInput);
            sourceBeforeLoopPolicy = SourceProfile == GameProfile.Original
                ? new OriginalSourceGameBeforeLoopPolicy()
                : new EverestSourceGameBeforeLoopPolicy(PhysicalIO.WindowFocus);
            sourceRunPlatform =
                new global::Celeste.Game.Runtime.Platform.HostRunPlatform(GraphicsAdapters, PhysicalIO.HostRuntime);
            PublishSourceActualGame(new GameRuntime(this, this, PhysicalIO.CommandLine,
                Content, sourceWindowPlatform, FnaInput, TextBindings, FrameworkDispatcher,
                PhysicalIO.RuntimeErrors, GraphicsAdapters, GraphicsIO, FnaInput, Statistics,
                PhysicalIO.Clock, PhysicalIO.TimerStart, sourceRunPlatform, sourceBeforeLoopPolicy));
            ActualGame.Disposed += DisposeSourceFrameworkAudio;
            if (sourceContentRegistry != null) ActualGame.Disposed += DisposeSourceContentRegistry;
        }
    }
}
