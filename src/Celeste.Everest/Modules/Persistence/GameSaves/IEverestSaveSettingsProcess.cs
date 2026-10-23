using System.Collections;

namespace Celeste.Everest.Modules.Persistence.GameSaves
{
    public interface IEverestSaveSettingsProcess
    {
        bool SavingSettings { get; }
        IEnumerator SaveSettings();
    }
}
