using System;
using System.Runtime.InteropServices;

namespace Celeste.Graphics.Direct3D12.Interop
{
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct CelesteDirect3D12HostRecording
    {
        public IntPtr commands;
        public CelesteDirect3D12HostResourceState* resourceStates;
        public uint resourceStateCount;
    }
}
