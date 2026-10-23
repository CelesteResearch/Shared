using System;
using System.Text;
using Celeste.Audio.Fmod.Interop;
using Celeste.Audio.Fmod.Events;

namespace Celeste.Audio.Fmod.Banks
{
    public partial class FmodBankReference
    {
        public bool IsValidNative() => Handle != IntPtr.Zero;
        public FmodResult GetID(out Guid id) => DeviceIO.StudioBankGetID(Handle, out id);

        public FmodResult GetEventListNative(out FmodEventDescriptionReference[] array)
        {
            array = null;
            FmodResult rESULT = DeviceIO.StudioBankGetEventCount(Handle, out var count);
            if (rESULT != FmodResult.OK)
            {
                return rESULT;
            }

            if (count == 0)
            {
                array = new FmodEventDescriptionReference[0];
                return rESULT;
            }

            IntPtr[] array2 = new IntPtr[count];
            rESULT = DeviceIO.StudioBankGetEventList(Handle, array2, count, out var count2);
            if (rESULT != FmodResult.OK)
            {
                return rESULT;
            }

            if (count2 > count)
            {
                count2 = count;
            }

            array = new FmodEventDescriptionReference[count2];
            for (int i = 0; i < count2; i++)
            {
                array[i] = new FmodEventDescriptionReference(array2[i], DeviceIO);
            }

            return FmodResult.OK;
        }

        public FmodResult GetPath(out string path)
        {
            path = null;
            byte[] buffer = new byte[256];
            int retrieved = 0;
            FmodResult result = DeviceIO.StudioBankGetPath(Handle, buffer, buffer.Length, out retrieved);
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
