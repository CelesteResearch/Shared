using System;
using Celeste.Core.Scheduling;
using Celeste.Game.Presentation.Hud.Speedrun;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : ISourceEngineTimingEnvironment, ISourceSpeedrunTimeMetricsEnvironment
    {
        public TimeSpan TargetElapsedTime => ActualGame.TargetElapsedTime;
        public SpeedrunTimeMetrics SpeedrunTimeMetrics { get; } = new();
    }
}
