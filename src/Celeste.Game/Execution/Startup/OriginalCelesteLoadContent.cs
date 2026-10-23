using System;
using Celeste.Core.Scheduling;
using System.Diagnostics;
using Celeste.Game.Content.Playback;
using Celeste.Game.Menus.Loading;
using Celeste.Game.Execution.Engine;
using Celeste.Game.Execution.Graphics;
using Celeste.Graphics.Content.Compiled;
using Celeste.Graphics.Rendering.Devices;
using Celeste.Graphics.Rendering.Effects;
using Celeste.Game.Execution.Graphics.Drawing;

namespace Celeste.Game.Execution.Startup
{
    public sealed class OriginalCelesteLoadContent : IOriginalCelesteContentLifecycle
    {
        private bool firstLoad = true;
        public bool FirstLoad => firstLoad;
        private readonly IGameLoaderSourceResources resources;
        private readonly OriginalOverworldGraphicsResources overworld;
        private readonly OriginalPlaybackData playback;
        private readonly IOriginalEngineGraphicsState graphics;
        private readonly SourceContentManager content;
        private readonly ISourceEngineContext engine;
        private readonly SourceStockEffectResources stockEffects;

        public OriginalCelesteLoadContent(IGameLoaderSourceResources actualResources,
            OriginalOverworldGraphicsResources actualOverworld, OriginalPlaybackData actualPlayback,
            IOriginalEngineGraphicsState actualGraphics, SourceContentManager actualContent,
            ISourceEngineContext actualEngine, SourceStockEffectResources actualStockEffects)
        {
            resources = actualResources ?? throw new ArgumentNullException(nameof(actualResources));
            overworld = actualOverworld ?? throw new ArgumentNullException(nameof(actualOverworld));
            playback = actualPlayback ?? throw new ArgumentNullException(nameof(actualPlayback));
            graphics = actualGraphics ?? throw new ArgumentNullException(nameof(actualGraphics));
            content = actualContent ?? throw new ArgumentNullException(nameof(actualContent));
            engine = actualEngine ?? throw new ArgumentNullException(nameof(actualEngine));
            stockEffects = actualStockEffects ?? throw new ArgumentNullException(nameof(actualStockEffects));
        }

        public void UnloadContent() => resources.VirtualContent.Unload();

        public void LoadContent()
        {
            resources.VirtualContent.Reload();
            ((IOriginalMonocleDrawInitializationEnvironment)engine).InitializeSourceDrawing();
            Console.WriteLine("BEGIN LOAD");
            resources.ProcessTiming.LoadTimer = Stopwatch.StartNew();
            playback.Load(resources.ContentDirectory, resources.ContentFiles);
            if (firstLoad)
            {
                firstLoad = false;
                graphics.HudTarget = resources.VirtualContent.CreateRenderTarget("hud-target", 1922, 1082);
                graphics.WipeTarget = resources.VirtualContent.CreateRenderTarget("wipe-target", 1922, 1082);
                overworld.Load(resources);
                resources.GraphicsResources.LoadGraphics(resources, resources.SpriteRandomContext,
                    resources.ParticleTypes, resources, engine);
                resources.MountainResources.Load(resources);
            }

            if (resources.GraphicsResources.GameAtlas != null)
                resources.GraphicsResources.PublishDrawingTextures();
            resources.GraphicsResources.LoadEffects(content, ((ISourceGraphicsDeviceEnvironment)engine).GraphicsDevice,
                stockEffects);
            ((global::Celeste.Game.Execution.Engine.Effects.IOriginalDistortionEnvironment)engine)
                .OnDistortionEffectLoaded();
        }
    }
}
