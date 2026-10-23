using System.Numerics;
using Celeste.Core.Rendering.States;

namespace Celeste.Core.Rendering
{
    public readonly struct SourceRenderBatchState(
        SourceSpriteSortMode sortMode,
        SourceBlendState blend,
        SourceSamplerState sampler,
        SourceDepthStencilState depthStencil,
        SourceRasterizerState rasterizer,
        object effect,
        Matrix4x4 transform)
    {
        public readonly SourceSpriteSortMode SortMode = sortMode;
        public readonly SourceBlendState Blend = blend;
        public readonly SourceSamplerState Sampler = sampler;
        public readonly SourceDepthStencilState DepthStencil = depthStencil;
        public readonly SourceRasterizerState Rasterizer = rasterizer;
        public readonly object Effect = effect;
        public readonly Matrix4x4 Transform = transform;
    }
}
