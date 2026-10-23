using Celeste.Game.Profiles;
using Celeste.Simulation.Gameplay.Player.Presentation.Hair;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : IPlayerHairColorEnvironment
    {
        public bool UseHairSegmentColorGetter => SourceProfile == GameProfile.InstalledEverest;
    }
}
