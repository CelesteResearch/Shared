using System;
using System.Collections;
using Celeste.Core.Display;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Mathematics.LinearAlgebra;
using Celeste.Core.Randomness;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Graphics.Rendering.Primitives;
using Celeste.Graphics.Rendering.Vertices;
using Celeste.Scene.Rendering;

namespace Celeste.Simulation.Presentation.Scene.Transitions
{
    public abstract class ScreenWipePresentation : SceneRenderer
    {
        public ISourceRendererScene Scene;
        public bool WipeIn;
        public float Percent;
        public Action OnComplete;
        public bool Completed;
        public float Duration = .5f;
        public float EndTimer;
        private bool ending;
        public const int Left = -10;
        public const int Top = -10;
        public int Right => 1930;
        public int Bottom => 1090;
        protected ISourceEngineContext EngineContext => ((ISourceEngineContextScene)Scene).EngineContext;
        protected ScreenWipeProcessState ProcessWipe => ((ISourceScreenWipeEnvironment)EngineContext).ProcessWipe;
        protected PackedColor WipeColor => ProcessWipe.WipeColor;
        protected ISourceRandom Random => ((ISourceRandomEnvironment)EngineContext).Random;
        protected ISourceEasingArithmetic Easing => ((ISourceEasingEnvironment)EngineContext).EasingArithmetic;

        protected ISourceVectorArithmetic VectorArithmetic =>
            ((ISourceVectorEnvironment)EngineContext).VectorArithmetic;

        protected ISourceExtremaArithmetic Extrema => ((ISourceExtremaEnvironment)EngineContext).ExtremaArithmetic;
        protected ISourceCurveArithmetic CurveArithmetic => ((ISourceCurveEnvironment)EngineContext).CurveArithmetic;
        protected ISourceRenderContext RenderContext => ((ISourceRenderEnvironment)EngineContext).CurrentContext;

        protected ISourcePrimitiveGraphicsDevice PrimitiveGraphics =>
            ((ISourcePrimitiveGraphicsEnvironment)EngineContext).PrimitiveGraphics;

        public ScreenWipePresentation(ISourceRendererScene scene, bool wipeIn, Action onComplete = null)
        {
            Scene = scene;
            WipeIn = wipeIn;
            if (Scene is ILevelScreenWipeScene level) level.Wipe = this;
            Scene.Renderers.Add(this);
            OnComplete = onComplete;
        }

        public override void Update(object actualScene)
        {
            var scene = (ISourceRendererScene)actualScene;
            if (!Completed)
            {
                if (Percent < 1f)
                    Percent = ScalarMath.Approach(Percent, 1f, EngineContext.RawDeltaTime / Duration, Extrema);
                else if (EndTimer > 0f) EndTimer -= EngineContext.RawDeltaTime;
                else Completed = true;
            }
            else if (!ending)
            {
                ending = true;
                scene.Renderers.Remove(this);
                if (scene is ILevelScreenWipeScene level && ReferenceEquals(level.Wipe, this)) level.Wipe = null;
                if (OnComplete != null) OnComplete();
            }
        }

        public virtual void Cancel()
        {
            Scene.Renderers.Remove(this);
            if (Scene is ILevelScreenWipeScene level) level.Wipe = null;
        }

        public IEnumerator Wait()
        {
            while (Percent < 1f) yield return null;
        }

        protected void DrawPrimitives(SourceVertexPositionColor[] vertices)
        {
            DrawPrimitives(EngineContext, vertices);
        }

        public static void DrawPrimitives(ISourceEngineContext engine, SourceVertexPositionColor[] vertices)
        {
            var device = ((ISourcePrimitiveGraphicsEnvironment)engine).PrimitiveGraphics;
            SourcePrimitiveGraphics.DrawVertices(device,
                SourceMatrixMath.CreateScale(device.ViewportWidth / 1920f), vertices, vertices.Length);
        }
    }
}
