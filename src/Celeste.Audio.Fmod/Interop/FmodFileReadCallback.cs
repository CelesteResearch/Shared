using System;

namespace Celeste.Audio.Fmod.Interop
{
    public delegate FmodResult FmodFileReadCallback(IntPtr handle, IntPtr buffer, uint sizebytes, ref uint bytesread,
        IntPtr userdata);
}
