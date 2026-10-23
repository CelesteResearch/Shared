using System.Numerics;
using Celeste.Core.Rendering.States;

namespace Celeste.Core.Rendering
{
    public readonly struct SourceRenderBatchState
    {
        public readonly SourceSpriteSortMode SortMode;
        public readonly SourceBlendState Blend;
        public readonly SourceSamplerState Sampler;
        public readonly SourceDepthStencilState DepthStencil;
        public readonly SourceRasterizerState Rasterizer;
        public readonly object Effect;
        public readonly Matrix4x4 Transform;

        public SourceRenderBatchState(SourceSpriteSortMode sortMode, SourceBlendState blend,
            SourceSamplerState sampler, SourceDepthStencilState depthStencil,
            SourceRasterizerState rasterizer, object effect, Matrix4x4 transform)
        {
            SortMode = sortMode;
            Blend = blend;
            Sampler = sampler;
            DepthStencil = depthStencil;
            Rasterizer = rasterizer;
            Effect = effect;
            Transform = transform;
        }
    }
}
