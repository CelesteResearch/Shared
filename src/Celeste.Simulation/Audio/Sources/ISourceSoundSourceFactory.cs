namespace Celeste.Simulation.Audio.Sources
{
    // One logical Engine binds only native instance IO here. The source owner
    // still creates at the original phase, then AddTo and Play in original order.
    public interface ISourceSoundSourceFactory
    {
        SoundSourceComponentState Create();
    }
}
