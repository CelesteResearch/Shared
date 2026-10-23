namespace Celeste.Audio.Fmod.Events
{
    public interface ISourceAudioInterceptionOwner
    {
        ISourceAudioInterceptionPolicy AudioInterceptionPolicy { get; }
        string GetEventName(FmodEventDescriptionReference description);
    }
}
