using Celeste.Everest.Content.Maps.Metadata.Completion;
using Celeste.Everest.Content.Maps.Metadata.Mountain;
using Celeste.Simulation.Gameplay.Environment.Core;
using Celeste.Simulation.Gameplay.Player.Intro;

namespace Celeste.Everest.Content.Maps.Metadata
{
    public partial class EverestMapMetadata
    {
        public string Parent { get; set; }

        public string Icon { get; set; }

        public bool? Interlude { get; set; }

        public int? CassetteCheckpointIndex { get; set; }

        public string TitleBaseColor { get; set; }

        public string TitleAccentColor { get; set; }

        public string TitleTextColor { get; set; }

        public PlayerIntroType? IntroType { get; set; }

        public bool? Dreaming { get; set; } = false;

        public string ColorGrade { get; set; }

        public string Wipe { get; set; }

        public float? DarknessAlpha { get; set; }

        public float? BloomBase { get; set; }

        public float? BloomStrength { get; set; }

        public string Jumpthru { get; set; }

        public RoomCoreMode? CoreMode { get; set; }

        public string CassetteNoteColor { get; set; }

        public string CassetteSong { get; set; }

        public string PostcardSoundID { get; set; }

        public string ForegroundTiles { get; set; }

        public string BackgroundTiles { get; set; }

        public string AnimatedTiles { get; set; }

        public string Sprites { get; set; }

        public string Portraits { get; set; }

        public bool? OverrideASideMeta { get; set; }

        public EverestModeMetadata[] Modes { get; set; }

        public MapMetaMountain Mountain { get; set; }

        public MapMetaCompleteScreen CompleteScreen { get; set; }

        public MapMetaCompleteScreen LoadingVignetteScreen { get; set; }

        public MapMetaTextVignette LoadingVignetteText { get; set; }

        public EverestCassetteModifier CassetteModifier { get; set; }

        public EverestMapPostcardMetadata Postcard { get; set; }
    }
}
