using System;
using Celeste.Game.Execution.Engine;
using Celeste.Graphics.Content.VirtualAssets;
using Celeste.Input.Runtime;
using Celeste.Scene.Rendering;
using Celeste.Scene.Scenes;

namespace Celeste.Everest.Presentation.Scenes
{
    public class NestedSceneRenderer : SceneRenderer, IDisposable
    {
        public SourceSceneState WrappedScene;

        private VirtualRenderTarget hudTarget;
        private bool allocated;

        public NestedSceneRenderer(SourceSceneState scene)
        {
            WrappedScene = scene ?? throw new ArgumentNullException(nameof(scene));
        }

        public void Alloc()
        {
            if (allocated) return;
            hudTarget = ((ISourceVirtualContentEnvironment)WrappedScene.EngineContext).VirtualContent
                .CreateRenderTarget("hud-target", 1922, 1082);
            allocated = true;
        }

        public void Dispose()
        {
            if (!allocated) return;
            allocated = false;
            hudTarget.Dispose();
            hudTarget = null;
        }

        public VirtualRenderTarget SwapHudTarget(VirtualRenderTarget target)
        {
            var graphics = ((IOriginalEngineGraphicsEnvironment)WrappedScene.EngineContext).EngineGraphics;
            var previous = (VirtualRenderTarget)graphics.HudTarget;
            graphics.HudTarget = target;
            return previous;
        }

        public override void Update(object scene)
        {
            base.Update(scene);
            var input = ((ISourceMInputEnvironment)WrappedScene.EngineContext).MInput;
            var disabled = input.Disabled;
            input.Disabled = false;
            try
            {
                WrappedScene.BeforeUpdate();
                WrappedScene.Update();
                WrappedScene.AfterUpdate();
            }
            finally
            {
                input.Disabled = disabled;
            }
        }

        public override void BeforeRender(object scene)
        {
            base.BeforeRender(scene);
            var previous = SwapHudTarget(hudTarget);
            try
            {
                WrappedScene.BeforeRender();
            }
            finally
            {
                SwapHudTarget(previous);
            }
        }

        public override void AfterRender(object scene)
        {
            base.AfterRender(scene);
            var previous = SwapHudTarget(hudTarget);
            try
            {
                WrappedScene.Render();
                WrappedScene.AfterRender();
            }
            finally
            {
                SwapHudTarget(previous);
            }
        }
    }
}
