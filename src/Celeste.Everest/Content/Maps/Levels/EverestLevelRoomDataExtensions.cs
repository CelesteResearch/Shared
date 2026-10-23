using System;
using System.Globalization;
using System.Numerics;
using Celeste.Everest.Content.Extensions.Collectibles;
using Celeste.Formats.Map.Binary.Source;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Game.Content.Maps.Levels;
using Celeste.Game.Entities.Decoration.Decals;
using Celeste.Graphics.Display.Colors;

namespace Celeste.Everest.Content.Maps.Levels
{
    public sealed class EverestLevelRoomDataExtensions : IOriginalLevelRoomDataExtensions
    {
        private readonly ISourceInstalledStrawberryRegistryEnvironment environment;

        public EverestLevelRoomDataExtensions(ISourceInstalledStrawberryRegistryEnvironment environment)
        {
            this.environment = environment;
        }

        public bool TrackableContains(BinaryPackerElement entity)
        {
            return environment.StrawberryRegistry.TrackableContains(entity);
        }

        public void CheckForDefaultSpawn(OriginalLevelRoomData room, BinaryPackerElement entity, Vector2 spawn)
        {
            if (!room.DefaultSpawn.HasValue && entity.Attributes.TryGetValue("isDefaultSpawn", out var value) &&
                Convert.ToBoolean(value, CultureInfo.InvariantCulture))
                room.DefaultSpawn = spawn;
        }

        public void ReadDecalExtensions(BinaryPackerElement source, OriginalDecalPlacement decal)
        {
            decal.Rotation = EntityAttributeReader.Float(source.Attributes, "rotation");
            decal.ColorHex = EntityAttributeReader.Attr(source.Attributes, "color");
            if (source.Attributes.ContainsKey("depth"))
                decal.Depth = NullableInt(source, "depth");
            if (source.Attributes.ContainsKey("parallax"))
                decal.Parallax = NullableFloat(source, "parallax");
        }

        public void CompleteConstruction(OriginalLevelRoomData room, BinaryPackerElement source)
        {
            var color = EntityAttributeReader.Attr(source.Attributes, "color");
            room.CustomEditorColor = string.IsNullOrEmpty(color) ? null : SourceHexColor.HexToColor(color);
        }

        private static int? NullableInt(BinaryPackerElement source, string key)
        {
            if (source.Attributes == null || !source.Attributes.TryGetValue(key, out var value))
                return null;
            if (value is int number)
                return number;
            return int.Parse(value.ToString(), CultureInfo.InvariantCulture);
        }

        private static float? NullableFloat(BinaryPackerElement source, string key)
        {
            if (source.Attributes == null || !source.Attributes.TryGetValue(key, out var value))
                return null;
            if (value is float number)
                return number;
            return float.Parse(value.ToString(), CultureInfo.InvariantCulture);
        }
    }
}
