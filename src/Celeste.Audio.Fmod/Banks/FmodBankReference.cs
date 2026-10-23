using System;
using Celeste.Audio.Fmod.Interop;
using Celeste.Audio.Fmod.IO;

namespace Celeste.Audio.Fmod.Banks
{
    public partial class FmodBankReference : FmodSourceHandleBase
    {
        public FmodBankReference(IntPtr handle) : this(handle, NativeFmodStudioDeviceIO.Instance)
        {
        }

        public FmodBankReference(IntPtr handle, IFmodStudioDeviceIO deviceIO) : base(handle, deviceIO)
        {
        }

        public IntPtr Handle => rawPtr;

        public FmodResult LoadSampleDataNative()
        {
            return DeviceIO.StudioBankLoadSampleData(rawPtr);
        }
    }
}
