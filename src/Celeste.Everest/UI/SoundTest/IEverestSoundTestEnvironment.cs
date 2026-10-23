using Celeste.Everest.Audio;

namespace Celeste.Everest.UI.SoundTest
{
    public interface IEverestSoundTestEnvironment
    {
        EverestCoreSettings CurrentCoreSettings { get; }
        EverestAudioEventNamePolicy AudioNames { get; }
    }
}
