using System.Collections.Generic;

namespace Celeste.Core.Reflection.Assemblies
{
    public interface ISourceAggregateAssemblyOrder
    {
        IEnumerable<string> GetOriginalAggregateAssemblyOrder();
    }
}
