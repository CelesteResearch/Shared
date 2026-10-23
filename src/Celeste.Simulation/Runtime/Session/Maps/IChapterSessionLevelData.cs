using System.Collections.Generic;
using System.Numerics;

namespace Celeste.Simulation.Runtime.Session.Maps
{
    public interface IChapterSessionLevelData
    {
        string Name { get; }
        List<Vector2> Spawns { get; }
    }
}
