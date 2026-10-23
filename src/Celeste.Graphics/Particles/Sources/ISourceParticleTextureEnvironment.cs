namespace Celeste.Graphics.Particles.Sources
{
    public interface ISourceParticleTextureEnvironment : global::Celeste.Core.Mathematics.ISourceScalarEnvironment,
        global::Celeste.Core.Mathematics.ISourceVectorEnvironment,
        global::Celeste.Core.Mathematics.Easing.ISourceEasingEnvironment,
        global::Celeste.Core.Mathematics.Extrema.ISourceExtremaEnvironment,
        global::Celeste.Core.Components.ISourceEntitySourceDataEnvironment
    {
        global::Celeste.Graphics.Content.Atlas.AtlasEntry DefaultParticleSource { get; }
    }
}
