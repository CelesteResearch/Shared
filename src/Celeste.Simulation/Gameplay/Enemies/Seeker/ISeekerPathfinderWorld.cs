using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Mathematics;

namespace Celeste.Simulation.Gameplay.Enemies.Seeker
{
    public interface ISeekerPathfinderWorld
    {
        int RoomX { get; }
        int RoomY { get; }
        int RoomWidth { get; }
        int RoomHeight { get; }
        Vector2 LevelOffset { get; }
        int SolidOffsetX { get; }
        int SolidOffsetY { get; }
        char SolidTile(int x, int y);
        ISourceVectorArithmetic VectorArithmetic { get; }
        List<object> Solids { get; }
    }
}
