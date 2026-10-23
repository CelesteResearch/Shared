using System;
using System.Runtime.InteropServices;

namespace FFmpeg.Util
{
    public class ConstCharPtrMarshaler : ICustomMarshaler
    {
        private static readonly ConstCharPtrMarshaler Instance = new ConstCharPtrMarshaler();

        public object MarshalNativeToManaged(nint pNativeData)
        {
            return Marshal.PtrToStringAnsi(pNativeData);
        }

        public nint MarshalManagedToNative(object managedObj)
        {
            return IntPtr.Zero;
        }

        public void CleanUpNativeData(nint pNativeData)
        {
        }

        public void CleanUpManagedData(object managedObj)
        {
        }

        public int GetNativeDataSize()
        {
            return IntPtr.Size;
        }

        public static ICustomMarshaler GetInstance(string cookie)
        {
            return Instance;
        }
    }
}
