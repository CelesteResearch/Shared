using System;
using System.Linq;
using Celeste.Everest.Content.Maps.Binary;
using Celeste.Formats.Map.Binary.Source;
using Celeste.Simulation.Gameplay.Environment.Core;
using Celeste.Simulation.Gameplay.Player.Intro;

namespace Celeste.Everest.Content.Maps.Metadata
{
    public partial class EverestMapMetadata
    {
        public EverestMapMetadata()
        {
        }

        public EverestMapMetadata(BinaryPackerElement meta)
        {
            Parse(meta);
        }

        public void Parse(BinaryPackerElement meta)
        {
            meta.AttrIf("Parent", delegate(string v) { Parent = v; });
            meta.AttrIf("Icon", delegate(string v) { Icon = v; });
            meta.AttrIfBool("Interlude", delegate(bool v) { Interlude = v; });
            meta.AttrIfInt("CassetteCheckpointIndex", delegate(int v) { CassetteCheckpointIndex = v; });
            meta.AttrIf("TitleBaseColor", delegate(string v) { TitleBaseColor = v; });
            meta.AttrIf("TitleAccentColor", delegate(string v) { TitleAccentColor = v; });
            meta.AttrIf("TitleTextColor", delegate(string v) { TitleTextColor = v; });
            meta.AttrIf("IntroType",
                delegate(string v) { IntroType = (PlayerIntroType)Enum.Parse(typeof(PlayerIntroType), v, true); });
            meta.AttrIfBool("Dreaming", delegate(bool v) { Dreaming = v; });
            meta.AttrIf("ColorGrade", delegate(string v) { ColorGrade = v; });
            meta.AttrIf("Wipe", delegate(string v) { Wipe = v; });
            meta.AttrIfFloat("DarknessAlpha", delegate(float v) { DarknessAlpha = v; });
            meta.AttrIfFloat("BloomBase", delegate(float v) { BloomBase = v; });
            meta.AttrIfFloat("BloomStrength", delegate(float v) { BloomStrength = v; });
            meta.AttrIf("Jumpthru", delegate(string v) { Jumpthru = v; });
            meta.AttrIf("CoreMode",
                delegate(string v) { CoreMode = (RoomCoreMode)Enum.Parse(typeof(RoomCoreMode), v, true); });
            meta.AttrIf("CassetteNoteColor", delegate(string v) { CassetteNoteColor = v; });
            meta.AttrIf("CassetteSong", delegate(string v) { CassetteSong = v; });
            meta.AttrIf("PostcardSoundID", delegate(string v) { PostcardSoundID = v; });
            meta.AttrIf("ForegroundTiles", delegate(string v) { ForegroundTiles = v; });
            meta.AttrIf("BackgroundTiles", delegate(string v) { BackgroundTiles = v; });
            meta.AttrIf("AnimatedTiles", delegate(string v) { AnimatedTiles = v; });
            meta.AttrIf("Sprites", delegate(string v) { Sprites = v; });
            meta.AttrIf("Portraits", delegate(string v) { Portraits = v; });
            meta.AttrIfBool("OverrideASideMeta", delegate(bool v) { OverrideASideMeta = v; });
            var element =
                meta.Children?.FirstOrDefault(el => el.Name == "cassettemodifier");
            if (element != null) CassetteModifier = new(element);

            Modes = new EverestModeMetadata[3];
            element = meta.Children?.FirstOrDefault(el => el.Name == "modes");
            if (element?.Children is not { } children) return;
            for (var num = 0; num < children.Count; num++) Modes[num] = new(children[num]);
            for (var num2 = children.Count; num2 < Modes.Length; num2++) Modes[num2] = null;
        }
    }
}
