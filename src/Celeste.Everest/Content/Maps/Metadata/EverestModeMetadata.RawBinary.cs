using System.Linq;
using Celeste.Everest.Content.Maps.Binary;
using Celeste.Formats.Map.Binary.Source;

namespace Celeste.Everest.Content.Maps.Metadata
{
    public partial class EverestModeMetadata
    {
        public EverestModeMetadata()
        {
        }

        public EverestModeMetadata(BinaryPackerElement meta)
        {
            Parse(meta);
        }

        public void Parse(BinaryPackerElement meta)
        {
            meta.AttrIfBool("IgnoreLevelAudioLayerData", delegate(bool v) { IgnoreLevelAudioLayerData = v; });
            meta.AttrIf("Inventory", delegate(string v) { Inventory = v; });
            meta.AttrIf("Path", delegate(string v) { Path = v; });
            meta.AttrIf("PoemID", delegate(string v) { PoemID = v; });
            meta.AttrIf("StartLevel", delegate(string v) { StartLevel = v; });
            meta.AttrIfBool("HeartIsEnd", delegate(bool v) { HeartIsEnd = v; });
            meta.AttrIfBool("SeekerSlowdown", delegate(bool v) { SeekerSlowdown = v; });
            meta.AttrIfBool("TheoInBubble", delegate(bool v) { TheoInBubble = v; });
            meta.AttrIfBool("CoreModeIceTileOverlay", delegate(bool v) { CoreModeIceTileOverlay = v; });
            var element =
                meta.Children?.FirstOrDefault(el => el.Name == "audiostate");
            if (element != null) AudioState = new(element);

            element = meta.Children?.FirstOrDefault(el => el.Name == "checkpoints");
            if (element == null) return;

            Checkpoints = new EverestCheckpointMetadata[element.Children?.Count ?? 0];
            for (var num = 0; num < Checkpoints.Length; num++) Checkpoints[num] = new(element.Children![num]);
        }
    }
}
