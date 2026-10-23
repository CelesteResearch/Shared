namespace Celeste.Simulation.Gameplay.Player.Runtime
{
    public interface ISourcePlayerAntiSoftlockLevel
    {
        bool CanPause { get; }
        string LevelSet { get; }
        void Pause(int startIndex = 0, bool minimal = false, bool quickReset = false);
    }
}
