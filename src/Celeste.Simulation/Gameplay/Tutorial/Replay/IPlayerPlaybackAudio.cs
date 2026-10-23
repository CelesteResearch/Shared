using System.Numerics;

namespace Celeste.Simulation.Gameplay.Tutorial.Replay
{
// Pure spatial audio IO; the replay entity owns all event selection and timing.
    public interface IPlayerPlaybackAudio
    {
        void Play(string eventPath, Vector2 position);
    }
}
