using System.Linq;
using Celeste.Core.Scheduling;
using Celeste.Everest.Content.Maps.Registry;
using Celeste.Game.Execution.Areas;
using Celeste.Game.Execution.Graphics;
using Celeste.Graphics.Content;
using Celeste.Graphics.Display.Colors;

namespace Celeste.Everest.Content.Maps.Metadata
{
    public partial class EverestMapMetadata
    {
        public void ApplyTo(EverestArea area, ISourceEngineContext process)
        {
            if (!string.IsNullOrEmpty(Icon) &&
                ((OriginalGameGraphicsResources)((ISourceGameGraphicsEnvironment)process).GameGraphics).GuiAtlas
                .Has(Icon))
            {
                area.Icon = Icon;
            }

            if (Interlude.HasValue)
            {
                area.Interlude = Interlude.Value;
            }

            if (CassetteCheckpointIndex.HasValue)
            {
                area.CassetteCheckpointIndex = CassetteCheckpointIndex.Value;
            }

            if (!string.IsNullOrEmpty(TitleBaseColor))
            {
                area.TitleBaseColor = SourceHexColor.HexToColor(TitleBaseColor);
            }

            if (!string.IsNullOrEmpty(TitleAccentColor))
            {
                area.TitleAccentColor = SourceHexColor.HexToColor(TitleAccentColor);
            }

            if (!string.IsNullOrEmpty(TitleTextColor))
            {
                area.TitleTextColor = SourceHexColor.HexToColor(TitleTextColor);
            }

            if (IntroType.HasValue)
            {
                area.IntroType = IntroType.Value;
            }

            if (Dreaming.HasValue)
            {
                area.Dreaming = Dreaming.Value;
            }

            if (!string.IsNullOrEmpty(ColorGrade))
            {
                area.ColorGrade = ColorGrade;
            }

            if (!string.IsNullOrEmpty(Wipe))
            {
                ((IEverestMapWipeEnvironment)process).MapWipes.Apply(area, Wipe);
            }

            if (DarknessAlpha.HasValue)
            {
                area.DarknessAlpha = DarknessAlpha.Value;
            }

            if (BloomBase.HasValue)
            {
                area.BloomBase = BloomBase.Value;
            }

            if (BloomStrength.HasValue)
            {
                area.BloomStrength = BloomStrength.Value;
            }

            if (!string.IsNullOrEmpty(Jumpthru))
            {
                area.Jumpthru = Jumpthru;
            }

            if (CoreMode.HasValue)
            {
                area.CoreMode = CoreMode.Value;
            }

            if (!string.IsNullOrEmpty(CassetteNoteColor))
            {
                area.CassseteNoteColor = SourceHexColor.HexToColor(CassetteNoteColor);
            }

            if (!string.IsNullOrEmpty(CassetteSong))
            {
                area.CassetteSong = CassetteSong;
            }

            area.MountainIdle =
                Mountain?.Idle?.Convert(((Celeste.Core.Mathematics.ISourceVectorEnvironment)process)
                    .VectorArithmetic) ??
                area.MountainIdle;
            area.MountainSelect =
                Mountain?.Select?.Convert(((Celeste.Core.Mathematics.ISourceVectorEnvironment)process)
                    .VectorArithmetic) ??
                area.MountainSelect;
            area.MountainZoom =
                Mountain?.Zoom?.Convert(((Celeste.Core.Mathematics.ISourceVectorEnvironment)process)
                    .VectorArithmetic) ??
                area.MountainZoom;
            area.MountainCursor = MetadataVectorArrays.ToVector3(Mountain?.Cursor) ?? area.MountainCursor;
            area.MountainState = Mountain?.State ?? area.MountainState;
            OriginalAreaModeData[] mode = area.Mode;
            area.Mode = Convert(Modes) ?? mode;
            if (mode != null)
            {
                for (int num = 0; num < area.Mode.Length && num < mode.Length; num++)
                {
                    if (area.Mode[num] == null)
                    {
                        area.Mode[num] = mode[num];
                    }
                }
            }

            EverestMapMetadata meta = area.Metadata;
            if (meta == null)
            {
                area.Metadata = this;
                return;
            }

            if (!string.IsNullOrEmpty(Parent))
            {
                meta.Parent = Parent;
            }

            if (!string.IsNullOrEmpty(PostcardSoundID))
            {
                meta.PostcardSoundID = PostcardSoundID;
            }

            if (!string.IsNullOrEmpty(ForegroundTiles))
            {
                meta.ForegroundTiles = ForegroundTiles;
            }

            if (!string.IsNullOrEmpty(BackgroundTiles))
            {
                meta.BackgroundTiles = BackgroundTiles;
            }

            if (!string.IsNullOrEmpty(AnimatedTiles))
            {
                meta.AnimatedTiles = AnimatedTiles;
            }

            if (!string.IsNullOrEmpty(Sprites))
            {
                meta.Sprites = Sprites;
            }

            if (!string.IsNullOrEmpty(Portraits))
            {
                meta.Portraits = Portraits;
            }

            if (OverrideASideMeta.HasValue)
            {
                meta.OverrideASideMeta = OverrideASideMeta;
            }

            EverestModeMetadata[] modes = Modes;
            if (modes != null && modes.Length != 0 &&
                Modes.Any((EverestModeMetadata mapMetaModeProperties) => mapMetaModeProperties != null))
            {
                meta.Modes = Modes;
            }

            if (Mountain != null)
            {
                meta.Mountain = Mountain;
            }

            if (CompleteScreen != null)
            {
                meta.CompleteScreen = CompleteScreen;
            }

            if (LoadingVignetteScreen != null)
            {
                meta.LoadingVignetteScreen = LoadingVignetteScreen;
            }

            if (LoadingVignetteText != null)
            {
                meta.LoadingVignetteText = LoadingVignetteText;
            }

            if (CassetteModifier != null)
            {
                meta.CassetteModifier = CassetteModifier;
            }

            if (Postcard != null)
            {
                meta.Postcard = Postcard;
            }
        }
    }
}
