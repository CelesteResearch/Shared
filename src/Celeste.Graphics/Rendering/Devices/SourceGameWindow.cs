using System;
using System.ComponentModel;
using Celeste.Core.Display;
using Celeste.Core.Geometry;

namespace Celeste.Graphics.Rendering.Devices
{
    public abstract class SourceGameWindow : ISourceGraphicsManagerWindow
    {
        private string _title;

        [DefaultValue(false)] public abstract bool AllowUserResizing { get; set; }

        public abstract IntRect ClientBounds { get; }

        public abstract SourceDisplayOrientation CurrentOrientation { get; internal set; }

        public abstract IntPtr Handle { get; }

        public abstract string ScreenDeviceName { get; }

        public string Title
        {
            get => _title;
            set
            {
                if (_title != value)
                {
                    SetTitle(value);
                    _title = value;
                }
            }
        }

        public virtual bool IsBorderlessEXT
        {
            get => false;
            set => throw new NotImplementedException();
        }

        public event EventHandler<EventArgs> ClientSizeChanged;

        public event EventHandler<EventArgs> OrientationChanged;

        public event EventHandler<EventArgs> ScreenDeviceNameChanged;

        public abstract void BeginScreenDeviceChange(bool willBeFullScreen);

        public abstract void EndScreenDeviceChange(string screenDeviceName, int clientWidth, int clientHeight);

        public void EndScreenDeviceChange(string screenDeviceName)
        {
            EndScreenDeviceChange(screenDeviceName, ClientBounds.Width, ClientBounds.Height);
        }

        protected void OnActivated()
        {
        }

        protected void OnClientSizeChanged()
        {
            if (ClientSizeChanged != null) ClientSizeChanged(this, EventArgs.Empty);
        }

        protected void OnDeactivated()
        {
        }

        protected void OnOrientationChanged()
        {
            if (OrientationChanged != null) OrientationChanged(this, EventArgs.Empty);
        }

        protected void OnPaint()
        {
        }

        protected void OnScreenDeviceNameChanged()
        {
            if (ScreenDeviceNameChanged != null) ScreenDeviceNameChanged(this, EventArgs.Empty);
        }

        void ISourceGraphicsManagerWindow.SetSupportedOrientations(SourceDisplayOrientation orientations)
        {
            SetSupportedOrientations(orientations);
        }

        protected internal abstract void SetSupportedOrientations(SourceDisplayOrientation orientations);

        protected abstract void SetTitle(string title);
    }
}
