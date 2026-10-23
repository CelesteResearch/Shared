using System;
using System.Runtime.InteropServices;

namespace Celeste.Graphics.Direct3D12.Interop
{
    [StructLayout(LayoutKind.Sequential)]
    public struct CelesteDirect3D12HostResourceState
    {
        public IntPtr resource;
        public uint expectedState, currentState;
    }
}
