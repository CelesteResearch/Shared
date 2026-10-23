using System.Numerics;

namespace Celeste.Simulation.Gameplay.Player.Intro
{
    public interface ISourcePlayerIntroScene
    {
        float CameraX { get; set; }
        void EmitSummitLand(int type, bool background, int count, Vector2 position, Vector2 range, float? direction);
    }
}
