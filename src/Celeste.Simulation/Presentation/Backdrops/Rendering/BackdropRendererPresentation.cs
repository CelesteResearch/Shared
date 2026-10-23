using Celeste.Core.Display;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Rendering;
using Celeste.Core.Rendering.States;
using Celeste.Scene.Rendering;
using Celeste.Simulation.Presentation.Backdrops.Runtime;
using Celeste.Simulation.Presentation.Backdrops.Parallax;
using Celeste.Graphics.Display;
using Celeste.Graphics.Rendering;
using Celeste.Graphics.Rendering.Drawing;

namespace Celeste.Simulation.Presentation.Backdrops.Rendering
{
    public partial class BackdropRendererPresentation : SceneRenderer
    {
        public Matrix4x4 Matrix = Matrix4x4.Identity;
        public List<BackdropPresentation> Backdrops = new();
        public float Fade;
        public PackedColor FadeColor = PackedColor.Black;
        private bool usingSpritebatch;
        private bool usingLoopingSpritebatch;

        public void Add(BackdropPresentation backdrop)
        {
            Backdrops.Add(backdrop);
            backdrop.Renderer = this;
        }

        public override void BeforeRender(object actualScene)
        {
            var scene = (ISourceBackdropScene)actualScene;
            foreach (var backdrop in Backdrops)
                if (((ISourceBackdropBeforeRenderEnvironment)scene.EngineContext).BackdropBeforeRender
                    .ShouldBeforeRender(backdrop))
                    backdrop.BeforeRender(scene);
        }

        public override void Update(object actualScene)
        {
            foreach (var backdrop in Backdrops) backdrop.Update((ISourceBackdropScene)actualScene);
        }

        public void Ended(ISourceBackdropScene scene)
        {
            foreach (var backdrop in Backdrops) backdrop.Ended(scene);
        }

        public T Get<T>() where T : class
        {
            foreach (var backdrop in Backdrops)
                if (backdrop is T)
                    return backdrop as T;
            return null;
        }

        public IEnumerable<T> GetEach<T>() where T : class
        {
            foreach (var backdrop in Backdrops)
                if (backdrop is T)
                    yield return backdrop as T;
        }

        public IEnumerable<T> GetEach<T>(string tag) where T : class
        {
            foreach (var backdrop in Backdrops)
                if (backdrop is T && backdrop.Tags.Contains(tag))
                    yield return backdrop as T;
        }

        public void StartSpritebatch(ISourceBackdropScene scene, SourceBlendState blendState)
        {
            if (!usingSpritebatch)
                ((ISourceDrawScope)scene.EngineContext).Draw.SpriteBatch.Begin(SourceSpriteSortMode.Deferred,
                    blendState, SourceSamplerState.PointClamp, SourceDepthStencilState.None,
                    SourceRasterizerState.CullNone, null, Matrix);
            usingSpritebatch = true;
        }

        public void EndSpritebatch(ISourceBackdropScene scene)
        {
            if (usingSpritebatch) ((ISourceDrawScope)scene.EngineContext).Draw.SpriteBatch.End();
            usingSpritebatch = false;
            usingLoopingSpritebatch = false;
        }

        public override void Render(object actualScene)
        {
            var scene = (ISourceBackdropScene)actualScene;
            var context = ((ISourceRenderEnvironment)scene.EngineContext).CurrentContext;
            ((ISourceBackdropBeforeRenderEnvironment)scene.EngineContext).BackdropBeforeRender.Render(this, context,
                scene);
        }

        public void RenderOriginal(ISourceRenderContext context, ISourceBackdropScene scene)
        {
            SourceBlendState blendState = SourceBlendState.AlphaBlend;
            foreach (var backdrop in Backdrops)
            {
                if (IsVisibleForRender(backdrop, scene))
                {
                    if (backdrop is ParallaxBackdropPresentation &&
                        (backdrop as ParallaxBackdropPresentation).BlendState != blendState)
                    {
                        EndSpritebatch(scene);
                        blendState = (backdrop as ParallaxBackdropPresentation).BlendState;
                    }

                    if (backdrop.UseSpritebatch && !usingSpritebatch) StartSpritebatch(scene, blendState);
                    if (!backdrop.UseSpritebatch && usingSpritebatch) EndSpritebatch(scene);
                    RenderBackdrop(context, scene, backdrop, blendState);
                }
            }

            if (Fade > 0f)
                SourcePrimitiveDrawing.Rect(context, null, -10, -10, 340, 200,
                    (FadeColor * Fade));
            EndSpritebatch(scene);
        }

        public void StartSpritebatchLooping(ISourceBackdropScene scene, SourceBlendState blendState)
        {
            if (!usingSpritebatch)
                ((ISourceDrawScope)scene.EngineContext).Draw.SpriteBatch.Begin(SourceSpriteSortMode.Deferred,
                    blendState, SourceSamplerState.PointWrap, SourceDepthStencilState.None,
                    SourceRasterizerState.CullNone, null, Matrix);
            usingSpritebatch = true;
            usingLoopingSpritebatch = true;
        }

        public void RenderInstalled(ISourceRenderContext context, ISourceBackdropScene scene)
        {
            SourceBlendState blendState = SourceBlendState.AlphaBlend;
            foreach (var backdrop in Backdrops)
            {
                if (!IsVisibleForRender(backdrop, scene)) continue;
                if (backdrop is ParallaxBackdropPresentation parallax &&
                    (!usingLoopingSpritebatch || parallax.BlendState != blendState))
                {
                    EndSpritebatch(scene);
                    blendState = parallax.BlendState;
                }

                if (!(backdrop is ParallaxBackdropPresentation) && backdrop.UseSpritebatch && usingLoopingSpritebatch)
                    EndSpritebatch(scene);
                if (backdrop.UseSpritebatch && !usingSpritebatch)
                {
                    if (backdrop is ParallaxBackdropPresentation) StartSpritebatchLooping(scene, blendState);
                    else StartSpritebatch(scene, blendState);
                }

                if (!backdrop.UseSpritebatch && usingSpritebatch) EndSpritebatch(scene);
                RenderBackdrop(context, scene, backdrop, blendState);
            }

            if (Fade > 0f)
                SourcePrimitiveDrawing.Rect(context, null, -10, -10, 340, 200, FadeColor * Fade);
            EndSpritebatch(scene);
        }

        public void Remove<T>() where T : BackdropPresentation
        {
            for (int index = Backdrops.Count - 1; index >= 0; index--)
                if (Backdrops[index].GetType() == typeof(T))
                    Backdrops.RemoveAt(index);
        }
    }
}
