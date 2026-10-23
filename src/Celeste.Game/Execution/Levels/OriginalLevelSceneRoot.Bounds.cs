using Celeste.Core.Geometry;
using Celeste.Game.Content.Maps.Levels;
using Celeste.Scene.Geometry;

namespace Celeste.Game.Execution.Levels
{
    public sealed partial class OriginalLevelSceneRoot : ISourceSceneBounds
    {
        public IntRect Bounds => ((OriginalLevelRoomData)Session.LevelData).Bounds;
    }
}
