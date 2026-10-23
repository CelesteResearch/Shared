using Celeste.Core.Scheduling;
using Celeste.Game.Execution.Areas;

namespace Celeste.Game.Editor
{
    public interface IOriginalMapEditorConstruction
    {
        MapEditorState Create(ISourceEngineContext engine, OriginalAreaKey area, bool reloadMapData = true);
    }
}
