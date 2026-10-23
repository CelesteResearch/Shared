using System;
using System.Collections.Generic;

namespace Celeste.Game.Execution.Levels.Update
{
    public enum OriginalLevelUpdateBranch
    {
        EngineSkipped,
        ErrorEarlyReturn,
        UnpauseDelay,
        Overlay,
        Normal,
        Transition,
        Frozen,
        Paused,
        RetryCorpse,
        SkippingCutscene
    }
}
