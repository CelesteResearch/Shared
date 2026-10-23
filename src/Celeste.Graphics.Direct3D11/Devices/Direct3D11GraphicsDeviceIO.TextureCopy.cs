using System;
using Celeste.Graphics.Direct3D11.Interop;

namespace Celeste.Graphics.Direct3D11.Devices
{
    public sealed partial class Direct3D11GraphicsDeviceIO
    {
        public void CopyTexture2D(IntPtr source, IntPtr destination)
        {
            var owned = BorrowWriteScope();
            try
            {
                Direct3D11GraphicsBindings.RequireSuccess(
                    Direct3D11GraphicsBindings.SourceGpuRecordTextureCopy(source, destination));
            }
            finally
            {
                CompleteWriteScope(owned);
            }
        }
    }
}
