using Celeste.Core.Audio;
using Celeste.Core.Randomness;
using Celeste.Simulation.Gameplay.Player.Presentation.Sprites;

namespace Celeste.Simulation.Gameplay.Player.Presentation.Idle
{
    public interface IPlayerIdleWorld
    {
        PlayerSprite Sprite { get; }
        bool ScenePresent { get; }
        bool Dead { get; }
        bool InCutscene { get; }
        bool CoreHot { get; }
        ISourceRandom Random { get; }
        ISourceAudioEventReference PlaySound(string name);
        void StopSound(ISourceAudioEventReference instance);
    }
}
