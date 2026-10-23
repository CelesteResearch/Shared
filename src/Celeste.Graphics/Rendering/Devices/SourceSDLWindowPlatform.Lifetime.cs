using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Celeste.Graphics.Rendering.Devices
{
    public sealed partial class SourceSDLWindowPlatform
    {
        public SourceFNAWindow CreateWindow()
        {
            var sDL_WindowFlags = 0x608 | device.PrepareWindowAttributes();
            if ((sDL_WindowFlags & 0x10000000u) == 0x10000000u)
            {
                var text = device.GetHint("FNA3D_VULKAN_PIPELINE_CACHE_FILE_NAME");
                if (text == null)
                {
                    if (platform.OSVersion.Equals("Windows") || platform.OSVersion.Equals("Mac OS X") ||
                        platform.OSVersion.Equals("Linux") || platform.OSVersion.Equals("FreeBSD") ||
                        platform.OSVersion.Equals("OpenBSD") || platform.OSVersion.Equals("NetBSD"))
                    {
                        var text2 = Path.GetFileNameWithoutExtension(platform.FriendlyName).Replace(".vshost", "");
                        text = Path.Combine(device.GetPrefPath(null, "FNA3D"), text2 + "_Vulkan_PipelineCache.blob");
                    }
                    else
                    {
                        text = string.Empty;
                    }

                    device.SetHint("FNA3D_VULKAN_PIPELINE_CACHE_FILE_NAME", text);
                }
            }

            if (device.GetEnvironmentVariable("FNA_GRAPHICS_ENABLE_HIGHDPI") == "1") sDL_WindowFlags |= 0x2000u;

            var defaultWindowTitle = GetDefaultWindowTitle();
            var intPtr = device.CreateWindow(defaultWindowTitle, 805240832, 805240832,
                SourceGraphicsDeviceManager.DefaultBackBufferWidth, SourceGraphicsDeviceManager.DefaultBackBufferHeight,
                sDL_WindowFlags);
            if (intPtr == IntPtr.Zero) throw new NoSuitableGraphicsDeviceException(device.GetError());

            INTERNAL_SetIcon(intPtr, defaultWindowTitle);
            device.DisableScreenSaver();
            device.ShowCursor(0);
            sDL_WindowFlags = device.GetWindowFlags(intPtr);
            if ((sDL_WindowFlags & 0x2000u) == 0) device.SetEnvironmentVariable("FNA_GRAPHICS_ENABLE_HIGHDPI", "0");

            return new(intPtr, "\\\\.\\DISPLAY" + (device.GetWindowDisplayIndex(intPtr) + 1), this,
                device);
        }

        public void DisposeWindow(SourceGameWindow window)
        {
            device.SetHintWithPriority("SDL_VIDEO_MINIMIZE_ON_FOCUS_LOSS", "0", 2);
            if (inputMetrics.MouseWindowHandle == window.Handle) inputMetrics.MouseWindowHandle = IntPtr.Zero;

            if (inputMetrics.TouchWindowHandle == window.Handle) inputMetrics.TouchWindowHandle = IntPtr.Zero;

            device.DestroyWindow(window.Handle);
        }

        private void INTERNAL_SetIcon(IntPtr window, string title)
        {
            var empty = string.Empty;
            try
            {
                empty = INTERNAL_GetIconName(title + ".png");
                if (!string.IsNullOrEmpty(empty))
                {
                    IntPtr intPtr;
                    IntPtr intPtr2;
                    using (var stream = device.OpenTitleStream(empty))
                    {
                        intPtr = images.ImageStreams.ReadImageStream(stream, out var width, out var height, out _);
                        intPtr2 = device.CreateRGBSurfaceFrom(intPtr, width, height, 32, width * 4, 255u, 65280u,
                            16711680u,
                            4278190080u);
                    }

                    device.SetWindowIcon(window, intPtr2);
                    device.FreeSurface(intPtr2);
                    device.FreeImage(intPtr);
                    return;
                }
            }
            catch (DllNotFoundException)
            {
            }

            empty = INTERNAL_GetIconName(title + ".bmp");
            if (!string.IsNullOrEmpty(empty))
            {
                var intPtr3 = device.LoadBMP(empty);
                device.SetWindowIcon(window, intPtr3);
                device.FreeSurface(intPtr3);
            }
        }

        private string INTERNAL_GetIconName(string title)
        {
            var text = Path.Combine(platform.TitleLocation, title);
            if (File.Exists(text)) return text;

            text = Path.Combine(platform.TitleLocation, INTERNAL_StripBadChars(title));
            if (File.Exists(text)) return text;

            return string.Empty;
        }

        private string INTERNAL_StripBadChars(string path)
        {
            var collection = new[] { '<', '>', ':', '"', '/', '\\', '|', '?', '*' };
            var list = new List<char>();
            list.AddRange(Path.GetInvalidFileNameChars());
            list.AddRange(collection);
            var text = path;
            foreach (var item in list) text = text.Replace(item.ToString(), "");

            return text;
        }

        private string GetDefaultWindowTitle()
        {
            var text = string.Empty;
            var entryAssembly = platform.EntryAssembly;
            if (entryAssembly != null)
            {
                try
                {
                    var assemblyTitleAttribute =
                        (AssemblyTitleAttribute)Attribute.GetCustomAttribute(entryAssembly,
                            typeof(AssemblyTitleAttribute));
                    if (assemblyTitleAttribute != null) text = assemblyTitleAttribute.Title;
                }
                catch
                {
                }

                if (string.IsNullOrEmpty(text)) text = entryAssembly.GetName().Name;
            }

            return text;
        }
    }
}
