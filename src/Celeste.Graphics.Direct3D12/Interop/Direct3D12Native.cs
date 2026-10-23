using System;
using System.Runtime.InteropServices;
using Celeste.Graphics.Rendering.Devices.Native.Interop;

namespace Celeste.Graphics.Direct3D12.Interop
{
    public static unsafe class Direct3D12Native
    {
        private const string Library = "CelesteGraphicsDirect3D12";

        // ReSharper disable once UnusedMember.Global
        public const uint AbiVersion = NativeGraphicsDeviceApi.AbiVersion;

        public static void RequireSuccess(int result)
        {
            if (result != 1)
                throw new InvalidOperationException(Marshal.PtrToStringUTF8(CelesteDirect3D12GetLastError()) ??
                                                    "Direct3D12 operation failed.");
        }

        public static CelesteGraphicsDeviceApi* GetDeviceApi()
        {
            var api = CelesteDirect3D12GetDeviceApi();
            if (api == null)
                throw new InvalidOperationException(Marshal.PtrToStringUTF8(CelesteDirect3D12GetLastError()) ??
                                                    "Direct3D12 device API is unavailable.");
            NativeGraphicsDeviceApi.RequireComplete(api);
            return api;
        }

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        // ReSharper disable once MemberCanBePrivate.Global
        public static extern CelesteGraphicsDeviceApi* CelesteDirect3D12GetDeviceApi();

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        // ReSharper disable once MemberCanBePrivate.Global
        public static extern IntPtr CelesteDirect3D12GetLastError();

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int CelesteDirect3D12CreateOwnedDevice(CelesteDirect3D12OwnedDeviceInfo* info,
            out IntPtr device);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        // ReSharper disable once UnusedMember.Global
        public static extern int CelesteDirect3D12CreateBorrowedDevice(CelesteDirect3D12BorrowedDeviceInfo* info,
            out IntPtr device);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        // ReSharper disable once UnusedMember.Global
        public static extern int CelesteDirect3D12GetNativeDevice(IntPtr device, out IntPtr nativeDevice);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        // ReSharper disable once UnusedMember.Global
        public static extern int CelesteDirect3D12AcquireOutput(IntPtr device, CelesteDirect3D12OutputInfo* info,
            out IntPtr output);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        // ReSharper disable once UnusedMember.Global
        public static extern int CelesteDirect3D12PrepareHostPacket(IntPtr packet,
            out CelesteDirect3D12HostRecording recording);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        // ReSharper disable once UnusedMember.Global
        public static extern int CelesteDirect3D12CommitHostPacket(IntPtr packet, IntPtr fence, ulong value,
            out IntPtr submission);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        // ReSharper disable once UnusedMember.Global
        public static extern int CelesteDirect3D12CancelPreparedHostPacket(IntPtr packet);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        // ReSharper disable once UnusedMember.Global
        public static extern int CelesteDirect3D12RetainPacket(IntPtr packet);
    }
}
