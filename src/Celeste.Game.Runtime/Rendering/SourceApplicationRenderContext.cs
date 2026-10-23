using Celeste.Core.Display;
using Celeste.Graphics.Rendering.Devices;
using System;
using System.Numerics;
using Celeste.Core.Rendering;
using Celeste.Core.Rendering.States;
using Celeste.Graphics.Content.VirtualAssets;
using Celeste.Graphics.Display;
using Celeste.Graphics.Rendering.Drawing;
using Celeste.Graphics.Rendering.Textures;

namespace Celeste.Game.Runtime.Rendering
{
// This context borrows the actual process Draw and device. It owns no batch, mesh or texture queue.
    public sealed class SourceApplicationRenderContext : ISourceRenderTargetContext,
        global::Celeste.Core.Rendering.Observation.ISourceRenderObservationContext,
        ISourceDrawScope, ISourceRenderCommandSink<SourceDebugRectangle>, ISourceRenderCommandSink<AtlasTextureDraw>,
        ISourceRenderCommandSink<RenderTargetTextureDraw>,
        global::Celeste.Graphics.Rendering.ISourceGameAtlasRenderContext,
        global::Celeste.Graphics.Rendering.ISourceDrawingTextureRenderContext,
        global::Celeste.Graphics.Effects.SpeedRings.ISpeedRingBufferRenderContext
    {
        private readonly global::Celeste.Core.Scheduling.ISourceEngineContext engine;

        public ISourceGraphicsContext Graphics =>
            ((global::Celeste.Game.Execution.Engine.IOriginalEngineGraphicsEnvironment)engine).EngineGraphics;

        private SourceDrawState ActualDraw => ((ISourceDrawScope)engine).Draw;

        private global::Celeste.Graphics.Rendering.Devices.SourceGraphicsDevice Device =>
            ((global::Celeste.Graphics.Rendering.Devices.ISourceGraphicsDeviceEnvironment)engine).GraphicsDevice;

        SourceDrawState ISourceDrawScope.Draw => ActualDraw;

        public global::Celeste.Graphics.Content.Atlas.AtlasData GameAtlas =>
            ((global::Celeste.Graphics.Content.ISourceGameGraphicsEnvironment)engine).GameGraphics.GameAtlas;

        public global::Celeste.Graphics.Content.Atlas.AtlasEntry Pixel => ActualDraw.Pixel;
        public global::Celeste.Graphics.Content.Atlas.AtlasEntry Particle => ActualDraw.Particle;

        public object SpeedRingsTarget => ((global::Celeste.Graphics.Effects.SpeedRings.ISourceSpeedRingBufferResources)
            ((global::Celeste.Graphics.Content.ISourceGameGraphicsEnvironment)engine).GameGraphics).SpeedRings;

        public object CurrentTarget => Device.CurrentRenderTarget;
        public bool HasOpenBatch => ActualDraw.SpriteBatch.IsBatchOpen;

        public global::Celeste.Core.Rendering.Observation.ISourceRenderObserver RenderObserver
            => ActualDraw.SpriteBatch.ActivePresentationCapture;

        public SourceApplicationRenderContext(global::Celeste.Core.Scheduling.ISourceEngineContext engine)
        {
            this.engine = engine ?? throw new ArgumentNullException(nameof(engine));
        }

        public void BeginBatch(in SourceRenderBatchState state) => ActualDraw.SpriteBatch.Begin(in state);
        public void EndBatch() => ActualDraw.SpriteBatch.End();

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
            => global::Celeste.Graphics.Rendering.SourcePrimitiveDrawing.Rect(this,
                new global::Celeste.Core.Geometry.IntRect(value.X, value.Y, value.Width, value.Height),
                new PackedColor(value.Color));

        public void Draw(in AtlasTextureDraw value, object actualEntity)
        {
            uint color = value.Color.PackedValue;
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
            var source = value.WholeTexture ? (global::Celeste.Core.Geometry.IntRect?)null : value.Source;
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
