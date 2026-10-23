using Celeste.Core.Maps;

namespace Celeste.Formats.Map.Binary
{
    public sealed class MapBinaryData
    {
        public string Package { get; }
        public MapElement Root { get; }

        public MapBinaryData(string package, MapElement root)
        {
            Package = package;
            Root = root;
        }
    }
}
