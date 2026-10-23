using System;

namespace Celeste.Audio.Fmod.Interop
{
    public delegate FmodResult FmodFileSeekCallback(IntPtr handle, uint pos, IntPtr userdata);
}
