using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Numerics;
using Celeste.Audio.Framework;
using Celeste.Core.Geometry;
using Celeste.Core.Randomness;
using Celeste.Core.Scheduling;
using Celeste.Everest.Content.Registry;
using Celeste.Everest.Modules.Persistence.GameSaves;
using Celeste.Everest.Runtime.Startup;
using Celeste.Framework.Diagnostics.Commands;
using Celeste.Game.Chapters.Flow;
using Celeste.Game.Content.Maps;
using Celeste.Game.Diagnostics.Scenes;
using Celeste.Game.Execution;
using Celeste.Game.Execution.Areas;
using Celeste.Game.Execution.LevelLoader;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Execution.Session;
using Celeste.Game.Gameplay.Tutorials.Playback;
using Celeste.Game.Menus.Overworld;
using Celeste.Game.Save.Data;
using Celeste.Game.Save.IO;
using Celeste.Game.Save.Runtime;
using Celeste.Scene.Scenes;
using Celeste.Simulation;
using Celeste.Simulation.Runtime.Session;
using Celeste.Simulation.Save.Progress;

namespace Celeste.Everest.Diagnostics.Commands
{
    public static class InstalledCelesteCommands
    {
        private static ISourceEngineContext Process => EngineRuntime.Instance.Process;
        private static OriginalSaveDataState CurrentSave => ((IOriginalGameplayProcess)Process).SaveContext.CurrentSave;

        private static SourceSceneState Scene
        {
            get => (SourceSceneState)Process.Frame.Scenes.CurrentScene;
            set => Process.Frame.Scenes.NextScene = value;
        }

        private static SourceCommands Console => EngineRuntime.Instance.Commands;
        private static IOriginalAreaKeyPolicy AreaKeys => ((IOriginalAreaKeyEnvironment)Process).AreaKeys;
        private static OriginalSessionFactory Sessions => ((IOriginalSessionEnvironment)Process).Sessions;

        private static EverestSaveRuntimePolicy SavePolicy =>
            (EverestSaveRuntimePolicy)((IOriginalSaveCounterEnvironment)Process).SaveCounters;

        private static void InitializeDebugMode()
        {
            ((IOriginalSaveDebugEnvironment)Process).SaveDebug.InitializeDebugMode(
                ((IOriginalUserIOStorageEnvironment)Process).UserIOStorage,
                (IOriginalSaveInitializationServices)Process);
        }

        private static OriginalLevelLoaderScene CreateLevelLoader(ChapterCompletionSession session)
        {
            return ((IOriginalLevelLoaderEnvironment)Process).LevelLoaders.CreateLevelLoader(session);
        }

        private static OverworldLoaderSequence CreateOverworldLoader(OverworldStartMode mode)
        {
            return ((IOriginalOverworldLoaderEnvironment)Process).OverworldLoaders.CreateOverworldLoader(mode);
        }

        private static void CmdHeartGem(int area, int mode, bool gem = true)
        {
            SavePolicy.GetAreasSafe(CurrentSave)[area].Modes[mode].HeartGem = gem;
        }


        private static void CmdComplete(int index = 1, int mode = 0, int deaths = 0, int strawberries = 0,
            bool gem = false)
        {
            if (CurrentSave == null)
            {
                InitializeDebugMode();
                CurrentSave.CurrentSessionSafe = Sessions.CreateSession(AreaKeys.Create(0));
            }

            var area = AreaKeys.Create(index, mode);
            var num = 0;
            var session = Sessions.CreateSession(area);
            while (session.Strawberries.Count < strawberries)
            {
                num++;
                session.Strawberries.Add(new("null", num));
            }

            session.Deaths = deaths;
            session.Cassette = gem;
            session.Time = 100000L + ((ISourceRandomEnvironment)Process).Random.Next();
            Scene = ((IOriginalLevelExitEnvironment)Process).LevelExits.CreateLevelExit(LevelExitMode.Completed,
                session);
        }


