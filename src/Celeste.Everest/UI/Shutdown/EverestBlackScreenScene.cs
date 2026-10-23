using System;
using Celeste.Core.Display;
using Celeste.Core.Scheduling;
using Celeste.Graphics.Rendering.Devices;
using Celeste.Scene.Scenes;
using Celeste.Scene.Scheduling;
using Celeste.Scene.Tracking;

namespace Celeste.Everest.UI.Shutdown
{
    public sealed class EverestBlackScreenScene : SourceSceneState
    {
        public Action RunAfterRender;

        public EverestBlackScreenScene(ISourceEngineContext engine)
            : base(engine, ((ISourceSceneCatalogEnvironment)engine).SceneCatalog,
                ((ISourceSceneUpdatePolicyEnvironment)engine).PlainScenePolicy)
        {
        }

        public override void Render()
        {
            base.Render();
            ((ISourceGraphicsDeviceEnvironment)EngineContext).GraphicsDevice.Clear(PackedColor.Black);
        }

        public override void AfterRender()
        {
            base.AfterRender();
            if (!(RunAfterRender != null))
                return;
            RunAfterRender();
            RunAfterRender = null;
        }
    }
}
