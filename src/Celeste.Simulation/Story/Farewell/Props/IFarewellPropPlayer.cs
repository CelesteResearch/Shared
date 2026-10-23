using System.Numerics;
using Celeste.Core.Geometry;

namespace Celeste.Simulation.Story.Farewell.Props
{
    // Player view shared by the ported props. Vector members are settable because the original
    // entities mutate the Player directly (Position, Speed, DummyGravity, State...).
    public interface IFarewellPropPlayer
    {
        bool Present { get; }
        bool Dead { get; }
        Vector2 Position { get; set; }
        Vector2 Center { get; }

        Vector2 Speed { get; set; }

        // Player.Collider is the hurtbox the original PlayerCollider checks against, so the
        // absolute hurtbox is exposed instead of a reconstructed hitbox.
        Bounds Hurtbox { get; }
        int State { get; set; }
        int Facing { get; set; }
        bool DummyGravity { get; set; }
        bool DummyAutoAnimate { get; set; }
        void PlaySprite(string animation);
        void SummitLaunch(float x);
    }
}
