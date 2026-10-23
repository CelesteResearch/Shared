using System.Collections;
using System.Diagnostics;

namespace Celeste.Everest.Runtime.Boot
{
    public interface IEverestBootProcessEnvironment
    {
        EverestBootProcess BootProcess { get; }
    }
}
