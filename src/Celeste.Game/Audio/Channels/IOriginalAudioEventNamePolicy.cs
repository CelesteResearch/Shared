using Celeste.Audio.Fmod.Events;

namespace Celeste.Game.Audio.Channels
{
    public interface IOriginalAudioEventNamePolicy
    {
        string GetEventName(FmodEventReference instance);
        string GetEventName(FmodEventDescriptionReference description);
    }
}
