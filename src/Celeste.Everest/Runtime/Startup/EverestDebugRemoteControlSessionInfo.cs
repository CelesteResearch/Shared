using System;
using System.Linq;
using System.Numerics;
using System.Net;
using System.Text;
using System.Threading;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using Celeste.Core.Scheduling;
using Celeste.Scene.Tracking;
using Celeste.Scene.Scenes;
using Celeste.Simulation;
using Celeste.Simulation.Runtime.Session;
using Celeste.Game.Execution.Areas;
using Celeste.Game.Content.Maps;
using Celeste.Game.Content.Maps.Entities;
using Celeste.Game.Content.Maps.Levels;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.LevelLoader;
using Celeste.Game.Execution.Session;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Execution.Startup;
using Celeste.Game.Save.Runtime;
using Celeste.Game.Save.IO;
using Celeste.Everest.Modules.Runtime;
using Celeste.Everest.Modules.Settings;
using Celeste.Everest.Content.Registry;
using Celeste.Everest.Content.Assets;
using Celeste.Everest.Content.Serialization;
using Celeste.Everest.Diagnostics.Logging;
using Celeste.Everest.Diagnostics.Commands;
using Celeste.Everest.Runtime.Threading;
using Celeste.Framework.Diagnostics.Commands;

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

        public string TP
        {
            get
            {
                if (!string.IsNullOrEmpty(Area))
                {
                    return
                        $"/tp?area={Area}&side={Side}&level={Level}&x={X.ToString(CultureInfo.InvariantCulture)}&y={Y.ToString(CultureInfo.InvariantCulture)}";
                }

                return "";
            }
        }

        public EverestDebugRemoteControlSessionInfo(ISourceEngineContext engine, OriginalLevelSceneRoot level)
        {
            if (level?.Session != null)
            {
                Area = ((IOriginalAreaKeyEnvironment)engine).AreaKeys.GetSID(
                    ((IOriginalAreaKeyEnvironment)engine).AreaKeys.GetSessionArea(level.Session));
                Side = (char)(65 + ((IOriginalAreaKeyEnvironment)engine).AreaKeys.GetSessionArea(level.Session).Mode);
                Level = level.Session.Level;
                MapBin = ((OriginalChapterMapData)level.Session.MapData).Filename;
                Vector2 vector =
                    ((ISourceScene)level).SourceScene.Entities
                    .GetTrackedEntity<RoomPlayerSession>(typeof(global::Celeste.Simulation.RoomPlayerSession).FullName)
                    ?.Position ?? level.Session.RespawnPoint ?? Vector2.Zero;
                vector -= ((OriginalLevelRoomData)level.Session.LevelData).Position;
                X = vector.X;
                Y = vector.Y;
            }
        }
    }
}
