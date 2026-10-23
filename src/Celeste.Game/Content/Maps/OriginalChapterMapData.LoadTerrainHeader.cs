using System;
using System.Collections.Generic;
using Celeste.Core.Display;
using Celeste.Core.Geometry;
using Celeste.Formats.Map.Binary.Source;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Game.Content.Maps.Entities;
using Celeste.Game.Content.Maps.Levels;
using Celeste.Graphics.Display.Colors;

namespace Celeste.Game.Content.Maps
{
    public partial class OriginalChapterMapData
    {
        public List<IntRect> Filler = [];
        public List<OriginalLevelEntityData> Strawberries = [];
        public List<OriginalLevelEntityData> Goldenberries = [];
        public int DetectedStrawberries;
        public bool DetectedRemixNotes;
        public bool DetectedHeartGem;
        public IntRect Bounds;
        public PackedColor BackgroundColor = PackedColor.Black;
        public BinaryPackerElement Foreground;
        public BinaryPackerElement Background;

        public IntRect TileBounds => new(Bounds.X / 8, Bounds.Y / 8,
            (int)Math.Ceiling(Bounds.Width / 8f), (int)Math.Ceiling(Bounds.Height / 8f));

        public int LoadSeed
        {
            get
            {
                var value = 0;
                var name = Data.Name;
                foreach (var character in name) value += character;
                return value;
            }
        }

        // Source point after File.Exists succeeds and before FromBinary.
        public void BeginSourceMapLoad()
        {
            Strawberries = [];
        }

        // The source Load stage after FromBinary and before mode collectible publication.
        public void LoadSourceParsedHeader(BinaryPackerElement source, IOriginalLevelRoomDataExtensions extensions,
            IOriginalChapterMapHeaderPolicy headerPolicy)
        {
            headerPolicy.CheckPackage(source, ModeData);
            foreach (var child in source.Children)
                if (child.Name == "levels")
                {
                    Levels = [];
                    foreach (var levelSource in child.Children)
                    {
                        var level = OriginalLevelRoomDataReader.Read(levelSource, extensions);
                        DetectedStrawberries += level.Strawberries;
                        if (level.HasGem) DetectedRemixNotes = true;
                        if (level.HasHeartGem) DetectedHeartGem = true;
                        Levels.Add(level);
                    }
                }
                else if (child.Name == "Filler")
                {
                    Filler = [];
                    if (child.Children == null) continue;
                    foreach (var element in child.Children)
                        Filler.Add(new((int)element.Attributes["x"], (int)element.Attributes["y"],
                            (int)element.Attributes["w"], (int)element.Attributes["h"]));
                }
                else
                {
                    if (!(child.Name == "Style")) continue;
                    if (child.HasAttr("color"))
                        BackgroundColor = SourceHexColor.HexToColor(child.Attr("color"));
                    if (child.Children == null) continue;
                    foreach (var element in child.Children)
                        if (element.Name == "Backgrounds") Background = element;
                        else if (element.Name == "Foregrounds") Foreground = element;
                }

            foreach (var level in Levels)
            foreach (var entity in level.Entities)
                if (headerPolicy.TrackableContains(entity)) Strawberries.Add(entity);
                else if (entity.Name == "goldenBerry") Goldenberries.Add(entity);

            var num = int.MaxValue;
            var num2 = int.MaxValue;
            var num3 = int.MinValue;
            var num4 = int.MinValue;
            foreach (var level2 in Levels)
            {
                if (level2.Bounds.Left < num) num = level2.Bounds.Left;

                if (level2.Bounds.Top < num2) num2 = level2.Bounds.Top;

                if (level2.Bounds.Right > num3) num3 = level2.Bounds.Right;

                if (level2.Bounds.Bottom > num4) num4 = level2.Bounds.Bottom;
            }

            foreach (var item in Filler)
            {
                if (item.Left < num) num = item.Left;

                if (item.Top < num2) num2 = item.Top;

                if (item.Right > num3) num3 = item.Right;

                if (item.Bottom > num4) num4 = item.Bottom;
            }

            var num5 = 64;
            Bounds = new(num - num5, num2 - num5, num3 - num + num5 * 2, num4 - num2 + num5 * 2);
            ModeData.TotalStrawberries = 0;
            ModeData.StartStrawberries = 0;
            ModeData.StrawberriesByCheckpoint = new OriginalLevelEntityData[10, 25];
            var checkpointIndex = 0;
            while (ModeData.Checkpoints != null && checkpointIndex < ModeData.Checkpoints.Length)
            {
                if (ModeData.Checkpoints[checkpointIndex] != null)
                    ModeData.Checkpoints[checkpointIndex].Strawberries = 0;
                checkpointIndex++;
            }

            foreach (var strawberry in Strawberries)
                if (!EntityAttributeReader.Bool(strawberry.Values,
                        "moon"))
                {
                    var checkpointId =
                        EntityAttributeReader.Int(strawberry.Values,
                            "checkpointID");
                    var order =
                        EntityAttributeReader.Int(strawberry.Values,
                            "order");
                    if (headerPolicy.GrowAndGet(ref ModeData.StrawberriesByCheckpoint, checkpointId, order) == null)
                        ModeData.StrawberriesByCheckpoint[checkpointId, order] = strawberry;
                    if (checkpointId == 0)
                        ModeData.StartStrawberries++;
                    else if (ModeData.Checkpoints != null)
                        ModeData.Checkpoints[checkpointId - 1].Strawberries++;
                    ModeData.TotalStrawberries++;
                }
        }
    }
}
