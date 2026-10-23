using Celeste.Core.Display;
using Celeste.Core.Scheduling;
using Celeste.Game.Execution.Areas;
using Celeste.Graphics.Geometry.TwoD.Camera;

namespace Celeste.Game.Editor
{
    public abstract class MapEditorProcessState
    {
        public abstract PackedColor GridColor { get; }
        public abstract LevelTemplateColorsState TemplateColors { get; }
        public CameraState Camera;
        public OriginalAreaKey Area;
        public float SaveFlash;

        protected MapEditorProcessState(ISourceEngineContext engine)
        {
            Area = ((IOriginalAreaKeyEnvironment)engine).AreaKeys.Create(-1);
        }
    }
}
