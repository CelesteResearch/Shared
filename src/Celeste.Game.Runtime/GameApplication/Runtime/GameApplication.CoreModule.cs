using System;
using Celeste.Everest;
using Celeste.Everest.Modules.Core;
using Celeste.Everest.Modules.Runtime;
using Celeste.Everest.Modules.Settings;
using Celeste.Everest.UI.Controls;
using Celeste.Everest.UI.ModOptions;
using Celeste.Everest.UI.Settings;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : IEverestCoreModuleEnvironment,
        IEverestCoreSettingsEnvironment,
        IEverestCurrentCoreSettingsEnvironment,
        IEverestModOptionsEnvironment, IEverestControlConfigEnvironment,
        IEverestFileNamingEnvironment
    {
        private SourceCoreModule sourceCoreModule;
        private EverestOverworldUiProcess sourceEverestUi;

        public SourceCoreModule ActualCoreModule => sourceCoreModule ??
                                                    throw new InvalidOperationException(
                                                        "The actual core module has not been constructed.");

        public SourceEverestModule CoreModule => ActualCoreModule;
        public EverestCoreSettings CurrentCoreSettings => (EverestCoreSettings)ActualCoreModule._Settings;

        EverestCoreSettings IEverestControlConfigEnvironment.CoreSettings =>
            CurrentCoreSettings;

        EverestCoreSettings IEverestFileNamingEnvironment.CoreSettings =>
            CurrentCoreSettings;

        public EverestOverworldUiProcess EverestUI => sourceEverestUi ??
                                                      throw new InvalidOperationException(
                                                          "The actual installed overworld UI process has not been constructed.");

        internal void ConstructSourceInstalledUiProcess()
        {
            if (sourceEverestUi != null)
                throw new InvalidOperationException(
                    "The actual installed overworld UI process is already constructed.");
            sourceEverestUi = new();
        }

        internal void ConstructSourceCoreModule()
        {
            if (sourceCoreModule != null)
                throw new InvalidOperationException("The actual core module is already constructed.");
            sourceCoreModule = new(this);
        }
    }
}
