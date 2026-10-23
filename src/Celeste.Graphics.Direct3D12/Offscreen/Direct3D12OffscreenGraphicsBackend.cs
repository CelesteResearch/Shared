using System;
using System.Runtime.InteropServices;
using Celeste.Graphics.Direct3D12.Interop;
using Celeste.Graphics.Rendering.Offscreen;
using Celeste.Graphics.Threading;

namespace Celeste.Graphics.Direct3D12.Offscreen
{
    public sealed unsafe class Direct3D12OffscreenGraphicsBackend : NativeOffscreenGraphicsBackend
    {
        // ReSharper disable once ConvertToPrimaryConstructor
        public Direct3D12OffscreenGraphicsBackend(GraphicsOwnerDispatcher dispatcher,
            IOffscreenGraphicsPresentation presentation)
            : base(Direct3D12Native.GetDeviceApi(), "hlsl", dispatcher, presentation)
        {
        }

        protected override IntPtr CreateOwnedDevice()
        {
            var info = new CelesteDirect3D12OwnedDeviceInfo();
            Direct3D12Native.RequireSuccess(Direct3D12Native.CelesteDirect3D12CreateOwnedDevice(&info, out var device));
            return device;
        }

        protected override IntPtr AcquireTextureOutput(IntPtr actualDevice, IntPtr outputTexture)
        {
            Direct3D12Native.RequireSuccess(
                CelesteDirect3D12AcquireTextureOutput(actualDevice, outputTexture, out var output));
            return output;
        }

        [DllImport("CelesteGraphicsDirect3D12", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        private static extern int CelesteDirect3D12AcquireTextureOutput(IntPtr device, IntPtr texture,
            out IntPtr output);
    }
}
