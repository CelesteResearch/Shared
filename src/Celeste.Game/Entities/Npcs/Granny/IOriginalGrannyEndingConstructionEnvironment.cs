using System.Numerics;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Structure;

namespace Celeste.Game.Entities.Npcs.Granny
{
    public interface IOriginalGrannyEndingConstructionEnvironment
    {
        IOriginalGrannyEndingConstructionPolicy GrannyEndingConstruction { get; }
    }
}
