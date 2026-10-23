using System.Numerics;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Structure;

namespace Celeste.Game.Gameplay.Environment.Water
{
    public interface IOriginalWaterConstructionEnvironment
    {
        IOriginalWaterConstructionPolicy WaterConstruction { get; }
    }
}
