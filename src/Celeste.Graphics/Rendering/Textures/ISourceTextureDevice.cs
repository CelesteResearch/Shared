using Celeste.Graphics.Rendering.Effects;

namespace Celeste.Graphics.Rendering.Textures
{
    public interface ISourceTextureDevice : ISourceEffectDevice
    {
        ISourceTextureIO TextureIO { get; }
    }
}
