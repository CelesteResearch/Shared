using Celeste.Core.Randomness;
using System;
using System.Numerics;
using Celeste.Scene.Components.Oscillation;
using Celeste.Simulation.Presentation.Decals.Entities;
using Celeste.Graphics.Content;
using Celeste.Graphics.Display.Colors;

namespace Celeste.Game.Entities.Decoration.Decals
{
    public sealed class OriginalDecalFactory
    {
        private readonly Celeste.Core.Scheduling.ISourceEngineContext engine;
        private readonly IOriginalDecalRegistrationPolicy registration;
        private readonly WigglerComponentPool wigglers;
        private readonly ISourceRandom random;
        private readonly ISourceGameGraphicsEnvironment graphics;

        public OriginalDecalFactory(Celeste.Core.Scheduling.ISourceEngineContext engine,
            IOriginalDecalRegistrationPolicy registration,
            WigglerComponentPool wigglers, ISourceRandom processRandom, ISourceGameGraphicsEnvironment graphics)
        {
            this.engine = engine;
            this.registration = registration ?? throw new ArgumentNullException(nameof(registration));
            this.wigglers = wigglers ?? throw new ArgumentNullException(nameof(wigglers));
            random = processRandom ?? throw new ArgumentNullException(nameof(processRandom));
            this.graphics = graphics ?? throw new ArgumentNullException(nameof(graphics));
        }

        public OriginalDecalEntity Create(OriginalDecalPlacement placement, Vector2 offset, int defaultDepth)
        {
            var decal = new OriginalDecalEntity(engine, placement.Texture, offset + placement.Position,
                placement.Scale, placement.Depth ?? defaultDepth, graphics.GameGraphics.GameAtlas,
                registration, wigglers, random, graphics);
            decal.Rotation = placement.Rotation * ((float)Math.PI / 180f);
            decal.Color = SourceColorParsing.HexToPackedColorWithAlpha(placement.ColorHex);
            if (placement.Depth.HasValue) decal.DepthSetByPlacement = true;
            if (placement.Parallax.HasValue)
            {
                decal.MakeParallax(placement.Parallax.Value);
                decal.ParallaxSetByPlacement = true;
            }

            return decal;
        }
    }
}
