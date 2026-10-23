using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Display;
using Celeste.Core.Rendering;
using Celeste.Core.Rendering.States;
using Celeste.Graphics.Content.VirtualAssets;
using Celeste.Graphics.Rendering.Devices;
using Celeste.Graphics.Rendering.Drawing;
using Celeste.Graphics.Rendering.Textures;
using Celeste.Simulation.Presentation.Backdrops.Parallax;
using Celeste.Simulation.Presentation.Backdrops.Runtime;

namespace Celeste.Simulation.Presentation.Backdrops.Rendering
{
    public partial class BackdropRendererPresentation
    {
        private List<Func<BackdropPresentation, ISourceBackdropScene, bool>> visibilityPolicies;
        private List<OpacityPolicy> opacityPolicies;
        private VirtualRenderTarget opacityTarget;
        private SourceRenderTargetBinding[] previousOpacityTargets;

        public IDisposable AddVisibilityPolicy(Func<BackdropPresentation, ISourceBackdropScene, bool> policy)
        {
            (visibilityPolicies ??= []).Add(policy);
            return new BackdropPolicyLease(() =>
            {
                visibilityPolicies.Remove(policy);
                if (visibilityPolicies.Count == 0) visibilityPolicies = null;
            });
        }

        public IDisposable AddOpacityPolicy(Func<BackdropPresentation, ISourceBackdropScene, float?> policy,
            int width, int height)
        {
            var entry = new OpacityPolicy(policy, width, height);
            (opacityPolicies ??= []).Add(entry);
            return new BackdropPolicyLease(() =>
            {
                opacityPolicies.Remove(entry);
                if (opacityPolicies.Count != 0) return;
                opacityPolicies = null;
                opacityTarget?.Dispose();
                opacityTarget = null;
                previousOpacityTargets = null;
            });
        }

        private bool IsVisibleForRender(BackdropPresentation backdrop, ISourceBackdropScene scene)
        {
            if (backdrop.Visible) return true;
            if (visibilityPolicies != null)
                foreach (var policy in visibilityPolicies)
                    if (policy(backdrop, scene))
                        return true;
            return false;
        }

        private void RenderBackdrop(ISourceRenderContext context, ISourceBackdropScene scene,
            BackdropPresentation backdrop, SourceBlendState blendState)
        {
            OpacityPolicy selected = null;
            float opacity = 1;
            if (opacityPolicies != null)
                foreach (var policy in opacityPolicies)
                {
                    var value = policy.GetOpacity(backdrop, scene);
                    if (!value.HasValue) continue;
                    selected = policy;
                    opacity *= value.Value;
                }

            if (selected == null)
            {
                backdrop.Render(context, scene);
                return;
            }

            EndSpritebatch(scene);
            var device = ((ISourceGraphicsDeviceEnvironment)scene.EngineContext).GraphicsDevice;
            var previousViewport = device.Viewport;
            var previousScissor = device.ScissorRectangle;
            var count = device.GetRenderTargetsNoAllocEXT(null);
            if (previousOpacityTargets == null || previousOpacityTargets.Length != count)
                previousOpacityTargets = new SourceRenderTargetBinding[count];
            device.GetRenderTargetsNoAllocEXT(previousOpacityTargets);
            if (opacityTarget == null || opacityTarget.Width != selected.Width ||
                opacityTarget.Height != selected.Height)
            {
                opacityTarget?.Dispose();
                opacityTarget = ((ISourceVirtualContentEnvironment)scene.EngineContext).VirtualContent
                    .CreateRenderTarget("backdrop-opacity", selected.Width, selected.Height);
            }

            device.SetRenderTarget(opacityTarget.Target);
            device.Clear(PackedColor.Transparent);
            if (backdrop.UseSpritebatch)
            {
                if (backdrop is ParallaxBackdropPresentation)
                    StartSpritebatchLooping(scene, SourceBlendState.AlphaBlend);
                else StartSpritebatch(scene, SourceBlendState.AlphaBlend);
            }

            try
            {
                backdrop.Render(context, scene);
            }
            finally
            {
                EndSpritebatch(scene);
                device.SetRenderTargets(previousOpacityTargets);
                device.Viewport = previousViewport;
                device.ScissorRectangle = previousScissor;
            }

            StartSpritebatch(scene, blendState);
            ((ISourceDrawScope)scene.EngineContext).Draw.SpriteBatch.Draw(opacityTarget.Target, Vector2.Zero,
                (PackedColor.White * opacity).PackedValue);
        }

        private sealed class OpacityPolicy
        {
            public readonly Func<BackdropPresentation, ISourceBackdropScene, float?> GetOpacity;
            public readonly int Width;
            public readonly int Height;

            public OpacityPolicy(Func<BackdropPresentation, ISourceBackdropScene, float?> getOpacity, int width,
                int height)
            {
                GetOpacity = getOpacity;
                Width = width;
                Height = height;
            }
        }

        private sealed class BackdropPolicyLease : IDisposable
        {
            private Action remove;

            public BackdropPolicyLease(Action remove)
            {
                this.remove = remove;
            }

            public void Dispose()
            {
                var action = remove;
                remove = null;
                action?.Invoke();
            }
        }
    }
}
