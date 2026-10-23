using Celeste.Core.Display;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Content.Maps.Levels;
using Celeste.Graphics.Display;
using System;
using System.IO;
using System.Xml.Serialization;
using System.Numerics;
using Celeste.Core.Maps;
using Celeste.Core.Randomness;
using Celeste.Core.Mathematics;
using Celeste.Audio.Framework;
using Celeste.Game.Content.Dialogs;
using Celeste.Game.Execution.Areas;
using Celeste.Game.Execution.LevelLoader;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Menus.Overworld;
using Celeste.Game.Chapters.Flow;
using Celeste.Game.Save.Runtime;
using Celeste.Game.Minigames.CelesteClassic.Emulation;
using Celeste.Game.Presentation.Environment;
using Celeste.Game.Presentation.Backdrops.Blackhole;
using Celeste.Game.Audio;
using Celeste.Formats.Graphics.Atlas;
using Celeste.Simulation.Runtime.Session;
using Celeste.Simulation.Gameplay.Player.Intro;
using Celeste.Simulation.Save.Progress;
using Celeste.Localization.Languages;
using Celeste.Graphics.Display.Colors;
using Celeste.Framework.Diagnostics.Commands;

namespace Celeste.Game.Execution.Engine.Commands
{
    public static partial class OriginalCelesteCommands
    {
        [SourceCommandAttribute("export_dialog", "export dialog files to binary format")]
        private static void CmdExportDialog()
        {
            foreach (string item in Directory.EnumerateFiles(Path.Combine("Content", "Dialog"), "*.txt"))
            {
                if (item.EndsWith(".txt"))
                {
                    DialogLanguage language = Text.ReadLanguageText(item);
                    OriginalDialogLanguageCodec.Export(language, item + ".export");
                    language.Dispose();
                }
            }
        }


