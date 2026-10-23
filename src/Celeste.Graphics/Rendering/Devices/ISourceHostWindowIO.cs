using System;
using Celeste.Core.Geometry;

namespace Celeste.Graphics.Rendering.Devices
{
    public interface ISourceHostWindowIO
    {
        IntPtr Handle { get; }
        IntRect Bounds { get; }
        string DisplayName { get; }
        bool Resizable { get; set; }
        bool Borderless { get; set; }
        void SetTitle(string title);
        void ApplyResolution(int width, int height, bool fullscreen, string displayName);
        void GetWindowSize(out int width, out int height);
        void GetDrawableSize(out int width, out int height);
        void LogWarning(string message);
    }
}
