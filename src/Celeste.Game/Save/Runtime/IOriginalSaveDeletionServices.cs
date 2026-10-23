namespace Celeste.Game.Save.Runtime
{
// Only source storage/path operations cross this boundary; the selected policy
// retains all branch, module, file ordering and loaded-slot publication logic.
    public interface IOriginalSaveDeletionServices
    {
        string GetSaveFilePath(string name);
        bool Exists(string name);
        bool Delete(string name);
    }
}
