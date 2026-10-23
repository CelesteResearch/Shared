using System;
using Celeste.Core.Display;
using Celeste.Core.Geometry;

namespace Celeste.Graphics.Rendering.Devices
{
    public interface ISourceGraphicsManagerWindow
    {
        IntPtr Handle { get; }
        IntRect ClientBounds { get; }
        event EventHandler<EventArgs> ClientSizeChanged;
        void SetSupportedOrientations(SourceDisplayOrientation orientations);
        void BeginScreenDeviceChange(bool willBeFullScreen);
        void EndScreenDeviceChange(string deviceName, int clientWidth, int clientHeight);
    }
}
