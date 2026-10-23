using Celeste.Everest.Content.Maps.Registry;
using Celeste.Game.Execution.Areas;

namespace Celeste.Everest.Content.Maps.Metadata
{
    public partial class EverestModeMetadata
    {
        public void ApplyTo(EverestArea area, int mode)
        {
            area.Metadata.Modes[mode] = this;
            OriginalAreaModeData properties = area.Mode[mode];
            if (properties != null)
            {
                properties.AudioState = AudioState?.Convert() ?? properties.AudioState;
                properties.Checkpoints = EverestMapMetadata.Convert(Checkpoints) ?? properties.Checkpoints;
                properties.IgnoreLevelAudioLayerData =
                    IgnoreLevelAudioLayerData ?? properties.IgnoreLevelAudioLayerData;
                properties.Inventory = EverestMapMetadata.GetInventory(Inventory) ?? properties.Inventory;
                properties.Path = Path ?? properties.Path;
                properties.PoemID = PoemID ?? properties.PoemID;
            }
            else properties = Convert();

            area.Mode[mode] = properties;
        }
    }
}
