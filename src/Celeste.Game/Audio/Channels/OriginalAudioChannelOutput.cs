using Celeste.Audio.Fmod.Events;
using Celeste.Game.Audio.Runtime;
using Celeste.Simulation.Audio;

namespace Celeste.Game.Audio.Channels
{
    public sealed class OriginalAudioChannelOutput : IRoomAudioOutput
    {
        private readonly OriginalGameAudioSession audio;

        internal OriginalAudioChannelOutput(OriginalGameAudioSession audio)
        {
            this.audio = audio;
        }

        public FmodEventReference ActualMusicInstance => audio.CurrentMusicEventInstance;
        public FmodEventReference ActualAmbienceInstance => audio.CurrentAmbienceEventInstance;
        public bool HasMusic => ActualMusicInstance != null;
        public bool HasAmbience => ActualAmbienceInstance != null;

        public bool SetMusic(string path, bool startPlaying = true, bool allowFadeOut = true)
        {
            return audio.SetMusic(path, startPlaying, allowFadeOut);
        }

        public bool SetAmbience(string path, bool startPlaying = true)
        {
            return audio.SetAmbience(path, startPlaying);
        }

        public void SetAltMusic(string path)
        {
            audio.SetAltMusic(path);
        }

        public void SetMusicParam(string key, float value)
        {
            if (HasMusic) ActualMusicInstance.SetParameter(key, value);
        }

        public void StartMusic()
        {
            if (HasMusic) ActualMusicInstance.Start();
        }

        public void SetAmbienceParam(string key, float value)
        {
            if (HasAmbience) ActualAmbienceInstance.SetParameter(key, value);
        }

        public void SetAmbienceVolume(float value)
        {
            if (HasAmbience) ActualAmbienceInstance.SetVolume(value);
        }

        public void StartAmbience()
        {
            if (HasAmbience) ActualAmbienceInstance.Start();
        }
    }
}
