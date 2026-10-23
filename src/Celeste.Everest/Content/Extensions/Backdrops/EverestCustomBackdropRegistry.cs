using System;
using System.Collections.Generic;
using Celeste.Core.Maps;
using Celeste.Everest.Modules.Runtime;
using Celeste.Graphics.Content.Atlas;
using Celeste.Simulation.Presentation.Backdrops.Runtime;

namespace Celeste.Everest.Content.Extensions.Backdrops
{
    // The engine-independent construction seam for custom stylegrounds. The
    // normal MapBackdropParser still applies shared map attributes after the
    // registered factory returns a BackdropPresentation.
    public sealed class EverestCustomBackdropRegistry
    {
        private readonly
            Dictionary<string, Func<MapDocument, MapElement,
                AtlasData, AtlasData
                , AtlasData, Random,
                BackdropPresentation>> factories =
                new(StringComparer
                    .Ordinal);

        private readonly
            List<Func<MapDocument, MapElement, MapElement,
                BackdropPresentation>> loadHandlers = [];

        public static EverestCustomBackdropRegistry
            Shared { get; } = new();

        public void Register(string mapName,
            Func<MapDocument, MapElement, AtlasData,
                AtlasData, AtlasData
                , Random, BackdropPresentation> factory)
        {
            if (string.IsNullOrWhiteSpace(mapName))
                throw new ArgumentException("A map backdrop name is required", nameof(mapName));
            if (factory == null) throw new ArgumentNullException(nameof(factory));
            factories.TryGetValue(mapName, out var previous);
            factories[mapName] = factory;
            EverestModuleLifetime.Track(() =>
            {
                if (!factories.TryGetValue(mapName, out var active) || !ReferenceEquals(active, factory)) return;
                if (previous == null) factories.Remove(mapName);
                else factories[mapName] = previous;
            });
        }

        // Everest.Events.Level.LoadBackdrop runs before name-based loaders. The
        // enclosing `apply` element is supplied unchanged to each subscriber.
        public void RegisterLoadHandler(
            Func<MapDocument, MapElement, MapElement,
                BackdropPresentation> handler)
        {
            if (handler == null) throw new ArgumentNullException(nameof(handler));
            loadHandlers.Add(handler);
            EverestModuleLifetime.Track(() => loadHandlers.Remove(handler));
        }

        public void UnregisterLoadHandler(
            Func<MapDocument, MapElement, MapElement,
                BackdropPresentation> handler)
        {
            loadHandlers.Remove(handler);
        }

        public BackdropPresentation Create(MapDocument map,
            MapElement source,
            AtlasData game,
            AtlasData gui,
            AtlasData misc, Random random)
        {
            return Create(map, source, null, game, gui, misc, random);
        }

        public BackdropPresentation Create(MapDocument map,
            MapElement source, MapElement above,
            AtlasData game,
            AtlasData gui,
            AtlasData misc, Random random)
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
