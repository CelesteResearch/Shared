namespace Celeste.Game.Execution.Engine.Update
{
    public interface IOriginalEngineFrameDevice
    {
        void Exit();

        // Only framework device work remains here; the source component loop is shared.
        void FrameworkDispatcherUpdate();
    }
}
