using System;
using Celeste.Core.Framework.Graphics;
using Celeste.Graphics.Rendering.Textures;

namespace Celeste.Graphics.Rendering.Devices
{
    public sealed class SourceGraphicsAdapter : ISourceScreenGraphicsAdapter
    {
        ISourceScreenDisplayMode ISourceScreenGraphicsAdapter.CurrentDisplayMode => CurrentDisplayMode;

        private readonly SourceGraphicsAdapterProcess process;

        public SourceDisplayMode CurrentDisplayMode => process.GetCurrentDisplayMode(process.Adapters.IndexOf(this));

        public SourceDisplayModeCollection SupportedDisplayModes { get; private set; }

        public string Description { get; private set; }

        public int DeviceId => throw new NotImplementedException();

        public string DeviceName { get; private set; }

        public bool IsDefaultAdapter => this == process.DefaultAdapter;

        public bool IsWideScreen => CurrentDisplayMode.AspectRatio > 1.3333334f;

        public IntPtr MonitorHandle => throw new NotImplementedException();

        public int Revision => throw new NotImplementedException();

        public int SubSystemId => throw new NotImplementedException();

        public bool UseNullDevice { get; set; }

        public bool UseReferenceDevice { get; set; }

        public int VendorId => throw new NotImplementedException();

        internal SourceGraphicsAdapter(SourceGraphicsAdapterProcess process, SourceDisplayModeCollection modes,
            string name,
            string description)
        {
            this.process = process;
            SupportedDisplayModes = modes;
            DeviceName = name;
            Description = description;
            UseNullDevice = false;
            UseReferenceDevice = false;
        }

        public bool IsProfileSupported(SourceGraphicsProfile graphicsProfile)
        {
            return true;
        }

        public bool QueryRenderTargetFormat(SourceGraphicsProfile graphicsProfile, SourceSurfaceFormat format,
            SourceDepthFormat depthFormat, int multiSampleCount, out SourceSurfaceFormat selectedFormat,
            out SourceDepthFormat selectedDepthFormat, out int selectedMultiSampleCount)
        {
            if (format != SourceSurfaceFormat.Color && format != SourceSurfaceFormat.Rgba1010102 &&
                format != SourceSurfaceFormat.Rg32 && format != SourceSurfaceFormat.Rgba64 &&
                format != SourceSurfaceFormat.Single && format != SourceSurfaceFormat.Vector2 &&
                format != SourceSurfaceFormat.Vector4 && format != SourceSurfaceFormat.HalfSingle &&
                format != SourceSurfaceFormat.HalfVector2 && format != SourceSurfaceFormat.HalfVector4 &&
                format != SourceSurfaceFormat.HdrBlendable)
                selectedFormat = SourceSurfaceFormat.Color;
            else
                selectedFormat = format;

            selectedDepthFormat = depthFormat;
            selectedMultiSampleCount = 0;
            if (format == selectedFormat && depthFormat == selectedDepthFormat)
                return multiSampleCount == selectedMultiSampleCount;

            return false;
        }

        public bool QueryBackBufferFormat(SourceGraphicsProfile graphicsProfile, SourceSurfaceFormat format,
            SourceDepthFormat depthFormat, int multiSampleCount, out SourceSurfaceFormat selectedFormat,
            out SourceDepthFormat selectedDepthFormat, out int selectedMultiSampleCount)
        {
            selectedFormat = SourceSurfaceFormat.Color;
            selectedDepthFormat = depthFormat;
            selectedMultiSampleCount = 0;
            if (format == selectedFormat && depthFormat == selectedDepthFormat)
                return multiSampleCount == selectedMultiSampleCount;

            return false;
        }
    }
}
