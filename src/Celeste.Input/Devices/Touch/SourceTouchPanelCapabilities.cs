using System.Numerics;

namespace Celeste.Input.Devices.Touch
{
    public struct SourceTouchPanelCapabilities
    {
        public bool IsConnected { get; private set; }

        public int MaximumTouchCount { get; private set; }

        internal SourceTouchPanelCapabilities(bool isConnected, int maximumTouchCount)
        {
            this = default(SourceTouchPanelCapabilities);
            IsConnected = isConnected;
            MaximumTouchCount = maximumTouchCount;
        }
    }
}
