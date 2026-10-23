using Celeste.Core.Maps;
using System;

namespace Celeste.Simulation.Content
{
    public delegate bool RidgeGateCollectiblesRule(MapElement source, Func<MapEntityId, bool> collected,
        Func<MapEntityId, bool> doNotLoad);
}
