using Celeste.Simulation.Gameplay.Player.Scene.Particles;
using Celeste.Simulation.Gameplay.Player.Presentation.Sprites;

namespace Celeste.Simulation
{
    public sealed partial class RoomPlayerSession
    {
        internal void EmitNormalDashParticle()
        {
            var definitions = (ISourcePlayerDashParticleEnvironment)engineContext;
            var type = !Data.WasDashB ? definitions.DashA
                : Sprite.Mode != PlayerSpriteMode.MadelineAsBadeline ? definitions.DashB : definitions.DashBadB;
            ((ISourcePlayerDashParticleScene)Level).EmitPlayerDashParticle(type, this);
        }
    }
}
