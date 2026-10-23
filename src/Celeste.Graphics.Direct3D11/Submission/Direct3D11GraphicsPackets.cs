using System;
using System.Runtime.InteropServices;
using Celeste.Graphics.Direct3D11.Interop;

namespace Celeste.Graphics.Direct3D11.Submission
{
    /// <summary>Native packet lifetime and completion operations needed by host submissions.</summary>
    public static class Direct3D11GraphicsPackets
    {
        public static void Execute(IntPtr device, IntPtr packet)
        {
            Direct3D11GraphicsBindings.RequireSuccess(
                Direct3D11GraphicsBindings.SourceGpuExecutePhysicalPacket(device, packet));
        }

        public static void Retain(IntPtr packet)
        {
            Direct3D11GraphicsBindings.SourceGpuRetainPacket(packet);
        }

        public static void Release(IntPtr packet)
        {
            Direct3D11GraphicsBindings.SourceGpuReleasePacket(packet);
        }

        public static int GetCompletion(IntPtr packet)
        {
            return Direct3D11GraphicsBindings.SourceGpuPacketCompletion(packet);
        }

        public static string LastError => Marshal.PtrToStringUTF8(Direct3D11GraphicsBindings.SourceGpuGetLastError());
    }
}
