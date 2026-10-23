using System.Numerics;
using Celeste.Core.Mathematics;
using YamlDotNet.Serialization;

namespace Celeste.Everest.Content.Maps.Metadata.Completion
{
    public class MapMetaCompleteScreen
    {
        public string Atlas { get; set; }
        [YamlIgnore] public Vector2 Start => Vector2ArrayConversion.ToVector2(StartArray) ?? Vector2.Zero;
        [YamlMember(Alias = "Start")] public float[] StartArray { get; set; }
        [YamlIgnore] public Vector2 Center => Vector2ArrayConversion.ToVector2(CenterArray) ?? Vector2.Zero;
        [YamlMember(Alias = "Center")] public float[] CenterArray { get; set; }
        [YamlIgnore] public Vector2 Offset => Vector2ArrayConversion.ToVector2(OffsetArray) ?? Vector2.Zero;
        [YamlMember(Alias = "Offset")] public float[] OffsetArray { get; set; }
        public MapMetaCompleteScreenLayer[] Layers { get; set; }
        public string[] MusicBySide { get; set; }
        public MapMetaCompleteScreenTitle Title { get; set; }
    }
}
