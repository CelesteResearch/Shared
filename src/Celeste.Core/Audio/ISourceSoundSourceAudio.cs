using System.Numerics;

namespace Celeste.Core.Audio
{
    public interface ISourceSoundSourceAudio
    {
        void CreateInstance(string path, ref ISourceAudioEventReference instance, ref bool is3D, ref bool isOneshot);
        void Stop(ISourceAudioEventReference instance, bool allowFadeOut = true);
    }
}
