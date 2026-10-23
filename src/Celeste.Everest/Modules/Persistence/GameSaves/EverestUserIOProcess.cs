using System;
using System.Collections.Generic;
using Celeste.Core.Scheduling;
using Celeste.Game.Execution.Threading;
using Celeste.Game.Save.Data;
using Celeste.Game.Save.IO;
using Celeste.Game.Save.Runtime;
using Celeste.Game.Settings;
using Celeste.Simulation.Presentation.Hud.Saving;
using Celeste.Everest.Diagnostics.Logging;
using Celeste.Everest.Modules.Runtime;
using Celeste.Everest.Settings;

namespace Celeste.Everest.Modules.Persistence.GameSaves
{
    public sealed partial class EverestUserIOProcess : OriginalUserIOProcess
    {
        private Queue<Tuple<bool, bool>> QueuedSaves;
        private List<Tuple<SourceEverestModule, byte[], byte[]>> savingModFileData;
        private byte[] savingMouseBindingsData;
        private readonly IEverestSaveModulesEnvironment modules;
        private readonly IEverestLoggerEnvironment coreSettings;
        private readonly IOriginalSaveInitializationServices initializationServices;
        public bool SaveQueued => QueuedSaves != null && QueuedSaves.Count > 0;

        public EverestUserIOProcess(ISourceEngineContext engine, IOriginalGameSaveContext saves,
            ISettingsContext settings, OriginalGameThreadSession threads,
            SaveLoadIconProcess icons, OriginalUserIOStorage storage,
            IOriginalSavePreparationPolicy preparation, IOriginalSaveInitializationPolicy initialization,
            IEverestSaveModulesEnvironment modules, IEverestLoggerEnvironment coreSettings,
            IOriginalSaveInitializationServices initializationServices)
            : base(engine, saves, settings, threads, icons, storage, preparation, initialization)
        {
            this.modules = modules;
            this.coreSettings = coreSettings;
            this.initializationServices = initializationServices;
        }

        public override void SaveHandler(bool file, bool settings)
        {
            if (QueuedSaves == null) QueuedSaves = new Queue<Tuple<bool, bool>>();
            if (Saving) QueuedSaves.Enqueue(Tuple.Create(file, settings));
            base.SaveHandler(file, settings);
        }

        protected override void AfterFileSerialized()
        {
            savingModFileData = new List<Tuple<SourceEverestModule, byte[], byte[]>>();
            savingModFileData.Add(Tuple.Create<SourceEverestModule, byte[], byte[]>(null,
                storage.Serialize(new OriginalModSaveData(saves.CurrentSave)), null));
            foreach (SourceEverestModule module in modules.SaveModules)
            {
                if (module.SaveDataAsync)
                {
                    savingModFileData.Add(Tuple.Create(module,
                        module.SerializeSaveData(saves.CurrentSave.FileSlot),
                        module.SerializeSession(saves.CurrentSave.FileSlot)));
                }
                else
                {
                    if (coreSettings.Settings.SaveDataFlush.GetValueOrDefault()) module.ForceSaveDataFlush += 2;
#pragma warning disable CS0618 // Preserve original legacy module override dispatch.
                    module.SaveSaveData(saves.CurrentSave.FileSlot);
#pragma warning restore CS0618
#pragma warning disable CS0618 // Preserve original legacy module override dispatch.
                    module.SaveSession(saves.CurrentSave.FileSlot);
#pragma warning restore CS0618
                }
            }

            initialization.AfterInitialize(saves.CurrentSave, initializationServices);
        }

        protected override void AfterSettingsSerialized()
        {
            savingMouseBindingsData = storage.Serialize(new VanillaMouseBindings().Init(settings));
        }

        protected override void OnSaveRoutineEnd()
        {
            if (QueuedSaves.Count > 0)
            {
                Tuple<bool, bool> queued = QueuedSaves.Dequeue();
                SaveHandler(queued.Item1, queued.Item2);
            }
        }

        protected override void SaveThread()
        {
            if (savingModFileData != null)
            {
                foreach (Tuple<SourceEverestModule, byte[], byte[]> tuple in savingModFileData)
                {
                    if (tuple.Item1 == null)
                        storage.Save<OriginalModSaveData>(
                            initialization.GetFilename(saves.CurrentSave.FileSlot) + "-modsavedata", tuple.Item2);
                    else
                    {
                        tuple.Item1.WriteSaveData(saves.CurrentSave.FileSlot, tuple.Item2);
                        tuple.Item1.WriteSession(saves.CurrentSave.FileSlot, tuple.Item3);
                    }
                }

                savingModFileData = null;
            }

            if (savingMouseBindingsData != null)
            {
                storage.Save<VanillaMouseBindings>("modsettings-Everest_MouseBindings", savingMouseBindingsData);
                savingMouseBindingsData = null;
            }

            base.SaveThread();
        }
    }
}
