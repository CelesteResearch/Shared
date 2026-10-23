using Celeste.Audio.Fmod.Events;

namespace Celeste.Audio.Fmod.Runtime
{
    public interface ISourceFmodEventDescriptionPolicy
    {
        FmodEventDescriptionReference GetEventDescription(string path);
    }
}
