using System;

namespace Celeste.Game.Execution.Levels
{
    public sealed partial class OriginalLevelSceneRoot
    {
        public bool SkippingCutscene => Cutscene.SkippingCutscene;

        internal global::Celeste.Game.Presentation.Hud.Strawberries.TotalStrawberriesDisplayState
            SourceStrawberriesDisplay => strawberriesDisplay;

        public void StartCutscene(Action<OriginalLevelSceneRoot> onSkip, bool fadeInOnSkip = true,
            bool endingChapterAfterCutscene = false, bool resetZoomOnSkip = true)
            => CutscenePolicy.StartCutscene(onSkip, fadeInOnSkip, endingChapterAfterCutscene, resetZoomOnSkip);

        public void CancelCutscene() => CutscenePolicy.CancelCutscene();
        public void SkipCutscene() => CutscenePolicy.SkipCutscene();
        public void EndCutscene() => CutscenePolicy.EndCutscene();
    }
}
