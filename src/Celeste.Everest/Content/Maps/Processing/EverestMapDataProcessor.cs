using System;
using System.Collections.Generic;
using Celeste.Everest.Content.Maps.Registry;
using Celeste.Formats.Map.Binary.Source;
using Celeste.Game.Content.Maps;
using Celeste.Game.Execution.Areas;

namespace Celeste.Everest.Content.Maps.Processing
{
    public abstract class EverestMapDataProcessor
    {
        public EverestMapDataFixup Context { get; private set; }
        public OriginalAreaKey AreaKey => Context.AreaKey;
        public EverestArea AreaData => Context.AreaData;
        public EverestArea ParentAreaData => Context.ParentAreaData;
        public OriginalAreaModeData Mode => Context.Mode;
        public OriginalAreaModeData ParentMode => Context.ParentMode;
        public OriginalChapterMapData MapData => Context.MapData;
        public OriginalChapterMapData ParentMapData => Context.ParentMapData;
        public Dictionary<string, Action<BinaryPackerElement>> Steps { get; protected set; }

        public abstract void Reset();

        internal void Initialize(EverestMapDataFixup context)
        {
            Context = context;
            Steps = Init();
        }

        public abstract Dictionary<string, Action<BinaryPackerElement>> Init();

        public virtual void Run(string stepName, BinaryPackerElement element)
        {
            var steps = Steps;
            if (steps != null && steps.TryGetValue(stepName, out var value)) value?.Invoke(element);
        }

        public abstract void End();
    }
}
