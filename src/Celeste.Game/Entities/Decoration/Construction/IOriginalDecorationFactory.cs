using System.Numerics;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Entities.Decoration.Cobwebs;
using Celeste.Game.Entities.Decoration.Wires;

namespace Celeste.Game.Entities.Decoration.Construction
{
    public interface IOriginalDecorationFactory
    {
        OriginalCobwebState CreateCobweb(EntityData data, Vector2 offset, ISourceEngineContext engine);
        OriginalWireState CreateWire(EntityData data, Vector2 offset, ISourceEngineContext engine);
    }
}
