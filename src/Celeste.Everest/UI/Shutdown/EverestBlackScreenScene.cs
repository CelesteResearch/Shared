using Celeste.Core.Display;
using System;
using Celeste.Core.Scheduling;
using Celeste.Scene.Scenes;
using Celeste.Scene.Tracking;
using Celeste.Scene.Scheduling;
using Celeste.Graphics.Display;
using Celeste.Graphics.Rendering.Devices;

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
            if (RunAfterRender != null)
            {
                RunAfterRender();
                RunAfterRender = null;
            }
        }
    }
}
