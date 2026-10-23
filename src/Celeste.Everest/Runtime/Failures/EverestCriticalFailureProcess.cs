using System;
using Celeste.Everest.Diagnostics.Logging;
using Celeste.Everest.Modules.Runtime;

namespace Celeste.Everest.Runtime.Failures
{
    public sealed class EverestCriticalFailureProcess : IEverestCriticalFailureProcess
    {
        private bool criticalFailureIsUnhandledException;
        private readonly EverestLoggerProcess logger;
        private readonly SourceEverestModulesProcess detours;
        private readonly EverestErrorLogProcess errors;
        private readonly ISourceFatalExitIo exit;

        public EverestCriticalFailureProcess(EverestLoggerProcess logger, SourceEverestModulesProcess detours,
            EverestErrorLogProcess errors, ISourceFatalExitIo exit)
        {
            this.logger = logger;
            this.detours = detours;
            this.errors = errors;
            this.exit = exit;
        }

        public void CriticalFailure(Exception exception)
        {
            detours.LogDetours();
            if (exception == null) exception = new Exception("Unknown exception");
            logger.LogDetailed(exception, "CRITICAL");
            errors.Write(exception);
            errors.Open();
            if (!criticalFailureIsUnhandledException) exit.Exit(-1);
        }

        public void UnhandledExceptionHandler(object sender, UnhandledExceptionEventArgs args)
        {
            if (args.IsTerminating)
            {
                criticalFailureIsUnhandledException = true;
                CriticalFailure((args.ExceptionObject as Exception) ?? new Exception("Unknown unhandled exception"));
            }
            else
                logger.LogDetailed((args.ExceptionObject as Exception) ?? new Exception("Unknown unhandled exception"),
                    "UNHANDLED");
        }
    }
}
