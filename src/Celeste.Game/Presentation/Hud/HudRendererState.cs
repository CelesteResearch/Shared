using Celeste.Core.Display;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Game.Execution.Startup;
using Celeste.Graphics.Rendering;
using Celeste.Scene.Tracking;
using Celeste.Simulation.Presentation.Rendering;

namespace Celeste.Game.Presentation.Hud
{
    public class HudRendererState : HiresRendererState
    {
        public float BackgroundFade;

        public HudRendererState() : base(1920, 1080)
        {
        }

        public override void RenderContent(object scene, ISourceRenderContext context)
        {
            var entities = ((ISourceScene)scene).SourceScene.Entities;
            var engine = ((ISourceEngineContextScene)scene).EngineContext;
            if (entities.HasVisibleEntities(((IOriginalGameTagsEnvironment)engine).Tags.HUD.Value) ||
                BackgroundFade > 0f)
            {
                BeginRender(context);
                if (BackgroundFade > 0f)
                    SourcePrimitiveDrawing.Rect(context, this, -1f, -1f, 1922f, 1082f,
                        PackedColor.Black * BackgroundFade * .7f);
                entities.RenderOnly(((IOriginalGameTagsEnvironment)engine).Tags.HUD.Value, context);
                EndRender(context);
            }
        }
    }
}
