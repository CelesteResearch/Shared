using Celeste.Game.Execution.Areas;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Profiles;

namespace Celeste.Game.Gameplay.Hazards.Puffer
{
    public partial class OriginalPufferState
    {
        public override void Added(object actualScene)
        {
            base.Added(actualScene);
            if (((IGameProfileEnvironment)sourceEngine).SourceProfile ==
                GameProfile.InstalledEverest
                && Depth == 0)
            {
                var areas = ((IOriginalAreaKeyEnvironment)sourceEngine).AreaKeys;
                if (areas.GetLevelSet(areas.GetSessionArea((actualScene as OriginalLevelSceneRoot).Session)) !=
                    "Celeste")
                    Depth = -1;
            }
        }
    }
}
