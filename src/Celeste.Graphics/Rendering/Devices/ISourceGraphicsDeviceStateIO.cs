using System;
using Celeste.Core.Rendering.States;

namespace Celeste.Graphics.Rendering.Devices
{
    public interface ISourceGraphicsDeviceStateIO
    {
        void SetBlendState(ref SourceNativeBlendState state);
        void SetDepthStencilState(ref SourceNativeDepthStencilState state);
        void ApplyRasterizerState(ref SourceNativeRasterizerState state);
        void VerifySampler(int index, IntPtr texture, ref SourceNativeSamplerState state);
        void VerifyVertexSampler(int index, IntPtr texture, ref SourceNativeSamplerState state);
    }
}
