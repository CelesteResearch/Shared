using System;
using System.Collections.Generic;
using System.Reflection;
using Celeste.Everest.Diagnostics.Logging;
using Celeste.Everest.Modules.Runtime;

namespace Celeste.Everest.Runtime.Compatibility
{
    public sealed class EverestMonoModPoliceProcess
    {
        private readonly IEverestLegacyAssemblyMetadataEnvironment environment;
        private readonly EverestLoggerProcess Logger;

        public EverestMonoModPoliceProcess(IEverestLegacyAssemblyMetadataEnvironment environment,
            EverestLoggerProcess logger)
        {
            this.environment = environment ?? throw new ArgumentNullException(nameof(environment));
            Logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public sealed class MonoModCrimeException : Exception
        {
            public MonoModCrimeException(string descr)
                : base("MONOMOD CRIME DETECTED - THIS IS A BUG: " + descr)
            {
            }
        }

        private readonly HashSet<(string descr, Assembly perpetrator, string backtrace)> loggedCrimes = [];

        public void ReportMonoModCrime(string descr, MethodBase perpetrator)
        {
            Module perpetrator2 = null;
            try
            {
                perpetrator2 = perpetrator.Module;
            }
            catch
            {
            }

            ReportMonoModCrime(descr, perpetrator2);
        }

        public void ReportMonoModCrime(string descr)
        {
            ReportMonoModCrime(descr, (Assembly)null);
        }

        public void ReportMonoModCrime(string descr, Module perpetrator)
        {
            ReportMonoModCrime(descr, perpetrator?.Assembly);
        }

        public void ReportMonoModCrime(string descr, Assembly perpetrator)
        {
            EverestModuleMetadata everestModuleMetadata = null;
            if (perpetrator != null)
                everestModuleMetadata = environment.LegacyAssemblyMetadataRuntime.GetContextModuleMetadata(perpetrator);

            if (!string.IsNullOrWhiteSpace(everestModuleMetadata?.PathDirectory) ||
                loggedCrimes.Add((descr, perpetrator, Environment.StackTrace)))
            {
                Logger.Log(EverestLogLevel.Error, "legacy-monomod",
                    "##################################################################################");
                Logger.Log(EverestLogLevel.Error, "legacy-monomod",
                    "                              MONOMOD CRIME DETECTED                              ");
                Logger.Log(EverestLogLevel.Error, "legacy-monomod",
                    "##################################################################################");
                Logger.Log(EverestLogLevel.Error, "legacy-monomod",
                    "                 !!! This means one of your mods has a bug !!!                    ");
                Logger.Log(EverestLogLevel.Error, "legacy-monomod",
                    "   However, for the sake of backwards compatibility, a crash has been prevented   ");
                Logger.Log(EverestLogLevel.Error, "legacy-monomod",
                    "      Please report this to the mod author so that they can fix their mod!        ");
                Logger.Log(EverestLogLevel.Error, "legacy-monomod", "");
                if (everestModuleMetadata != null)
                {
                    var message = Logger.BeginEnabledMessage("legacy-monomod", EverestLogLevel.Error);
                    if (message.ShouldLog)
                        message.Write("Suspected perpetrator: " + everestModuleMetadata.Name + " version " +
                                      everestModuleMetadata.VersionString + " [" + everestModuleMetadata.Version + "]");
                }

                var details = Logger.BeginEnabledMessage("legacy-monomod", EverestLogLevel.Error);
                if (details.ShouldLog)
                    details.Write("Details of infraction: " + descr);
                Logger.LogDetailed(EverestLogLevel.Error, "legacy-monomod", "Stacktrace:");
            }

            if (!string.IsNullOrEmpty(everestModuleMetadata?.PathDirectory)) throw new MonoModCrimeException(descr);
        }
    }
}
