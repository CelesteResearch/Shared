using Celeste.Graphics.Direct3D11.Interop.Descriptors;
using Celeste.Graphics.Direct3D11.Interop;
using Celeste.Graphics.Direct3D11.Submission;
using Celeste.Core.Display;
using Celeste.Core.Rendering.States;
using Celeste.Graphics.Display;
using Celeste.Graphics.Rendering.Devices;
using Celeste.Graphics.Rendering.Textures;

namespace Celeste.Graphics.Direct3D11.Devices
{
    public sealed unsafe partial class Direct3D11GraphicsDeviceIO : ISourceGraphicsDeviceStateIO
    {
        public void GetBlendFactor(out PackedColor color)
            => color = new PackedColor { PackedValue = Direct3D11GraphicsBindings.SourceGpuGetBlendFactor(device) };

        public void SetBlendFactor(ref PackedColor color)
        {
            uint owned = BorrowWriteScope();
            try
            {
                Direct3D11GraphicsBindings.RequireSuccess(
                    Direct3D11GraphicsBindings.SourceGpuRecordBlendFactor(device, color.PackedValue));
            }
            finally
            {
                CompleteWriteScope(owned);
            }
        }

        public int GetMultiSampleMask() => Direct3D11GraphicsBindings.SourceGpuGetSampleMask(device);

        public void SetMultiSampleMask(int mask)
        {
            uint owned = BorrowWriteScope();
            try
            {
                Direct3D11GraphicsBindings.RequireSuccess(
                    Direct3D11GraphicsBindings.SourceGpuRecordSampleMask(device, mask));
            }
            finally
            {
                CompleteWriteScope(owned);
            }
        }

        public int GetReferenceStencil() => Direct3D11GraphicsBindings.SourceGpuGetStencilReference(device);

        public void SetReferenceStencil(int reference)
        {
            uint owned = BorrowWriteScope();
            try
            {
                Direct3D11GraphicsBindings.RequireSuccess(
                    Direct3D11GraphicsBindings.SourceGpuRecordStencilReference(device, reference));
            }
            finally
            {
                CompleteWriteScope(owned);
            }
        }

        public void SetBlendState(ref SourceNativeBlendState state)
        {
            D3D11BlendDesc description = D3D11Conversions.Blend(ref state);
            uint owned = BorrowWriteScope();
            try
            {
                Direct3D11GraphicsBindings.RequireSuccess(
                    Direct3D11GraphicsBindings.SourceGpuRecordSourceBlend(device, ref description,
                        state.blendFactor, state.multiSampleMask));
            }
            finally
            {
                CompleteWriteScope(owned);
            }
        }

        public void SetDepthStencilState(ref SourceNativeDepthStencilState state)
        {
            D3D11DepthStencilDesc description = D3D11Conversions.DepthStencil(ref state);
            uint owned = BorrowWriteScope();
            try
            {
                Direct3D11GraphicsBindings.RequireSuccess(
                    Direct3D11GraphicsBindings.SourceGpuRecordSourceDepthStencil(device, ref description,
                        state.referenceStencil));
            }
            finally
            {
                CompleteWriteScope(owned);
            }
        }

        public void ApplyRasterizerState(ref SourceNativeRasterizerState state)
        {
            SourceDepthFormat format =
                (SourceDepthFormat)Direct3D11GraphicsBindings.SourceGpuGetCurrentDepthFormat(device);
            D3D11RasterizerDesc description = D3D11Conversions.Rasterizer(ref state, format);
            uint owned = BorrowWriteScope();
            try
            {
                Direct3D11GraphicsBindings.RequireSuccess(
                    Direct3D11GraphicsBindings.SourceGpuRecordRasterizer(device, ref description));
            }
            finally
            {
                CompleteWriteScope(owned);
            }
        }

        public void VerifySampler(int index, System.IntPtr texture, ref SourceNativeSamplerState state)
        {
            D3D11SamplerDesc description = D3D11Conversions.Sampler(ref state);
            uint owned = BorrowWriteScope();
            try
            {
                Direct3D11GraphicsBindings.RequireSuccess(
                    Direct3D11GraphicsBindings.SourceGpuRecordSourceSampler(device, unchecked((uint)index),
                        texture, ref description, 0));
            }
            finally
            {
                CompleteWriteScope(owned);
            }
        }

        public void VerifyVertexSampler(int index, System.IntPtr texture, ref SourceNativeSamplerState state)
        {
            D3D11SamplerDesc description = D3D11Conversions.Sampler(ref state);
            uint owned = BorrowWriteScope();
            try
            {
                Direct3D11GraphicsBindings.RequireSuccess(
                    Direct3D11GraphicsBindings.SourceGpuRecordSourceSampler(device, unchecked((uint)index),
                        texture, ref description, 1));
            }
            finally
            {
                CompleteWriteScope(owned);
            }
        }
    }
}
