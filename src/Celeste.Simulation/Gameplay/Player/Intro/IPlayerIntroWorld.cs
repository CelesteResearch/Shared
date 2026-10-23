using System.Numerics;
using Celeste.Core.Geometry;
using Celeste.Simulation.Gameplay.Player.Presentation.Sprites;

namespace Celeste.Simulation.Gameplay.Player.Intro
{
    public interface IPlayerIntroWorld
    {
        PlayerSprite Sprite { get; }
        Vector2 Position { get; set; }
        IntRect RoomBounds { get; }
        int Depth { get; set; }
        bool Visible { get; set; }
        float CameraX { get; set; }
        bool SolidAt(Vector2 position);
        bool OnGround();
        void MoveTowardsX(float target, float maximum);
        void MoveToX(float target);
        void MoveH(float amount);
        void MoveV(float amount);
        void PlaySound(string name);
        void DirectionalShake(Vector2 direction);
        void RumbleStrongMedium();
        void EmitSummitLand(int type, bool background, int count, Vector2 position, Vector2 range, float? direction);
        Vector2 BottomCenter { get; }
    }
}
