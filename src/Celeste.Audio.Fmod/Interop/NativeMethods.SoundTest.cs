using System;
using System.Runtime.InteropServices;

namespace Celeste.Audio.Fmod.Interop
{
    internal static partial class NativeMethods
    {
        [DllImport(StudioLibrary, CallingConvention = CallingConvention.Winapi)]
        internal static extern bool FMOD_Studio_Bank_IsValid(IntPtr bank);

        [DllImport(StudioLibrary, CallingConvention = CallingConvention.Winapi)]
        internal static extern bool FMOD_Studio_EventDescription_IsValid(IntPtr description);

        [DllImport(StudioLibrary, CallingConvention = CallingConvention.Winapi)]
        internal static extern FmodResult FMOD_Studio_Bank_GetID(IntPtr bank, out Guid id);

        [DllImport(StudioLibrary, CallingConvention = CallingConvention.Winapi)]
        internal static extern FmodResult FMOD_Studio_EventDescription_GetParameter(IntPtr description, byte[] name,
            out NativeParameterDescription parameter);
    }
}
