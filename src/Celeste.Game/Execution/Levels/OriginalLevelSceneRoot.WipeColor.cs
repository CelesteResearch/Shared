using Celeste.Core.Display;
using Celeste.Simulation.Presentation.Scene.Transitions;

namespace Celeste.Game.Execution.Levels
{
    public sealed partial class OriginalLevelSceneRoot
    {
        public PackedColor WipeColor
        {
            get => ((ISourceScreenWipeEnvironment)EngineContext).ProcessWipe.WipeColor;
            set => ((ISourceScreenWipeEnvironment)EngineContext).ProcessWipe.WipeColor = value;
        }
    }
}
