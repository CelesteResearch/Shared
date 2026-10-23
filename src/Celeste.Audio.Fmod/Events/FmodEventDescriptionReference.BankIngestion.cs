using System;
using Celeste.Audio.Fmod.Interop;
using Celeste.Audio.Fmod.IO;

namespace Celeste.Audio.Fmod.Events
{
    public sealed partial class FmodEventDescriptionReference
    {
        public IntPtr RawHandle => handle;

        public static FmodEventDescriptionReference BorrowSourceHandle(IntPtr value)
        {
            return new(value);
        }

        public static FmodEventDescriptionReference BorrowSourceHandle(IntPtr value, IFmodStudioDeviceIO deviceIO)
        {
            return new(value, deviceIO);
        }

        public FmodResult LoadSampleDataNative()
        {
            return DeviceIO.StudioEventDescriptionLoadSampleData(handle);
        }

        public FmodResult UnloadSampleDataNative()
        {
            return DeviceIO.StudioEventDescriptionUnloadSampleData(handle);
        }
    }
}
