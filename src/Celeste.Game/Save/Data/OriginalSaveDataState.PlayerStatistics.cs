using Celeste.Simulation;
using Celeste.Simulation.Rendering;
using Celeste.Simulation.Gameplay.Player.Statistics;

namespace Celeste.Game.Save.Data
{
    public sealed partial class OriginalSaveDataState : IPlayerActionStatistics
    {
        int IPlayerActionStatistics.TotalJumps
        {
            get => TotalJumps;
            set => TotalJumps = value;
        }

        int IPlayerActionStatistics.TotalWallJumps
        {
            get => TotalWallJumps;
            set => TotalWallJumps = value;
        }

        int IPlayerActionStatistics.TotalDashes
        {
            get => TotalDashes;
            set => TotalDashes = value;
        }
    }
}
