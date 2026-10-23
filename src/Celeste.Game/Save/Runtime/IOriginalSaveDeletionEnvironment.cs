namespace Celeste.Game.Save.Runtime
{
    public interface IOriginalSaveDeletionEnvironment
    {
        IOriginalSaveDeletionPolicy SaveDeletion { get; }
        IOriginalSaveDeletionServices SaveDeletionServices { get; }
    }
}
