using System;
using Celeste.Core.Maps;

namespace Celeste.Simulation.Content
{
    public delegate bool RidgeGateCollectiblesRule(MapElement source, Func<MapEntityId, bool> collected,
        Func<MapEntityId, bool> doNotLoad);
}
