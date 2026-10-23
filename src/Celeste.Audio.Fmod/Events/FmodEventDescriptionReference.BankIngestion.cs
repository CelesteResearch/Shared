using System;
using Celeste.Audio.Fmod.Interop;

namespace Celeste.Audio.Fmod.Events
{
    public sealed partial class FmodEventDescriptionReference
    {
        public IntPtr RawHandle => handle;

        public static FmodEventDescriptionReference BorrowSourceHandle(IntPtr value) =>
            new FmodEventDescriptionReference(value);

        public static FmodEventDescriptionReference BorrowSourceHandle(IntPtr value, IO.IFmodStudioDeviceIO deviceIO) =>
            new FmodEventDescriptionReference(value, deviceIO);

        public FmodResult LoadSampleDataNative() => DeviceIO.StudioEventDescriptionLoadSampleData(handle);

        public FmodResult UnloadSampleDataNative() =>
            DeviceIO.StudioEventDescriptionUnloadSampleData(handle);
    }
}
