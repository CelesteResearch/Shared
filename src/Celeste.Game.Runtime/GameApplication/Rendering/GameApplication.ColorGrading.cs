using Celeste.Game.Presentation.PostProcessing.ColorGrading;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : IOriginalColorGradeEnvironment
    {
        private readonly OriginalColorGradeProcess originalColorGradeProcess;
        OriginalColorGradeProcess IOriginalColorGradeEnvironment.ColorGradeProcess => originalColorGradeProcess;
    }
}