        private static void CmdOWComplete(int index = 1, int mode = 0, int deaths = 0, int strawberries = -1,
            bool cassette = true, bool heartGem = true, float beatBestTimeBy = 1.7921f,
            float beatBestFullClearTimeBy = 1.7921f)
        {
            if (CurrentSave == null)
            {
                InitializeDebugMode();
                CurrentSave.CurrentSessionSafe = Sessions.CreateSession(AreaKeys.Create(0));
            }

            var areaKey = AreaKeys.Create(index, mode);
            var session = Sessions.CreateSession(areaKey);
            var areaStats = SavePolicy.GetAreasSafe(CurrentSave)[index];
            var areaModeStats = areaStats.Modes[mode];
            var totalSeconds = TimeSpan.FromTicks(areaModeStats.BestTime).TotalSeconds;
            var totalSeconds2 = TimeSpan.FromTicks(areaModeStats.BestFullClearTime).TotalSeconds;
            ((IOriginalSaveCompletionPolicy)((IOriginalSaveCounterEnvironment)Process).SaveCounters).RegisterCompletion(
                CurrentSave, session);
            CurrentSave.CurrentSessionSafe = session;
            CurrentSave.CurrentSessionSafe.OldStats =
                ((IOriginalAreaStatsPolicy)((IOriginalSaveCounterEnvironment)Process).SaveCounters)
                .CreateAreaStats(index);
            CurrentSave.LastAreaSafe = areaKey;
            if (mode == 0)
            {
                if (strawberries == -1)
                    areaStats.Modes[0].TotalStrawberries =
                        ((IOriginalAreaSourceTable)Process).Areas[index].Mode[0].TotalStrawberries;
                else
                    areaStats.Modes[0].TotalStrawberries = Math.Max(areaStats.TotalStrawberries, strawberries);

                if (cassette) areaStats.Cassette = true;
            }

            areaModeStats.Deaths = Math.Max(deaths, areaModeStats.Deaths);
            if (heartGem) areaModeStats.HeartGem = true;

            if (totalSeconds <= 0.0)
                areaModeStats.BestTime = ((ISourceAudioEnvironment)Process).AudioMedia
                    .Audio
                    .TimeSpans.FromMinutes(5.0).Ticks;
            else if (beatBestTimeBy > 0f)
                areaModeStats.BestTime = ((ISourceAudioEnvironment)Process).AudioMedia
                    .Audio
                    .TimeSpans.FromSeconds(totalSeconds - beatBestTimeBy).Ticks;

            if (beatBestFullClearTimeBy > 0f)
            {
                if (totalSeconds2 <= 0.0)
                    areaModeStats.BestFullClearTime = ((ISourceAudioEnvironment)Process)
                        .AudioMedia.Audio.TimeSpans.FromMinutes(5.0).Ticks;
                else
                    areaModeStats.BestFullClearTime = ((ISourceAudioEnvironment)Process)
                        .AudioMedia.Audio.TimeSpans.FromSeconds(totalSeconds2 - beatBestFullClearTimeBy).Ticks;
            }

            Scene = CreateOverworldLoader(OverworldStartMode.AreaComplete);
        }


        private static void CmdFlag(string flag, bool setTo = true)
        {
            CurrentSave.CurrentSessionSafe.SetFlag(flag, setTo);
        }


        private static void CmdLevelFlag(string flag)
        {
            CurrentSave.CurrentSessionSafe.LevelFlags.Add(flag);
        }


        private static void CmdOverworld()
        {
            if (CurrentSave == null)
            {
                InitializeDebugMode();
                CurrentSave.CurrentSessionSafe = Sessions.CreateSession(AreaKeys.Default);
            }

            Scene = CreateOverworldLoader(OverworldStartMode.Titlescreen);
        }


        private static void CmdLoad(int id = 0, string level = null)
        {
            LoadIdLevel(OriginalAreaMode.Normal, id, level);
        }


        private static void CmdHard(int id = 0, string level = null)
        {
            LoadIdLevel(OriginalAreaMode.BSide, id, level);
        }


        private static void CmdRMX2(int id = 0, string level = null)
        {
            LoadIdLevel(OriginalAreaMode.CSide, id, level);
        }


        private static void CmdHearts(int amount = int.MaxValue, string levelSet = null)
        {
            var instance = CurrentSave;
            if (instance == null) return;

            if (string.IsNullOrEmpty(levelSet)) levelSet = SavePolicy.GetLevelSet(instance);

            var num = 0;
            foreach (var item in from ChapterAreaProgress stats in SavePolicy.GetAreasSafe(instance)
                     where AreaKeys.GetAreaById(SavePolicy.GetAreaStatsId(stats)).LevelSet == levelSet
                     select stats)
                for (var num2 = 0; num2 < item.Modes.Length; num2++)
                {
                    var mode = AreaKeys.GetAreaById(SavePolicy.GetAreaStatsId(item)).Mode;
                    if (mode != null && mode.Length > num2 && mode[num2]?.MapData != null)
                    {
                        var areaModeStats = item.Modes[num2];
                        if (num < amount)
                        {
                            areaModeStats.HeartGem = true;
                            num++;
                        }
                        else
                        {
                            areaModeStats.HeartGem = false;
                        }
                    }
                }
        }


