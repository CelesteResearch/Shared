using System;
using System.Collections.Generic;
using Celeste.Core.Maps;

namespace Celeste.Game.Content.Maps
{
    // Celeste/Level.cs:1437-1484 GotCollectables. Attribute text is "level:id" lists; the
    // original parses each id through EntityID (int), so the key is re-formatted as an int.
    public static class OriginalCollectables
    {
        public static bool ShouldCreateRidgeGate(MapElement source, Func<MapEntityId, bool> collected,
            Func<MapEntityId, bool> doNotLoad)
        {
            return Got(source.Text("strawberries"), source.Text("keys"), collected, doNotLoad);
        }

        public static bool Got(string strawberries, string keys, Func<MapEntityId, bool> collected,
            Func<MapEntityId, bool> doNotLoad)
        {
            bool flag = true, flag2 = true;
            var list = Parse(strawberries);
            foreach (var id in list)
                if (!collected(id))
                {
                    flag = false;
                    break;
                }

            var list2 = Parse(keys);
            foreach (var id in list2)
                if (!doNotLoad(id))
                {
                    flag2 = false;
                    break;
                }

            return flag2 && flag;
        }

        public static List<MapEntityId> Parse(string text)
        {
            var list = new List<MapEntityId>();
            if (text.Length == 0) return list;
            foreach (var item in text.Split(','))
            {
                var parts = item.Split(':');
                list.Add(new(parts[0], Convert.ToInt32(parts[1])));
            }

            return list;
        }
    }
}
