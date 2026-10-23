namespace Celeste.Game.Execution.Engine.Update
{
    public interface IOriginalEngineCommands
    {
        bool Open { get; }
        bool Enabled { get; }
        void UpdateOpen();
        void UpdateClosed();
    }
}
