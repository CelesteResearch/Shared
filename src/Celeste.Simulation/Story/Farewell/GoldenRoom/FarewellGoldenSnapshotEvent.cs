using System;
using System.Numerics;
using Celeste.Simulation;

namespace Celeste.Simulation.Story.Farewell.GoldenRoom
{
    public sealed class FarewellGoldenSnapshotEvent
    {
        public const string SnapshotName = "snapshot:/game_10_golden_room_flavour";
        public const string ColorGrade = "golden";
        readonly global::Celeste.Simulation.Story.Farewell.GoldenRoom.IFarewellGoldenSnapshotWorld world;
        public object Snapshot { get; private set; }
        public bool Started { get; private set; }

        public FarewellGoldenSnapshotEvent(
            global::Celeste.Simulation.Story.Farewell.GoldenRoom.IFarewellGoldenSnapshotWorld world)
        {
            this.world = world;
        }

        public void Enter()
        {
            Snapshot = world.CreateSnapshot(SnapshotName);
            world.SnapColorGrade(ColorGrade);
            Started = true;
        }

        public void Release()
        {
            world.ReleaseSnapshot(Snapshot);
            Snapshot = null;
            Started = false;
        }
    }
}
