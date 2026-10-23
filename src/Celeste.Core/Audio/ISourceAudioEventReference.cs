namespace Celeste.Core.Audio
{
    // The actual borrowed event identity, still non-null after native release.
    public interface ISourceAudioEventReference
    {
        SourceAudioPlaybackState PlaybackState { get; }
        bool GetPaused();
        void SetPaused(bool paused);
        void Start();
        void SetParameter(string name, float value);
        void GetVolume(out float volume, out float finalVolume);
        void SetVolume(float volume);
        void SetPitch(float pitch);
        void Release();
        void Stop(bool allowFadeOut = true);
    }
}
