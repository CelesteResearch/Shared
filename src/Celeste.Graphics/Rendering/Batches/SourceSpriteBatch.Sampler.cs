using Celeste.Core.Rendering.States;

namespace Celeste.Graphics.Rendering.Batches
{
    public partial class SourceSpriteBatch
    {
        public SourceSamplerState CurrentSamplerState => state.Sampler;
    }
}
