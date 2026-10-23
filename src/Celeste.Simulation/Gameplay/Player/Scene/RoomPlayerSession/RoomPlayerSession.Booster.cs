using Celeste.Simulation.Gameplay.Interaction.Booster;

namespace Celeste.Simulation
{
    public sealed partial class RoomPlayerSession
    {
        public ISourceBooster CurrentBooster, LastBooster;
        public void Boost(ISourceBooster booster) => boostSequence.Boost(booster, false);
        public void RedBoost(ISourceBooster booster) => boostSequence.Boost(booster, true);
    }
}
