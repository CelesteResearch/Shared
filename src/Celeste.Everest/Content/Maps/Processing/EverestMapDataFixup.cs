using System.Collections.Generic;
using System.Linq;
using Celeste.Everest.Content.Maps.Registry;
using Celeste.Everest.Modules.Runtime;
using Celeste.Formats.Map.Binary.Source;
using Celeste.Game.Content.Maps;
using Celeste.Game.Execution.Areas;

namespace Celeste.Everest.Content.Maps.Processing
{
    public class EverestMapDataFixup
    {
        public List<EverestMapDataProcessor> Processors = [];
        public readonly OriginalChapterMapData MapData;
        public readonly OriginalAreaKey AreaKey;
        public readonly EverestArea AreaData;
        public readonly EverestArea ParentAreaData;
        public readonly OriginalAreaModeData Mode;
        public readonly OriginalAreaModeData ParentMode;
        public readonly OriginalChapterMapData ParentMapData;
        public BinaryPackerElement Root;

        public EverestMapDataFixup(OriginalChapterMapData map, IOriginalAreaKeyPolicy areas,
            ISourceEverestModulesEnvironment modules)
        {
            MapData = map;
            AreaKey = map.Area;
            AreaData = (EverestArea)areas.GetArea(AreaKey);
            ParentAreaData = (EverestArea)areas.GetAreaBySID(AreaData.Metadata?.Parent) ?? AreaData;
            Mode = AreaData.Mode[AreaKey.Mode];
            ParentMode = ParentAreaData.Mode.ElementAtOrDefault(AreaKey.Mode) ?? Mode;
            ParentMapData = ParentMode?.MapData ?? map;
            foreach (var module in modules.Modules)
                module.PrepareMapDataProcessors(this);
        }

        public void Add<T>() where T : EverestMapDataProcessor, new()
        {
            Add(new T());
        }

        public void Add<T>(T processor) where T : EverestMapDataProcessor
        {
            processor.Initialize(this);
            Processors.Add(processor);
        }

        public T Get<T>() where T : EverestMapDataProcessor
        {
            foreach (var processor in Processors)
                if (processor is T)
                    return (T)processor;
            return null;
        }

        public void Process(BinaryPackerElement root)
        {
            Root = root;
            foreach (var processor in Processors) processor.Reset();
            Run("root", root);
            foreach (var processor in Processors) processor.End();
        }

        public void Run(string stepName, BinaryPackerElement element)
        {
            foreach (var processor in Processors) processor.Run(stepName, element);
        }
    }
}
