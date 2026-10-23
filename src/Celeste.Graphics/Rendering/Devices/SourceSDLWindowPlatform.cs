using System;
using Celeste.Core.Geometry;
using Celeste.Graphics.Content.Images;
using Celeste.Input.Runtime;

namespace Celeste.Graphics.Rendering.Devices
{
    public sealed partial class SourceSDLWindowPlatform(
        ISourceSDLWindowDevice device,
        SourceGraphicsAdapterProcess adapters,
        ISourceWindowInputMetrics inputMetrics,
        ISourceSDLPlatformEnvironment platform,
        ISourceImageStreamProcessEnvironment images) : ISourceGameWindowPlatform
    {
        SourceGameWindow ISourceGameWindowPlatform.CreateWindow()
        {
            return CreateWindow();
        }

        private readonly ISourceSDLWindowDevice device = device;
        private readonly SourceGraphicsAdapterProcess adapters = adapters;
        private readonly ISourceWindowInputMetrics inputMetrics = inputMetrics;
        private readonly ISourceSDLPlatformEnvironment platform = platform;
        private readonly ISourceImageStreamProcessEnvironment images = images;

        public bool SupportsOrientationChanges()
        {
            if (!platform.OSVersion.Equals("iOS"))
                return platform.OSVersion.Equals("Android");
            return true;
        }

        public void ApplyWindowChanges(IntPtr window, int clientWidth, int clientHeight, bool wantsFullscreen,
            string screenDeviceName, ref string resultDeviceName)
        {
            var flag = false;
            ScaleForWindow(window, false, ref clientWidth, ref clientHeight);
            if (!wantsFullscreen)
            {
                var flag2 = false;
                if ((device.GetWindowFlags(window) & 1) != 0)
                {
                    device.SetWindowFullscreen(window, 0u);
                    flag2 = true;
                }
                else
                {
                    device.GetWindowSize(window, out var w, out var h);
                    flag2 = clientWidth != w || clientHeight != h;
                }

                if (flag2)
                {
                    device.RestoreWindow(window);
                    device.SetWindowSize(window, clientWidth, clientHeight);
                    flag = true;
                }
            }

            var num = 0;
            for (var i = 0; i < adapters.Adapters.Count; i++)
                if (screenDeviceName == adapters.Adapters[i].DeviceName)
                {
                    num = i;
                    break;
                }

            if (resultDeviceName != screenDeviceName)
            {
                device.SetWindowFullscreen(window, 0u);
                resultDeviceName = screenDeviceName;
                flag = true;
            }

            if (flag)
            {
                var num2 = 0x2FFF0000 | num;
                device.SetWindowPosition(window, num2, num2);
            }

            if (wantsFullscreen)
            {
                if ((device.GetWindowFlags(window) & 4) == 0)
                {
                    device.GetCurrentDisplayMode(num, out var mode);
                    device.SetWindowSize(window, mode.Width, mode.Height);
                }

                device.SetWindowFullscreen(window, 4097u);
            }

            if (inputMetrics.MouseWindowHandle == window)
            {
                var windowBounds = GetWindowBounds(window);
                inputMetrics.MouseWindowWidth = windowBounds.Width;
                inputMetrics.MouseWindowHeight = windowBounds.Height;
            }
        }

        public void ScaleForWindow(IntPtr window, bool invert, ref int w, ref int h)
        {
            device.GetWindowSize(window, out var w2, out var h2);
            device.GetDrawableSize(window, out var w3, out var h3);
            if (w2 != 0 && h2 != 0 && w3 != 0 && h3 != 0 && (w2 != w3 || h2 != h3))
            {
                if (invert)
                {
                    w = (int)(w * (w3 / (float)w2));
                    h = (int)(h * (h3 / (float)h2));
                }
                else
                {
                    w = (int)(w / (w3 / (float)w2));
                    h = (int)(h / (h3 / (float)h2));
                }
            }
        }

        public IntRect GetWindowBounds(IntPtr window)
        {
            var result = default(IntRect);
            if ((device.GetWindowFlags(window) & 1) != 0)
            {
                device.GetCurrentDisplayMode(device.GetWindowDisplayIndex(window), out var mode);
                result.X = 0;
                result.Y = 0;
                result.Width = mode.Width;
                result.Height = mode.Height;
            }
            else
            {
                device.GetWindowPosition(window, out result.X, out result.Y);
                device.GetWindowSize(window, out result.Width, out result.Height);
            }

            return result;
        }

        public bool GetWindowResizable(IntPtr window)
        {
            return (device.GetWindowFlags(window) & 0x20) != 0;
        }

        public void SetWindowResizable(IntPtr window, bool resizable)
        {
            device.SetWindowResizable(window, resizable ? 1 : 0);
        }

        public bool GetWindowBorderless(IntPtr window)
        {
            return (device.GetWindowFlags(window) & 0x10) != 0;
        }

        public void SetWindowBorderless(IntPtr window, bool borderless)
        {
            device.SetWindowBordered(window, !borderless ? 1 : 0);
        }

        public void SetWindowTitle(IntPtr window, string title)
        {
            device.SetWindowTitle(window, title);
        }
    }
}
