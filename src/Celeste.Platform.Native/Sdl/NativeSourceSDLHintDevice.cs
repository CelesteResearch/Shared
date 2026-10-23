using System.Runtime.InteropServices;
using Celeste.Core.IO.Platform.SDL;

namespace Celeste.Platform.Native.Sdl
{
    public sealed class NativeSourceSDLHintDevice : ISourceSDLHintDevice
    {
        public bool GetHintBoolean(string name, bool defaultValue) =>
            SDL_GetHintBoolean(name, defaultValue ? 1 : 0) != 0;

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl)]
        private static extern int
            SDL_GetHintBoolean([MarshalAs(UnmanagedType.LPUTF8Str)] string name, int defaultValue);
    }
}
