using System.Numerics;

namespace Celeste.Simulation.Gameplay.Enemies.Badeline.Projectiles
{
    public interface IFinalBossSource
    {
        Vector2 Position { get; }
        Vector2 Center { get; }
        Vector2 ShotOrigin { get; }
        Vector2 BeamOrigin { get; }
        bool Moving { get; }
    }
}
