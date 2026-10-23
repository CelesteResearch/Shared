using System.Numerics;
using Celeste.Game.Audio.Runtime;
using Celeste.Game.Save.Runtime;
using Celeste.Simulation.Gameplay.Tutorial.Replay;

namespace Celeste.Game.Entities.Playback
{
    public sealed class OriginalPlayerPlaybackAudio : IPlayerPlaybackAudio
    {
        private readonly OriginalGameAudioSession audio;
        private readonly IOriginalGameSaveContext save;

        public OriginalPlayerPlaybackAudio(OriginalGameAudioSession audio, IOriginalGameSaveContext save)
        {
            this.audio = audio;
            this.save = save;
        }

        public void Play(string eventPath, Vector2 position) => audio.Play(eventPath, position, save);
    }
}
