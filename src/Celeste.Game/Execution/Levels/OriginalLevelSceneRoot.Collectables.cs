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
            var strawberries = true;
            var keys = true;
            var strawberryIds = new List<MapEntityId>();
            if (data.Attr("strawberries").Length > 0)
            {
                var values = data.Attr("strawberries").Split([',']);
                foreach (var value in values)
                {
                    var parts = value.Split([':']);
                    strawberryIds.Add(new(parts[0], Convert.ToInt32(parts[1])));
                }
            }

            foreach (var id in strawberryIds)
                if (!Session.Strawberries.Contains(id))
                {
                    strawberries = false;
                    break;
                }

            var keyIds = new List<MapEntityId>();
            if (data.Attr("keys").Length > 0)
            {
                var values = data.Attr("keys").Split([',']);
                foreach (var value in values)
                {
                    var parts = value.Split([':']);
                    keyIds.Add(new(parts[0], Convert.ToInt32(parts[1])));
                }
            }

            foreach (var id in keyIds)
                if (!Session.DoNotLoad.Contains(id))
                {
                    keys = false;
                    break;
                }

            return keys && strawberries;
        }
    }
}
