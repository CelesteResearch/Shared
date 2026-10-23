using System;
using System.Numerics;
using Celeste.Core.Display;
using Celeste.Graphics.Content.VirtualAssets;
using Celeste.Graphics.Rendering.Batches;
using Celeste.Graphics.Rendering.Devices;
using Celeste.Graphics.Rendering.Textures;

namespace Celeste.Graphics.Effects.Outlines
{
    // A reusable full-screen batch pass. The caller owns sprite selection, tints and batch state.
    public sealed class BufferedFourOffsetOutline : IDisposable
    {
        private readonly VirtualContent content;
        private readonly SourceGraphicsDevice device;
        private readonly SourceSpriteBatch batch;
        private readonly string name;

        private readonly SourceRenderTargetBinding[][] targetBindings =
        [ /* ReSharper disable once UseCollectionExpression */
            new SourceRenderTargetBinding[0], new SourceRenderTargetBinding[1], new SourceRenderTargetBinding[2],
            new SourceRenderTargetBinding[3], new SourceRenderTargetBinding[4],
        ];

        private VirtualRenderTarget target;

        // ReSharper disable once ConvertToPrimaryConstructor
        public BufferedFourOffsetOutline(VirtualContent content, SourceGraphicsDevice device, SourceSpriteBatch batch,
            string name)
        {
            this.content = content ?? throw new ArgumentNullException(nameof(content));
            this.device = device ?? throw new ArgumentNullException(nameof(device));
            this.batch = batch ?? throw new ArgumentNullException(nameof(batch));
            this.name = name ?? throw new ArgumentNullException(nameof(name));
        }

        // Capture closes its sprite batch. The caller chooses the later output batch.
        public void Capture(int width, int height, Action endBatch, Action beginSprites, Action drawSprites,
            Action recoverBatch)
        {
            if (target == null || target.Width != width || target.Height != height || target.IsDisposed)
            {
                target?.Dispose();
                target = content.CreateRenderTarget(name, width, height);
            }

            var captured = targetBindings[device.GetRenderTargetsNoAllocEXT(null)];
            device.GetRenderTargetsNoAllocEXT(captured);
            var viewport = device.Viewport;
            var scissor = device.ScissorRectangle;
            endBatch();
            try
            {
                device.SetRenderTarget(target.Target);
                device.Clear(PackedColor.Transparent);
                beginSprites();
                drawSprites();
                endBatch();
                device.SetRenderTargets(captured);
                device.Viewport = viewport;
                device.ScissorRectangle = scissor;
            }
            catch
            {
                if (batch.IsBatchOpen)
                    endBatch();
                device.SetRenderTargets(captured);
                device.Viewport = viewport;
                device.ScissorRectangle = scissor;
                recoverBatch();
                throw;
            }
        }

        // Draws into the caller's already-open batch, including delayed BeforeRender captures.
        public void RenderCaptured(Vector2 outputPosition, PackedColor outlineTint, bool drawUnshifted)
        {
            if (target == null || target.IsDisposed)
                return;
            batch.Draw(target.Target, outputPosition - Vector2.UnitY, outlineTint.PackedValue);
            batch.Draw(target.Target, outputPosition + Vector2.UnitY, outlineTint.PackedValue);
            batch.Draw(target.Target, outputPosition - Vector2.UnitX, outlineTint.PackedValue);
            batch.Draw(target.Target, outputPosition + Vector2.UnitX, outlineTint.PackedValue);
            if (drawUnshifted)
                batch.Draw(target.Target, outputPosition, PackedColor.White.PackedValue);
        }

        public void Render(int width, int height, Vector2 outputPosition, PackedColor outlineTint, bool drawUnshifted,
            bool outlineEffect, Action endBatch, Action beginSprites, Action drawSprites, Action beginOutline,
            Action beginGameplay)
        {
            var captured = targetBindings[device.GetRenderTargetsNoAllocEXT(null)];
            device.GetRenderTargetsNoAllocEXT(captured);
            var viewport = device.Viewport;
            var scissor = device.ScissorRectangle;
            Capture(width, height, endBatch, beginSprites, drawSprites, beginGameplay);
            try
            {
                beginOutline();
                RenderCaptured(outputPosition, outlineTint, false);
                if (outlineEffect)
                {
                    endBatch();
                    beginGameplay();
                }

                if (drawUnshifted)
                {
                    batch.Draw(target.Target, outputPosition, PackedColor.White.PackedValue);
                    endBatch();
                    beginGameplay();
                }
            }
            catch
            {
                if (batch.IsBatchOpen)
                    endBatch();
                device.SetRenderTargets(captured);
                device.Viewport = viewport;
                device.ScissorRectangle = scissor;
                beginGameplay();
                throw;
            }
        }

        public void Dispose()
        {
            target?.Dispose();
            target = null;
        }
    }
}
