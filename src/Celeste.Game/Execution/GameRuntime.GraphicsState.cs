using System.Numerics;
using Celeste.Core.Rendering;
using Celeste.Game.Execution.Engine;
using Celeste.Graphics.Content.VirtualAssets;
using Celeste.Graphics.Geometry.TwoD.Camera;
using Celeste.Simulation.Presentation.Scene.Transitions;

namespace Celeste.Game.Execution
{
    public partial class GameRuntime : IOriginalEngineGraphicsState, ISourceScreenWipeGraphicsContext
    {
        public static VirtualRenderTarget HudTarget;
        public static VirtualRenderTarget WipeTarget;
        VirtualRenderTarget ISourceScreenWipeGraphicsContext.WipeTarget => WipeTarget;
        int ISourceGraphicsContext.Width => Width;
        int ISourceGraphicsContext.Height => Height;
        int ISourceGraphicsContext.ViewWidth => ViewWidth;
        int ISourceGraphicsContext.ViewHeight => ViewHeight;
        Matrix4x4 ISourceGraphicsContext.ScreenMatrix => ScreenMatrix;
        object ISourceGraphicsContext.HudTarget => HudTarget;

        int IOriginalEngineGraphicsState.ViewPadding
        {
            get => ViewPadding;
            set => ViewPadding = value;
        }

        CameraViewport IOriginalEngineGraphicsState.Viewport => Viewport;

        object IOriginalEngineGraphicsState.HudTarget
        {
            get => HudTarget;
            set => HudTarget = (VirtualRenderTarget)value;
        }

        object IOriginalEngineGraphicsState.WipeTarget
        {
            get => WipeTarget;
            set => WipeTarget = (VirtualRenderTarget)value;
        }
    }
}
