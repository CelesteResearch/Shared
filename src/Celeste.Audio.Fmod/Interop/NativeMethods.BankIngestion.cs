using System;
using System.Runtime.InteropServices;

namespace Celeste.Audio.Fmod.Interop
{
    internal static partial class NativeMethods
    {
        [DllImport(StudioLibrary, CallingConvention = CallingConvention.Winapi)]
        internal static extern FmodResult FMOD_Studio_System_LoadBankCustom(IntPtr studio, ref FmodBankInfo info,
            uint flags, out IntPtr bank);

        [DllImport(StudioLibrary, CallingConvention = CallingConvention.Winapi)]
        internal static extern FmodResult FMOD_Studio_System_GetEventByID(IntPtr studio, ref Guid id,
            out IntPtr description);

        [DllImport(StudioLibrary, CallingConvention = CallingConvention.Winapi)]
        internal static extern FmodResult FMOD_Studio_EventDescription_UnloadSampleData(IntPtr description);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr SDL_GetPlatform();

        [DllImport("fmod_SDL", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void FMOD_SDL_Register(IntPtr system);
    }
}
