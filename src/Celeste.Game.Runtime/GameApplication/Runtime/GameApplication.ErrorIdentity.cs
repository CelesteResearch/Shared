using Celeste.Game.Execution.Diagnostics;
using Celeste.Game.Execution.Engine;
using global::Celeste.Game.Execution;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : IOriginalErrorLogEnvironment
    {
        ISourceErrorLogEngine IOriginalErrorLogEnvironment.Engine => EngineRuntime.Instance;
    }
}
