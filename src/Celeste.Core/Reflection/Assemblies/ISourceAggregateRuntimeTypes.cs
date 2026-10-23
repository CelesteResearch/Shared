using System;
using System.Collections.Generic;

namespace Celeste.Core.Reflection.Assemblies
{
    public interface ISourceAggregateRuntimeTypes
    {
        IEnumerable<Type> GetAggregateRuntimeTypes();
        Type GetAggregateRuntimeType(string name, bool ignoreCase);
    }
}
