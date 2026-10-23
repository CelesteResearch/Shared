using System;
using Celeste.Core.Scheduling;

namespace Celeste.Game.Execution.Levels.Cutscenes
{
    public sealed class OriginalLevelCutsceneState
    {
        public readonly OriginalLevelSceneRoot Level;
        public bool InCutscene;
        public bool SkippingCutscene;
        internal SimulationCoroutine SkipCoroutine;
        internal Action<OriginalLevelSceneRoot> OnCutsceneSkip;
        internal bool OnCutsceneSkipFadeIn;
        internal bool OnCutsceneSkipResetZoom;
        internal bool EndingChapterAfterCutscene;

        public OriginalLevelCutsceneState(OriginalLevelSceneRoot level)
        {
            Level = level ?? throw new ArgumentNullException(nameof(level));
        }
    }
}
