using System.Collections;

namespace Celeste.Everest.Modules.Persistence.GameSaves
{
    public interface IEverestSaveSettingsEnvironment
    {
        IEverestSaveSettingsProcess SaveSettingsProcess { get; }
    }
}
