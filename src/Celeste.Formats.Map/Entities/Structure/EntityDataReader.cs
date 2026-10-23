using System;
using System.Collections.Generic;
using System.Globalization;
using System.Numerics;
using Celeste.Core.Maps;

namespace Celeste.Formats.Map.Entities.Structure
{
    public static class EntityDataReader
    {
        public static int ReadId(MapElement entity)
            => entity.Attributes.TryGetValue("id", out var value) ? (int)value : 0;

        public static EntityData Read(MapElement entity)
        {
            var data = new EntityData { Name = entity.Name };
            if (entity.Attributes != null)
            {
                foreach (var attribute in entity.Attributes)
                {
                    if (attribute.Key == "id")
                    {
                        data.ID = (int)attribute.Value;
                        continue;
                    }

                    if (attribute.Key == "x")
                    {
                        data.Position.X = Convert.ToSingle(attribute.Value, CultureInfo.InvariantCulture);
                        continue;
                    }

                    if (attribute.Key == "y")
                    {
                        data.Position.Y = Convert.ToSingle(attribute.Value, CultureInfo.InvariantCulture);
                        continue;
                    }

                    if (attribute.Key == "width")
                    {
                        data.Width = (int)attribute.Value;
                        continue;
                    }

                    if (attribute.Key == "height")
                    {
                        data.Height = (int)attribute.Value;
                        continue;
                    }

                    if (attribute.Key == "originX")
                    {
                        data.Origin.X = Convert.ToSingle(attribute.Value, CultureInfo.InvariantCulture);
                        continue;
                    }

                    if (attribute.Key == "originY")
                    {
                        data.Origin.Y = Convert.ToSingle(attribute.Value, CultureInfo.InvariantCulture);
                        continue;
                    }

                    if (data.Values == null) data.Values = new Dictionary<string, object>();
                    data.Values.Add(attribute.Key, attribute.Value);
                }
            }

            data.Nodes = new Vector2[entity.Children != null ? entity.Children.Count : 0];
            for (int i = 0; i < data.Nodes.Length; i++)
            {
                foreach (var attribute in entity.Children[i].Attributes)
                {
                    if (attribute.Key == "x")
                        data.Nodes[i].X = Convert.ToSingle(attribute.Value, CultureInfo.InvariantCulture);
                    else if (attribute.Key == "y")
                        data.Nodes[i].Y = Convert.ToSingle(attribute.Value, CultureInfo.InvariantCulture);
                }
            }

            return data;
        }
    }
}
