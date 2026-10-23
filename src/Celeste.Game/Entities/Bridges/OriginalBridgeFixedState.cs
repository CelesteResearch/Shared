using System.Numerics;
using Celeste.Core.Geometry;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Execution.Levels;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content;
using Celeste.Simulation.Gameplay.Platforms.Foundation;

namespace Celeste.Game.Entities.Bridges
{
    public class OriginalBridgeFixedState : SourceSolidEntityState
    {
        public OriginalBridgeFixedState(EntityData data, Vector2 offset, OriginalLevelSceneRoot actualLevel)
            : base(data.Position + offset, data.Width, 8f, true,
                actualLevel.SolidWorldFactory.Create(data.Position + offset, true))
        {
            var texture =
                ((ISourceGameGraphicsEnvironment)actualLevel.EngineContext).GameGraphics.GameAtlas[
                    "scenery/bridge_fixed"];
            for (var index = 0; index < Width; index += texture.FrameWidth)
            {
                // The original computes this last-slice rectangle, but Image still
                // receives the full texture. Preserve that original tiling behavior.
                var rectangle = new IntRect(0, 0, texture.FrameWidth, texture.FrameHeight);
                if (index + rectangle.Width > Width)
                    rectangle.Width = (int)Width - index;
                Add(new SpriteImage(texture) { Position = new(index, -8f) });
            }
        }
    }
}
