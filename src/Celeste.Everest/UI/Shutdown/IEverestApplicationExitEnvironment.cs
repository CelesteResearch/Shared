using Celeste.Core.Framework.Timing;

namespace Celeste.Everest.UI.Shutdown
{
    public interface IEverestApplicationExitEnvironment
    {
        SourceGameLoopState ApplicationLoop { get; }
    }
}
