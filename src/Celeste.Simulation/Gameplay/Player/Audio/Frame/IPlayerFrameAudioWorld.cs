using System.Numerics;
using Celeste.Simulation.Gameplay.Player.Presentation.Sprites;

namespace Celeste.Simulation.Gameplay.Player.Audio.Frame
{
    public interface IPlayerFrameAudioWorld
    {
        PlayerSprite Sprite { get; }
        bool ScenePresent { get; }
        bool Dead { get; }
        int Facing { get; }
        Vector2 Position { get; }
        int? StepSurface();
        int? WallSurface(int side);
        void PlaySound(string path, string parameter = null, float value = 0);
        void BurstForegroundDust(Vector2 position, float angle, int count, float range);
    }
}
