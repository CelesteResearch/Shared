using System;
using Celeste.Core.Display;
using Celeste.Core.Geometry;
using Celeste.Graphics.Rendering.Textures;

namespace Celeste.Graphics.Rendering.Devices
{
    [Serializable]
    public class SourcePresentationParameters
    {
        internal SourceNativePresentationParameters parameters;

        public SourceSurfaceFormat BackBufferFormat
        {
            get => parameters.backBufferFormat;
            set => parameters.backBufferFormat = value;
        }

        public int BackBufferHeight
        {
            get => parameters.backBufferHeight;
            set => parameters.backBufferHeight = value;
        }

        public int BackBufferWidth
        {
            get => parameters.backBufferWidth;
            set => parameters.backBufferWidth = value;
        }

        public IntRect Bounds => new(0, 0, BackBufferWidth, BackBufferHeight);

        public IntPtr DeviceWindowHandle
        {
            get => parameters.deviceWindowHandle;
            set => parameters.deviceWindowHandle = value;
        }

        public SourceDepthFormat DepthStencilFormat
        {
            get => parameters.depthStencilFormat;
            set => parameters.depthStencilFormat = value;
        }

        public bool IsFullScreen
        {
            get => parameters.isFullScreen == 1;
            set => parameters.isFullScreen = value ? (byte)1 : (byte)0;
        }

        public int MultiSampleCount
        {
            get => parameters.multiSampleCount;
            set => parameters.multiSampleCount = value;
        }

        public SourcePresentInterval PresentationInterval
        {
            get => parameters.presentationInterval;
            set => parameters.presentationInterval = value;
        }

        public SourceDisplayOrientation DisplayOrientation
        {
            get => parameters.displayOrientation;
            set => parameters.displayOrientation = value;
        }

        public SourceRenderTargetUsage RenderTargetUsage
        {
            get => parameters.renderTargetUsage;
            set => parameters.renderTargetUsage = value;
        }

        public SourcePresentationParameters()
        {
            BackBufferFormat = SourceSurfaceFormat.Color;
            BackBufferWidth = SourceGraphicsDeviceManager.DefaultBackBufferWidth;
            BackBufferHeight = SourceGraphicsDeviceManager.DefaultBackBufferHeight;
            DeviceWindowHandle = IntPtr.Zero;
            IsFullScreen = false;
            DepthStencilFormat = SourceDepthFormat.None;
            MultiSampleCount = 0;
            PresentationInterval = SourcePresentInterval.Default;
            DisplayOrientation = SourceDisplayOrientation.Default;
            RenderTargetUsage = SourceRenderTargetUsage.DiscardContents;
        }

        public SourcePresentationParameters Clone()
        {
            return new()
            {
                BackBufferFormat = BackBufferFormat,
                BackBufferHeight = BackBufferHeight,
                BackBufferWidth = BackBufferWidth,
                DeviceWindowHandle = DeviceWindowHandle,
                IsFullScreen = IsFullScreen,
                DepthStencilFormat = DepthStencilFormat,
                MultiSampleCount = MultiSampleCount,
                PresentationInterval = PresentationInterval,
                DisplayOrientation = DisplayOrientation,
                RenderTargetUsage = RenderTargetUsage,
            };
        }
    }
}
