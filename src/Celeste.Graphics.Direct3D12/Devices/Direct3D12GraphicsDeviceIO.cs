using System;
using Celeste.Graphics.Content.Images;
using Celeste.Graphics.Direct3D12.Interop;
using Celeste.Graphics.Rendering.Devices.Native;
using Celeste.Graphics.Rendering.Devices.Native.Submission;

namespace Celeste.Graphics.Direct3D12.Devices
{
    public sealed unsafe class Direct3D12GraphicsDeviceIO : NativeGraphicsDeviceIO
    {
        // ReSharper disable once ConvertToPrimaryConstructor
        public Direct3D12GraphicsDeviceIO(SourceImageStreamProcess imageStreams, INativeGraphicsSubmission submission,
            IntPtr hostWindow) : base(imageStreams, submission, hostWindow, Direct3D12Native.GetDeviceApi(), "hlsl")
        {
        }
    }
}
