using System;
using Celeste.Audio.Fmod.Interop;

namespace Celeste.Audio.Fmod.Events
{
    public interface ISourceAudioInterceptionPolicy
    {
        bool IsEventInstanceInterceptionEnabled { get; }
        bool InvokeSetMusic(Func<bool> original);
        void InvokeSetAltMusic(Action original);

        FmodResult InvokeCreateEventInstance(string path, SourceFmodCreateEventInstance original,
            out FmodEventReference instance);
    }
}
