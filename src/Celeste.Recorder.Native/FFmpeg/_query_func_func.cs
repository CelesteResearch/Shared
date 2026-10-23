using System;
using System.Runtime.InteropServices;

namespace FFmpeg
{
    public struct _query_func_func
    {
        public nint Pointer;

        public static implicit operator _query_func_func(_query_func func)
        {
            return new _query_func_func
            {
                Pointer = ((func == null) ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func))
            };
        }
    }
}
