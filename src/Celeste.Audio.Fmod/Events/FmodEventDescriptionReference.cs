using System;
using System.Text;
using Celeste.Audio.Fmod.Interop;
using Celeste.Audio.Fmod.IO;

namespace Celeste.Audio.Fmod.Events
{
    public sealed partial class FmodEventDescriptionReference : FmodSourceHandleBase
    {
        private IntPtr handle => rawPtr;

        internal FmodEventDescriptionReference(IntPtr handle) : this(handle, NativeFmodStudioDeviceIO.Instance)
        {
        }

        internal FmodEventDescriptionReference(IntPtr handle, IFmodStudioDeviceIO deviceIO) : base(handle, deviceIO)
        {
        }

        public FmodResult GetInstanceCount(out int count)
        {
            return DeviceIO.StudioEventDescriptionGetInstanceCount(handle, out count);
        }

        public FmodResult GetID(out Guid id)
        {
            return DeviceIO.StudioEventDescriptionGetID(handle, out id);
        }

        public FmodResult GetPath(out string path)
        {
            path = null;
            var buffer = new byte[256];
            var retrieved = 0;
            var result =
                DeviceIO.StudioEventDescriptionGetPath(handle, buffer, buffer.Length, out retrieved);
            if (result == FmodResult.ERR_TRUNCATED)
            {
                buffer = new byte[retrieved];
                result = DeviceIO.StudioEventDescriptionGetPath(handle, buffer, buffer.Length,
                    out retrieved);
            }

            if (result == FmodResult.OK)
                path = Encoding.UTF8.GetString(buffer, 0, retrieved - 1);
            return result;
        }
    }
}
