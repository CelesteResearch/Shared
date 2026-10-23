using Celeste.Graphics.Rendering.Textures;
using System;
using Celeste.Core.Rendering.States;
using Celeste.Graphics.Rendering.Effects;

namespace Celeste.Graphics.Rendering.Devices
{
    public partial class SourceGraphicsDevice
    {
        private SourceBlendState currentBlend;
        private SourceBlendState nextBlend;
        private SourceDepthStencilState currentDepthStencil;
        private SourceDepthStencilState nextDepthStencil;
        private readonly bool[] modifiedSamplers = new bool[16];
        private readonly bool[] modifiedVertexSamplers = new bool[4];
        private readonly ISourceGraphicsDeviceStateIO sourceIO;

        public SourceTextureCollection Textures { get; private set; }
        public SourceSamplerStateCollection SamplerStates { get; private set; }
        public SourceTextureCollection VertexTextures { get; private set; }
        public SourceSamplerStateCollection VertexSamplerStates { get; private set; }

        public SourceBlendState BlendState
        {
            get => nextBlend;
            set => nextBlend = value;
        }

        public SourceDepthStencilState DepthStencilState
        {
            get => nextDepthStencil;
            set => nextDepthStencil = value;
        }

        public SourceRasterizerState RasterizerState { get; set; }

        private void ApplyState()
        {
            if (currentBlend != nextBlend)
            {
                sourceIO.SetBlendState(ref nextBlend.NativeState);
                currentBlend = nextBlend;
            }

            if (currentDepthStencil != nextDepthStencil)
            {
                sourceIO.SetDepthStencilState(ref nextDepthStencil.NativeState);
                currentDepthStencil = nextDepthStencil;
            }

            sourceIO.ApplyRasterizerState(ref RasterizerState.NativeState);
            ApplySamplers();
        }

        private void ApplySamplers()
        {
            for (int i = 0; i < modifiedSamplers.Length; i++)
            {
                if (modifiedSamplers[i])
                {
                    modifiedSamplers[i] = false;
                    sourceIO.VerifySampler(i, Textures[i] != null ? Textures[i].texture : IntPtr.Zero,
                        ref SamplerStates[i].NativeState);
                }
            }

            for (int j = 0; j < modifiedVertexSamplers.Length; j++)
            {
                if (modifiedVertexSamplers[j])
                {
                    modifiedVertexSamplers[j] = false;
                    sourceIO.VerifyVertexSampler(j, VertexTextures[j] != null ? VertexTextures[j].texture : IntPtr.Zero,
                        ref VertexSamplerStates[j].NativeState);
                }
            }
        }
    }
}
