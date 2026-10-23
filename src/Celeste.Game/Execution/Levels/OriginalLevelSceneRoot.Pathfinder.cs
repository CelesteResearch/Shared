using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Mathematics;
using Celeste.Simulation.Gameplay.Enemies.Seeker;

namespace Celeste.Game.Execution.Levels
{
    public sealed partial class OriginalLevelSceneRoot : ISeekerPathfinderWorld
    {
        public SeekerPathfinder Pathfinder { get; private set; }

        public void ConstructSourcePathfinder()
        {
            if (Pathfinder != null)
                throw new InvalidOperationException("This actual Level already constructed its Pathfinder.");
            Pathfinder = new(this);
        }

        int ISeekerPathfinderWorld.RoomX => Bounds.Left;
        int ISeekerPathfinderWorld.RoomY => Bounds.Top;
        int ISeekerPathfinderWorld.RoomWidth => Bounds.Width;
        int ISeekerPathfinderWorld.RoomHeight => Bounds.Height;
        Vector2 ISeekerPathfinderWorld.LevelOffset => new(Bounds.Left, Bounds.Top);
        int ISeekerPathfinderWorld.SolidOffsetX => Bounds.Left / 8 - TileBounds.X;
        int ISeekerPathfinderWorld.SolidOffsetY => Bounds.Top / 8 - TileBounds.Y;

        char ISeekerPathfinderWorld.SolidTile(int x, int y)
        {
            return SolidsData[x, y];
        }

        List<object> ISeekerPathfinderWorld.Solids =>
            Scheduler.Entities.GetTrackedEntities("Celeste.Solid");

        ISourceVectorArithmetic ISeekerPathfinderWorld.VectorArithmetic =>
            ((ISourceVectorEnvironment)EngineContext).VectorArithmetic;
    }
}
