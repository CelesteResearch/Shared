using System.Collections.Generic;
using System.Threading.Tasks;
using Celeste.Core.Scheduling;
using Celeste.Everest.Modules.Dependencies;
using Celeste.Everest.Modules.Runtime;

namespace Celeste.Everest.Modules.Updating
{
    public interface IEverestModUpdaterEnvironment
    {
        EverestModUpdaterProcess ModUpdater { get; }
    }
}
