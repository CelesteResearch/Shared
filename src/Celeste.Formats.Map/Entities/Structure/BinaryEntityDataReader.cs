using System;
using System.Globalization;
using System.Numerics;
using Celeste.Formats.Map.Binary.Source;

namespace Celeste.Formats.Map.Entities.Structure
{
    public static class BinaryEntityDataReader
    {
        public static EntityData Read(BinaryPackerElement entity)
        {
            var data = new EntityData { Name = entity.Name };
            Populate(data, entity);
            return data;
        }

        public static void Populate(EntityData data, BinaryPackerElement entity)
        {
            if (entity.Attributes != null)
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

                    if (data.Values == null) data.Values = new();
                    data.Values.Add(attribute.Key, attribute.Value);
                }

            data.Nodes = new Vector2[entity.Children != null ? entity.Children.Count : 0];
            for (var i = 0; i < data.Nodes.Length; i++)
                foreach (var attribute in entity.Children[i].Attributes)
                    if (attribute.Key == "x")
                        data.Nodes[i].X = Convert.ToSingle(attribute.Value, CultureInfo.InvariantCulture);
                    else if (attribute.Key == "y")
                        data.Nodes[i].Y = Convert.ToSingle(attribute.Value, CultureInfo.InvariantCulture);
        }
    }
}
