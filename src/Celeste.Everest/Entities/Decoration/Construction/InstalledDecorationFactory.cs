using System.Numerics;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Entities.Decoration.Cobwebs;
using Celeste.Game.Entities.Decoration.Wires;
using Celeste.Game.Entities.Decoration.Construction;
using Celeste.Everest.Entities.Decoration.Cobwebs;
using Celeste.Everest.Entities.Decoration.Wires;

namespace Celeste.Everest.Entities.Decoration.Construction
{
    public sealed class InstalledDecorationFactory : OriginalDecorationFactory
    {
        public override OriginalCobwebState CreateCobweb(EntityData data, Vector2 offset,
            ISourceEngineContext engine)
            => new InstalledCobwebState(data, offset, engine);

        public override OriginalWireState CreateWire(EntityData data, Vector2 offset,
            ISourceEngineContext engine)
            => new InstalledWireState(data, offset, engine);
    }
}
