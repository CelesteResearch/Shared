using System;
using System.Runtime.InteropServices;
using Celeste.Audio.Fmod.Interop;
using Celeste.Audio.Fmod.Events;
using Celeste.Audio.Fmod.Banks;

namespace Celeste.Audio.Fmod.Runtime
{
    public sealed partial class FmodStudioRuntime
    {
        public FmodResult GetLowLevelSystemNative(out IntPtr value) =>
            DeviceIO.StudioSystemGetLowLevelSystem(system, out value);

        public static string GetSourceSdlPlatformNative() =>
            FmodSourceMarshallingHelper.stringFromNativeUtf8(NativeMethods.SDL_GetPlatform());

        public static void RegisterSourceSdlSystemNative(IntPtr system) => NativeMethods.FMOD_SDL_Register(system);

        public void ConfigureSourcePlatformNative(IntPtr core) => DeviceIO.ConfigureSourcePlatform(core);

        public FmodResult GetEventNative(string path, out FmodEventDescriptionReference value)
        {
            value = null;
            var result = DeviceIO.StudioSystemGetEvent(system, Utf8(path), out var handle);
            if (result != FmodResult.OK) return result;
            value = new FmodEventDescriptionReference(handle, DeviceIO);
            return result;
        }

        public FmodResult GetEventByIDNative(Guid guid, out FmodEventDescriptionReference _event)
        {
            _event = null;
            IntPtr description = default(IntPtr);
            FmodResult rESULT = DeviceIO.StudioSystemGetEventByID(system, ref guid, out description);
            if (rESULT != FmodResult.OK)
            {
                return rESULT;
            }

            _event = new FmodEventDescriptionReference(description, DeviceIO);
            return rESULT;
        }

        public FmodResult LoadBankCustomNative(FmodBankInfo info, uint flags, out FmodBankReference bank)
        {
            bank = null;
            info.size = Marshal.SizeOf((object)info);
            IntPtr bank2 = default(IntPtr);
            FmodResult rESULT = DeviceIO.StudioSystemLoadBankCustom(system, ref info, flags, out bank2);
            if (rESULT != FmodResult.OK)
            {
                return rESULT;
            }

            bank = new FmodBankReference(bank2, DeviceIO);
            return rESULT;
        }
    }
}
