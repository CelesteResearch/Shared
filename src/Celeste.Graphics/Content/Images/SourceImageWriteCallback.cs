using System;
using System.Runtime.InteropServices;

namespace Celeste.Graphics.Content.Images
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void SourceImageWriteCallback(IntPtr context, IntPtr data, int size);
}
