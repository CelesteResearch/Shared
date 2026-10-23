using Celeste.Game.Execution.Areas;
using Celeste.Core.Threading;

namespace Celeste.Everest.Content.Maps.Registry
{
    public sealed class InstalledAreaDataFactory : IOriginalAreaDataFactory
    {
        private readonly SourceTypeInitialization<InstalledAreaSourceStatics> sourceStatics;

        public InstalledAreaDataFactory(SourceTypeInitialization<InstalledAreaSourceStatics> sourceStatics)
            => this.sourceStatics = sourceStatics;

        public OriginalAreaData Create()
        {
            _ = sourceStatics.Value;
            return new EverestArea();
        }

        public OriginalAreaModeData CreateMode() => new EverestAreaModeData();

        public OriginalCheckpointData CreateCheckpoint(string level, string name,
            global::Celeste.Simulation.Gameplay.Player.Inventory.RoomPlayerInventory? inventory = null,
            bool dreaming = false, global::Celeste.Simulation.Audio.RoomAudioState audioState = null)
            => new global::Celeste.Everest.Content.Maps.Metadata.EverestCheckpointData(
                level, name, inventory, dreaming, audioState);
    }
}
