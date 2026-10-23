using System;
using Celeste.Audio.Fmod.Banks;
using Celeste.Audio.Fmod.Events;
using Celeste.Audio.Fmod.Interop;

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
                    throw new("FMOD getEvent failed: " + result);
            }

            return description;
        }

        public FmodResult GetBankListNative(out FmodBankReference[] array)
        {
            array = null;
            var rEsult = DeviceIO.StudioSystemGetBankCount(system, out var count);
            if (rEsult != FmodResult.OK) return rEsult;

            if (count == 0)
            {
                array = /* ReSharper disable once UseCollectionExpression */ new FmodBankReference[0];
                return rEsult;
            }

            var array2 = new IntPtr[count];
            rEsult = DeviceIO.StudioSystemGetBankList(system, array2, count, out var count2);
            if (rEsult != FmodResult.OK) return rEsult;

            if (count2 > count) count2 = count;

            array = new FmodBankReference[count2];
            for (var i = 0; i < count2; i++) array[i] = new(array2[i], DeviceIO);

            return FmodResult.OK;
        }
    }
}