        private static void CmdCapture(string filename)
        {
            var entity =
                Scene.SourceScene.Entities.GetTrackedEntity<RoomPlayerSession>(
                    typeof(RoomPlayerSession).FullName);

            if (entity != null)
                OriginalPlaybackData.Export(entity.ChaserStates,
                    Path.Combine(((IEverestContentRegistryEnvironment)Process).SourceContentRegistry.PathContentOrig,
                        "Tutorials", filename + ".bin"));
        }


        private static void CmdPlayback(string filename)
        {
            filename = Path.Combine(((IEverestContentRegistryEnvironment)Process).SourceContentRegistry.PathContentOrig,
                "Tutorials", filename + ".bin");
            if (((ISourceEverestFileProxyEnvironment)Process).FileProxy.Exists(filename))
                Scene = ((IOriginalPreviewRecordingEnvironment)Process).PreviewRecordings.CreatePreviewRecording(
                    Process,
                    filename);
            else
                Console.Log("FILE NOT FOUND");
        }


        private static void CmdPrintCounts()
        {
            if (CurrentSave == null)
            {
                Console.Log("No save loaded!");
                return;
            }

            var levelSetStats = SavePolicy.GetLevelSetStats(CurrentSave);
            Console.Log($"** Level Set Stats: {levelSetStats.Name} **");
            Console.Log($"Max strawberry count = {levelSetStats.MaxStrawberries}");
            Console.Log($"Max golden strawberry count = {levelSetStats.MaxGoldenStrawberries}");
            Console.Log(
                $"Max strawberry count including untracked = {levelSetStats.MaxStrawberriesIncludingUntracked}");
            Console.Log($"Max cassettes = {levelSetStats.MaxCassettes}");
            Console.Log($"Max crystal hearts = {levelSetStats.MaxHeartGems}");
            Console.Log($"Max crystal hearts excluding C-sides = {levelSetStats.MaxHeartGemsExcludingCSides}");
            Console.Log($"Chapter count = {levelSetStats.MaxCompletions}");
            Console.Log("====");
            Console.Log($"Owned strawberries = {levelSetStats.TotalStrawberries}");
            Console.Log($"Owned golden strawberries = {levelSetStats.TotalGoldenStrawberries}");
            Console.Log($"Owned cassettes = {levelSetStats.TotalCassettes}");
            Console.Log($"Owned crystal hearts = {levelSetStats.TotalHeartGems}");
            Console.Log($"Completed chapters = {levelSetStats.TotalCompletions}");
            Console.Log("====");
            Console.Log($"Completion percent = {levelSetStats.CompletionPercent}");
        }


        private static void LoadIdLevel(OriginalAreaMode areaMode, int id = 0, string level = null)
        {
            InitializeDebugMode();
            var areaKey = AreaKeys.Create(id, (int)areaMode);
            CurrentSave.LastAreaSafe = areaKey;
            var session = Sessions.CreateSession(areaKey);
            if (level != null && session.MapData.GetLevel(level) != null)
            {
                if (Sessions.GetCheckpoint(areaKey, level) != null)
                {
                    session = Sessions.CreateSession(areaKey, level);
                    session.StartCheckpoint = null;
                }
                else
                {
                    session.Level = level;
                }

                session.StartedFromBeginning = session.FirstLevel = level == session.MapData.StartLevel().Name;
            }

            Scene = CreateLevelLoader(session);
        }


        private static void CmdLoadIDorSID(string idOrSID = "0", string level = null)
        {
            if (int.TryParse(idOrSID, out var result))
                CmdLoad(result, level);
            else
                loadMapBySID(idOrSID, level, OriginalAreaMode.Normal, CmdLoad);
        }


        private static void CmdHardIDorSID(string idOrSID = null, string level = null)
        {
            if (int.TryParse(idOrSID, out var result))
                CmdHard(result, level);
            else
                loadMapBySID(idOrSID, level, OriginalAreaMode.BSide, CmdHard);
        }


        private static void CmdRMX2IDorSID(string idOrSID = null, string level = null)
        {
            if (int.TryParse(idOrSID, out var result))
                CmdRMX2(result, level);
            else
                loadMapBySID(idOrSID, level, OriginalAreaMode.CSide, CmdRMX2);
        }


