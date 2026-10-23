using System.Collections.Generic;

namespace Celeste.Core.Components
{
    public interface ISourceTrackedComponents : ISourceComponentIndex
    {
        List<SourceComponentState> GetTrackedComponents(string sourceType);
    }
}
