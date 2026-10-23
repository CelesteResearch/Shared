using Celeste.Game.Save.Runtime;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : IOriginalSaveCheckpointEnvironment
    {
        IOriginalSaveCheckpointQueries IOriginalSaveCheckpointEnvironment.SaveCheckpoints
            => (IOriginalSaveCheckpointQueries)SaveCounters;
    }
}
