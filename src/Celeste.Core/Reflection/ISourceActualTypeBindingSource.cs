using System;
using System.Collections.Generic;

namespace Celeste.Core.Reflection
{
    // Borrow the existing qualified runtime type registry; do not copy its mappings.
    public interface ISourceActualTypeBindingSource
    {
        long ActualSourceBindingsRevision { get; }
        IEnumerable<Type> ActualSourceTypes { get; }
        bool TryGetSelectedActualSourceType(string assemblyIdentity, string originalIdentity, out Type actualType);
        bool TryGetActualSourceType(string assemblyIdentity, string originalIdentity, out Type actualType);
        bool TryGetOriginalSourceType(Type actualType, out string assemblyIdentity, out string originalIdentity);
    }
}
