using Celeste.Game.Entities.Platforms.Wood;
using Celeste.Game.Execution.Areas;
using Celeste.Game.Execution.Levels;

namespace Celeste.Everest.Entities.Platforms.Wood
{
    public sealed class EverestWoodPlatformAddedPolicy : IWoodPlatformAddedPolicy
    {
        public WoodPlatformAddedScope Begin(object incomingScene, string overrideTexture)
        {
            var area = (OriginalAreaData)((OriginalLevelSceneRoot)incomingScene).AreaData;
            var previous = area.WoodPlatform;
            if (overrideTexture != null) area.WoodPlatform = overrideTexture;
            return new(area, previous);
        }

        public void End(WoodPlatformAddedScope scope)
        {
            scope.Area.WoodPlatform = scope.PreviousTexture;
        }
    }
}
