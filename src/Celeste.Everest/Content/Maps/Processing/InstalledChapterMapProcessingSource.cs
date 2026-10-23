using System.Linq;
using Celeste.Core.Scheduling;
using Celeste.Everest.Content.Maps.Metadata;
using Celeste.Everest.Content.Maps.Registry;
using Celeste.Everest.Modules.Runtime;
using Celeste.Formats.Map.Binary.Source;
using Celeste.Game.Content.Maps;
using Celeste.Game.Execution.Areas;

namespace Celeste.Everest.Content.Maps.Processing
{
    public sealed class InstalledChapterMapProcessingSource : IOriginalChapterMapBoostMetadata
    {
        private readonly ISourceEngineContext process;
        private readonly IOriginalAreaKeyPolicy areas;
        private readonly IOriginalAreaDataFactory areaFactory;
        private readonly ISourceEverestModulesEnvironment modules;

        public InstalledChapterMapProcessingSource(ISourceEngineContext process,
            IOriginalAreaKeyPolicy areas, IOriginalAreaDataFactory areaFactory,
            ISourceEverestModulesEnvironment modules)
        {
            this.process = process;
            this.areas = areas;
            this.areaFactory = areaFactory;
            this.modules = modules;
        }

        public BinaryPackerElement ProcessReadRoot(BinaryPackerElement root,
            OriginalChapterMapData map)
        {
            return areas.GetLevelSet(map.Area) == "Celeste" ? root : Process(root, map);
        }

        private BinaryPackerElement Process(BinaryPackerElement root,
            OriginalChapterMapData map)
        {
            if (root.Children == null) return root;
            var meta = root.Children.Find(element => element.Name == "meta");
            if (meta != null) ProcessMeta(meta, map);
            new EverestMapDataFixup(map, areas, modules).Process(root);
            return root;
        }

        public bool? GetTheoInBubble(OriginalChapterMapData actualMap)
        {
            return GetModeMeta(actualMap)?.TheoInBubble;
        }

        public EverestModeMetadata GetModeMeta(OriginalChapterMapData map)
        {
            var meta = ((EverestArea)areas.GetArea(map.Area)).Metadata;
            return (meta?.Modes?.Length).GetValueOrDefault() <= map.Area.Mode ? null : meta.Modes[map.Area.Mode];
        }

        private void ProcessMeta(BinaryPackerElement meta, OriginalChapterMapData map)
        {
            var area = (EverestArea)areas.GetArea(map.Area);
            var mode = map.Area.Mode;
            if (mode == 0)
            {
                new EverestMapMetadata(meta).ApplyTo(area, process);
                map.Area = areas.ToKey(area);
                var backup = (EverestArea)areaFactory.Create();
                backup.IntroType = area.IntroType;
                backup.ColorGrade = area.ColorGrade;
                backup.DarknessAlpha = area.DarknessAlpha;
                backup.BloomBase = area.BloomBase;
                backup.BloomStrength = area.BloomStrength;
                backup.CoreMode = area.CoreMode;
                backup.Dreaming = area.Dreaming;
                area.ASideAreaDataBackup = backup;
            }

            var child = meta.Children?.FirstOrDefault(element => element.Name == "mode");
            if (child != null)
            {
                new EverestModeMetadata(child).ApplyTo(area, mode);
                if (mode != 0)
                {
                    var mapMeta = new EverestMapMetadata(meta) { Modes = area.Metadata.Modes };
                    ((EverestAreaModeData)area.Mode[mode]).MapMeta =
                        mapMeta;
                }
            }
        }
    }
}
