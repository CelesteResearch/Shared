using System;
using System.IO;
using System.Reflection;

namespace Celeste.Graphics.Rendering.Devices
{
    public interface ISourceSDLWindowDevice
    {
        uint GetWindowFlags(IntPtr window);
        int SetWindowFullscreen(IntPtr window, uint flags);
        void GetWindowSize(IntPtr window, out int width, out int height);
        void RestoreWindow(IntPtr window);
        void SetWindowSize(IntPtr window, int width, int height);
        void SetWindowPosition(IntPtr window, int x, int y);
        int GetCurrentDisplayMode(int index, out SourceSDLWindowDisplayMode mode);
        int GetWindowDisplayIndex(IntPtr window);
        void GetWindowPosition(IntPtr window, out int x, out int y);
        void GetDrawableSize(IntPtr window, out int width, out int height);
        void SetWindowResizable(IntPtr window, int enabled);
        void SetWindowBordered(IntPtr window, int enabled);
        void SetWindowTitle(IntPtr window, string title);
        void LogWarning(string message);
        uint PrepareWindowAttributes();
        string GetHint(string name);
        string GetPrefPath(string organization, string application);
        int SetHint(string name, string value);
        int SetHintWithPriority(string name, string value, int priority);
        IntPtr CreateWindow(string title, int x, int y, int width, int height, uint flags);
        string GetError();
        void DisableScreenSaver();
        int ShowCursor(int toggle);
        void DestroyWindow(IntPtr window);
        string GetEnvironmentVariable(string name);
        void SetEnvironmentVariable(string name, string value);
        Stream OpenTitleStream(string name);

        IntPtr CreateRGBSurfaceFrom(IntPtr data, int width, int height, int depth, int pitch, uint r, uint g, uint b,
            uint alpha);

        void SetWindowIcon(IntPtr window, IntPtr surface);
        void FreeSurface(IntPtr surface);
        void FreeImage(IntPtr image);
        IntPtr LoadBMP(string path);
    }
}
