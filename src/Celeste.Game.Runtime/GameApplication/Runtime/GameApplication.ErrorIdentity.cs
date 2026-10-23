using Celeste.Game.Execution;
using Celeste.Game.Execution.Diagnostics;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : IOriginalErrorLogEnvironment
    {
        ISourceErrorLogEngine IOriginalErrorLogEnvironment.Engine => EngineRuntime.Instance;
    }
}
