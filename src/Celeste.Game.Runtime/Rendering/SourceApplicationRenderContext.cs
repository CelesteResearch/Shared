using System;
using System.Numerics;
using Celeste.Core.Geometry;
using Celeste.Core.Rendering;
using Celeste.Core.Rendering.Observation;
using Celeste.Core.Rendering.States;
using Celeste.Core.Scheduling;
using Celeste.Game.Execution.Engine;
using Celeste.Graphics.Content;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Content.VirtualAssets;
using Celeste.Graphics.Display;
using Celeste.Graphics.Effects.SpeedRings;
using Celeste.Graphics.Rendering;
using Celeste.Graphics.Rendering.Devices;
using Celeste.Graphics.Rendering.Drawing;
using Celeste.Graphics.Rendering.Textures;

namespace Celeste.Game.Runtime.Rendering
{
// This context borrows the actual process Draw and device. It owns no batch, mesh or texture queue.
    public sealed class SourceApplicationRenderContext : ISourceRenderTargetContext,
        ISourceRenderObservationContext,
        ISourceDrawScope, ISourceRenderCommandSink<SourceDebugRectangle>, ISourceRenderCommandSink<AtlasTextureDraw>,
        ISourceRenderCommandSink<RenderTargetTextureDraw>,
        ISourceGameAtlasRenderContext,
        ISourceDrawingTextureRenderContext,
        ISpeedRingBufferRenderContext
    {
        private readonly ISourceEngineContext engine;

        public ISourceGraphicsContext Graphics =>
            ((IOriginalEngineGraphicsEnvironment)engine).EngineGraphics;

        private SourceDrawState ActualDraw => ((ISourceDrawScope)engine).Draw;

        private SourceGraphicsDevice Device =>
            ((ISourceGraphicsDeviceEnvironment)engine).GraphicsDevice;

        SourceDrawState ISourceDrawScope.Draw => ActualDraw;

        public AtlasData GameAtlas =>
            ((ISourceGameGraphicsEnvironment)engine).GameGraphics.GameAtlas;

        public AtlasEntry Pixel => ActualDraw.Pixel;
        public AtlasEntry Particle => ActualDraw.Particle;

        public object SpeedRingsTarget => ((ISourceSpeedRingBufferResources)
            ((ISourceGameGraphicsEnvironment)engine).GameGraphics).SpeedRings;

        public object CurrentTarget => Device.CurrentRenderTarget;
        public bool HasOpenBatch => ActualDraw.SpriteBatch.IsBatchOpen;

        public ISourceRenderObserver RenderObserver
            => ActualDraw.SpriteBatch.ActivePresentationCapture;

        public SourceApplicationRenderContext(ISourceEngineContext engine)
        {
            this.engine = engine ?? throw new ArgumentNullException(nameof(engine));
        }

        public void BeginBatch(in SourceRenderBatchState state)
        {
            ActualDraw.SpriteBatch.Begin(in state);
        }

        public void EndBatch()
        {
            ActualDraw.SpriteBatch.End();
        }

        public void SetTarget(object target)
        {
            var actualTarget = target is VirtualRenderTarget sourceTarget
                ? sourceTarget.Target
                : (SourceRenderTarget2DResource)target;
            Device.SetRenderTarget(actualTarget);
        }

        public void Clear(Vector4 clear)
        {
            var device = Device;
            device.Clear(SourceClearOptions.Target | SourceClearOptions.DepthBuffer | SourceClearOptions.Stencil,
                clear, device.Viewport.MaxDepth, 0);
        }

        public void SetTargetAndClear(object target, Vector4 clear)
        {
            SetTarget(target);
            Clear(clear);
        }

        public void Draw(in SourceDebugRectangle value, object actualEntity)
        {
            SourcePrimitiveDrawing.Rect(this,
                new(value.X, value.Y, value.Width, value.Height),
                new(value.Color));
        }

        public void Draw(in AtlasTextureDraw value, object actualEntity)
        {
            var color = value.Color.PackedValue;
            var effects = (value.FlipX ? SourceSpriteEffects.FlipHorizontally : SourceSpriteEffects.None)
                          | (value.FlipY ? SourceSpriteEffects.FlipVertically : SourceSpriteEffects.None);
            if (value.DestinationRectangle.HasValue)
                ActualDraw.SpriteBatch.Draw(value.Resource, value.DestinationRectangle.Value, value.Clip,
                    color, value.Rotation, value.Origin - value.DrawOffset, effects, 0f);
            else
                ActualDraw.SpriteBatch.Draw(value.Resource, value.Position, value.Clip,
                    color, value.Rotation, value.Origin - value.DrawOffset, value.Scale, effects, 0f);
        }

        public void Draw(in RenderTargetTextureDraw value, object actualEntity)
        {
            var texture = value.Texture;
            var source = value.WholeTexture ? (IntRect?)null : value.Source;
            var color = value.Color.PackedValue;
            var effects = (value.FlipX ? SourceSpriteEffects.FlipHorizontally : SourceSpriteEffects.None)
                          | (value.FlipY ? SourceSpriteEffects.FlipVertically : SourceSpriteEffects.None);
            if (value.DestinationRectangle.HasValue)
                ActualDraw.SpriteBatch.Draw(texture, value.DestinationRectangle.Value, source,
                    color, value.Rotation, value.Origin, effects, 0f);
            else
                ActualDraw.SpriteBatch.Draw(texture, value.Position, source,
                    color, value.Rotation, value.Origin, value.Scale, effects, 0f);
        }
    }
}
