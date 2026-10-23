using System;
using System.Runtime.InteropServices;
using Celeste.Core.IO.Platform.SDL;

namespace Celeste.Platform.Native.Sdl
{
    public sealed class NativeSourceSDLRuntimeDevice : ISourceSDLRuntimeDevice
    {
        public string GetPlatform()
        {
            return Marshal.PtrToStringUTF8(SDL_GetPlatform());
        }

        public string GetPrefPath(string organization, string application)
        {
            var value = SDL_GetPrefPath(organization, application);
            if (value == IntPtr.Zero) throw new InvalidOperationException(Marshal.PtrToStringUTF8(SDL_GetError()));
            try
            {
                return Marshal.PtrToStringUTF8(value);
            }
            finally
            {
                SDL_free(value);
            }
        }

        public void SetHint(string name, string value)
        {
            SDL_SetHint(name, value);
        }

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl)]
        private static extern byte SDL_SetHint([MarshalAs(UnmanagedType.LPUTF8Str)] string name,
            [MarshalAs(UnmanagedType.LPUTF8Str)] string value);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr SDL_GetPlatform();

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr SDL_GetPrefPath([MarshalAs(UnmanagedType.LPUTF8Str)] string organization,
            [MarshalAs(UnmanagedType.LPUTF8Str)] string application);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr SDL_GetError();

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl)]
        private static extern void SDL_free(IntPtr value);
    }
}
