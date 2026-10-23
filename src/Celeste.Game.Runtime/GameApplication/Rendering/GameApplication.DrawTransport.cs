using Celeste.Game.Execution.Startup;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : IOriginalCelesteDrawTransportEnvironment
    {
        void IOriginalCelesteDrawTransportEnvironment.BeginAcceptedSourceDraw()
            => PhysicalIO.DrawTransport.BeginAcceptedSourceDraw();
    }
}
