using System;

namespace Celeste.Audio.Fmod.Interop
{
    public delegate FmodResult FmodFileOpenCallback(FmodStringWrapper name, ref uint filesize, ref IntPtr handle,
        IntPtr userdata);
}
