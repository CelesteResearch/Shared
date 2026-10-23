using Celeste.Simulation.Gameplay.Player.Movement;
using Celeste.Simulation.Gameplay.Player.Runtime;

namespace Celeste.Simulation
{
    public sealed partial class RoomPlayerWorld : IPlayerSwimSurfaceCorrectionWorld
    {
        public bool CanCorrectSwimSurface =>
            ((ISourcePlayerRuntimeEnvironment)EngineContext).PlayerRuntimePolicy
            .AllowSwimSurfaceCorrection(sourceOwner);
    }
}
