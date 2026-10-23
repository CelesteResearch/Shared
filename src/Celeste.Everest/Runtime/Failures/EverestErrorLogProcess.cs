using System;
using System.IO;
using Celeste.Game.Execution.Diagnostics;
using Celeste.Everest.Diagnostics.Logging;
using Celeste.Everest.Modules.Runtime;

namespace Celeste.Everest.Runtime.Failures
{
    public sealed class EverestErrorLogProcess : OriginalErrorLogProcess
    {
        private readonly IEverestErrorLogEnvironment everest;
        private readonly EverestLoggerProcess logger;
        private readonly SourceEverestModulesProcess detours;

        public EverestErrorLogProcess(IOriginalErrorLogIo io, IEverestErrorLogEnvironment environment,
            EverestLoggerProcess logger, SourceEverestModulesProcess detours)
            : base(io, environment, GetLogPath(environment))
        {
            everest = environment;
            this.logger = logger;
            this.detours = detours;
        }

        protected override string GetVersionText() => everest.VersionCelesteString;

        public override void Write(Exception exception)
        {
            logger.LogDetailed(exception);
            detours.LogDetours();
            base.Write(exception);
        }

        public override void Open()
        {
            if (everest.GetEnvironmentVariable("EVEREST_NO_ERRORLOG_ON_CRASH") != "1" &&
                everest.Settings.OpenErrorLogOnCrash && !everest.IsHeadless)
                base.Open();
        }

        private static string GetLogPath(IEverestErrorLogEnvironment environment)
        {
            string platform = environment.Platform;
            if (platform.Equals("Linux") || platform.Equals("FreeBSD") || platform.Equals("OpenBSD") ||
                platform.Equals("NetBSD"))
            {
                string variable = environment.GetEnvironmentVariable("XDG_DATA_HOME");
                if (!string.IsNullOrEmpty(variable)) return Path.Combine(variable, "Celeste", "errorLog.txt");
                variable = environment.GetEnvironmentVariable("HOME");
                if (!string.IsNullOrEmpty(variable))
                    return Path.Combine(variable, ".local/share/Celeste", "errorLog.txt");
            }
            else if (platform.Equals("Mac OS X"))
            {
                string variable = environment.GetEnvironmentVariable("HOME");
                if (!string.IsNullOrEmpty(variable))
                    return Path.Combine(variable, "Library/Application Support/Celeste", "errorLog.txt");
            }
            else if (!platform.Equals("Windows"))
                return Path.Combine(environment.GetPrefPath(null, "Celeste"), "errorLog.txt");

            return Path.Combine(environment.BaseDirectory, "errorLog.txt");
        }
    }
}
