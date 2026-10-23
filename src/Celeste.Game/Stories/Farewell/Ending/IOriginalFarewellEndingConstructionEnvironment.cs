using Celeste.Core.Scheduling;
using Celeste.Simulation;

namespace Celeste.Game.Stories.Farewell.Ending
{
    public interface IOriginalFarewellEndingConstructionEnvironment
    {
        IOriginalFarewellEndingConstructionPolicy FarewellEndingConstruction { get; }
    }
}
