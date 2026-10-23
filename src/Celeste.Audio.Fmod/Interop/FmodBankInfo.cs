using System;

namespace Celeste.Audio.Fmod.Interop
{
    public struct FmodBankInfo
    {
        public int size;

        public IntPtr userdata;

        public int userdatalength;

        public FmodFileOpenCallback opencallback;

        public FmodFileCloseCallback closecallback;

        public FmodFileReadCallback readcallback;

        public FmodFileSeekCallback seekcallback;
    }
}
