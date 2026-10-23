using Celeste.Everest.Modules.Runtime;
using Celeste.Game.Controls.Source;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : IEverestModuleLifecycleEnvironment
    {
        OriginalGameInputProcess IEverestModuleLifecycleEnvironment.ActualInput => InputSource;
    }
}
