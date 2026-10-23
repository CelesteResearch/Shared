using System;
using System.Runtime.InteropServices;

namespace Celeste.Graphics.Direct3D12.Interop;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct CelesteDirect3D12OutputInfo
{
    public IntPtr resource;
    public uint subresource, width, height, format, incomingState, outgoingState;
}
