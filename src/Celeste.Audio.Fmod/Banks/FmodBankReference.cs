using System;
using Celeste.Audio.Fmod.Interop;

namespace Celeste.Audio.Fmod.Banks
{
    public partial class FmodBankReference : FmodSourceHandleBase
    {
        public FmodBankReference(IntPtr handle) : this(handle, IO.NativeFmodStudioDeviceIO.Instance)
        {
        }

        public FmodBankReference(IntPtr handle, IO.IFmodStudioDeviceIO deviceIO) : base(handle, deviceIO)
        {
        }

        public IntPtr Handle => rawPtr;
        public FmodResult LoadSampleDataNative() => DeviceIO.StudioBankLoadSampleData(rawPtr);
    }
}
