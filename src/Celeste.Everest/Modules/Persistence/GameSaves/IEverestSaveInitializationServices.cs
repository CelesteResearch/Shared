using Celeste.Game.Save.Data;
using Celeste.Game.Save.Runtime;

namespace Celeste.Everest.Modules.Persistence.GameSaves
{
// Required IO and input-state publication; initialization CPU stays in the source policy.
    public interface
        IEverestSaveInitializationServices : IOriginalSaveInitializationServices
    {
        OriginalModSaveData LoadModBackup(string filename, bool backup);
        void WarnBackupRestored(int levelSetCount, string filename);
    }
}
