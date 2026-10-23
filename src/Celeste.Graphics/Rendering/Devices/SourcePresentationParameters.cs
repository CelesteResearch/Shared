using Celeste.Core.Display;
using Celeste.Core.Geometry;
using Celeste.Graphics.Rendering.Textures;
using System;

namespace Celeste.Graphics.Rendering.Devices
{
    [Serializable]
    public class SourcePresentationParameters
    {
        internal SourceNativePresentationParameters parameters;

        public SourceSurfaceFormat BackBufferFormat
        {
            get { return parameters.backBufferFormat; }
            set { parameters.backBufferFormat = value; }
        }

        public int BackBufferHeight
        {
            get { return parameters.backBufferHeight; }
            set { parameters.backBufferHeight = value; }
        }

        public int BackBufferWidth
        {
            get { return parameters.backBufferWidth; }
            set { parameters.backBufferWidth = value; }
        }

        public IntRect Bounds => new IntRect(0, 0, BackBufferWidth, BackBufferHeight);

        public IntPtr DeviceWindowHandle
        {
            get { return parameters.deviceWindowHandle; }
            set { parameters.deviceWindowHandle = value; }
        }

        public SourceDepthFormat DepthStencilFormat
        {
            get { return parameters.depthStencilFormat; }
            set { parameters.depthStencilFormat = value; }
        }

        public bool IsFullScreen
        {
            get { return parameters.isFullScreen == 1; }
            set { parameters.isFullScreen = (value ? ((byte)1) : ((byte)0)); }
        }

        public int MultiSampleCount
        {
            get { return parameters.multiSampleCount; }
            set { parameters.multiSampleCount = value; }
        }

        public SourcePresentInterval PresentationInterval
        {
            get { return parameters.presentationInterval; }
            set { parameters.presentationInterval = value; }
        }

        public SourceDisplayOrientation DisplayOrientation
        {
            get { return parameters.displayOrientation; }
            set { parameters.displayOrientation = value; }
        }

        public SourceRenderTargetUsage RenderTargetUsage
        {
            get { return parameters.renderTargetUsage; }
            set { parameters.renderTargetUsage = value; }
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
            return new SourcePresentationParameters
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
                RenderTargetUsage = RenderTargetUsage
            };
        }
    }
}
