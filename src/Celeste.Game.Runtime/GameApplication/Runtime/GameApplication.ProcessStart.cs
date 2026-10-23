namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : Celeste.Everest.Runtime.Processes.IEverestProcessStartEnvironment
    {
        public Celeste.Everest.Runtime.Processes.IEverestProcessStartIo ProcessStart => PhysicalIO.ProcessStart;
    }
}
