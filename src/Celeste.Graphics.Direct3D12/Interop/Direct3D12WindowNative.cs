using System;
using System.Runtime.InteropServices;

namespace Celeste.Graphics.Direct3D12.Interop
{
    internal static unsafe class Direct3D12WindowNative
    {
        private const string Library = "CelesteGraphicsDirect3D12";

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        internal static extern int CelesteDirect3D12CreateWindow(CelesteDirect3D12WindowInfo* info,
            out IntPtr window, out IntPtr device);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        internal static extern int CelesteDirect3D12DestroyWindow(IntPtr window);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        internal static extern int CelesteDirect3D12ResizeWindow(IntPtr window, uint width, uint height, uint interval);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        internal static extern int CelesteDirect3D12AcquireWindowOutput(IntPtr window, out IntPtr output);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        internal static extern int CelesteDirect3D12SubmitWindowPacket(IntPtr window, IntPtr packet, uint wait);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        internal static extern int CelesteDirect3D12PresentWindow(IntPtr window, uint enabled, out uint presented);
    }
}
