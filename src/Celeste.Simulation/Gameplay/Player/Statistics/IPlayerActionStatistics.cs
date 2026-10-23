namespace Celeste.Simulation.Gameplay.Player.Statistics
{
    public interface IPlayerActionStatistics
    {
        int TotalJumps { get; set; }
        int TotalWallJumps { get; set; }
        int TotalDashes { get; set; }
    }
}
