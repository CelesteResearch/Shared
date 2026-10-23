namespace Celeste.Game.Save.Runtime
{
    public interface IOriginalSaveDeletionPolicy
    {
        bool TryDelete(int slot, IOriginalSaveDeletionServices services);
    }
}
