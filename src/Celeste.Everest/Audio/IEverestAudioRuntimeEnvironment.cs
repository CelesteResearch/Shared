namespace Celeste.Everest.Audio
{
    public interface IEverestAudioRuntimeEnvironment
    {
        // Exactly the Installed profile GameplayProcess.AudioSession instance.
        EverestGameAudioSession EverestAudio { get; }
    }
}
