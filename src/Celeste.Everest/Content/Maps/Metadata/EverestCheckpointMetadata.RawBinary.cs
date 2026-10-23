using System;
using System.Linq;
using Celeste.Formats.Map.Binary.Source;
using Celeste.Everest.Content.Maps.Binary;
using Celeste.Simulation.Gameplay.Player.Intro;
using Celeste.Simulation.Gameplay.Environment.Core;

namespace Celeste.Everest.Content.Maps.Metadata
{
    public partial class EverestCheckpointMetadata
    {
        public EverestCheckpointMetadata()
        {
        }

        public EverestCheckpointMetadata(BinaryPackerElement meta)
        {
            Parse(meta);
        }

        public void Parse(BinaryPackerElement meta)
        {
            meta.AttrIf("Level", delegate(string v) { Level = v; });
            meta.AttrIf("Name", delegate(string v) { Name = v; });
            meta.AttrIfBool("Dreaming", delegate(bool v) { Dreaming = v; });
            meta.AttrIf("Inventory", delegate(string v) { Inventory = v; });
            meta.AttrIf("CoreMode",
                delegate(string v) { CoreMode = (RoomCoreMode)Enum.Parse(typeof(RoomCoreMode), v, ignoreCase: true); });
            BinaryPackerElement element =
                meta.Children?.FirstOrDefault((BinaryPackerElement el) => el.Name == "audiostate");
            if (element != null)
            {
                AudioState = new EverestAudioMetadata(element);
            }

            element = meta.Children?.FirstOrDefault((BinaryPackerElement el) => el.Name == "flags");
            if (element != null)
            {
                Flags = new string[element.Children?.Count ?? 0];
                for (int num = 0; num < Flags.Length; num++)
                {
                    Flags[num] = element.Children[num].Attr("innerText");
                }
            }
        }
    }
}
