using Celeste.Core.Display;
using System;
using System.ComponentModel;
using Celeste.Core.Geometry;

namespace Celeste.Graphics.Rendering.Devices
{
    public class SourceFNAWindow : SourceGameWindow
    {
        private IntPtr window;
        private readonly SourceSDLWindowPlatform platform;
        private readonly ISourceSDLWindowDevice device;

        private string deviceName;

        private bool wantsFullscreen;

        [DefaultValue(false)]
        public override bool AllowUserResizing
        {
            get { return platform.GetWindowResizable(window); }
            set { platform.SetWindowResizable(window, value); }
        }

        public override IntRect ClientBounds => platform.GetWindowBounds(window);

        public override SourceDisplayOrientation CurrentOrientation { get; internal set; }

        public override IntPtr Handle => window;

        public override bool IsBorderlessEXT
        {
            get { return platform.GetWindowBorderless(window); }
            set { platform.SetWindowBorderless(window, value); }
        }

        public override string ScreenDeviceName => deviceName;

        public SourceFNAWindow(IntPtr nativeWindow, string display, SourceSDLWindowPlatform platform,
            ISourceSDLWindowDevice device)
        {
            this.platform = platform;
            this.device = device;
            window = nativeWindow;
            deviceName = display;
            wantsFullscreen = false;
        }

        public override void BeginScreenDeviceChange(bool willBeFullScreen)
        {
            wantsFullscreen = willBeFullScreen;
        }

        public override void EndScreenDeviceChange(string screenDeviceName, int clientWidth, int clientHeight)
        {
            string text = deviceName;
            platform.ApplyWindowChanges(window, clientWidth, clientHeight, wantsFullscreen, screenDeviceName,
                ref deviceName);
            if (deviceName != text)
            {
                OnScreenDeviceNameChanged();
            }
        }

        internal void INTERNAL_ClientSizeChanged()
        {
            OnClientSizeChanged();
        }

        internal void INTERNAL_ScreenDeviceNameChanged()
        {
            OnScreenDeviceNameChanged();
        }

        internal void INTERNAL_OnOrientationChanged()
        {
            OnOrientationChanged();
        }

        protected internal override void SetSupportedOrientations(SourceDisplayOrientation orientations)
        {
            device.LogWarning("Setting SupportedOrientations has no effect!");
        }

        protected override void SetTitle(string title)
        {
            platform.SetWindowTitle(window, title);
        }
    }
}
