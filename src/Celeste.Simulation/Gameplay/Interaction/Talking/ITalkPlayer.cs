using System;
using System.Numerics;
using Celeste.Simulation.Rendering;
using Celeste.Simulation;

namespace Celeste.Simulation.Gameplay.Interaction.Talking
{
    public interface ITalkPlayer
    {
        Vector2 Position { get; }
        float Bottom { get; }
        int State { get; }
        int Facing { get; }
        bool CollideRect(global::Celeste.Core.Geometry.IntRect rectangle);
        bool OnGround();
    }
}
