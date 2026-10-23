using Celeste.Core.Display;
using Celeste.Scene.Tracking;
using System;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Components.Rendering;
using Celeste.Core.Mathematics.LinearAlgebra;
using Celeste.Core.Rendering;
using Celeste.Core.Rendering.States;
using Celeste.Core.Scheduling;
using Celeste.Game.Execution.Graphics;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Startup;
using Celeste.Scene.Entities;
using Celeste.Simulation.Presentation.Effects.Mirrors;
using Celeste.Graphics.Content;
using Celeste.Graphics.Content.VirtualAssets;
using Celeste.Graphics.Display;
using Celeste.Graphics.Rendering.Devices;
using Celeste.Graphics.Rendering.Drawing;

namespace Celeste.Game.Presentation.Effects.Mirrors
{
    public class MirrorSurfacesState : SceneEntityState
    {
        public const int MaxMirrorOffset = 32;
        private readonly ISourceEngineContext engine;
        private bool hasReflections;
        private VirtualRenderTarget target;

        private OriginalGameGraphicsResources Graphics
            => (OriginalGameGraphicsResources)((ISourceGameGraphicsEnvironment)engine).GameGraphics;

        public MirrorSurfacesState(ISourceEngineContext engine) : base(
            ((global::Celeste.Core.Components.ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration)
        {
            this.engine = engine;
            Depth = 9490;
            Tags = ((IOriginalGameTagsEnvironment)engine).Tags.Global.Value;
            OwnedComponents.Add(new BeforeRenderCallbackComponentState(BeforeRender));
        }

        public void BeforeRender()
        {
            var level = Scene as OriginalLevelSceneRoot;
            var components = ((ISourceTrackedComponents)((ISourceComponentIndexScene)Scene).ComponentIndex)
                .GetTrackedComponents("Celeste.MirrorReflection");
            var surfaces = ((ISourceTrackedComponents)((ISourceComponentIndexScene)Scene).ComponentIndex)
                .GetTrackedComponents("Celeste.MirrorSurface");
            if (!(hasReflections = surfaces.Count > 0 && components.Count > 0)) return;
            if (target == null)
                target = ((ISourceVirtualContentEnvironment)engine).VirtualContent.CreateRenderTarget("mirror-surfaces",
                    320, 180);
            var transform =
                SourceMatrixMath.Multiply(SourceMatrixMath.CreateTranslation(32f, 32f, 0f), level.Camera.Matrix);
            components.Sort((a, b) => ((ISceneEntityDepth)b.Entity).DepthState.RawDepth -
                                      ((ISceneEntityDepth)a.Entity).DepthState.RawDepth);
            ((ISourceGraphicsDeviceEnvironment)engine).GraphicsDevice.SetRenderTarget(Graphics.Buffers.MirrorSources
                .Target);
            ((ISourceGraphicsDeviceEnvironment)engine).GraphicsDevice.Clear(PackedColor.Transparent);
            ((ISourceDrawScope)engine).Draw.SpriteBatch.Begin(SourceSpriteSortMode.Deferred,
                SourceBlendState.AlphaBlend,
                SourceSamplerState.PointClamp, SourceDepthStencilState.None, SourceRasterizerState.CullNone, null,
                transform);
            foreach (MirrorReflectionState item in components)
            {
                if ((((ISourceEntityVisibility)item.Entity).Visible || item.IgnoreEntityVisible) && item.Visible)
                {
                    item.IsRendering = true;
                    ((ISourceEntityRender)item.Entity).Render(level.SourceRenderContext);
                    item.IsRendering = false;
                }
            }

            ((ISourceDrawScope)engine).Draw.SpriteBatch.End();
            ((ISourceGraphicsDeviceEnvironment)engine).GraphicsDevice.SetRenderTarget(Graphics.Buffers.MirrorMasks
                .Target);
            ((ISourceGraphicsDeviceEnvironment)engine).GraphicsDevice.Clear(PackedColor.Transparent);
            ((ISourceDrawScope)engine).Draw.SpriteBatch.Begin(SourceSpriteSortMode.Deferred,
                SourceBlendState.AlphaBlend,
                SourceSamplerState.PointClamp, null, SourceRasterizerState.CullNone, null, transform);
            foreach (MirrorSurfaceState item in surfaces)
                if (item.Visible && item.OnRender != null)
                    item.OnRender();
            ((ISourceDrawScope)engine).Draw.SpriteBatch.End();
            ((ISourceGraphicsDeviceEnvironment)engine).GraphicsDevice.SetRenderTarget(target.Target);
            ((ISourceGraphicsDeviceEnvironment)engine).GraphicsDevice.Clear(PackedColor.Transparent);
            ((ISourceGraphicsDeviceEnvironment)engine).GraphicsDevice.Textures[1] =
                Graphics.Buffers.MirrorSources.Target;
            Graphics.FxMirrors.Parameters["pixel"].SetValue(new Vector2(
                1f / Graphics.Buffers.MirrorMasks.Width, 1f / Graphics.Buffers.MirrorMasks.Height));
            ((ISourceDrawScope)engine).Draw.SpriteBatch.Begin(SourceSpriteSortMode.Deferred,
                SourceBlendState.AlphaBlend,
                SourceSamplerState.PointClamp, null, null, Graphics.FxMirrors, Matrix4x4.Identity);
            ((ISourceDrawScope)engine).Draw.SpriteBatch.Draw(Graphics.Buffers.MirrorMasks.Target,
                new Vector2(-32f, -32f),
                PackedColor.White.PackedValue);
            ((ISourceDrawScope)engine).Draw.SpriteBatch.End();
        }

        public override void Render(ISourceRenderContext context)
        {
            if (hasReflections)
            {
                var position = FlooredCamera();
                ((ISourceDrawScope)engine).Draw.SpriteBatch.Draw(target.Target, position,
                    (PackedColor.White * .5f).PackedValue);
            }
        }

        private Vector2 FlooredCamera()
        {
            var position = (Scene as OriginalLevelSceneRoot).Camera.Position;
            position.X = (int)Math.Floor(position.X);
            position.Y = (int)Math.Floor(position.Y);
            return position;
        }

        public override void Removed(object scene)
        {
            base.Removed(scene);
            Dispose();
        }

        public override void SceneEnd(object scene)
        {
            base.SceneEnd(scene);
            Dispose();
        }

        public void Dispose()
        {
            if (target != null && !target.IsDisposed) target.Dispose();
            target = null;
        }
    }
}
