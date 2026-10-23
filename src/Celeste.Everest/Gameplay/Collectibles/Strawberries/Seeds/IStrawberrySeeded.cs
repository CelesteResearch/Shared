using System.Collections.Generic;
using Celeste.Core.Reflection.Runtime;

namespace Celeste.Everest.Gameplay.Collectibles.Strawberries.Seeds
{
    [RuntimeTypeAlias("Celeste.Mod.IStrawberrySeeded")]
    public interface IStrawberrySeeded
    {
        void CollectedSeeds();
        List<GenericStrawberrySeed> Seeds { get; }
        string gotSeedFlag { get; }
        bool WaitingOnSeeds { get; }
    }
}
