using System;
using Celeste.Core.Framework.Timing;
using Celeste.Everest.Framework.Startup;
using Celeste.Everest.Platform.Statistics;
using Celeste.Everest.UI.Shutdown;
using Celeste.Framework.Startup;
using Celeste.Game.Platform.Statistics;
using Celeste.Game.Profiles;
using Celeste.Game.Runtime.Platform;
using Celeste.Graphics.Rendering.Devices;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : IOriginalPlatformStatisticsEnvironment,
        IEverestApplicationExitEnvironment
    {
        SourceGameLoopState
            IEverestApplicationExitEnvironment.ApplicationLoop =>
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
            sourceStatistics = new(PhysicalIO.StatisticsOutput, this,
                SourceProfile == GameProfile.Original
                    ? OriginalPlatformAchievementFactory.Shared
                    : new EverestPlatformAchievementFactory(this));
            sourceWindowPlatform = new(PhysicalIO.Window, FnaInput);
            sourceBeforeLoopPolicy = SourceProfile == GameProfile.Original
                ? new OriginalSourceGameBeforeLoopPolicy()
                : new EverestSourceGameBeforeLoopPolicy(PhysicalIO.WindowFocus);
            sourceRunPlatform =
                new HostRunPlatform(GraphicsAdapters, PhysicalIO.HostRuntime);
            PublishSourceActualGame(new(this, this, PhysicalIO.CommandLine,
                Content, sourceWindowPlatform, FnaInput, TextBindings, FrameworkDispatcher,
                PhysicalIO.RuntimeErrors, GraphicsAdapters, GraphicsIO, FnaInput, Statistics,
                PhysicalIO.Clock, PhysicalIO.TimerStart, sourceRunPlatform, sourceBeforeLoopPolicy));
            ActualGame.Disposed += DisposeSourceFrameworkAudio;
            if (sourceContentRegistry != null) ActualGame.Disposed += DisposeSourceContentRegistry;
        }
    }
}
