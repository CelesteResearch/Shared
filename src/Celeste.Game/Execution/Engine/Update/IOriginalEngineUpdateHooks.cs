using Celeste.Core.Scheduling;

namespace Celeste.Game.Execution.Engine.Update
{
    // Runtime patch points, in source order. Scene update algorithms stay on the actual scene.
    public interface IOriginalEngineUpdateHooks
    {
        bool PausedAfterInput { get; }
        void PreEngineUpdate();
        void PostEngineUpdate();
        void BeforeFreezeTimerDecrement(ISourceSceneExecution scene);
    }
}
