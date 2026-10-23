using System;
using System.Collections.Generic;
using Celeste.Everest.Modules.Runtime;
using Celeste.Everest.Modules.Persistence.GameSaves;
using Celeste.Game.Profiles;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : ISourceEverestModulesEnvironment, IEverestSaveModulesEnvironment
    {
        private SourceEverestModulesProcess sourceModulesProcess;

        public SourceEverestModulesProcess ModulesProcess => sourceModulesProcess ??
                                                             throw new InvalidOperationException(
                                                                 "The actual installed modules process is not constructed.");

        public List<SourceEverestModule> Modules => ModulesProcess.Modules;
        public List<SourceEverestModule> SaveModules => Modules;

        public void ConstructSourceInstalledModuleRoster()
        {
            if (SourceProfile != GameProfile.InstalledEverest)
                throw new InvalidOperationException("The original profile has no installed module roster.");
            if (sourceModulesProcess != null)
                throw new InvalidOperationException("The actual installed module roster is already constructed.");
            sourceModulesProcess = new SourceEverestModulesProcess(this);
        }
    }
}
