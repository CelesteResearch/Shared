using System;
using System.Collections.Generic;
using System.Globalization;
using System.Numerics;
using Celeste.Formats.Map.Binary.Source;
using Celeste.Game.Content.Maps.Entities;
using Celeste.Game.Entities.Decoration.Decals;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Simulation.Gameplay.Environment.Wind;

namespace Celeste.Game.Content.Maps.Levels
{
    public static class OriginalLevelRoomDataReader
    {
        public static OriginalLevelRoomData Read(BinaryPackerElement source) => Read(source, null);

        public static OriginalLevelRoomData Read(BinaryPackerElement source,
            IOriginalLevelRoomDataExtensions extensions)
        {
            var room = new OriginalLevelRoomData(source);
            foreach (var attribute in source.Attributes)
            {
                switch (attribute.Key)
                {
                    case "name": room.Name = attribute.Value.ToString().Substring(4); break;
                    case "x": room.Bounds.X = (int)attribute.Value; break;
                    case "y": room.Bounds.Y = (int)attribute.Value; break;
                    case "width": room.Bounds.Width = (int)attribute.Value; break;
                    case "height":
                        room.Bounds.Height = (int)attribute.Value;
                        if (room.Bounds.Height == 184) room.Bounds.Height = 180;
                        break;
                    case "c": room.EditorColorIndex = (int)attribute.Value; break;
                    case "music": room.Music = (string)attribute.Value; break;
                    case "alt_music": room.AltMusic = (string)attribute.Value; break;
                    case "ambience": room.Ambience = (string)attribute.Value; break;
                    case "windPattern":
                        room.WindPattern =
                            (RoomWindPattern)Enum.Parse(typeof(RoomWindPattern), (string)attribute.Value); break;
                    case "dark": room.Dark = (bool)attribute.Value; break;
                    case "underwater": room.Underwater = (bool)attribute.Value; break;
                    case "space": room.Space = (bool)attribute.Value; break;
                    case "cameraOffsetX":
                        room.CameraOffset.X = Convert.ToSingle(attribute.Value, CultureInfo.InvariantCulture); break;
                    case "cameraOffsetY":
                        room.CameraOffset.Y = Convert.ToSingle(attribute.Value, CultureInfo.InvariantCulture); break;
                    case "musicLayer1": room.MusicLayers[0] = (bool)attribute.Value ? 1f : 0f; break;
                    case "musicLayer2": room.MusicLayers[1] = (bool)attribute.Value ? 1f : 0f; break;
                    case "musicLayer3": room.MusicLayers[2] = (bool)attribute.Value ? 1f : 0f; break;
                    case "musicLayer4": room.MusicLayers[3] = (bool)attribute.Value ? 1f : 0f; break;
                    case "musicProgress":
                        string music = attribute.Value.ToString();
                        if (string.IsNullOrEmpty(music) || !int.TryParse(music, out room.MusicProgress))
                            room.MusicProgress = -1;
                        break;
                    case "ambienceProgress":
                        string ambience = attribute.Value.ToString();
                        if (string.IsNullOrEmpty(ambience) || !int.TryParse(ambience, out room.AmbienceProgress))
                            room.AmbienceProgress = -1;
                        break;
                    case "whisper": room.MusicWhispers = (bool)attribute.Value; break;
                    case "disableDownTransition": room.DisableDownTransition = (bool)attribute.Value; break;
                    case "delayAltMusicFade": room.DelayAltMusic = (bool)attribute.Value; break;
                    case "enforceDashNumber": room.EnforceDashNumber = (int)attribute.Value; break;
                }
            }

            room.Spawns = new List<Vector2>();
            room.Entities = new List<OriginalLevelEntityData>();
            room.Triggers = new List<OriginalLevelEntityData>();
            room.BgDecals = new List<OriginalDecalPlacement>();
            room.FgDecals = new List<OriginalDecalPlacement>();
            foreach (var child in source.Children)
            {
                if (child.Name == "entities")
                {
                    if (child.Children == null) continue;
                    foreach (var entity in child.Children)
                    {
                        if (entity.Name == "player")
                        {
                            var spawn = new Vector2(
                                room.Bounds.X + Convert.ToSingle(entity.Attributes["x"], CultureInfo.InvariantCulture),
                                room.Bounds.Y + Convert.ToSingle(entity.Attributes["y"], CultureInfo.InvariantCulture));
                            extensions?.CheckForDefaultSpawn(room, entity, spawn);
                            room.Spawns.Add(spawn);
                        }
                        else if ((extensions == null
                                     ? entity.Name == "strawberry"
                                     : extensions.TrackableContains(entity)) ||
                                 entity.Name == "snowberry") room.Strawberries++;
                        else if (entity.Name == "shard") room.HasGem = true;
                        else if (entity.Name == "blackGem") room.HasHeartGem = true;
                        else if (entity.Name == "checkpoint") room.HasCheckpoint = true;

                        if (!entity.Name.Equals("player"))
                            room.Entities.Add(CreateEntityData(room, entity));
                    }
                }
                else if (child.Name == "triggers")
                {
                    if (child.Children == null) continue;
                    foreach (var trigger in child.Children)
                        room.Triggers.Add(CreateEntityData(room, trigger));
                }
                else if (child.Name == "bgdecals")
                {
                    if (child.Children == null) continue;
                    foreach (var decal in child.Children) room.BgDecals.Add(ReadDecal(decal, extensions));
                }
                else if (child.Name == "fgdecals")
                {
                    if (child.Children == null) continue;
                    foreach (var decal in child.Children) room.FgDecals.Add(ReadDecal(decal, extensions));
                }
                else if (child.Name == "solids") room.Solids = child.Attr("innerText");
                else if (child.Name == "bg") room.Bg = child.Attr("innerText");
                else if (child.Name == "fgtiles") room.FgTiles = child.Attr("innerText");
                else if (child.Name == "bgtiles") room.BgTiles = child.Attr("innerText");
                else if (child.Name == "objtiles") room.ObjTiles = child.Attr("innerText");
            }

            room.Dummy = room.Spawns.Count <= 0;
            extensions?.CompleteConstruction(room, source);
            return room;
        }

        public static OriginalLevelEntityData CreateEntityData(OriginalLevelRoomData room,
            BinaryPackerElement source)
        {
            var record = new OriginalLevelEntityData();
            record.Name = source.Name;
            record.Level = room;
            BinaryEntityDataReader.Populate(record, source);
            return record;
        }

        private static OriginalDecalPlacement ReadDecal(BinaryPackerElement source,
            IOriginalLevelRoomDataExtensions extensions)
        {
            var decal = new OriginalDecalPlacement
            {
                Position = new Vector2(Convert.ToSingle(source.Attributes["x"], CultureInfo.InvariantCulture),
                    Convert.ToSingle(source.Attributes["y"], CultureInfo.InvariantCulture)),
                Scale = new Vector2(Convert.ToSingle(source.Attributes["scaleX"], CultureInfo.InvariantCulture),
                    Convert.ToSingle(source.Attributes["scaleY"], CultureInfo.InvariantCulture)),
                Texture = (string)source.Attributes["texture"]
            };
            extensions?.ReadDecalExtensions(source, decal);
            return decal;
        }
    }
}
