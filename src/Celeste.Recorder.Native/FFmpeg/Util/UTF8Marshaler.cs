using System;
using System.Runtime.InteropServices;
using System.Text;

namespace FFmpeg.Util
{
    public class UTF8Marshaler : ICustomMarshaler
    {
        private static readonly UTF8Marshaler Instance = new();

        public virtual object MarshalNativeToManaged(nint pNativeData)
        {
            return FromNative(Encoding.UTF8, pNativeData);
        }

        public virtual nint MarshalManagedToNative(object managedObj)
        {
            if (managedObj == null) return IntPtr.Zero;

            return managedObj is string value
                ? FromManaged(Encoding.UTF8, value)
                : throw new MarshalDirectiveException(GetType().Name + " must be used on a string.");
        }

        public virtual void CleanUpNativeData(nint pNativeData)
        {
            if (pNativeData != IntPtr.Zero) Marshal.FreeHGlobal(pNativeData);
        }

        public void CleanUpManagedData(object managedObj)
        {
        }

        public int GetNativeDataSize()
        {
            return -1;
        }

        public static ICustomMarshaler GetInstance(string cookie)
        {
            return Instance;
        }

        public static unsafe string FromNative(Encoding encoding, nint pNativeData)
        {
            return FromNative(encoding, (byte*)pNativeData);
        }

        public static unsafe string FromNative(Encoding encoding, byte* pNativeData)
        {
            if (pNativeData == null) return null;

            byte* ptr;
            for (ptr = pNativeData; *ptr != 0; ptr++)
            {
            }

            return ptr == pNativeData ? string.Empty : new((sbyte*)pNativeData, 0, (int)(ptr - pNativeData), encoding);
        }

        public static unsafe nint FromManaged(Encoding encoding, string value)
        {
            if (encoding == null || value == null) return IntPtr.Zero;

            var byteCount = encoding.GetByteCount(value);
            var ptr = (byte*)Marshal.AllocHGlobal(byteCount + 1).ToPointer();
            if (byteCount > 0)
                fixed (char* chars = value)
                {
                    encoding.GetBytes(chars, value.Length, ptr, byteCount);
                }

            ptr[byteCount] = 0;
            return new IntPtr(ptr);
        }
    }
}
