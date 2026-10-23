using System;
using System.IO;

namespace Celeste.Core.Reflection.Members
{
    public sealed class SourceConsoleMemberLookupDiagnostics(TextWriter errors) : ISourceMemberLookupDiagnostics
    {
        private readonly TextWriter _errors = errors ?? throw new ArgumentNullException(nameof(errors));


        public void MissingMember(Type actualType, string originalTypeFullName,
            string memberName, SourceMemberKind kind)
        {
            var memberKind = kind == SourceMemberKind.Field ? "field" : "property";
            _errors.WriteLine($"Failed to find {memberKind} '{memberName}' on type '{originalTypeFullName}'");
        }
    }
}
