using Celeste.Simulation.Presentation.Scene.Transitions;
using System.Numerics;
using Celeste.Core.Rendering;
using Celeste.Game.Execution.Engine;
using Celeste.Graphics.Content.VirtualAssets;
using Celeste.Graphics.Geometry.TwoD.Camera;
using global::Celeste.Game.Execution.Startup;
using global::Celeste.Game.Execution;

namespace Celeste.Game.Execution
{
    public partial class GameRuntime : IOriginalEngineGraphicsState, ISourceScreenWipeGraphicsContext
    {
        public static VirtualRenderTarget HudTarget;
        public static VirtualRenderTarget WipeTarget;
        VirtualRenderTarget ISourceScreenWipeGraphicsContext.WipeTarget => WipeTarget;
        int ISourceGraphicsContext.Width => EngineRuntime.Width;
        int ISourceGraphicsContext.Height => EngineRuntime.Height;
        int ISourceGraphicsContext.ViewWidth => EngineRuntime.ViewWidth;
        int ISourceGraphicsContext.ViewHeight => EngineRuntime.ViewHeight;
        Matrix4x4 ISourceGraphicsContext.ScreenMatrix => EngineRuntime.ScreenMatrix;
        object ISourceGraphicsContext.HudTarget => HudTarget;

        int IOriginalEngineGraphicsState.ViewPadding
        {
            get => EngineRuntime.ViewPadding;
            set => EngineRuntime.ViewPadding = value;
        }

        CameraViewport IOriginalEngineGraphicsState.Viewport => EngineRuntime.Viewport;

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
