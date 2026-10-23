using Celeste.Simulation.Gameplay.Hazards.Spinners.Dust;

namespace Celeste.Game.Execution.Levels
{
    public sealed partial class OriginalLevelSceneRoot : IDustGraphicScene
    {
        int IDustGraphicScene.DustAreaID => Session.AreaID;
    }
}