        private static void loadMapBySID(string sid, string room, OriginalAreaMode mode,
            Action<int, string> vanillaLoadFunction)
        {
            if (sid == null)
            {
                Console.Log("Please specify a map ID or SID.");
                return;
            }

            var areaData = AreaKeys.GetAreaBySID(sid);
            OriginalChapterMapData mapData = null;
            if (areaData?.Mode.Length > (int?)mode)
                mapData = areaData == null ? null : areaData.Mode[(int)mode]?.MapData;

            if (areaData == null)
            {
                Console.Log($"Map {sid} does not exist!");
                return;
            }

            if (mapData == null)
            {
                Console.Log($"Map {sid} has no {mode} mode!");
                return;
            }

            if (room != null)
            {
                var levels = mapData.Levels;
                if (levels != null && levels.All(level => level.Name != room))
                {
                    Console.Log($"Map {sid} / mode {mode} has no room named {room}!");
                    return;
                }
            }

            vanillaLoadFunction(areaData.ID, room);
        }


        private static void CmdExportObj(string objPath, string objExportPath = null)
        {
            if (!File.Exists(objPath))
            {
                Console.Log($"File {objPath} does not exist!");
                return;
            }

            if (objExportPath == null) objExportPath = objPath + ".export";

            using var binaryWriter = new BinaryWriter(File.OpenWrite(objExportPath));
            using var streamReader = new StreamReader(File.OpenRead(objPath));
            var list = new List<MeshData>();
            MeshData meshData = null;
            string text;
            while ((text = streamReader.ReadLine()) != null)
            {
                var array = text.Split(' ');
                if (array.Length == 0) continue;

                switch (array[0])
                {
                    case "o":
                        meshData = new();
                        meshData.Name = array[1];
                        list.Add(meshData);
                        break;
                    case "v":
                    {
                        var item3 = new Vector3(Float(array[1]), Float(array[2]), Float(array[3]));
                        meshData.Vertices.Add(item3);
                        break;
                    }
                    case "vt":
                    {
                        var item2 = new Vector2(Float(array[1]), Float(array[2]));
                        meshData.TextureCoordinates.Add(item2);
                        break;
                    }
                    case "f":
                    {
                        for (var i = 1; i < Math.Min(4, array.Length); i++)
                        {
                            var item = default(IntPoint);
                            var array2 = array[i].Split('/');
                            if (array2[0].Length > 0) item.X = int.Parse(array2[0]);

                            if (array2[1].Length > 0) item.Y = int.Parse(array2[1]);

                            meshData.FaceData.Add(item);
                        }

                        break;
                    }
                }
            }

            binaryWriter.Write(list.Count);
            foreach (var item4 in list) item4.WriteTo(binaryWriter);
        }


        private static float Float(string data)
        {
            return float.Parse(data, CultureInfo.InvariantCulture);
        }


        private static void CmdMainMenu()
        {
            Scene = CreateOverworldLoader(OverworldStartMode.MainMenu);
        }


        private static void ReturnToMap()
        {
            if (CurrentSave == null)
            {
                InitializeDebugMode();
                CurrentSave.CurrentSessionSafe = Sessions.CreateSession(AreaKeys.Default);
            }

            Scene = CreateOverworldLoader(OverworldStartMode.AreaQuit);
        }


        private static void CmdOpenLog()
        {
            var pathLog = ((IEverestStartupRuntimeEnvironment)Process).EverestRuntime.PathLog;
            if (File.Exists(pathLog))
                System.Diagnostics.Process.Start(new ProcessStartInfo
                {
                    FileName = pathLog,
                    UseShellExecute = true,
                });
            else
                Console.Log(pathLog + " does not exist");
        }

        private class MeshData
        {
            public string Name;

            public readonly List<Vector3> Vertices = [];

            public readonly List<Vector2> TextureCoordinates = [];

            public readonly List<IntPoint> FaceData = [];

            public void WriteTo(BinaryWriter writer)
            {
                writer.Write(Name);
                writer.Write(Vertices.Count);
                foreach (var vertex in Vertices)
                {
                    writer.Write(vertex.X);
                    writer.Write(vertex.Y);
                    writer.Write(vertex.Z);
                }

                writer.Write(TextureCoordinates.Count);
                foreach (var textureCoordinate in TextureCoordinates)
                {
                    writer.Write(textureCoordinate.X);
                    writer.Write(textureCoordinate.Y);
                }

                writer.Write(FaceData.Count);
                foreach (var faceDatum in FaceData)
                {
                    writer.Write(faceDatum.X);
                    writer.Write(faceDatum.Y);
                }
            }
        }
    }
}
