using System.Numerics;
using Celeste.Core.Mathematics;
using YamlDotNet.Serialization;

namespace Celeste.Everest.Content.Maps.Metadata
{
    public class MapMetaTextVignette
    {
        public string Dialog { get; set; }
        public string Audio { get; set; } = "event:/game/00_prologue/intro_vignette";
        public float InitialDelay { get; set; } = 3f;
        public float FinalDelay { get; set; }

        [YamlIgnore]
        public Vector2 SnowDirection => Vector2ArrayConversion.ToVector2(SnowDirectionArray) ?? -Vector2.UnitX;

        [YamlMember(Alias = "SnowDirection")] public float[] SnowDirectionArray { get; set; }
    }
}
