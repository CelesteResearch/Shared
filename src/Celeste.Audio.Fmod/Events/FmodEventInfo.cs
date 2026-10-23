using System;

namespace Celeste.Audio.Fmod.Events
{
    public sealed class FmodEventInfo
    {
        public string Path { get; internal set; }
        public Guid Id { get; internal set; }
        public int LengthMilliseconds { get; internal set; }
        public bool IsOneShot { get; internal set; }
        public bool Is3D { get; internal set; }
        public global::Celeste.Audio.Fmod.Parameters.FmodParameterInfo[] Parameters { get; internal set; }
    }
}
