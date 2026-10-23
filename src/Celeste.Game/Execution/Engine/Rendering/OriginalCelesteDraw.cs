using System;
using Celeste.Core.Framework.Components;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Framework.Diagnostics.Commands;
using Celeste.Scene.Entities;

namespace Celeste.Game.Execution.Engine.Rendering
{
    public sealed class OriginalCelesteDraw : OriginalEngineDraw
    {
        private readonly ISourceRenderEnvironment renderEnvironment;
        public SceneEntityState DisconnectUI;
        public Action ContentLoadingOverlay;

        public OriginalCelesteDraw(SourceEngineSceneState scenes,
            SourceGameFrameworkState framework, SourceCommands commands,
            IOriginalEngineRenderDevice device, ISourceRenderEnvironment renderEnvironment)
            : base(scenes, framework, commands, device)
        {
            this.renderEnvironment = renderEnvironment ?? throw new ArgumentNullException(nameof(renderEnvironment));
        }

        protected override void RenderCore()
        {
            base.RenderCore();
            if (DisconnectUI != null)
                DisconnectUI.Render(renderEnvironment.CurrentContext);
            ContentLoadingOverlay?.Invoke();
        }
    }
}
