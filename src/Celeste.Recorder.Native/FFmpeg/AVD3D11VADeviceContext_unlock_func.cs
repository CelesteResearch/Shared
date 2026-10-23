using System;
using System.Runtime.InteropServices;

namespace FFmpeg
{
    public struct AVD3D11VADeviceContext_unlock_func
    {
        public nint Pointer;

        public static implicit operator AVD3D11VADeviceContext_unlock_func(AVD3D11VADeviceContext_unlock func)
        {
            return new AVD3D11VADeviceContext_unlock_func
            {
                Pointer = ((func == null) ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func))
            };
        }
    }
}
