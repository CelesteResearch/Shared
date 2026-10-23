using System;
using System.Collections.Generic;
using System.Linq;
using Celeste.Core.IO;
using Celeste.Everest.Content.Maps.Registry;
using Celeste.Everest.Content.Registry;
using Celeste.Everest.Diagnostics.Logging;
using Celeste.Game.Content.Maps;
using Celeste.Game.Content.Maps.Entities;
using Celeste.Game.Content.Maps.Levels;
using Celeste.Game.Execution.Areas;
using Celeste.Formats.Map.Binary.Source;

namespace Celeste.Everest.Content.Maps.Processing
{
    public sealed class InstalledChapterMapLoadPolicy : IOriginalChapterMapLoadPolicy
    {
        private readonly ISourceContentDirectoryEnvironment content;
        private readonly SourceEverestFileProxyProcess files;
        private readonly InstalledChapterMapProcessingSource processing;
        private readonly IOriginalLevelRoomDataExtensions extensions;
        private readonly IOriginalChapterMapHeaderPolicy header;
        private readonly IOriginalAreaKeyPolicy areas;
        private readonly EverestLoggerProcess logger;

        public InstalledChapterMapLoadPolicy(ISourceContentDirectoryEnvironment content,
            SourceEverestFileProxyProcess files, InstalledChapterMapProcessingSource processing,
            IOriginalLevelRoomDataExtensions extensions, IOriginalChapterMapHeaderPolicy header,
            IOriginalAreaKeyPolicy areas, EverestLoggerProcess logger)
        {
            this.content = content;
            this.files = files;
            this.processing = processing;
            this.extensions = extensions;
            this.header = header;
            this.areas = areas;
            this.logger = logger;
        }

        public void Load(OriginalChapterMapData map)
        {
            map.DetectedStrawberries = 0;
            map.DetectedHeartGem = false;
            map.DetectedRemixNotes = false;
            map.Goldenberries = new List<OriginalLevelEntityData>();
            map.DashlessGoldenberries = new List<OriginalLevelEntityData>();
            map.DetectedCassette = false;
            map.DetectedStrawberriesIncludingUntracked = 0;
            try
            {
                LoadOriginalPatched(map);
                RegenerateLevelsByNameCache(map);
                foreach (var level in map.Levels)
                foreach (var entity in level.Entities)
                    if (entity.Name == "memorialTextController")
                        map.DashlessGoldenberries.Add(entity);
                var mode = ((EverestArea)areas.GetAreaBySID(((EverestArea)areas.GetArea(map.Area)).Metadata?.Parent))
                    ?.Mode?.ElementAtOrDefault(map.Area.Mode);
                if (mode == null) return;
                var parent = mode.MapData;
                if (parent == null)
                {
                    logger.WarnMapDataUnloadedParent(map, areas);
                    return;
                }

                parent.Strawberries.AddRange(map.Strawberries);
                mode.TotalStrawberries = 0;
                mode.StartStrawberries = 0;
                mode.StrawberriesByCheckpoint = new OriginalLevelEntityData[10, 25];
                int i = 0;
                while (mode.Checkpoints != null && i < mode.Checkpoints.Length)
                {
                    if (mode.Checkpoints[i] != null) mode.Checkpoints[i].Strawberries = 0;
                    i++;
                }

                foreach (var strawberry in parent.Strawberries)
                {
                    if (!strawberry.Bool("moon"))
                    {
                        int checkpoint = strawberry.Int("checkpointIDParented", strawberry.Int("checkpointID"));
                        int order = strawberry.Int("order");
                        if (header.GrowAndGet(ref mode.StrawberriesByCheckpoint, checkpoint, order) == null)
                            mode.StrawberriesByCheckpoint[checkpoint, order] = strawberry;
                        if (checkpoint == 0) mode.StartStrawberries++;
                        else if (mode.Checkpoints != null) mode.Checkpoints[checkpoint - 1].Strawberries++;
                        mode.TotalStrawberries++;
                    }
                }
            }
            catch (Exception error) when (!(error is OutOfMemoryException))
            {
                logger.WarnMapDataLoadFailure(map, areas);
                logger.LogDetailed(error);
            }
        }

        private void LoadOriginalPatched(OriginalChapterMapData map)
        {
            if (!files.Exists(map.GetSourceFilepath(content))) return;
            map.BeginSourceMapLoad();
            var source = processing.ProcessReadRoot(
                BinaryPacker.FromBinary(files.OpenRead(map.GetSourceFilepath(content))), map);
            map.LoadSourceParsedHeader(source, extensions, header);
        }

        public OriginalLevelRoomData Get(OriginalChapterMapData map, string levelName)
        {
            if (map.LevelsByName == null) RegenerateLevelsByNameCache(map);
            if (map.LevelsByName.TryGetValue(levelName, out var value)) return value;
            return null;
        }

        private void RegenerateLevelsByNameCache(OriginalChapterMapData map)
        {
            if (map.LevelsByName == null) map.LevelsByName = new Dictionary<string, OriginalLevelRoomData>();
            else map.LevelsByName.Clear();
            foreach (var level in map.Levels)
            {
                if (!map.LevelsByName.ContainsKey(level.Name))
                {
                    map.LevelsByName.Add(level.Name, level);
                    continue;
                }

                logger.WarnMapDataDuplicateRoom(map, level);
            }
        }
    }
}
