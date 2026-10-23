using Celeste.Core.Threading;
using Celeste.Everest.Content.Maps.Metadata;
using Celeste.Game.Execution.Areas;
using Celeste.Simulation.Audio;
using Celeste.Simulation.Gameplay.Player.Inventory;

namespace Celeste.Everest.Content.Maps.Registry
{
    public sealed class InstalledAreaDataFactory : IOriginalAreaDataFactory
    {
        private readonly SourceTypeInitialization<InstalledAreaSourceStatics> sourceStatics;

        public InstalledAreaDataFactory(SourceTypeInitialization<InstalledAreaSourceStatics> sourceStatics)
        {
            this.sourceStatics = sourceStatics;
        }

        public OriginalAreaData Create()
        {
            _ = sourceStatics.Value;
            return new EverestArea();
        }

        public OriginalAreaModeData CreateMode()
        {
            return new EverestAreaModeData();
        }

        public OriginalCheckpointData CreateCheckpoint(string level, string name,
            RoomPlayerInventory? inventory = null,
            bool dreaming = false, RoomAudioState audioState = null)
        {
            return new EverestCheckpointData(
                level, name, inventory, dreaming, audioState);
        }
    }
}
