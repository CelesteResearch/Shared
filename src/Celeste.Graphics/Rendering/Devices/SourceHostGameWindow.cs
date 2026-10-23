using Celeste.Core.Display;
using System;
using Celeste.Core.Geometry;

namespace Celeste.Graphics.Rendering.Devices
{
    public sealed class SourceHostGameWindow : SourceGameWindow
    {
        private readonly ISourceHostWindowIO device;
        private string deviceName;
        private bool wantsFullscreen;

        public SourceHostGameWindow(ISourceHostWindowIO device)
        {
            this.device = device;
            deviceName = device.DisplayName;
            wantsFullscreen = false;
        }

        public override bool AllowUserResizing
        {
            get => device.Resizable;
            set => device.Resizable = value;
        }

        public override IntRect ClientBounds => device.Bounds;
        public override SourceDisplayOrientation CurrentOrientation { get; internal set; }
        public override IntPtr Handle => device.Handle;
        public override string ScreenDeviceName => deviceName;

        public override bool IsBorderlessEXT
        {
            get => device.Borderless;
            set => device.Borderless = value;
        }

        public override void BeginScreenDeviceChange(bool willBeFullScreen) => wantsFullscreen = willBeFullScreen;

        public override void EndScreenDeviceChange(string screenDeviceName, int clientWidth, int clientHeight)
        {
            string previous = deviceName;
            device.ApplyResolution(clientWidth, clientHeight, wantsFullscreen, screenDeviceName);
            deviceName = device.DisplayName;
            if (deviceName != previous) OnScreenDeviceNameChanged();
        }

        protected internal override void SetSupportedOrientations(SourceDisplayOrientation orientations)
            => device.LogWarning("Setting SupportedOrientations has no effect!");

        protected override void SetTitle(string title) => device.SetTitle(title);
        public void NotifyClientSizeChanged() => OnClientSizeChanged();
    }
}
