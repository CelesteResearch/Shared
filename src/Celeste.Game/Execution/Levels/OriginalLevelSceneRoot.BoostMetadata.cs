using Celeste.Game.Content.Maps;
using Celeste.Simulation.Gameplay.Player.Scene;

namespace Celeste.Game.Execution.Levels
{
    public sealed partial class OriginalLevelSceneRoot : ISourcePlayerBoostMetadataScene
    {
        bool? ISourcePlayerBoostMetadataScene.BoostTheoInBubble
            => ((IOriginalChapterMapBoostMetadataEnvironment)EngineContext).ChapterMapBoostMetadata
                .GetTheoInBubble((OriginalChapterMapData)Session.MapData);
    }
}
