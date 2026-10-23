using Celeste.Core.Components;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Graphics.Content.Atlas;

namespace Celeste.Graphics.Particles.Sources
{
    public interface ISourceParticleTextureEnvironment : ISourceScalarEnvironment,
        ISourceVectorEnvironment,
        ISourceEasingEnvironment,
        ISourceExtremaEnvironment,
        ISourceEntitySourceDataEnvironment
    {
        AtlasEntry DefaultParticleSource { get; }
    }
}
