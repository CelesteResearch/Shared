namespace Celeste.Game.Save.Runtime
{
    public interface IOriginalSaveSessionSelectionEnvironment
    {
        IOriginalSaveSessionSelectionPolicy SaveSessionSelection { get; }
    }
}
