using System;
using System.Runtime.InteropServices;

namespace Celeste.Graphics.Content.Images
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void SourceImageSkipCallback(IntPtr context, int amount);
}
