using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Particles.Sources;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : ISourceParticleTextureEnvironment
    {
        AtlasEntry ISourceParticleTextureEnvironment.DefaultParticleSource => Draw.Particle;
    }
}
