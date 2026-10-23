using System.Numerics;
using Celeste.Core.Scheduling;
using Celeste.Scene.Scheduling;

namespace Celeste.Simulation.Rendering
{
    public interface IPlayerDashAssistScene
    {
        ISourceEngineContext EngineContext { get; }
        SceneUpdateScheduler Scheduler { get; }
        bool Paused { get; }
        void AddDashAssist(PlayerDashAssistPresentation entity);
        void PauseGameplaySfx(bool paused);
        void PlayDashAssistAim(Vector2 at, int direction);
    }
}
