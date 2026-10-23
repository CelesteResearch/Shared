using System;
using System.Linq;
using Celeste.Formats.Map.Binary.Source;
using Celeste.Everest.Content.Maps.Binary;
using Celeste.Simulation.Gameplay.Player.Intro;
using Celeste.Simulation.Gameplay.Environment.Core;

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
            BinaryPackerElement element =
                meta.Children?.FirstOrDefault((BinaryPackerElement el) => el.Name == "audiostate");
            if (element != null)
            {
                AudioState = new EverestAudioMetadata(element);
            }

            element = meta.Children?.FirstOrDefault((BinaryPackerElement el) => el.Name == "checkpoints");
            if (element != null)
            {
                Checkpoints = new EverestCheckpointMetadata[element.Children?.Count ?? 0];
                for (int num = 0; num < Checkpoints.Length; num++)
                {
                    Checkpoints[num] = new EverestCheckpointMetadata(element.Children[num]);
                }
            }
        }
    }
}
