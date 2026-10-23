using Celeste.Everest.Gameplay.Hazards.Spikes;

namespace Celeste.Everest.Modules.Core
{
    public partial class SourceCoreModule
    {
        private SpikeAttachmentBounds spikeAttachmentBounds;

        private void InstallSourceSpikeAttachmentBounds()
        {
            var bounds = SpikeAttachmentBounds.For(SourceEngine);
            try
            {
                bounds.Install();
                spikeAttachmentBounds = bounds;
            }
            catch
            {
                bounds.Dispose();
                throw;
            }
        }
    }
}
