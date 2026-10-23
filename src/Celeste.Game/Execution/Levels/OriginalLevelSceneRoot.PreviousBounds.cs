using Celeste.Core.Geometry;

namespace Celeste.Game.Execution.Levels
{
    public sealed partial class OriginalLevelSceneRoot
    {
        public IntRect? PreviousBounds { get; private set; }

        public void PublishSourcePreviousBounds(IntRect value) => PreviousBounds = value;
    }
}
