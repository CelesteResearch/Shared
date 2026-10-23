using System;
using Celeste.Audio.Fmod.IO;

namespace Celeste.Audio.Fmod.Interop
{
    public class FmodSourceHandleBase
    {
        protected IntPtr rawPtr;
        protected IFmodStudioDeviceIO DeviceIO { get; }

        public FmodSourceHandleBase(IntPtr newPtr) : this(newPtr, NativeFmodStudioDeviceIO.Instance)
        {
        }

        protected FmodSourceHandleBase(IntPtr newPtr, IFmodStudioDeviceIO deviceIO)
        {
            DeviceIO = deviceIO ?? throw new ArgumentNullException(nameof(deviceIO));
            rawPtr = newPtr;
        }

        public bool IsValid()
        {
            return rawPtr != IntPtr.Zero;
        }

        public IntPtr GetRaw()
        {
            return rawPtr;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as FmodSourceHandleBase);
        }

        public bool Equals(FmodSourceHandleBase p)
        {
            if ((object)p != null) return ReferenceEquals(DeviceIO, p.DeviceIO) && rawPtr == p.rawPtr;

            return false;
        }

        public override int GetHashCode()
        {
            return rawPtr.ToInt32();
        }

        public static bool operator ==(FmodSourceHandleBase a, FmodSourceHandleBase b)
        {
            if ((object)a == b) return true;

            if ((object)a == null || (object)b == null) return false;

            return ReferenceEquals(a.DeviceIO, b.DeviceIO) && a.rawPtr == b.rawPtr;
        }

        public static bool operator !=(FmodSourceHandleBase a, FmodSourceHandleBase b)
        {
            return !(a == b);
        }
    }
}
