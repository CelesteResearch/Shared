using Celeste.Core.Maps;

namespace Celeste.Formats.Map.Identifiers
{
    public static class EntityIdCodec
    {
        public static readonly MapEntityId None = new("null", -1);

        public static string Format(MapEntityId value) => value.Level + ":" + value.ID;

        public static MapEntityId Parse(string value)
        {
            string[] parts = value.Split(':');
            return new MapEntityId(parts[0], int.Parse(parts[1]));
        }
    }
}
