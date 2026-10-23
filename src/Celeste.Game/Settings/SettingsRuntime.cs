using Celeste.Game.Save.IO;

namespace Celeste.Game.Settings
{
    public sealed class SettingsRuntime
    {
        public SettingsState Instance;
        public bool Existed;
        public string LastVersion;

        public void Initialize(OriginalUserIOStorage storage, ISettingsFactory allocation)
        {
            if (storage.Open(OriginalUserIOStorage.Mode.Read))
            {
                Instance = storage.Load<SettingsState>("settings");
                storage.Close();
            }

            Existed = Instance != null;
            if (Instance == null) Instance = allocation.Create();
        }
    }
}
