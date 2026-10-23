using System;
using Celeste.Game.Execution.ProcessState;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : IOriginalGameProcessTimingEnvironment
    {
        private OriginalGameProcessTiming sourceProcessTiming;

        public OriginalGameProcessTiming ProcessTiming => sourceProcessTiming ??
                                                          throw new InvalidOperationException(
                                                              "The actual load timing process is not constructed.");

        public void ConstructSourceProcessTiming()
        {
            if (sourceProcessTiming != null)
                throw new InvalidOperationException("The actual load timing process is already constructed.");
            sourceProcessTiming = new OriginalGameProcessTiming();
        }
    }
}
