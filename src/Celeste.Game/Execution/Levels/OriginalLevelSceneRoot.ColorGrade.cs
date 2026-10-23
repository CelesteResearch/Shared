namespace Celeste.Game.Execution.Levels
{
    public sealed partial class OriginalLevelSceneRoot
    {
        public global::Celeste.Game.Presentation.PostProcessing.ColorGrading.OriginalLevelColorGradeState
            ColorGrade { get; }

        public void SnapColorGrade(string next) => ColorGrade.SnapColorGrade(next);
        public void NextColorGrade(string next, float speed = 1f) => ColorGrade.NextColorGrade(next, speed);
    }
}
