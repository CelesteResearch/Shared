using System;
using Celeste.Core.Components.Timing;
using Celeste.Core.Components.Animation;
using Celeste.Core.Mathematics.Extrema;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication
    {
        private SourceAlarmPool sourceAlarmPool;
        private SourceTweenPool sourceTweenPool;

        public SourceAlarmPool AlarmPool => sourceAlarmPool ??
                                            throw new InvalidOperationException(
                                                "The source Alarm pool is not constructed.");

        public SourceTweenPool TweenPool => sourceTweenPool ??
                                            throw new InvalidOperationException(
                                                "The source Tween pool is not constructed.");

        public void ConstructSourceComponentPools()
        {
            if (sourceAlarmPool != null || sourceTweenPool != null)
                throw new InvalidOperationException("The source component pools are already constructed.");
            sourceAlarmPool = new SourceAlarmPool(engine);
            sourceTweenPool = new SourceTweenPool(engine, () => engine.Frame.FrameCounter,
                ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
        }
    }
}
