using System;
using System.Runtime.InteropServices;
using Celeste.Graphics.Rendering.Devices.Native.Interop;

namespace Celeste.Graphics.Vulkan.Interop
{
    public static unsafe class VulkanNative
    {
        private const string Library = "CelesteGraphicsVulkan";
        public const uint AbiVersion = NativeGraphicsDeviceApi.AbiVersion;

        public static void RequireSuccess(int result)
        {
            if (result != 1)
                throw new InvalidOperationException(Marshal.PtrToStringUTF8(CelesteVulkanGetLastError()) ??
                                                    "Vulkan operation failed.");
        }

        public static CelesteGraphicsDeviceApi* GetDeviceApi()
        {
            var api = CelesteVulkanGetDeviceApi();
            if (api == null)
                throw new InvalidOperationException(Marshal.PtrToStringUTF8(CelesteVulkanGetLastError()) ??
                                                    "Vulkan device API is unavailable.");
            NativeGraphicsDeviceApi.RequireComplete(api);
            return api;
        }

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern CelesteGraphicsDeviceApi* CelesteVulkanGetDeviceApi();

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr CelesteVulkanGetLastError();

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int CelesteVulkanReleaseDevice(IntPtr device);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int CelesteVulkanCreateOwnedDevice(CelesteVulkanOwnedDeviceInfo* info, out IntPtr device);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int CelesteVulkanCreateBorrowedDevice(CelesteVulkanBorrowedDeviceInfo* info,
            out IntPtr device);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int
            CelesteVulkanGetNativeDevice(IntPtr device, out CelesteVulkanNativeDevice nativeDevice);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int CelesteVulkanAcquireOutput(IntPtr device, CelesteVulkanOutputInfo* info,
            out IntPtr output);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int CelesteVulkanRetainPacket(IntPtr packet);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int CelesteVulkanRecordHostPacket(IntPtr packet, CelesteVulkanHostRecording* recording);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void CelesteVulkanRetireHostSubmissions(IntPtr device, ulong completedSerial);
    }
}
