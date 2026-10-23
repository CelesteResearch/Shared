using System;
using System.Numerics;
using Celeste.Simulation;

namespace Celeste.Simulation.Story.Farewell.Travel
{
    public interface IFarewellTravelPlayer
    {
        Vector2 Position { get; set; }
        Vector2 Speed { get; set; }
        int Facing { get; set; }
        int Dashes { get; set; }
        void MoveHairBy(Vector2 offset);
    }
}
