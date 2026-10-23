using System;
using System.Globalization;
using System.Numerics;
using Celeste.Everest.Content.Maps.Metadata;
using Celeste.Simulation.Gameplay.Environment.Core;
using Celeste.Simulation.Gameplay.Player.Intro;
using YamlDotNet.Serialization;

namespace Celeste.Everest.Content.Maps.Yaml
{
    public static class EverestMapMetaSidecar
    {
        public static EverestMapMetadata Parse(string yaml)
        {
            if (yaml == null) return null;
            var source = new DeserializerBuilder().IgnoreUnmatchedProperties().Build()
                             .Deserialize<EverestMapMetaYaml>(yaml) ??
                         new EverestMapMetaYaml();
            var meta = new EverestMapMetadata
            {
                Parent = source.Parent, Icon = source.Icon, Interlude = source.Interlude,
                CassetteCheckpointIndex = source.CassetteCheckpointIndex,
                TitleBaseColor = source.TitleBaseColor, TitleAccentColor = source.TitleAccentColor,
                TitleTextColor = source.TitleTextColor, CassetteSong = source.CassetteSong,
                Jumpthru = source.Jumpthru, CassetteNoteColor = source.CassetteNoteColor,
                PostcardSoundID = source.PostcardSoundID, ForegroundTiles = source.ForegroundTiles,
                BackgroundTiles = source.BackgroundTiles, AnimatedTiles = source.AnimatedTiles,
                Sprites = source.Sprites, Portraits = source.Portraits,
                OverrideASideMeta = source.OverrideASideMeta,
                Mountain = source.Mountain, CassetteModifier = source.CassetteModifier,
                ColorGrade = source.ColorGrade, Wipe = source.Wipe,
                Dreaming = source.Dreaming ?? false,
                DarknessAlpha = source.DarknessAlpha,
                BloomBase = source.BloomBase,
                BloomStrength = source.BloomStrength,
            };
            if (!string.IsNullOrEmpty(source.IntroType))
                meta.IntroType = (PlayerIntroType)Enum.Parse(
                    typeof(PlayerIntroType), source.IntroType, true);
            if (!string.IsNullOrEmpty(source.CoreMode))
                meta.CoreMode = (RoomCoreMode)Enum.Parse(
                    typeof(RoomCoreMode), source.CoreMode, true);
            if (source.Modes != null)
                for (var i = 0; i < Math.Min(meta.Modes.Length, source.Modes.Length); i++)
                    meta.Modes[i] = source.Modes[i]?.Convert();
            return meta;
        }

        // Original Monocle.Calc.HexToColor: six hexadecimal digits, decimal numeric
        // fallback, otherwise white. This is the color consumed by AreaData.ApplyTo.
        public static Vector4 HexToColor(string hex)
        {
            if (hex == null) return Vector4.One;
            var start = hex.Length > 0 && hex[0] == '#' ? 1 : 0;
            if (hex.Length - start >= 6)
                return new(Byte(hex[start], hex[start + 1]) / 255f,
                    Byte(hex[start + 2], hex[start + 3]) / 255f,
                    Byte(hex[start + 4], hex[start + 5]) / 255f, 1f);
            if (int.TryParse(hex.Substring(start), NumberStyles.Integer, CultureInfo.CurrentCulture, out var number))
                return new((byte)(number >> 16) / 255f, (byte)(number >> 8) / 255f,
                    (byte)number / 255f, 1f);
            return Vector4.One;
        }

        private static int Byte(char high, char low)
        {
            return Nibble(high) * 16 + Nibble(low);
        }

        private static byte Nibble(char value)
        {
            return (byte)"0123456789ABCDEF".IndexOf(char.ToUpper(value));
        }
    }
}
