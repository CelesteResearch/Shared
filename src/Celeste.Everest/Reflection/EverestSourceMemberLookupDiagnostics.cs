using System;
using Celeste.Core.Reflection.Members;
using Celeste.Everest.Diagnostics.Logging;

namespace Celeste.Everest.Reflection
{
    public sealed class EverestSourceMemberLookupDiagnostics : ISourceMemberLookupDiagnostics
    {
        private readonly EverestLoggerProcess logger;

        public EverestSourceMemberLookupDiagnostics(EverestLoggerProcess logger)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public void MissingMember(Type actualType, string originalTypeFullName, string memberName,
            SourceMemberKind kind)
        {
            var name = kind == SourceMemberKind.Field ? "field" : "property";
            logger.Log(EverestLogLevel.Error, "CelesteTAS",
                $"Failed to find {name} '{memberName}' on type '{originalTypeFullName}'");
        }
    }
}
