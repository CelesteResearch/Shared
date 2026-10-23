namespace Celeste.Game.Save.Runtime
{
    public interface IOriginalUserIOProcess
    {
        bool Saving { get; }
        global::Celeste.Core.Scheduling.SimulationCoroutine SaveRoutine { get; }
        void SaveHandler(bool file, bool settings);
    }
}
