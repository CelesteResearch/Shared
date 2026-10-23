using System.Globalization;
using System.Numerics;
using Celeste.Core.Scheduling;
using Celeste.Game.Content.Maps;
using Celeste.Game.Content.Maps.Levels;
using Celeste.Game.Execution.Areas;
using Celeste.Game.Execution.Levels;
using Celeste.Scene.Tracking;
using Celeste.Simulation;

namespace Celeste.Everest.Runtime.Startup
{
    public sealed class EverestDebugRemoteControlSessionInfo
    {
        public string Area { get; set; }

        public char Side { get; set; } = '?';

        public string Level { get; set; }

        public string MapBin { get; set; }

        public float X { get; set; }

        public float Y { get; set; }

        public string TP => !string.IsNullOrEmpty(Area)
            ? $"/tp?area={Area}&side={Side}&level={Level}&x={X.ToString(CultureInfo.InvariantCulture)}&y={Y.ToString(CultureInfo.InvariantCulture)}"
            : "";

        public EverestDebugRemoteControlSessionInfo(ISourceEngineContext engine, OriginalLevelSceneRoot level)
        {
            if (level?.Session != null)
            {
                Area = ((IOriginalAreaKeyEnvironment)engine).AreaKeys.GetSID(
                    ((IOriginalAreaKeyEnvironment)engine).AreaKeys.GetSessionArea(level.Session));
                Side = (char)(65 + ((IOriginalAreaKeyEnvironment)engine).AreaKeys.GetSessionArea(level.Session).Mode);
                Level = level.Session.Level;
                MapBin = ((OriginalChapterMapData)level.Session.MapData).Filename;
                var vector =
                    ((ISourceScene)level).SourceScene.Entities
                    .GetTrackedEntity<RoomPlayerSession>(typeof(RoomPlayerSession).FullName)
                    ?.Position ?? level.Session.RespawnPoint ?? Vector2.Zero;
                vector -= ((OriginalLevelRoomData)level.Session.LevelData).Position;
                X = vector.X;
                Y = vector.Y;
            }
        }
    }
}
