using System.Collections;
using Celeste.Core.Scheduling;
using Celeste.Game.Execution.Threading;
using Celeste.Game.Save.Data;
using Celeste.Game.Save.Errors;
using Celeste.Game.Save.IO;
using Celeste.Game.Settings;
using Celeste.Simulation.Presentation.Hud.Saving;

namespace Celeste.Game.Save.Runtime
{
// One source UserIO process: the worker, routine and engine all share these actual fields.
    public class OriginalUserIOProcess : IOriginalUserIOProcess
    {
        private bool savingInternal;
        private bool savingFile;
        private bool savingSettings;
        private byte[] savingFileData;
        private byte[] savingSettingsData;
        public bool Saving { get; private set; }
        public bool SavingResult { get; private set; }
        public SimulationCoroutine SaveRoutine { get; private set; }

        protected readonly ISourceEngineContext engine;
        protected readonly IOriginalGameSaveContext saves;
        protected readonly ISettingsContext settings;

        protected readonly OriginalGameThreadSession threads;
        protected readonly SaveLoadIconProcess icons;
        protected readonly OriginalUserIOStorage storage;
        private readonly IOriginalSavePreparationPolicy preparation;
        protected readonly IOriginalSaveInitializationPolicy initialization;

        public OriginalUserIOProcess(ISourceEngineContext engine, IOriginalGameSaveContext saves,
            ISettingsContext settings,
            OriginalGameThreadSession threads, SaveLoadIconProcess icons,
            OriginalUserIOStorage storage, IOriginalSavePreparationPolicy preparation,
            IOriginalSaveInitializationPolicy initialization)
        {
            this.engine = engine;
            this.saves = saves;
            this.settings = settings;

            this.threads = threads;
            this.icons = icons;
            this.storage = storage;
            this.preparation = preparation;
            this.initialization = initialization;
        }

        public virtual void SaveHandler(bool file, bool settings)
        {
            if (!Saving)
            {
                Saving = true;
                SaveRoutine = new(engine, Routine(file, settings));
            }
        }

        private IEnumerator Routine(bool file, bool saveSettings)
        {
            savingFile = file;
            savingSettings = saveSettings;
            FileErrorOverlayEntity menu;
            do
            {
                if (savingFile)
                {
                    preparation.BeforeSave(saves.CurrentSave);
                    savingFileData = storage.Serialize(saves.CurrentSave);
                    AfterFileSerialized();
                }

                if (savingSettings)
                {
                    savingSettingsData = storage.Serialize(settings.Settings);
                    AfterSettingsSerialized();
                }

                savingInternal = true;
                SavingResult = false;
                threads.Start(SaveThread, "USER_IO");
                icons.Show(engine.Frame.Scenes.CurrentScene);
                while (savingInternal) yield return null;
                icons.Hide();
                if (SavingResult) break;
                menu = new(FileErrorOverlayEntity.Error.Save, engine);
                while (menu.Open) yield return null;
            } while (menu.TryAgain);

            Saving = false;
            SaveRoutine = null;
            OnSaveRoutineEnd();
        }

        protected virtual void SaveThread()
        {
            SavingResult = false;
            if (storage.Open(OriginalUserIOStorage.Mode.Write))
            {
                SavingResult = true;
                if (savingFile)
                    SavingResult &=
                        storage.Save<OriginalSaveDataState>(initialization.GetFilename(saves.CurrentSave.FileSlot),
                            savingFileData);
                if (savingSettings)
                    SavingResult &= storage.Save<SettingsState>("settings", savingSettingsData);
                storage.Close();
            }

            savingInternal = false;
        }

        protected virtual void AfterFileSerialized()
        {
        }

        protected virtual void AfterSettingsSerialized()
        {
        }

        protected virtual void OnSaveRoutineEnd()
        {
        }
    }
}
