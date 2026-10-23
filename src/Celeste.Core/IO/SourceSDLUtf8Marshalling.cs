using System;
using System.Text;

namespace Celeste.Core.IO
{
    public static class SourceSDLUtf8Marshalling
    {
        public static unsafe string Read(IntPtr s, bool freePtr, ISourceSDLMemoryDevice device)
        {
            if (s == IntPtr.Zero) return null;
            byte* ptr;
            for (ptr = (byte*)(void*)s; *ptr != 0; ptr++)
            {
            }

            int num = (int)(ptr - (byte*)(void*)s);
            if (num == 0) return string.Empty;
            char* ptr2 = stackalloc char[num];
            int chars = Encoding.UTF8.GetChars((byte*)(void*)s, num, ptr2, num);
            string result = new string(ptr2, 0, chars);
            if (freePtr) device.Free(s);
            return result;
        }
    }
}
