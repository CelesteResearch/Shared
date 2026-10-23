using System;
using System.Globalization;
using System.Linq;
using System.Numerics;
using Celeste.Simulation;
using Celeste.Simulation.Rendering;
using YamlDotNet.Serialization;
using Celeste.Everest;

namespace Celeste.Everest.Content.Maps.Yaml
{
    internal sealed class EverestMapMetaYaml
    {
        public string Parent { get; set; }
        public string Icon { get; set; }
        public bool? Interlude { get; set; }
        public int? CassetteCheckpointIndex { get; set; }
        public string TitleBaseColor { get; set; }
        public string TitleAccentColor { get; set; }
        public string TitleTextColor { get; set; }
        public string IntroType { get; set; }
        public bool? Dreaming { get; set; }
        public string ColorGrade { get; set; }
        public string Wipe { get; set; }
        public float? DarknessAlpha { get; set; }
        public float? BloomBase { get; set; }
        public float? BloomStrength { get; set; }
        public string CoreMode { get; set; }
        public string Jumpthru { get; set; }
        public string CassetteNoteColor { get; set; }
        public string CassetteSong { get; set; }
        public string PostcardSoundID { get; set; }
        public string ForegroundTiles { get; set; }
        public string BackgroundTiles { get; set; }
        public string AnimatedTiles { get; set; }
        public string Sprites { get; set; }
        public string Portraits { get; set; }
        public bool? OverrideASideMeta { get; set; }
        public global::Celeste.Everest.Content.Maps.Metadata.Mountain.MapMetaMountain Mountain { get; set; }
        public global::Celeste.Everest.Content.Maps.Metadata.EverestCassetteModifier CassetteModifier { get; set; }
        public global::Celeste.Everest.Content.Maps.Yaml.EverestModeMetaYaml[] Modes { get; set; }
    }
}
