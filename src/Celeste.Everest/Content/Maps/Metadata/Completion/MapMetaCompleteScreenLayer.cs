using System.Numerics;
using Celeste.Core.Mathematics;
using YamlDotNet.Serialization;

namespace Celeste.Everest.Content.Maps.Metadata.Completion
{
    public class MapMetaCompleteScreenLayer
    {
        public string Type { get; set; }
        public string[] Images { get; set; }
        [YamlIgnore] public Vector2 Position => Vector2ArrayConversion.ToVector2(PositionArray) ?? Vector2.Zero;
        [YamlMember(Alias = "Position")] public float[] PositionArray { get; set; }
        [YamlIgnore] public Vector2 Scroll => Vector2ArrayConversion.ToVector2(ScrollArray) ?? Vector2.Zero;
        [YamlMember(Alias = "Scroll")] public float[] ScrollArray { get; set; }
        public float FrameRate { get; set; } = 6f;
        public float Alpha { get; set; } = 1f;
        [YamlIgnore] public Vector2 Speed => Vector2ArrayConversion.ToVector2(SpeedArray) ?? Vector2.Zero;
        [YamlMember(Alias = "Speed")] public float[] SpeedArray { get; set; }
        public float Scale { get; set; } = 1f;
        public bool Loop { get; set; } = true;
    }
}
