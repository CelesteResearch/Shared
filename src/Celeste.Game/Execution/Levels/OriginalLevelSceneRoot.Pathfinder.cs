using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Physics.Collision;
using Celeste.Physics.Collision.Shapes;
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
            Pathfinder = new SeekerPathfinder(this);
        }

        int ISeekerPathfinderWorld.RoomX => (int)Bounds.Left;
        int ISeekerPathfinderWorld.RoomY => (int)Bounds.Top;
        int ISeekerPathfinderWorld.RoomWidth => (int)Bounds.Width;
        int ISeekerPathfinderWorld.RoomHeight => (int)Bounds.Height;
        Vector2 ISeekerPathfinderWorld.LevelOffset => new Vector2(Bounds.Left, Bounds.Top);
        int ISeekerPathfinderWorld.SolidOffsetX => (int)Bounds.Left / 8 - TileBounds.X;
        int ISeekerPathfinderWorld.SolidOffsetY => (int)Bounds.Top / 8 - TileBounds.Y;
        char ISeekerPathfinderWorld.SolidTile(int x, int y) => SolidsData[x, y];

        List<object> ISeekerPathfinderWorld.Solids =>
            Scheduler.Entities.GetTrackedEntities("Celeste.Solid");

        global::Celeste.Core.Mathematics.ISourceVectorArithmetic ISeekerPathfinderWorld.VectorArithmetic =>
            ((global::Celeste.Core.Mathematics.ISourceVectorEnvironment)EngineContext).VectorArithmetic;
    }
}
