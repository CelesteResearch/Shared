using Celeste.Graphics.Direct3D11.Interop;
using Celeste.Graphics.Rendering.Devices;

namespace Celeste.Graphics.Direct3D11.Devices
{
    public sealed partial class Direct3D11GraphicsDeviceIO
    {
        public void ResetBackbuffer(ref SourceNativePresentationParameters parameters)
        {
            var owned = BorrowWriteScope();
            try
            {
                Direct3D11GraphicsBindings.RequireSuccess(
                    Direct3D11GraphicsBindings.SourceGpuResetBackbuffer(device,
                        unchecked((uint)parameters.backBufferWidth), unchecked((uint)parameters.backBufferHeight),
                        D3D11Conversions.SurfaceFormat(parameters.backBufferFormat),
                        D3D11Conversions.TextureBytesPerBlock[(int)parameters.backBufferFormat],
                        unchecked((uint)parameters.multiSampleCount),
                        D3D11Conversions.DepthSurfaceFormat(parameters.depthStencilFormat),
                        (int)parameters.depthStencilFormat, (int)parameters.backBufferFormat));
                submission.SetPresentationSyncInterval(
                    Direct3D11GraphicsBindings.SourceGpuSetPresentationInterval(device,
                        (int)parameters.presentationInterval));
            }
            finally
            {
                CompleteWriteScope(owned);
            }
        }
    }
}
