using System;
using Celeste.Core.Display;
using Celeste.Core.Rendering.States;
using Celeste.Graphics.Direct3D11.Interop;
using Celeste.Graphics.Rendering.Devices;
using Celeste.Graphics.Rendering.Textures;

namespace Celeste.Graphics.Direct3D11.Devices
{
    public sealed partial class Direct3D11GraphicsDeviceIO : ISourceGraphicsDeviceStateIO
    {
        public void GetBlendFactor(out PackedColor color)
        {
            color = new() { PackedValue = Direct3D11GraphicsBindings.SourceGpuGetBlendFactor(device) };
        }

        public void SetBlendFactor(ref PackedColor color)
        {
            var owned = BorrowWriteScope();
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

        public int GetMultiSampleMask()
        {
            return Direct3D11GraphicsBindings.SourceGpuGetSampleMask(device);
        }

        public void SetMultiSampleMask(int mask)
        {
            var owned = BorrowWriteScope();
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

        public int GetReferenceStencil()
        {
            return Direct3D11GraphicsBindings.SourceGpuGetStencilReference(device);
        }

        public void SetReferenceStencil(int reference)
        {
            var owned = BorrowWriteScope();
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
            var description = D3D11Conversions.Blend(ref state);
            var owned = BorrowWriteScope();
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
            var description = D3D11Conversions.DepthStencil(ref state);
            var owned = BorrowWriteScope();
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
            var format =
                (SourceDepthFormat)Direct3D11GraphicsBindings.SourceGpuGetCurrentDepthFormat(device);
            var description = D3D11Conversions.Rasterizer(ref state, format);
            var owned = BorrowWriteScope();
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

        public void VerifySampler(int index, IntPtr texture, ref SourceNativeSamplerState state)
        {
            var description = D3D11Conversions.Sampler(ref state);
            var owned = BorrowWriteScope();
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

        public void VerifyVertexSampler(int index, IntPtr texture, ref SourceNativeSamplerState state)
        {
            var description = D3D11Conversions.Sampler(ref state);
            var owned = BorrowWriteScope();
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
