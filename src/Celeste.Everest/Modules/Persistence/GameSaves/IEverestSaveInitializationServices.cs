namespace Celeste.Everest.Modules.Persistence.GameSaves
{
// Required IO and input-state publication; initialization CPU stays in the source policy.
    public interface
        IEverestSaveInitializationServices : Celeste.Game.Save.Runtime.IOriginalSaveInitializationServices
    {
        Celeste.Game.Save.Data.OriginalModSaveData LoadModBackup(string filename, bool backup);
        void WarnBackupRestored(int levelSetCount, string filename);
    }
}
