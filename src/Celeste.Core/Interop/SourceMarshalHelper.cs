using System;
using System.Runtime.InteropServices;

namespace Celeste.Core.Interop
{
    public static class SourceMarshalHelper
    {
        public static int SizeOf<T>()
        {
            return Marshal.SizeOf(typeof(T));
        }

        public static string PtrToInternedStringAnsi(IntPtr ptr)
        {
            var text = Marshal.PtrToStringAnsi(ptr);
            if (text != null) text = string.Intern(text);

            return text;
        }
    }
}
