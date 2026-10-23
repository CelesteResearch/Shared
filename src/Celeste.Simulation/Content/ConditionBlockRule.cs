using System;
using Celeste.Core.Maps;

namespace Celeste.Simulation.Content
{
    public delegate bool ConditionBlockRule(MapElement source, Func<string, bool> getFlag,
        Func<MapEntityId, bool> doNotLoad, Func<MapEntityId, bool> strawberry);
}
