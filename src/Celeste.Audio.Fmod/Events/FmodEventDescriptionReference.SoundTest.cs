using System;
using System.Text;
using Celeste.Audio.Fmod.Interop;
using Celeste.Audio.Fmod.Parameters;

namespace Celeste.Audio.Fmod.Events
{
    public sealed partial class FmodEventDescriptionReference
    {
        public bool IsValidNative()
        {
            return handle != IntPtr.Zero;
        }

        public FmodResult GetParameterCountNative(out int count)
        {
            return DeviceIO.StudioEventDescriptionGetParameterCount(handle, out count);
        }

        private static void AssignSourceParameter(FmodParameterDescription value,
            out FmodParameterDescription parameter)
        {
            parameter.Name = value.Name;
            parameter.Index = value.Index;
            parameter.Minimum = value.Minimum;
            parameter.Maximum = value.Maximum;
            parameter.DefaultValue = value.DefaultValue;
            parameter.Type = value.Type;
        }

        public FmodResult GetParameterByIndexNative(int index, out FmodParameterDescription parameter)
        {
            parameter = default;
            FmodParameterDescription parameter2;
            var rEsult =
                DeviceIO.StudioEventDescriptionGetParameterByIndex(handle, index, out parameter2);
            if (rEsult != FmodResult.OK) return rEsult;

            AssignSourceParameter(parameter2, out parameter);
            return rEsult;
        }

        public FmodResult GetParameterNative(string name, out FmodParameterDescription parameter)
        {
            parameter = default;
            FmodParameterDescription parameter2;
            var rEsult =
                DeviceIO.StudioEventDescriptionGetParameter(handle, Encoding.UTF8.GetBytes(name + "\0"),
                    out parameter2);
            if (rEsult != FmodResult.OK) return rEsult;

            AssignSourceParameter(parameter2, out parameter);
            return rEsult;
        }
    }
}
