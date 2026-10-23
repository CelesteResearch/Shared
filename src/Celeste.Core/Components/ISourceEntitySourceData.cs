using Celeste.Core.Maps;

namespace Celeste.Core.Components
{
    public interface ISourceEntitySourceData
    {
        object SourceData { get; set; }
        MapEntityId SourceId { get; set; }
    }
}
