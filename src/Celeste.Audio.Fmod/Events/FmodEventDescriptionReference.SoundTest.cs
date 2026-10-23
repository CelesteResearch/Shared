using System;
using System.Text;
using Celeste.Audio.Fmod.Interop;
using Celeste.Audio.Fmod.Parameters;

namespace Celeste.Audio.Fmod.Events
{
    public sealed partial class FmodEventDescriptionReference
    {
        public bool IsValidNative() => handle != IntPtr.Zero;

        public FmodResult GetParameterCountNative(out int count) =>
            DeviceIO.StudioEventDescriptionGetParameterCount(handle, out count);

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
            parameter = default(FmodParameterDescription);
            FmodParameterDescription parameter2;
            FmodResult rESULT =
                DeviceIO.StudioEventDescriptionGetParameterByIndex(handle, index, out parameter2);
            if (rESULT != FmodResult.OK)
            {
                return rESULT;
            }

            AssignSourceParameter(parameter2, out parameter);
            return rESULT;
        }

        public FmodResult GetParameterNative(string name, out FmodParameterDescription parameter)
        {
            parameter = default(FmodParameterDescription);
            FmodParameterDescription parameter2;
            FmodResult rESULT =
                DeviceIO.StudioEventDescriptionGetParameter(handle, Encoding.UTF8.GetBytes(name + "\0"),
                    out parameter2);
            if (rESULT != FmodResult.OK)
            {
                return rESULT;
            }

            AssignSourceParameter(parameter2, out parameter);
            return rESULT;
        }
    }
}
