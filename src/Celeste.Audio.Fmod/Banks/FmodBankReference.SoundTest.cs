using System;
using System.Text;
using Celeste.Audio.Fmod.Events;
using Celeste.Audio.Fmod.Interop;

namespace Celeste.Audio.Fmod.Banks
{
    public partial class FmodBankReference
    {
        public bool IsValidNative()
        {
            return Handle != IntPtr.Zero;
        }

        public FmodResult GetID(out Guid id)
        {
            return DeviceIO.StudioBankGetID(Handle, out id);
        }

        public FmodResult GetEventListNative(out FmodEventDescriptionReference[] array)
        {
            array = null;
            var rEsult = DeviceIO.StudioBankGetEventCount(Handle, out var count);
            if (rEsult != FmodResult.OK) return rEsult;

            if (count == 0)
            {
                array = /* ReSharper disable once UseCollectionExpression */ new FmodEventDescriptionReference[0];
                return rEsult;
            }

            var array2 = new IntPtr[count];
            rEsult = DeviceIO.StudioBankGetEventList(Handle, array2, count, out var count2);
            if (rEsult != FmodResult.OK) return rEsult;

            if (count2 > count) count2 = count;

            array = new FmodEventDescriptionReference[count2];
            for (var i = 0; i < count2; i++) array[i] = new(array2[i], DeviceIO);

            return FmodResult.OK;
        }

        public FmodResult GetPath(out string path)
        {
            path = null;
            var buffer = new byte[256];
            var retrieved = 0;
            var result = DeviceIO.StudioBankGetPath(Handle, buffer, buffer.Length, out retrieved);
            if (result == FmodResult.ERR_TRUNCATED)
            {
                buffer = new byte[retrieved];
                result = DeviceIO.StudioBankGetPath(Handle, buffer, buffer.Length, out retrieved);
            }

            if (result == FmodResult.OK)
                path = Encoding.UTF8.GetString(buffer, 0, retrieved - 1);
            return result;
        }
    }
}
