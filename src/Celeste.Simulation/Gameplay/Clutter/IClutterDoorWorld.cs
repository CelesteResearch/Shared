using System.Numerics;
using Celeste.Core.Geometry;
using Celeste.Simulation.Gameplay.Clutter.Progression;

namespace Celeste.Simulation.Gameplay.Clutter
{
    public interface IClutterDoorWorld : IClutterFlags
    {
        Vector2 Position { get; }
        Bounds LevelBounds { get; }
        Vector2 CameraPosition { get; set; }
        float DeltaTime { get; }

        bool Transitioning { get; }

        // Original Entity.CollideCheck<Player>: target Collidable, no own-Collidable/dead gate.
        bool CollidePlayer();
        void UpdateSolidTail(float dt);
        void PlaySound(string name, Vector2 position);
        void Rumble(string strength, string length);
    }
}
