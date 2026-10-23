using Celeste.Everest.Runtime.Processes;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : IEverestProcessStartEnvironment
    {
        public IEverestProcessStartIo ProcessStart => PhysicalIO.ProcessStart;
    }
}
