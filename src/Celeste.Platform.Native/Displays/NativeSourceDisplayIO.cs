using System;
using System.Runtime.InteropServices;
using Celeste.Core.Geometry;
using Celeste.Graphics.Rendering.Devices;

namespace Celeste.Platform.Native.Displays
{
    public sealed class NativeSourceDisplayIO : ISourceGraphicsAdapterDisplayIO, IDisposable
    {
        private const uint SDL_INIT_VIDEO = 0x20;
        private bool disposed;

        public NativeSourceDisplayIO()
        {
            if (SDL_InitSubSystem(SDL_INIT_VIDEO) != 0) ThrowSdlError();
        }

        public int GetNumVideoDisplays()
        {
            var count = SDL_GetNumVideoDisplays();
            if (count < 0) ThrowSdlError();
            return count;
        }

        public int GetNumDisplayModes(int displayIndex)
        {
            var count = SDL_GetNumDisplayModes(displayIndex);
            if (count < 0) ThrowSdlError();
            return count;
        }

        public void GetDisplayMode(int displayIndex, int modeIndex, out SourceNativeDisplayMode mode)
        {
            if (SDL_GetDisplayMode(displayIndex, modeIndex, out mode) != 0) ThrowSdlError();
        }

        public void GetCurrentDisplayMode(int displayIndex, out SourceNativeDisplayMode mode)
        {
            if (SDL_GetCurrentDisplayMode(displayIndex, out mode) != 0) ThrowSdlError();
        }

        public void GetDisplayBounds(int displayIndex, out IntRect bounds)
        {
            if (SDL_GetDisplayBounds(displayIndex, out bounds) != 0) ThrowSdlError();
        }

        public string GetDisplayName(int displayIndex)
        {
            var name = SDL_GetDisplayName(displayIndex);
            if (name == IntPtr.Zero) ThrowSdlError();
            return Marshal.PtrToStringUTF8(name);
        }

        public void Dispose()
        {
            if (!disposed)
            {
                SDL_QuitSubSystem(SDL_INIT_VIDEO);
                disposed = true;
            }
        }

        private static void ThrowSdlError()
        {
            throw new InvalidOperationException(Marshal.PtrToStringUTF8(SDL_GetError()));
        }

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl)]
        private static extern int SDL_InitSubSystem(uint flags);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl)]
        private static extern void SDL_QuitSubSystem(uint flags);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl)]
        private static extern int SDL_GetNumVideoDisplays();

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl)]
        private static extern int SDL_GetNumDisplayModes(int displayIndex);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl)]
        private static extern int SDL_GetDisplayMode(int displayIndex, int modeIndex, out SourceNativeDisplayMode mode);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl)]
        private static extern int SDL_GetCurrentDisplayMode(int displayIndex, out SourceNativeDisplayMode mode);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr SDL_GetDisplayName(int displayIndex);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl)]
        private static extern int SDL_GetDisplayBounds(int displayIndex, out IntRect bounds);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr SDL_GetError();
    }
}