        [SourceCommandAttribute("logsession", "log session to output")]
        private static void CmdLogSession()
        {
            ChapterCompletionSession session = (Scene as OriginalLevelSceneRoot).Session;
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ChapterCompletionSession));
            StringWriter stringWriter = new StringWriter();
            xmlSerializer.Serialize(stringWriter, session);
            global::System.Console.WriteLine(stringWriter.ToString());
        }


        [SourceCommandAttribute("textures", "counts textures in memory")]
        private static void CmdTextures()
        {
            Console.Log(((ISourceAtlasLoaderEnvironment)Process).VirtualContent.Count);
            ((ISourceAtlasLoaderEnvironment)Process).VirtualContent.BySize();
        }


        [SourceCommandAttribute("ref_fall", "test the reflection fall sequence")]
        private static void CmdRefFall()
        {
            InitializeDebugMode();
            ChapterCompletionSession session = Sessions.CreateSession(AreaKeys.Create(6));
            session.Level = "04";
            var loader = ((IOriginalLevelLoaderEnvironment)Process).LevelLoaders.CreateLevelLoader(session,
                session.GetSpawnPoint(new Vector2(((OriginalLevelRoomData)session.LevelData).Bounds.Center.X,
                    ((OriginalLevelRoomData)session.LevelData).Bounds.Top)));
            loader.PlayerIntroTypeOverride = PlayerIntroType.Fall;
            loader.Level.SourceScene.QueueSourceEntity(new BackgroundFadeInState(Process, PackedColor.Black, 2f, 30f));
            Scene = loader;
        }

        [SourceCommandAttribute("pico", "plays pico-8 game, optional room skip (x/y)")]
        private static void CmdPico(int roomX = 0, int roomY = 0)
        {
            Scene = ClassicConsoleRuntime.Create(Process, null, roomX, roomY);
        }


        [SourceCommandAttribute("complete", "test the complete screen for an area")]
        private static void CmdComplete(int index = 1, int mode = 0, int deaths = 0, int strawberries = 0,
            bool gem = false)
        {
            if (CurrentSave == null)
            {
                InitializeDebugMode();
                CurrentSave.CurrentSession = Sessions.CreateSession(AreaKeys.Create(0));
            }

            OriginalAreaKey area = AreaKeys.Create(index, mode);
            int num = 0;
            ChapterCompletionSession session = Sessions.CreateSession(area);
            while (session.Strawberries.Count < strawberries)
            {
                num++;
                session.Strawberries.Add(new MapEntityId("null", num));
            }

            session.Deaths = deaths;
            session.Cassette = gem;
            session.Time = 100000L + (long)((ISourceRandomEnvironment)Process).Random.Next();
            Scene = ((IOriginalLevelExitEnvironment)Process).LevelExits.CreateLevelExit(LevelExitMode.Completed,
                session);
        }


        [SourceCommandAttribute("ow_complete", "test the completion sequence on the overworld after a level")]
        private static void CmdOWComplete(int index = 1, int mode = 0, int deaths = 0, int strawberries = -1,
            bool cassette = true, bool heartGem = true, float beatBestTimeBy = 1.7921f,
            float beatBestFullClearTimeBy = 1.7921f)
        {
            if (CurrentSave == null)
            {
                InitializeDebugMode();
                CurrentSave.CurrentSession = Sessions.CreateSession(AreaKeys.Create(0));
            }

            OriginalAreaKey areaKey = AreaKeys.Create(index, mode);
            ChapterCompletionSession session = Sessions.CreateSession(areaKey);
            ChapterAreaProgress areaStats = CurrentSave.Areas[index];
            ChapterModeProgress areaModeStats = areaStats.Modes[mode];
            double totalSeconds = TimeSpan.FromTicks(areaModeStats.BestTime).TotalSeconds;
            double totalSeconds2 = TimeSpan.FromTicks(areaModeStats.BestFullClearTime).TotalSeconds;
            ((IOriginalSaveCompletionPolicy)((IOriginalSaveCounterEnvironment)Process).SaveCounters).RegisterCompletion(
                CurrentSave, session);
            ((IOriginalSaveSessionSelectionEnvironment)Process).SaveSessionSelection
                .SetCurrentSessionSafe(CurrentSave, session);
            ((IOriginalSaveSessionSelectionEnvironment)Process).SaveSessionSelection
                .GetCurrentSessionSafe(CurrentSave).OldStats =
                ((IOriginalAreaStatsPolicy)((IOriginalSaveCounterEnvironment)Process).SaveCounters)
                .CreateAreaStats(index);
            CurrentSave.LastArea = areaKey;
            if (mode == 0)
            {
                if (strawberries == -1)
                {
                    areaStats.Modes[0].TotalStrawberries =
                        ((IOriginalAreaSourceTable)Process).Areas[index].Mode[0].TotalStrawberries;
                }
                else
                {
                    areaStats.Modes[0].TotalStrawberries = Math.Max(areaStats.TotalStrawberries, strawberries);
                }

                if (cassette)
                {
                    areaStats.Cassette = true;
                }
            }

            areaModeStats.Deaths = Math.Max(deaths, areaModeStats.Deaths);
            if (heartGem)
            {
                areaModeStats.HeartGem = true;
            }

            if (totalSeconds <= 0.0)
            {
                areaModeStats.BestTime =
                    ((ISourceAudioEnvironment)Process).AudioMedia.Audio.TimeSpans.FromMinutes(5.0).Ticks;
            }
            else if (beatBestTimeBy > 0f)
            {
                areaModeStats.BestTime = ((ISourceAudioEnvironment)Process).AudioMedia.Audio.TimeSpans
                    .FromSeconds(totalSeconds - (double)beatBestTimeBy).Ticks;
            }

            if (beatBestFullClearTimeBy > 0f)
            {
                if (totalSeconds2 <= 0.0)
                {
                    areaModeStats.BestFullClearTime = ((ISourceAudioEnvironment)Process).AudioMedia.Audio.TimeSpans
                        .FromMinutes(5.0).Ticks;
                }
                else
                {
                    areaModeStats.BestFullClearTime = ((ISourceAudioEnvironment)Process).AudioMedia.Audio.TimeSpans
                        .FromSeconds(totalSeconds2 - (double)beatBestFullClearTimeBy).Ticks;
                }
            }

            Scene = CreateOverworldLoader(OverworldStartMode.AreaComplete);
        }


        [SourceCommandAttribute("music", "play a music track")]
        private static void CmdMusic(string song)
        {
            ((IOriginalGameplayProcess)Process).AudioSession.SetMusic(((IOriginalSfxEnvironment)Process).Sfx
                .EventnameByHandle(song));
        }


        [SourceCommandAttribute("music_vol", "set the music volume")]
        private static void CmdMusicVol(int num)
        {
            Settings.MusicVolume = num;
            Settings.ApplyVolumes(((IOriginalGameplayProcess)Process).AudioSession);
        }


        [SourceCommandAttribute("sfx_vol", "set the sfx volume")]
        private static void CmdSFXVol(int num)
        {
            Settings.SFXVolume = num;
            Settings.ApplyVolumes(((IOriginalGameplayProcess)Process).AudioSession);
        }


        [SourceCommandAttribute("blackhole_strength", "value 0 - 3")]
        private static void CmdBlackHoleStrength(int strength)
        {
            strength = ScalarMath.Clamp(strength, 0, 3);
            if (Scene is OriginalLevelSceneRoot level)
            {
                level.Background.Get<BlackholeBackdropPresentation>()
                    ?.NextStrength(level, (BlackholeBackdropPresentation.Strengths)strength);
            }
        }
    }
}
