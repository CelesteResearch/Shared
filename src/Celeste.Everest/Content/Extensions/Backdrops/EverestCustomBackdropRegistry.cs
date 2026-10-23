using Celeste.Core.Maps;
using System;
using System.Collections.Generic;
using Celeste.Simulation;
using Celeste.Simulation.Rendering;
using Celeste.Everest;

namespace Celeste.Everest.Content.Extensions.Backdrops
{
    // The engine-independent construction seam for custom stylegrounds. The
    // normal MapBackdropParser still applies shared map attributes after the
    // registered factory returns a BackdropPresentation.
    public sealed class EverestCustomBackdropRegistry
    {
        private readonly
            Dictionary<string, Func<MapDocument, global::Celeste.Core.Maps.MapElement,
                global::Celeste.Graphics.Content.Atlas.AtlasData, global::Celeste.Graphics.Content.Atlas.AtlasData
                , global::Celeste.Graphics.Content.Atlas.AtlasData, Random,
                global::Celeste.Simulation.Presentation.Backdrops.Runtime.BackdropPresentation>> factories =
                new Dictionary<string, Func<MapDocument, global::Celeste.Core.Maps.MapElement,
                    global::Celeste.Graphics.Content.Atlas.AtlasData,
                    global::Celeste.Graphics.Content.Atlas.AtlasData,
                    global::Celeste.Graphics.Content.Atlas.AtlasData, Random,
                    global::Celeste.Simulation.Presentation.Backdrops.Runtime.BackdropPresentation>>(StringComparer
                    .Ordinal);

        private readonly
            List<Func<MapDocument, global::Celeste.Core.Maps.MapElement, global::Celeste.Core.Maps.MapElement,
                global::Celeste.Simulation.Presentation.Backdrops.Runtime.BackdropPresentation>> loadHandlers =
                new List<Func<MapDocument, global::Celeste.Core.Maps.MapElement, global::Celeste.Core.Maps.MapElement,
                    global::Celeste.Simulation.Presentation.Backdrops.Runtime.BackdropPresentation>>();

        public static global::Celeste.Everest.Content.Extensions.Backdrops.EverestCustomBackdropRegistry
            Shared { get; } = new global::Celeste.Everest.Content.Extensions.Backdrops.EverestCustomBackdropRegistry();

        public void Register(string mapName,
            Func<MapDocument, global::Celeste.Core.Maps.MapElement, global::Celeste.Graphics.Content.Atlas.AtlasData,
                global::Celeste.Graphics.Content.Atlas.AtlasData, global::Celeste.Graphics.Content.Atlas.AtlasData
                , Random, global::Celeste.Simulation.Presentation.Backdrops.Runtime.BackdropPresentation> factory)
        {
            if (string.IsNullOrWhiteSpace(mapName))
                throw new ArgumentException("A map backdrop name is required", nameof(mapName));
            if (factory == null) throw new ArgumentNullException(nameof(factory));
            factories.TryGetValue(mapName, out var previous);
            factories[mapName] = factory;
            global::Celeste.Everest.Modules.Runtime.EverestModuleLifetime.Track(() =>
            {
                if (!factories.TryGetValue(mapName, out var active) || !ReferenceEquals(active, factory)) return;
                if (previous == null) factories.Remove(mapName);
                else factories[mapName] = previous;
            });
        }

        // Everest.Events.Level.LoadBackdrop runs before name-based loaders. The
        // enclosing `apply` element is supplied unchanged to each subscriber.
        public void RegisterLoadHandler(
            Func<MapDocument, global::Celeste.Core.Maps.MapElement, global::Celeste.Core.Maps.MapElement,
                global::Celeste.Simulation.Presentation.Backdrops.Runtime.BackdropPresentation> handler)
        {
            if (handler == null) throw new ArgumentNullException(nameof(handler));
            loadHandlers.Add(handler);
            global::Celeste.Everest.Modules.Runtime.EverestModuleLifetime.Track(() => loadHandlers.Remove(handler));
        }

        public void UnregisterLoadHandler(
            Func<MapDocument, global::Celeste.Core.Maps.MapElement, global::Celeste.Core.Maps.MapElement,
                global::Celeste.Simulation.Presentation.Backdrops.Runtime.BackdropPresentation> handler)
        {
            loadHandlers.Remove(handler);
        }

        public global::Celeste.Simulation.Presentation.Backdrops.Runtime.BackdropPresentation Create(MapDocument map,
            global::Celeste.Core.Maps.MapElement source,
            global::Celeste.Graphics.Content.Atlas.AtlasData game,
            global::Celeste.Graphics.Content.Atlas.AtlasData gui,
            global::Celeste.Graphics.Content.Atlas.AtlasData misc, Random random)
            => Create(map, source, null, game, gui, misc, random);

        public global::Celeste.Simulation.Presentation.Backdrops.Runtime.BackdropPresentation Create(MapDocument map,
            global::Celeste.Core.Maps.MapElement source, global::Celeste.Core.Maps.MapElement above,
            global::Celeste.Graphics.Content.Atlas.AtlasData game,
            global::Celeste.Graphics.Content.Atlas.AtlasData gui,
            global::Celeste.Graphics.Content.Atlas.AtlasData misc, Random random)
        {
            if (source == null) return null;
            foreach (var handler in loadHandlers.ToArray())
            {
                var loaded = handler(map, source, above);
                if (loaded != null) return loaded;
            }

            return factories.TryGetValue(source.Name, out var factory)
                ? factory(map, source, game, gui, misc, random)
                : null;
        }
    }
}
