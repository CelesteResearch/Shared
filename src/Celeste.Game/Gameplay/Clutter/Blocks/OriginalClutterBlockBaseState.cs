using Celeste.Core.Display;
using System.Numerics;
using Celeste.Graphics.Display;
using Celeste.Simulation.Gameplay.Clutter;
using Celeste.Core.Rendering;
using Celeste.Simulation.Gameplay.Platforms.Foundation;
using Celeste.Simulation.Presentation.Lighting;

namespace Celeste.Game.Gameplay.Clutter.Blocks
{
    public class OriginalClutterBlockBaseState : SourceSolidEntityState
    {
        private static PackedColor enabledColor = PackedColor.Black * .7f;
        private static PackedColor disabledColor = PackedColor.Black * .3f;
        public ClutterColor BlockColor;
        private bool enabled;
        private PackedColor color;
        private LightOccludeState occluder;

        public OriginalClutterBlockBaseState(Vector2 position, int width, int height, bool enabled,
            ClutterColor blockColor, ISourceSolidWorld solidWorld) : base(position, width, height, true, solidWorld)
        {
            EnableAssistModeChecks = false;
            BlockColor = blockColor;
            Depth = 8999;
            this.enabled = enabled;
            color = enabled ? enabledColor : disabledColor;
            if (enabled)
            {
                occluder = new LightOccludeState();
                OwnedComponents.Add(occluder);
            }
            else Collidable = false;

            switch (blockColor)
            {
                case ClutterColor.Green: SurfaceSoundIndex = 19; break;
                case ClutterColor.Red: SurfaceSoundIndex = 17; break;
                case ClutterColor.Yellow: SurfaceSoundIndex = 18; break;
            }
        }

        public void Deactivate()
        {
            Collidable = false;
            color = disabledColor;
            enabled = false;
            if (occluder != null)
            {
                OwnedComponents.Remove(occluder);
                occluder = null;
            }
        }

        public override void Render(ISourceRenderContext context)
            => global::Celeste.Graphics.Rendering.SourcePrimitiveDrawing.Rect(context, this,
                Position.X, Position.Y, Width, Height + (enabled ? 2f : 0f), color);
    }
}
