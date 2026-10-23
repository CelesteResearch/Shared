using System.Collections.Generic;

namespace Celeste.Everest.Modules.Runtime
{
    public interface ISourceEverestModulesEnvironment
    {
        List<SourceEverestModule> Modules { get; }
    }
}
