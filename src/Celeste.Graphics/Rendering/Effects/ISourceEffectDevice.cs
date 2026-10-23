using System;
using Celeste.Core.Rendering.Resources;
using Celeste.Core.Rendering.States;

namespace Celeste.Graphics.Rendering.Effects
{
    public interface ISourceEffectDevice : ISourceGraphicsResourceDevice
    {
        IntPtr EffectStateChangesPointer { get; }
        SourcePipelineCache PipelineCache { get; }
        SourceTextureCollection Textures { get; }
        SourceTextureCollection VertexTextures { get; }
        SourceSamplerStateCollection SamplerStates { get; }
        SourceSamplerStateCollection VertexSamplerStates { get; }
        SourceBlendState BlendState { get; set; }
        SourceDepthStencilState DepthStencilState { get; set; }
        SourceRasterizerState RasterizerState { get; set; }

        void CreateEffect(byte[] effectCode, int effectCodeLength, out IntPtr effect, out IntPtr effectData);
        void CloneEffect(IntPtr originalEffect, out IntPtr effect, out IntPtr effectData);
        void SetEffectTechnique(IntPtr effect, IntPtr technique);
        void AddDisposeEffect(IntPtr effect);
        void ApplyEffect(IntPtr effect, uint pass, IntPtr stateChanges);
    }
}
