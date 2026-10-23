using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Celeste.Core.Diagnostics
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void SourceFnaLogFunction(IntPtr message);
}
