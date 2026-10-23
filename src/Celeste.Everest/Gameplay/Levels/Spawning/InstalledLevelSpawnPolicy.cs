using System.Numerics;
using Celeste.Game.Content.Maps.Levels;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Levels.Spawning;

namespace Celeste.Everest.Gameplay.Levels.Spawning
{
    public sealed class InstalledLevelSpawnPolicy : IOriginalLevelSpawnPolicy
    {
        public Vector2 GetDefaultSpawnPoint(OriginalLevelSceneRoot level)
        {
            if (level.AreaData.LevelSet == "Celeste")
                return level.GetSpawnPoint(new Vector2(level.Bounds.Left, level.Bounds.Bottom));
            var room = ((OriginalLevelRoomData)level.Session.LevelData);
            return room.DefaultSpawn ?? room.Spawns[0];
        }
    }
}
