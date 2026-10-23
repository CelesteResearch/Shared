using System.Collections.Generic;
using Celeste.Everest.Modules.Runtime;

namespace Celeste.Everest.Modules.Persistence.GameSaves
{
    public interface IEverestSaveModulesEnvironment
    {
        List<SourceEverestModule> SaveModules { get; }
    }
}
