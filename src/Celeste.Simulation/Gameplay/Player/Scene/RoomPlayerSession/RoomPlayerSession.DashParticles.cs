using Celeste.Simulation.Gameplay.Player.Presentation.Sprites;
using Celeste.Simulation.Gameplay.Player.Scene.Particles;

// ReSharper disable once CheckNamespace
namespace Celeste.Simulation
{
    public sealed partial class RoomPlayerSession
    {
        internal void EmitNormalDashParticle()
        {
            var definitions = (ISourcePlayerDashParticleEnvironment)EngineContext;
            var type = !Data.WasDashB ? definitions.DashA
                : Sprite.Mode != PlayerSpriteMode.MadelineAsBadeline ? definitions.DashB : definitions.DashBadB;
            ((ISourcePlayerDashParticleScene)Level).EmitPlayerDashParticle(type, this);
        }
    }
}
