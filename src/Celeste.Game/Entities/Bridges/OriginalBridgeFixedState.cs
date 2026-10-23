using System.Numerics;
using Celeste.Core.Geometry;
using Celeste.Game.Execution.Levels;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Simulation.Gameplay.Platforms.Foundation;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content;

namespace Celeste.Game.Entities.Bridges
{
    public class OriginalBridgeFixedState : SourceSolidEntityState
    {
        public OriginalBridgeFixedState(EntityData data, Vector2 offset, OriginalLevelSceneRoot actualLevel)
            : base(data.Position + offset, data.Width, 8f, safe: true,
                actualLevel.SolidWorldFactory.Create(data.Position + offset, true))
        {
            var texture =
                ((ISourceGameGraphicsEnvironment)actualLevel.EngineContext).GameGraphics.GameAtlas[
                    "scenery/bridge_fixed"];
            for (int index = 0; (float)index < Width; index += texture.FrameWidth)
            {
                // The original computes this last-slice rectangle, but Image still
                // receives the full texture. Preserve that original tiling behavior.
                var rectangle = new IntRect(0, 0, texture.FrameWidth, texture.FrameHeight);
                if ((float)(index + rectangle.Width) > Width)
                    rectangle.Width = (int)Width - index;
                Add(new SpriteImage(texture) { Position = new Vector2(index, -8f) });
            }
        }
    }
}
