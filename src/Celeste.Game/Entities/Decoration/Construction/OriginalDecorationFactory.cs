using System.Numerics;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Entities.Decoration.Cobwebs;
using Celeste.Game.Entities.Decoration.Wires;

namespace Celeste.Game.Entities.Decoration.Construction
{
    public class OriginalDecorationFactory : IOriginalDecorationFactory
    {
        public virtual OriginalCobwebState CreateCobweb(EntityData data, Vector2 offset,
            ISourceEngineContext engine)
            => new(data, offset, engine);

        public virtual OriginalWireState CreateWire(EntityData data, Vector2 offset, ISourceEngineContext engine)
            => new(data, offset, engine);
    }
}
