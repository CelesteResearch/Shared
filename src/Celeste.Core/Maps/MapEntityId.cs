using System;

namespace Celeste.Core.Maps
{
    public struct MapEntityId : IEquatable<MapEntityId>
    {
        public string Key
        {
            get => Level + ":" + ID;
            set
            {
                string[] parts = value.Split(':');
                Level = parts[0];
                ID = int.Parse(parts[1]);
            }
        }

        public override string ToString() => Key;
        public string Level;
        public int ID;

        public MapEntityId(string level, int id)
        {
            Level = level;
            ID = id;
        }

        public bool Equals(MapEntityId other) => Level == other.Level && ID == other.ID;
        public override bool Equals(object obj) => obj is MapEntityId other && Equals(other);
        public override int GetHashCode() => Level.GetHashCode() ^ ID;
        public static bool operator ==(MapEntityId left, MapEntityId right) => left.Equals(right);
        public static bool operator !=(MapEntityId left, MapEntityId right) => !left.Equals(right);
    }
}
