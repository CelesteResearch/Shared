using System;
using System.Runtime.InteropServices;
using Celeste.Audio.Fmod.Banks;
using Celeste.Audio.Fmod.Events;
using Celeste.Audio.Fmod.Interop;

namespace Celeste.Audio.Fmod.Runtime
{
    public sealed partial class FmodStudioRuntime
    {
        public FmodResult GetLowLevelSystemNative(out IntPtr value)
        {
            return DeviceIO.StudioSystemGetLowLevelSystem(system, out value);
        }

        public static string GetSourceSdlPlatformNative()
        {
            return FmodSourceMarshallingHelper.stringFromNativeUtf8(NativeMethods.SDL_GetPlatform());
        }

        public static void RegisterSourceSdlSystemNative(IntPtr system)
        {
            NativeMethods.FMOD_SDL_Register(system);
        }

        public void ConfigureSourcePlatformNative(IntPtr core)
        {
            DeviceIO.ConfigureSourcePlatform(core);
        }

        public FmodResult GetEventNative(string path, out FmodEventDescriptionReference value)
        {
            value = null;
            var result = DeviceIO.StudioSystemGetEvent(system, Utf8(path), out var handle);
            if (result != FmodResult.OK) return result;
            value = new(handle, DeviceIO);
            return result;
        }

        public FmodResult GetEventByIDNative(Guid guid, out FmodEventDescriptionReference _event)
        {
            _event = null;
            var description = default(IntPtr);
            var rEsult = DeviceIO.StudioSystemGetEventByID(system, ref guid, out description);
            if (rEsult != FmodResult.OK) return rEsult;

            _event = new(description, DeviceIO);
            return rEsult;
        }

        public FmodResult LoadBankCustomNative(FmodBankInfo info, uint flags, out FmodBankReference bank)
        {
            bank = null;
            info.size = Marshal.SizeOf((object)info);
            var bank2 = default(IntPtr);
            var rEsult = DeviceIO.StudioSystemLoadBankCustom(system, ref info, flags, out bank2);
            if (rEsult != FmodResult.OK) return rEsult;

            bank = new(bank2, DeviceIO);
            return rEsult;
        }
    }
}
