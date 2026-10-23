using System;
using Celeste.Audio.Fmod.Interop;
using Celeste.Audio.Fmod.Banks;
using Celeste.Audio.Fmod.Events;

namespace Celeste.Audio.Fmod.Runtime
{
    public sealed partial class FmodStudioRuntime
    {
        public FmodEventDescriptionReference GetSourceEventDescription(string path)
        {
            if (sourceDescriptionPolicy != null) return sourceDescriptionPolicy.GetEventDescription(path);
            FmodEventDescriptionReference description = null;
            if (path == null || descriptions.TryGetValue(path, out description)) return description;
            var result = GetEventNative(path, out description);
            switch (result)
            {
                case FmodResult.OK:
                    description.LoadSampleDataNative();
                    descriptions.Add(path, description);
                    break;
                case FmodResult.ERR_EVENT_NOTFOUND:
                    break;
                default:
                    throw new Exception("FMOD getEvent failed: " + result);
            }

            return description;
        }

        public FmodResult GetBankListNative(out FmodBankReference[] array)
        {
            array = null;
            FmodResult rESULT = DeviceIO.StudioSystemGetBankCount(system, out var count);
            if (rESULT != FmodResult.OK)
            {
                return rESULT;
            }

            if (count == 0)
            {
                array = new FmodBankReference[0];
                return rESULT;
            }

            IntPtr[] array2 = new IntPtr[count];
            rESULT = DeviceIO.StudioSystemGetBankList(system, array2, count, out var count2);
            if (rESULT != FmodResult.OK)
            {
                return rESULT;
            }

            if (count2 > count)
            {
                count2 = count;
            }

            array = new FmodBankReference[count2];
            for (int i = 0; i < count2; i++)
            {
                array[i] = new FmodBankReference(array2[i], DeviceIO);
            }

            return FmodResult.OK;
        }
    }
}
