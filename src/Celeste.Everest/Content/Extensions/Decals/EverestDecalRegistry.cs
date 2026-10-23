using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml;
using Celeste.Core.Scheduling;
using Celeste.Everest.Content.Registry;
using Celeste.Everest.Content.Reloading;
using Celeste.Everest.Content.Sources;
using Celeste.Everest.Diagnostics.Logging;
using Celeste.Simulation.Presentation.Decals.Entities;
using Celeste.Graphics.Content;

namespace Celeste.Everest.Content.Extensions.Decals
{
    public sealed partial class EverestDecalRegistry
    {
        public readonly Dictionary<string, EverestDecalInfo> RegisteredDecals = new();
        private readonly Dictionary<string, Func<EverestDecalPropertyHandler>> handlers = new();
        private readonly EverestAssetReloadProcess reload;
        private readonly EverestContentRegistry content;
        private readonly ISourceGameGraphicsEnvironment graphics;
        private readonly EverestLoggerProcess logger;
        private readonly ISourceEngineContext engine;
        private readonly EverestDecalFeatureContext sourceFeatures;
        private bool loaded, willHotReload, defaultHandlersRegistered;
        public event Action<SourceDecalEntityState, EverestDecalInfo> RegistryApplied;

        public EverestDecalRegistry(ISourceEngineContext engine, EverestContentRegistry content,
            ISourceGameGraphicsEnvironment graphics, EverestLoggerProcess logger,
            EverestDecalFeatureContext features, EverestAssetReloadProcess reload)
        {
            this.reload = reload;
            this.engine = engine;
            this.content = content;
            this.graphics = graphics;
            this.logger = logger;
            sourceFeatures = features;
        }

        public void RegisterDefaultHandlers()
        {
            if (defaultHandlersRegistered) return;
            defaultHandlersRegistered = true;
            AddPropertyHandlerFactory(() =>
                new global::Celeste.Everest.Content.Extensions.Decals.Handlers.Animation.AnimationDecalRegistryHandler(
                    sourceFeatures));
            AddPropertyHandlerFactory(() =>
                new global::Celeste.Everest.Content.Extensions.Decals.Handlers.Animation.
                    AnimationSpeedDecalRegistryHandler(
                        sourceFeatures));
            AddPropertyHandlerFactory(() =>
                new global::Celeste.Everest.Content.Extensions.Decals.Handlers.Images.Banners.
                    BannerDecalRegistryHandler(
                        sourceFeatures));
            AddPropertyHandlerFactory(() =>
                new global::Celeste.Everest.Content.Extensions.Decals.Handlers.Lighting.BloomDecalRegistryHandler(
                    sourceFeatures));
            AddPropertyHandlerFactory(() =>
                new global::Celeste.Everest.Content.Extensions.Decals.Handlers.Images.Flags.
                    CoreSwapDecalRegistryHandler(
                        sourceFeatures));
            AddPropertyHandlerFactory(() =>
                new global::Celeste.Everest.Content.Extensions.Decals.Handlers.Geometry.DepthDecalRegistryHandler(
                    sourceFeatures));
            AddPropertyHandlerFactory(() =>
                new global::Celeste.Everest.Content.Extensions.Decals.Handlers.Images.Flags.
                    FlagSwapDecalRegistryHandler(
                        sourceFeatures));
            AddPropertyHandlerFactory(() =>
                new global::Celeste.Everest.Content.Extensions.Decals.Handlers.Animation.FloatyDecalRegistryHandler(
                    sourceFeatures));
            AddPropertyHandlerFactory(() =>
                new global::Celeste.Everest.Content.Extensions.Decals.Handlers.Lighting.LightDecalRegistryHandler(
                    sourceFeatures));
            AddPropertyHandlerFactory(() =>
                new global::Celeste.Everest.Content.Extensions.Decals.Handlers.Lighting.
                    LightOccludeDecalRegistryHandler(
                        sourceFeatures));
            AddPropertyHandlerFactory(() =>
                new global::Celeste.Everest.Content.Extensions.Decals.Handlers.Images.Mirrors.
                    MirrorDecalRegistryHandler(
                        sourceFeatures));
            AddPropertyHandlerFactory(() =>
                new global::Celeste.Everest.Content.Extensions.Decals.Handlers.Images.Overlays.
                    OverlayDecalRegistryHandler(
                        sourceFeatures));
            AddPropertyHandlerFactory(() =>
                new global::Celeste.Everest.Content.Extensions.Decals.Handlers.Geometry.ParallaxDecalRegistryHandler(
                    sourceFeatures));
            AddPropertyHandlerFactory(() =>
                new global::Celeste.Everest.Content.Extensions.Decals.Handlers.Animation.
                    RandomizeFrameDecalRegistryHandler(
                        sourceFeatures));
            AddPropertyHandlerFactory(() =>
                new global::Celeste.Everest.Content.Extensions.Decals.Handlers.Geometry.ScaleDecalRegistryHandler(
                    sourceFeatures));
            AddPropertyHandlerFactory(() =>
                new global::Celeste.Everest.Content.Extensions.Decals.Handlers.Animation.Scared.
                    ScaredDecalRegistryHandler(
                        sourceFeatures));
            AddPropertyHandlerFactory(() =>
                new global::Celeste.Everest.Content.Extensions.Decals.Handlers.Particles.SmokeDecalRegistryHandler(
                    sourceFeatures));
            AddPropertyHandlerFactory(() =>
                new global::Celeste.Everest.Content.Extensions.Decals.Handlers.Platforms.SolidDecalRegistryHandler(
                    sourceFeatures));
            AddPropertyHandlerFactory(() =>
                new global::Celeste.Everest.Content.Extensions.Decals.Handlers.Audio.SoundDecalRegistryHandler(
                    sourceFeatures));
            AddPropertyHandlerFactory(() =>
                new global::Celeste.Everest.Content.Extensions.Decals.Handlers.Platforms.
                    StaticMoverDecalRegistryHandler(
                        sourceFeatures));
        }


        public void AddPropertyHandler<T>() where T : EverestDecalPropertyHandler, new()
        {
            var handler = new T();
            if (handlers.ContainsKey(handler.Name)) LogConflict(handler.Name, Assembly.GetCallingAssembly());
            handlers[handler.Name] = () => new T();
            ScheduleHotReloadIfNeeded();
        }

        public void AddPropertyHandler(string name, Action<SourceDecalEntityState, XmlAttributeCollection> action)
        {
            if (handlers.ContainsKey(name)) LogConflict(name, Assembly.GetCallingAssembly());
            string assemblyName = action.Method.DeclaringType?.Assembly.GetName().Name ?? "";
            logger.DecalLegacyHandler(assemblyName, name);
            handlers[name] = () => new LegacyEverestDecalPropertyHandler(name, action);
            ScheduleHotReloadIfNeeded();
        }

        private void AddPropertyHandlerFactory(Func<EverestDecalPropertyHandler> factory)
        {
            var handler = factory();
            if (handlers.ContainsKey(handler.Name)) LogConflict(handler.Name, Assembly.GetCallingAssembly());
            handlers[handler.Name] = factory;
            ScheduleHotReloadIfNeeded();
        }

        private void LogConflict(string property, Assembly callingAssembly)
        {
            string assemblyName = callingAssembly.GetName().Name;
            string modName = content.Mods.FirstOrDefault(mod => mod is AssemblyContentSource &&
                                                                mod.DefaultName == assemblyName)?.Name;
            string name = !string.IsNullOrEmpty(modName) ? modName : assemblyName;
            logger.DecalHandlerConflict(property, name);
        }
    }
}
