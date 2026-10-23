using System;

namespace Celeste.Core.Reflection.Members
{
    public interface ISourceMemberLookupDiagnostics
    {
        void MissingMember(Type actualType, string originalTypeFullName, string memberName, SourceMemberKind kind);
    }
}
