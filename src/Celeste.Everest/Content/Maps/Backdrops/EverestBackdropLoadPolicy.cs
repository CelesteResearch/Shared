using System;
using Celeste.Core.Scheduling;
using Celeste.Everest.Runtime.Levels.Update;
using Celeste.Formats.Map.Binary.Source;
using Celeste.Game.Content.Maps;
using Celeste.Game.Content.Maps.Backdrops;
using Celeste.Graphics.Display.Colors;
using Celeste.Simulation.Presentation.Backdrops.Runtime;

namespace Celeste.Everest.Content.Maps.Backdrops
{
    public sealed class EverestBackdropLoadPolicy : IOriginalBackdropLoadPolicy
    {
        private readonly ISourceEngineContext engine;
        private readonly EverestLevelUpdateEvents events;
        private readonly EverestBackdropLoaders loaders;

        public EverestBackdropLoadPolicy(ISourceEngineContext engine, EverestLevelUpdateEvents events,
            EverestBackdropLoaders loaders)
        {
            this.engine = engine;
            this.events = events;
            this.loaders = loaders;
        }

        public BackdropPresentation LoadCustomBackdrop(BinaryPackerElement child, BinaryPackerElement above,
            OriginalChapterMapData map)
        {
            var backdrop = events.LoadBackdrop(map, child, above);
            if (backdrop != null) return backdrop;
            if (loaders.BackdropLoaders.TryGetValue(child.Name, out var loader))
            {
                var loaded = loader(child);
                if (loaded != null) return loaded;
            }

            if (child.Name.Equals("rain", StringComparison.OrdinalIgnoreCase))
            {
                var rain = new EverestRainBackdropPresentation(engine);
                if (child.HasAttr("color")) rain.Color = SourceHexColor.HexToColor(child.Attr("color"));
                return rain;
            }

            return null;
        }
    }
}
