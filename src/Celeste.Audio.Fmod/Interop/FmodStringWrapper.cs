using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Celeste.Audio.Fmod.Interop
{
    public struct FmodStringWrapper
    {
#pragma warning disable CS0649 // Native FMOD marshalling populates this original SDK field.
        private IntPtr nativeUtf8Ptr;
#pragma warning restore CS0649

        public static implicit operator string(FmodStringWrapper fstring)
        {
            if (fstring.nativeUtf8Ptr == IntPtr.Zero)
            {
                return "";
            }

            int i;
            for (i = 0; Marshal.ReadByte(fstring.nativeUtf8Ptr, i) != 0; i++)
            {
            }

            if (i > 0)
            {
                byte[] array = new byte[i];
                Marshal.Copy(fstring.nativeUtf8Ptr, array, 0, i);
                return Encoding.UTF8.GetString(array, 0, i);
            }

            return "";
        }
    }
}
