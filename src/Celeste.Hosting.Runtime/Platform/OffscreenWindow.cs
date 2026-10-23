using System;
using Celeste.Core.Geometry;
using Celeste.Graphics.Rendering.Devices;

namespace Celeste.Hosting.Runtime.Platform
{
    public sealed class OffscreenWindow : ISourceHostWindowIO
    {
        private readonly EmbeddedGameConfiguration _configuration;
        public IntPtr Handle => IntPtr.Zero;
        public IntRect Bounds => new(0, 0, _configuration.Width, _configuration.Height);
        public string DisplayName => "Embedded Celeste";
        public bool Resizable { get; set; }
        public bool Borderless { get; set; }
        public int RequestedWidth { get; private set; }
        public int RequestedHeight { get; private set; }
        public bool RequestedFullscreen { get; private set; }
        public string Title { get; private set; } = string.Empty;

        public OffscreenWindow(EmbeddedGameConfiguration configuration)
        {
            _configuration = configuration;
            RequestedWidth = configuration.Width;
            RequestedHeight = configuration.Height;
        }

        public void SetTitle(string title)
        {
            Title = title;
        }

        public void ApplyResolution(int width, int height, bool fullscreen, string displayName)
        {
            RequestedWidth = width;
            RequestedHeight = height;
            RequestedFullscreen = fullscreen;
            // Source presentation still applies its backbuffer request. This physical
            // endpoint is the enclosing host's fixed surface, not an independent window.
        }

        public void GetWindowSize(out int width, out int height)
        {
            width = _configuration.Width;
            height = _configuration.Height;
        }

        public void GetDrawableSize(out int width, out int height)
        {
            GetWindowSize(out width, out height);
        }

        public void LogWarning(string message)
        {
            _configuration.ReportError("Celeste window", message);
        }
    }
}
