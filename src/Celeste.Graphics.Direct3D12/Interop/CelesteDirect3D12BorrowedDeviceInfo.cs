using System;
using System.Runtime.InteropServices;

namespace Celeste.Graphics.Direct3D12.Interop;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct CelesteDirect3D12BorrowedDeviceInfo
{
    public IntPtr device;
}
