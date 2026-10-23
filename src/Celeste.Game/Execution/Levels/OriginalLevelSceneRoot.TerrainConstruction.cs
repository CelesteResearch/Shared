using System.Numerics;
using Celeste.Core.Collections;
using Celeste.Game.Execution.LevelLoader.Terrain;

namespace Celeste.Game.Execution.Levels
{
    public sealed partial class OriginalLevelSceneRoot
    {
        public OriginalSolidTiles CreateSourceSolidTiles(Vector2 position, VirtualMap<char> data)
        {
            return new(position, data,
                SolidWorldFactory.Create(position, true));
        }

        public OriginalBackgroundTiles CreateSourceBackgroundTiles(Vector2 position, VirtualMap<char> data)
        {
            return new(position, data, EngineContext);
        }
    }
}
