using System;
using System.Runtime.InteropServices;

namespace Celeste.Audio.Fmod.Interop
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct NativeParameterDescription
    {
        public IntPtr Name;
        public int Index;
        public float Minimum, Maximum, DefaultValue;
        public int Type;
    }
}
