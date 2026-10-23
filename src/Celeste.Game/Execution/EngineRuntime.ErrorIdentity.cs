using System;
using Celeste.Game.Execution.Diagnostics;
using Celeste.Game.Execution.Threading;
using global::Celeste.Game.Execution.Engine;
using global::Celeste.Game.Execution;

namespace Celeste.Game.Execution
{
    public partial class EngineRuntime : ISourceErrorLogEngine
    {
        string IOriginalGameErrorIdentity.Title => Title;
        Version IOriginalGameErrorIdentity.Version => Version;
    }
}
