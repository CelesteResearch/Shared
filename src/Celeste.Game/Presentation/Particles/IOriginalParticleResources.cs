using Celeste.Graphics.Content.Atlas;

namespace Celeste.Game.Presentation.Particles
{
    public interface IOriginalParticleResources
    {
        AtlasEntry GetGameParticleSource(string path);
    }
}
