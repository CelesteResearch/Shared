using System;
using System.Runtime.InteropServices;

namespace Celeste.Core.Diagnostics
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void SourceFnaLogFunction(IntPtr message);
}
