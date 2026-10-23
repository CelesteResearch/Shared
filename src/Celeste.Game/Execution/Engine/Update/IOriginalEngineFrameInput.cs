namespace Celeste.Game.Execution.Engine.Update
{
    public interface IOriginalEngineFrameInput
    {
        void Update(float deltaTime);
        bool EscapePressed { get; }
        bool DashHeld { get; }
    }
}
