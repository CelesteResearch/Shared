using Celeste.Graphics.Rendering.Textures;
using Celeste.Core.Rendering;
using Celeste.Graphics.Rendering.Effects;
using System.Numerics;
using Celeste.Core.Rendering.States;

namespace Celeste.Graphics.Rendering.Batches
{
    public partial class SourceSpriteBatch
    {
        public void Begin()
            => Begin(SourceSpriteSortMode.Deferred, SourceBlendState.AlphaBlend,
                SourceSamplerState.LinearClamp, SourceDepthStencilState.None,
                SourceRasterizerState.CullCounterClockwise, null, Matrix4x4.Identity);

        public void Begin(SourceSpriteSortMode sortMode, SourceBlendState blendState)
            => Begin(sortMode, blendState, SourceSamplerState.LinearClamp,
                SourceDepthStencilState.None, SourceRasterizerState.CullCounterClockwise,
                null, Matrix4x4.Identity);

        public void Begin(SourceSpriteSortMode sortMode, SourceBlendState blendState,
            SourceSamplerState samplerState, SourceDepthStencilState depthStencilState,
            SourceRasterizerState rasterizerState)
            => Begin(sortMode, blendState, samplerState, depthStencilState, rasterizerState,
                null, Matrix4x4.Identity);

        public void Begin(SourceSpriteSortMode sortMode, SourceBlendState blendState,
            SourceSamplerState samplerState, SourceDepthStencilState depthStencilState,
            SourceRasterizerState rasterizerState, object effect)
            => Begin(sortMode, blendState, samplerState, depthStencilState, rasterizerState,
                effect, Matrix4x4.Identity);

        public void Begin(SourceSpriteSortMode sortMode, SourceBlendState blendState,
            SourceSamplerState samplerState, SourceDepthStencilState depthStencilState,
            SourceRasterizerState rasterizerState, object effect, Matrix4x4 transformMatrix)
        {
            var nextState = new SourceRenderBatchState(sortMode, blendState, samplerState,
                depthStencilState, rasterizerState, effect, transformMatrix);
            Begin(in nextState);
        }
    }
}
