using System;
using Celeste.Core.Framework.Components;
using Celeste.Core.Framework.Timing;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Framework.Diagnostics.Commands;

namespace Celeste.Game.Execution.Engine.Rendering
{
    public class OriginalEngineDraw
    {
        private readonly SourceEngineSceneState scenes;
        private readonly SourceGameFrameworkState framework;
        private readonly SourceCommands commands;
        private readonly IOriginalEngineRenderDevice device;
        private int fpsCounter;
        private TimeSpan counterElapsed;
        public int FPS;

        public OriginalEngineDraw(SourceEngineSceneState scenes,
            SourceGameFrameworkState framework, SourceCommands commands,
            IOriginalEngineRenderDevice device)
        {
            this.scenes = scenes ?? throw new ArgumentNullException(nameof(scenes));
            this.framework = framework ?? throw new ArgumentNullException(nameof(framework));
            this.commands = commands ?? throw new ArgumentNullException(nameof(commands));
            this.device = device ?? throw new ArgumentNullException(nameof(device));
        }

        public void Draw(SourceGameTime gameTime)
        {
            RenderCore();
            framework.DrawComponents(gameTime);
            if (commands.Open) commands.Render();
            fpsCounter = unchecked(fpsCounter + 1);
            counterElapsed += gameTime.ElapsedGameTime;
            if (!(counterElapsed >= TimeSpan.FromSeconds(1.0)))
                return;
            FPS = fpsCounter;
            fpsCounter = 0;
            counterElapsed -= TimeSpan.FromSeconds(1.0);
        }

        protected virtual void RenderCore()
        {
            var diagnostics = SourceFrameDiagnostics.Current;
            if (scenes.CurrentScene != null)
            {
                long engineBeforeRenderStarted = 0;
                var measuringEngineBeforeRender =
                    diagnostics?.BeginEngineBeforeRender(out engineBeforeRenderStarted) ?? false;
                try
                {
                    ((ISourceSceneRenderExecution)scenes.CurrentScene).BeforeRender();
                }
                finally
                {
                    if (measuringEngineBeforeRender) diagnostics.EndEngineBeforeRender(engineBeforeRenderStarted);
                }
            }

            device.SetBackBuffer();
            device.SetViewport(EngineRuntime.Viewport);
            device.Clear(EngineRuntime.ClearColor);
            if (scenes.CurrentScene != null)
            {
                long sceneRenderStarted = 0;
                var measuringSceneRender = diagnostics?.BeginSceneRender(out sceneRenderStarted) ?? false;
                try
                {
                    ((ISourceSceneRenderExecution)scenes.CurrentScene).Render();
                }
                finally
                {
                    if (measuringSceneRender) diagnostics.EndSceneRender(sceneRenderStarted);
                }

                long engineAfterRenderStarted = 0;
                var measuringEngineAfterRender =
                    diagnostics?.BeginEngineAfterRender(out engineAfterRenderStarted) ?? false;
                try
                {
                    ((ISourceSceneRenderExecution)scenes.CurrentScene).AfterRender();
                }
                finally
                {
                    if (measuringEngineAfterRender) diagnostics.EndEngineAfterRender(engineAfterRenderStarted);
                }
            }
        }
    }
}
