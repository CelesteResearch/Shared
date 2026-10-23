using Celeste.Core.Display;
using System;
using Celeste.Core.Geometry;
using Celeste.Core.Framework.Services;

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
