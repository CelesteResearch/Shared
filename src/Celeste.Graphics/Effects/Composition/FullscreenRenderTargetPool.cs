using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Display;
using Celeste.Core.Rendering;
using Celeste.Graphics.Content.VirtualAssets;
using Celeste.Graphics.Rendering.Devices;
using Celeste.Graphics.Rendering.Drawing;
using Celeste.Graphics.Rendering.Textures;

namespace Celeste.Graphics.Effects.Composition
{
    public sealed class FullscreenRenderTargetPool : IDisposable
    {
        private readonly VirtualContent content;
        private readonly SourceGraphicsDevice device;
        private readonly Stack<VirtualRenderTarget> targets = new();
        private readonly List<SourceRenderTargetBinding[][]> bindingFrames = [CreateBindings()];
        private int renderDepth;
        private bool disposed;

        private static SourceRenderTargetBinding[][] CreateBindings()
        {
            return
            [
                [], new SourceRenderTargetBinding[1],
                new SourceRenderTargetBinding[2], new SourceRenderTargetBinding[3], new SourceRenderTargetBinding[4],
            ];
        }

        private int createdCount;

        public FullscreenRenderTargetPool(VirtualContent content, SourceGraphicsDevice device)
        {
            this.content = content;
            this.device = device;
        }

        public VirtualRenderTarget Rent(int width, int height)
        {
            if (disposed) throw new ObjectDisposedException(nameof(FullscreenRenderTargetPool));
            while (targets.Count != 0)
            {
                var target = targets.Pop();
                if (target.Width == width && target.Height == height) return target;
                target.Dispose();
            }

            return content.CreateRenderTarget("fullscreen-composition-" + createdCount++, width, height);
        }

        public void Return(VirtualRenderTarget target)
        {
            if (disposed) target.Dispose();
            else targets.Push(target);
        }

        public void Render(ISourceRenderContext context, int width, int height, Vector2 camera,
            Action drawAllPaths, Action beginGameplay)
        {
            var batch = ((ISourceDrawScope)context).Draw.SpriteBatch;
            var target = Rent(width, height);
            var depth = renderDepth++;
            var previousBatch = batch.CurrentState;
            var batchWasOpen = batch.IsBatchOpen;
            SourceRenderTargetBinding[] previousTargets = null;
            var completed = false;
            try
            {
                if (bindingFrames.Count == depth) bindingFrames.Add(CreateBindings());
                batch.End();
                previousTargets = bindingFrames[depth][device.GetRenderTargetsNoAllocEXT(null)];
                device.GetRenderTargetsNoAllocEXT(previousTargets);
                device.SetRenderTarget(target.Target);
                device.Clear(PackedColor.Transparent);
                beginGameplay();
                drawAllPaths();
                batch.End();
                device.SetRenderTargets(previousTargets);
                beginGameplay();
                batch.Draw(target.Target, camera + Vector2.UnitY, PackedColor.Black.PackedValue);
                batch.Draw(target.Target, camera, PackedColor.White.PackedValue);
                completed = true;
            }
            finally
            {
                try
                {
                    if (!completed)
                    {
                        if (batch.IsBatchOpen) batch.End();
                        if (previousTargets != null) device.SetRenderTargets(previousTargets);
                        // Restore the entering batch directly; a failed callback must not be retried.
                        if (batchWasOpen) batch.Begin(in previousBatch);
                    }
                }
                finally
                {
                    try
                    {
                        Return(target);
                    }
                    finally
                    {
                        renderDepth--;
                    }
                }
            }
        }

        public void Dispose()
        {
            disposed = true;
            while (targets.Count != 0) targets.Pop().Dispose();
        }
    }
}
