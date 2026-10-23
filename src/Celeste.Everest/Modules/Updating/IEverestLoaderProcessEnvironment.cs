using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Celeste.Everest.Modules.Updating
{
    public interface IEverestLoaderProcessEnvironment
    {
        EverestLoaderProcess Loader { get; }
    }
}
