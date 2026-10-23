using System.Collections;
using Celeste.Everest.Modules.Persistence.GameSaves;
using Celeste.Game.Execution.Threading;
using Celeste.Game.Save.Runtime;
using Celeste.Simulation.Presentation.Hud.Saving;

namespace Celeste.Everest.Modules.Runtime
{
    public sealed partial class SourceEverestModulesProcess : IEverestSaveSettingsProcess
    {
        private bool _SavingSettings;
        public bool SavingSettings => _SavingSettings;

        public IEnumerator SaveSettings()
        {
            if (_SavingSettings) return SaveNoSettings();
            _SavingSettings = true;
            return new SourceSafeRoutine(SaveSettingsRoutine(), sourceEngine);
        }

        private IEnumerator SaveNoSettings()
        {
            yield break;
        }

        private IEnumerator SaveSettingsRoutine()
        {
            bool saving = true;
            ((IOriginalThreadEnvironment)sourceEngine).Threads.Start(() =>
            {
                foreach (var module in Modules) module.SaveSettings();
                saving = false;
            }, "MOD_IO");
            var icons = ((ISaveLoadIconEnvironment)sourceEngine).SaveLoadIconProcess;
            icons.Show(sourceEngine.Frame.Scenes.CurrentScene);
            while (saving) yield return null;
            yield return ((EverestUserIOProcess)((IOriginalUserIOEnvironment)sourceEngine).UserIO).SaveHandlerLegacy(
                false,
                true);
            icons.Hide();
            _SavingSettings = false;
        }
    }
}
