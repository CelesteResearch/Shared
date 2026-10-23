using System;
using System.Runtime.InteropServices;

namespace Celeste.Graphics.Content.Images
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int SourceImageEofCallback(IntPtr context);
}
