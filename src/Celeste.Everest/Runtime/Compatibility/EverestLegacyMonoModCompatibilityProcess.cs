using Celeste.Everest.Diagnostics.Logging;

namespace Celeste.Everest.Runtime.Compatibility
{
    public sealed class EverestLegacyMonoModCompatibilityProcess
    {
        private readonly EverestLegacyDynamicDataHookProcess hooks;
        private readonly EverestLoggerProcess logger;

        public EverestLegacyMonoModCompatibilityProcess(EverestLegacyDynamicDataHookProcess hooks,
            EverestLoggerProcess logger)
        {
            this.hooks = hooks;
            this.logger = logger;
        }

        public void Initialize()
        {
            hooks.InstallHook();
            logger.Log(EverestLogLevel.Info, "legacy-monomod", "Initialized legacy MonoMod compatibility layer");
        }

        public void Uninitialize()
        {
            hooks.UninstallHook();
            logger.Log(EverestLogLevel.Info, "legacy-monomod", "Uninitialized legacy MonoMod compatibility layer");
        }
    }
}
