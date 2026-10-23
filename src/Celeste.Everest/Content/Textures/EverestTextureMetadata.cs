using Celeste.Everest.Content.Serialization;

namespace Celeste.Everest.Content.Textures
{
    public class EverestTextureMetadata : IEverestMetadata
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public bool Premultiplied { get; set; }
    }
}
