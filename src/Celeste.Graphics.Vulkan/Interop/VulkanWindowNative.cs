using Celeste.Graphics.Rendering.Devices.Native.Interop;
using System;
using System.Runtime.InteropServices;

namespace Celeste.Graphics.Vulkan.Interop;

internal static unsafe class VulkanWindowNative
{
    private const string Library = "CelesteGraphicsVulkan";

    [DllImport(Library, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    internal static extern int CelesteVulkanCreateSurfaceWindow(CelesteVulkanSurfaceWindowInfo* info, out IntPtr window,
        out IntPtr device);

    [DllImport(Library, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    internal static extern int CelesteVulkanCreateWindow(CelesteVulkanWindowInfo* info, out IntPtr window,
        out IntPtr device);

    [DllImport(Library, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    internal static extern int CelesteVulkanResizeWindow(IntPtr window, uint width, uint height, uint synchronized);

    [DllImport(Library, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    internal static extern int CelesteVulkanAcquireWindowOutput(IntPtr window, out IntPtr output);

    [DllImport(Library, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    internal static extern int CelesteVulkanSubmitWindowPacket(IntPtr window, IntPtr packet, uint waitForCompletion);

    [DllImport(Library, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    internal static extern int CelesteVulkanPresentWindow(IntPtr window);

    [DllImport(Library, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    internal static extern int CelesteVulkanDestroyWindow(IntPtr window);
}
