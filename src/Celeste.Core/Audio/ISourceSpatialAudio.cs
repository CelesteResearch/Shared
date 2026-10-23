using System.Numerics;

namespace Celeste.Core.Audio
{
    public interface ISourceSpatialAudio
    {
        ISourceAudioEventReference Play(string path, Vector2 position, string parameter = null, float value = 0f);

        ISourceAudioEventReference Play(string path, Vector2 position, string parameter, float value, string parameter2,
            float value2);

        void Position(ISourceAudioEventReference instance, Vector2 position);
        void Stop(ISourceAudioEventReference instance, bool allowFadeOut = true);
    }
}
