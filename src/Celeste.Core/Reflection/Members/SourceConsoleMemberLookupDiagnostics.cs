using System;
using System.IO;

namespace Celeste.Core.Reflection.Members
{
    public sealed class SourceConsoleMemberLookupDiagnostics : ISourceMemberLookupDiagnostics
    {
        private readonly TextWriter errors;

        public SourceConsoleMemberLookupDiagnostics(TextWriter errors)
        {
            this.errors = errors ?? throw new ArgumentNullException(nameof(errors));
        }

        public void MissingMember(Type actualType, string originalTypeFullName,
            string memberName, SourceMemberKind kind)
        {
            string memberKind = kind == SourceMemberKind.Field ? "field" : "property";
            errors.WriteLine($"Failed to find {memberKind} '{memberName}' on type '{originalTypeFullName}'");
        }
    }
}
