using Celeste.Core.Scheduling;

namespace Celeste.Game.Save.Runtime
{
    public interface IOriginalUserIOProcess
    {
        bool Saving { get; }
        SimulationCoroutine SaveRoutine { get; }
        void SaveHandler(bool file, bool settings);
    }
}
