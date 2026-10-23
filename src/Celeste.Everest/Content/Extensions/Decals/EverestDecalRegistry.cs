using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml;
using Celeste.Core.Scheduling;
using Celeste.Everest.Content.Extensions.Decals.Handlers.Animation;
using Celeste.Everest.Content.Extensions.Decals.Handlers.Animation.Scared;
using Celeste.Everest.Content.Extensions.Decals.Handlers.Audio;
using Celeste.Everest.Content.Extensions.Decals.Handlers.Geometry;
using Celeste.Everest.Content.Extensions.Decals.Handlers.Images.Banners;
using Celeste.Everest.Content.Extensions.Decals.Handlers.Images.Flags;
using Celeste.Everest.Content.Extensions.Decals.Handlers.Images.Mirrors;
using Celeste.Everest.Content.Extensions.Decals.Handlers.Images.Overlays;
using Celeste.Everest.Content.Extensions.Decals.Handlers.Lighting;
using Celeste.Everest.Content.Extensions.Decals.Handlers.Particles;
using Celeste.Everest.Content.Extensions.Decals.Handlers.Platforms;
using Celeste.Everest.Content.Registry;
using Celeste.Everest.Content.Reloading;
using Celeste.Everest.Content.Sources;
using Celeste.Everest.Diagnostics.Logging;
using Celeste.Graphics.Content;
using Celeste.Simulation.Presentation.Decals.Entities;

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
                new AnimationDecalRegistryHandler(
                    sourceFeatures));
            AddPropertyHandlerFactory(() =>
                new AnimationSpeedDecalRegistryHandler(
                    sourceFeatures));
            AddPropertyHandlerFactory(() =>
                new BannerDecalRegistryHandler(
                    sourceFeatures));
            AddPropertyHandlerFactory(() =>
                new BloomDecalRegistryHandler(
                    sourceFeatures));
            AddPropertyHandlerFactory(() =>
                new CoreSwapDecalRegistryHandler(
                    sourceFeatures));
            AddPropertyHandlerFactory(() =>
                new DepthDecalRegistryHandler(
                    sourceFeatures));
            AddPropertyHandlerFactory(() =>
                new FlagSwapDecalRegistryHandler(
                    sourceFeatures));
            AddPropertyHandlerFactory(() =>
                new FloatyDecalRegistryHandler(
                    sourceFeatures));
            AddPropertyHandlerFactory(() =>
                new LightDecalRegistryHandler(
                    sourceFeatures));
            AddPropertyHandlerFactory(() =>
                new LightOccludeDecalRegistryHandler(
                    sourceFeatures));
            AddPropertyHandlerFactory(() =>
                new MirrorDecalRegistryHandler(
                    sourceFeatures));
            AddPropertyHandlerFactory(() =>
                new OverlayDecalRegistryHandler(
                    sourceFeatures));
            AddPropertyHandlerFactory(() =>
                new ParallaxDecalRegistryHandler(
                    sourceFeatures));
            AddPropertyHandlerFactory(() =>
                new RandomizeFrameDecalRegistryHandler(
                    sourceFeatures));
            AddPropertyHandlerFactory(() =>
                new ScaleDecalRegistryHandler(
                    sourceFeatures));
            AddPropertyHandlerFactory(() =>
                new ScaredDecalRegistryHandler(
                    sourceFeatures));
            AddPropertyHandlerFactory(() =>
                new SmokeDecalRegistryHandler(
                    sourceFeatures));
            AddPropertyHandlerFactory(() =>
                new SolidDecalRegistryHandler(
                    sourceFeatures));
            AddPropertyHandlerFactory(() =>
                new SoundDecalRegistryHandler(
                    sourceFeatures));
            AddPropertyHandlerFactory(() =>
                new StaticMoverDecalRegistryHandler(
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
            var assemblyName = action.Method.DeclaringType?.Assembly.GetName().Name ?? "";
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
            var assemblyName = callingAssembly.GetName().Name;
            var modName = content.Mods.FirstOrDefault(mod => mod is AssemblyContentSource &&
                                                             mod.DefaultName == assemblyName)?.Name;
            var name = !string.IsNullOrEmpty(modName) ? modName : assemblyName;
            logger.DecalHandlerConflict(property, name);
        }
    }
}
