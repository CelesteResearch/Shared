using Celeste.Core.Maps;

namespace Celeste.Formats.Map.Identifiers
{
    public static class EntityIdCodec
    {
        public static readonly MapEntityId None = new("null", -1);

        public static string Format(MapEntityId value)
        {
            return value.Level + ":" + value.ID;
        }

        public static MapEntityId Parse(string value)
        {
            var parts = value.Split(':');
            return new(parts[0], int.Parse(parts[1]));
        }
    }
}
