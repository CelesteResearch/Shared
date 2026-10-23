using System;
using System.Runtime.InteropServices;

namespace FFmpeg
{
    public struct AVD3D11VADeviceContext_lock_func
    {
        public nint Pointer;

        public static implicit operator AVD3D11VADeviceContext_lock_func(AVD3D11VADeviceContext_lock func)
        {
            return new()
            {
                Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func),
            };
        }
    }
}
