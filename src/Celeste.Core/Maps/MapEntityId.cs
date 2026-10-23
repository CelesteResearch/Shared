using System;

namespace Celeste.Core.Maps
{
    public struct MapEntityId(string level, int id) : IEquatable<MapEntityId>
    {
        public string Key
        {
            get => Level + ":" + ID;
            set
            {
                var parts = value.Split(':');
                Level = parts[0];
                ID = int.Parse(parts[1]);
            }
        }

        public override string ToString()
        {
            return Key;
        }

        public string Level = level;
        public int ID = id;

        public bool Equals(MapEntityId other)
        {
            return Level == other.Level && ID == other.ID;
        }

        public override bool Equals(object obj)
        {
            return obj is MapEntityId other && Equals(other);
        }

        public override int GetHashCode()
        {
            return Level.GetHashCode() ^ ID;
        }

        public static bool operator ==(MapEntityId left, MapEntityId right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(MapEntityId left, MapEntityId right)
        {
            return !left.Equals(right);
        }
    }
}
