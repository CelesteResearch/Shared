using System;
using System.Collections.Generic;
using Celeste.Core.Maps;
using Celeste.Formats.Map.Entities.Structure;

namespace Celeste.Game.Execution.Levels
{
    public sealed partial class OriginalLevelSceneRoot
    {
        private bool GotCollectables(EntityData data)
        {
            bool strawberries = true;
            bool keys = true;
            var strawberryIds = new List<MapEntityId>();
            if (data.Attr("strawberries").Length > 0)
            {
                string[] values = data.Attr("strawberries").Split(new char[1] { ',' });
                foreach (string value in values)
                {
                    string[] parts = value.Split(new char[1] { ':' });
                    strawberryIds.Add(new MapEntityId(parts[0], Convert.ToInt32(parts[1])));
                }
            }

            foreach (MapEntityId id in strawberryIds)
            {
                if (!Session.Strawberries.Contains(id))
                {
                    strawberries = false;
                    break;
                }
            }

            var keyIds = new List<MapEntityId>();
            if (data.Attr("keys").Length > 0)
            {
                string[] values = data.Attr("keys").Split(new char[1] { ',' });
                foreach (string value in values)
                {
                    string[] parts = value.Split(new char[1] { ':' });
                    keyIds.Add(new MapEntityId(parts[0], Convert.ToInt32(parts[1])));
                }
            }

            foreach (MapEntityId id in keyIds)
            {
                if (!Session.DoNotLoad.Contains(id))
                {
                    keys = false;
                    break;
                }
            }

            return keys && strawberries;
        }
    }
}
