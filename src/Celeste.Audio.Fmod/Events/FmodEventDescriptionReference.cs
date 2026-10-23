using System;
using System.Text;
using Celeste.Audio.Fmod.Interop;

namespace Celeste.Audio.Fmod.Events
{
    public sealed partial class FmodEventDescriptionReference : FmodSourceHandleBase
    {
        private IntPtr handle => rawPtr;

        internal FmodEventDescriptionReference(IntPtr handle) : this(handle, IO.NativeFmodStudioDeviceIO.Instance)
        {
        }

        internal FmodEventDescriptionReference(IntPtr handle, IO.IFmodStudioDeviceIO deviceIO) : base(handle, deviceIO)
        {
        }

        public FmodResult GetInstanceCount(out int count)
            => DeviceIO.StudioEventDescriptionGetInstanceCount(handle, out count);

        public FmodResult GetID(out Guid id) => DeviceIO.StudioEventDescriptionGetID(handle, out id);

        public FmodResult GetPath(out string path)
        {
            path = null;
            byte[] buffer = new byte[256];
            int retrieved = 0;
            FmodResult result =
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
