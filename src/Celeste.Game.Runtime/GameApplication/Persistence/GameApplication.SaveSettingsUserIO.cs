using System;
using System.IO;
using Celeste.Everest;
using Celeste.Everest.Content.Maps.Registry;
using Celeste.Everest.Diagnostics.Logging;
using Celeste.Everest.Modules.Persistence.GameSaves;
using Celeste.Everest.Runtime.Threading;
using Celeste.Everest.Settings;
using Celeste.Game.Content.Dialogs;
using Celeste.Game.Execution;
using Celeste.Game.Execution.Areas;
using Celeste.Game.Execution.Engine;
using Celeste.Game.Execution.Graphics;
using Celeste.Game.Execution.Session;
using Celeste.Game.Execution.Startup;
using Celeste.Game.Execution.Threading;
using Celeste.Game.Platform.Statistics;
using Celeste.Game.Save.Data;
using Celeste.Game.Save.Formats.Original;
using Celeste.Game.Save.IO;
using Celeste.Game.Save.Runtime;
using Celeste.Game.Settings;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content;
using Celeste.Scene.Components.Oscillation;
using Celeste.Simulation.Presentation.Hud.Saving;
using Celeste.Simulation.Runtime.Session.Maps;
using Profile = Celeste.Game.Profiles.GameProfile;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : IOriginalUserIOFormatEnvironment,
        IOriginalUserIOStorageEnvironment, IOriginalUserIOEnvironment,
        IOriginalSaveCounterEnvironment, IOriginalAreaKeyEnvironment,
        IOriginalSessionEnvironment, IOriginalSessionConstructionProcess, ISettingsContext,
        IOriginalSaveInitializationEnvironment, IEverestSaveSettingsEnvironment,
        IOriginalSaveCompletionEnvironment, IEverestSaveInitializationServices,
        ISaveLoadIconResources, ISaveLoadIconEnvironment, IOriginalGameErrorIdentity, IOriginalThreadFailureOutput
    {
        SaveLoadIconProcess ISaveLoadIconEnvironment.SaveLoadIconProcess
        {
            get
            {
                _ = UserIO;
                return sourceSaveIcons;
            }
        }

        void IOriginalThreadFailureOutput.WriteErrorLog(Exception exception)
        {
            ErrorLog.Write(exception);
        }

        void IOriginalThreadFailureOutput.OpenErrorLog()
        {
            ErrorLog.Open();
        }

        void IOriginalThreadFailureOutput.ExitGame()
        {
            ActualGame.GameLoop.Exit();
        }

        private readonly OriginalGameSaveContext sourceSaveContext = new();
        private IOriginalAreaKeyPolicy sourceAreaKeys;
        private OriginalSessionFactory sourceSessions;
        private IChapterSessionData sourceSessionMaps;
        private IOriginalSaveCounterQueries sourceSaveCounters;
        private OriginalUserIOStorage sourceUserIOStorage;
        private OriginalUserIOProcess sourceUserIO;
        private OriginalGameThreadSession sourceSaveThreads;
        private SaveLoadIconProcess sourceSaveIcons;
        public IOriginalGameSaveContext SaveContext => sourceSaveContext;
        public SettingsState Settings => SettingsProcess.Instance;

        public OriginalUserIOStorage UserIOStorage => sourceUserIOStorage ??
                                                      throw new InvalidOperationException(
                                                          "The source storage has not been constructed.");

        public IOriginalAreaKeyPolicy AreaKeys
        {
            get
            {
                if (sourceAreaKeys == null)
                    sourceAreaKeys = SourceProfile == Profile.Original
                        ? new OriginalAreaKeyPolicy((IOriginalAreaSourceTable)engine)
                        : new EverestAreaKeyPolicy((IOriginalAreaSourceTable)engine,
                            (ISourceAreaReloadLockEnvironment)engine,
                            (IEverestLoggerProcessEnvironment)engine);
                return sourceAreaKeys;
            }
        }

        public OriginalSessionFactory Sessions => sourceSessions ??=
            new((IOriginalSessionConstructionProcess)engine);

        public IOriginalAreaSourceTable AreaTable => (IOriginalAreaSourceTable)engine;

        public IChapterSessionData SessionMaps
            => sourceSessionMaps ??= new OriginalAreaSessionMaps((IOriginalAreaSourceTable)engine);

        public IOriginalAreaStatsPolicy AreaStats => (IOriginalAreaStatsPolicy)SaveCounters;

        public IOriginalSaveCounterQueries SaveCounters
        {
            get
            {
                if (sourceSaveCounters == null)
                {
                    sourceSaveCounters = SourceProfile == Profile.Original
                        ? new OriginalSaveRuntimePolicy((IOriginalSaveCompletionEnvironment)engine,
                            (IOriginalAreaSourceTable)engine, sourceSaveContext,
                            (IOriginalEngineIdentityEnvironment)engine,
                            (IOriginalPlatformStatisticsEnvironment)engine)
                        : new EverestSaveRuntimePolicy((IOriginalSaveCompletionEnvironment)engine,
                            (IOriginalAreaSourceTable)engine, sourceSaveContext, AreaKeys,
                            (IEverestLoggerProcessEnvironment)engine,
                            (IOriginalEngineIdentityEnvironment)engine,
                            (IEverestSaveModulesEnvironment)engine,
                            (IOriginalPlatformStatisticsEnvironment)engine);
                    sourceSaveContext.BindCounterQueries(sourceSaveCounters);
                    sourceSaveContext.BindCompletionPolicy((IOriginalSaveCompletionPolicy)sourceSaveCounters);
                    sourceSaveContext.BindStrawberryPolicy((IOriginalStrawberrySavePolicy)sourceSaveCounters,
                        ((IOriginalPlatformStatisticsEnvironment)engine).Statistics);
                }

                return sourceSaveCounters;
            }
        }

        public IOriginalSaveAllocationPolicy SaveAllocation => (IOriginalSaveAllocationPolicy)SaveCounters;
        public IOriginalSaveInitializationPolicy SaveInitialization => (IOriginalSaveInitializationPolicy)SaveCounters;

        public IOriginalSaveInitializationServices SaveInitializationServices => this;
        string IOriginalGameErrorIdentity.Title => ((IOriginalEngineIdentityEnvironment)engine).EngineIdentity.Title;

        Version IOriginalGameErrorIdentity.Version =>
            ((IOriginalEngineIdentityEnvironment)engine).EngineIdentity.Version;

        ISpriteFactory ISaveLoadIconResources.GuiSpriteBank
            => ((OriginalGameGraphicsResources)
                ((ISourceGameGraphicsEnvironment)engine).GameGraphics).GuiSpriteBank;

        WigglerComponentPool ISaveLoadIconResources.WigglerPool
            => ((ISourceWigglerPoolScope)engine).WigglerPool;

        int ISaveLoadIconResources.Tags
            => ((IOriginalGameTagsEnvironment)engine).Tags.HUD.Value
               | ((IOriginalGameTagsEnvironment)engine).Tags.FrozenUpdate.Value
               | ((IOriginalGameTagsEnvironment)engine).Tags.PauseUpdate.Value
               | ((IOriginalGameTagsEnvironment)engine).Tags.Global.Value;

        public bool EventMode =>
            ((IOriginalGamePlayModeEnvironment)engine).PlayMode
            == GameRuntime.PlayModes.Event;

        public int AreaCount => ((IOriginalAreaSourceTable)engine).Areas.Count;

        string IOriginalSaveInitializationServices.CleanDialog(string key)
        {
            return ((IOriginalGameTextEnvironment)engine).Text.CleanDialog(key);
        }

        void IOriginalSaveInitializationServices.SetInputInversion(bool mirrorMode)
        {
            InputSource.MoveX.Inverted = InputSource.Aim.InvertedX = InputSource.Feather.InvertedX = mirrorMode;
        }

        OriginalModSaveData IEverestSaveInitializationServices.LoadModBackup(
            string filename, bool backup)
        {
            return UserIOStorage.Load<OriginalModSaveData>(filename, backup);
        }

        void IEverestSaveInitializationServices.WarnBackupRestored(int levelSetCount, string filename)
        {
            var logger = ((IEverestLoggerProcessEnvironment)engine).Logger;
            if (logger.GetLogLevel("SaveData") <= EverestLogLevel.Warn)
                logger.Log(EverestLogLevel.Warn, "SaveData", string.Format(
                    "{0} level set(s) were restored from mod backup for save slot {1}", levelSetCount, filename));
        }

        public IOriginalUserIOProcess UserIO
        {
            get
            {
                if (sourceUserIO == null)
                {
                    var storage = UserIOStorage;
                    sourceSaveThreads = SourceProfile == Profile.Original
                        ? new(this, PhysicalIO.LoadingWorkScheduler)
                        : new OriginalGameThreadSession(this,
                            OriginalGameThreadProfile.Installed, (IOriginalThreadAbortDiagnostics)engine,
                            PhysicalIO.LoadingWorkScheduler);
                    sourceSaveIcons = new(engine, (ISaveLoadIconResources)engine);
                    sourceUserIO = SourceProfile == Profile.Original
                        ? new OriginalUserIOProcess(engine, sourceSaveContext, this,
                            sourceSaveThreads, sourceSaveIcons, storage,
                            (IOriginalSavePreparationPolicy)SaveCounters, SaveInitialization)
                        : new EverestUserIOProcess(engine, sourceSaveContext, this,
                            sourceSaveThreads, sourceSaveIcons, storage,
                            (IOriginalSavePreparationPolicy)SaveCounters, SaveInitialization,
                            (IEverestSaveModulesEnvironment)engine, (IEverestLoggerEnvironment)engine,
                            (IEverestSaveInitializationServices)engine);
                }

                return sourceUserIO;
            }
        }

        public IEverestSaveSettingsProcess SaveSettingsProcess => ModulesProcess;

        // Call before constructing OriginalCelesteProcess. Only the thread failure output
        // and already bound physical path device are IO loans; every CPU object is born here.
        public void ConstructSourceSaveSettingsUserIO()
        {
            if (sourceUserIOStorage != null)
                throw new InvalidOperationException("The source storage has already been constructed.");
            if (SourceProfile == Profile.Original)
            {
                BindSettingsAllocation(new OriginalSettingsAllocationPolicy(new()));
                BindSaveXmlFormat(new OriginalSaveXmlFormatPolicy());
            }
            else
            {
                BindSettingsAllocation(new InstalledSettingsAllocationPolicy(new()));
                BindSaveXmlFormat(new EverestSaveXmlFormatPolicy());
            }

            var format = new OriginalUserIOFormat(this);
            if (SourceProfile == Profile.Original)
            {
                sourceUserIOStorage = new(format,
                    (IOriginalGameErrorIdentity)engine,
                    Path.Combine(PhysicalIO.SavePaths.ApplicationBaseDirectory, "Saves"),
                    Path.Combine(PhysicalIO.SavePaths.ApplicationBaseDirectory, "Backups"));
            }
            else
            {
                sourceUserIOStorage = new EverestUserIOStorage(format,
                    (IOriginalGameErrorIdentity)engine, null, null,
                    (IEverestLoggerEnvironment)engine, (ISourceEverestMainThreadEnvironment)engine);
                EverestUserIOPathInitialization.Initialize(sourceUserIOStorage, PhysicalIO.SavePaths);
            }

            // Settings branch reads only SettingsAllocation. No AreaKeys, Sessions,
            // SaveCounters or save allocation is read by this call.
            SettingsProcess.Initialize(sourceUserIOStorage, SettingsAllocation);
        }
    }
}
