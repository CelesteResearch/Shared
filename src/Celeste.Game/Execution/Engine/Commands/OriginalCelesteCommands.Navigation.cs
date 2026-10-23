using System.IO;
using Celeste.Game.Execution.Areas;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.LevelLoader;
using Celeste.Game.Menus.Overworld;
using Celeste.Game.Editor;
using Celeste.Game.Diagnostics.Scenes;
using Celeste.Game.Entities.Doors.LockBlocks;
using Celeste.Framework.Diagnostics.Commands;
using Celeste.Simulation.Runtime.Session;

namespace Celeste.Game.Execution.Engine.Commands
{
    public static partial class OriginalCelesteCommands
    {
        private static OriginalLevelLoaderScene CreateLevelLoader(ChapterCompletionSession session) =>
            ((IOriginalLevelLoaderEnvironment)Process).LevelLoaders.CreateLevelLoader(session);

        private static OverworldLoaderSequence CreateOverworldLoader(OverworldStartMode mode) =>
            ((IOriginalOverworldLoaderEnvironment)Process).OverworldLoaders.CreateOverworldLoader(mode);

        [SourceCommandAttribute("load", "test a level")]
        private static void CmdLoad(int id = 0, string level = null)
        {
            InitializeDebugMode();
            CurrentSave.LastArea = AreaKeys.Create(id);
            var session = Sessions.CreateSession(AreaKeys.Create(id));
            if (level != null && session.MapData.GetLevel(level) != null)
            {
                session.Level = level;
                session.FirstLevel = false;
            }

            Scene = CreateLevelLoader(session);
        }

        [SourceCommandAttribute("hard", "test a hard level")]
        private static void CmdHard(int id = 0, string level = null)
        {
            InitializeDebugMode();
            CurrentSave.LastArea = AreaKeys.Create(id, 1);
            var session = Sessions.CreateSession(AreaKeys.Create(id, 1));
            if (level != null)
            {
                session.Level = level;
                session.FirstLevel = false;
            }

            Scene = CreateLevelLoader(session);
        }

        [SourceCommandAttribute("rmx2", "test a RMX2 level")]
        private static void CmdRMX2(int id = 0, string level = null)
        {
            InitializeDebugMode();
            CurrentSave.LastArea = AreaKeys.Create(id, 2);
            var session = Sessions.CreateSession(AreaKeys.Create(id, 2));
            if (level != null)
            {
                session.Level = level;
                session.FirstLevel = false;
            }

            Scene = CreateLevelLoader(session);
        }

        [SourceCommandAttribute("leaf", "play the leaf minigame")]
        private static void CmdLeaf()
        {
            Scene = new TestBreathingGameState(Process);
        }

        [SourceCommandAttribute("wipes", "plays screen wipes for kert")]
        private static void CmdWipes()
        {
            Scene = new TestWipesState(Process);
        }

        [SourceCommandAttribute("portraits", "portrait debugger")]
        private static void CmdPortraits()
        {
            Scene = new PreviewPortraitState(Process);
        }

        [SourceCommandAttribute("dialog", "dialog debugger")]
        private static void CmdDialog()
        {
            Scene = new PreviewDialogState(Process);
        }

        [SourceCommandAttribute("titlescreen", "go to the titlescreen")]
        private static void CmdTitlescreen()
        {
            Scene = CreateOverworldLoader(OverworldStartMode.Titlescreen);
        }

        [SourceCommandAttribute("overworld", "go to the overworld")]
        private static void CmdOverworld()
        {
            if (CurrentSave == null)
            {
                InitializeDebugMode();
                CurrentSave.CurrentSession = Sessions.CreateSession(AreaKeys.Default);
            }

            Scene = CreateOverworldLoader(OverworldStartMode.Titlescreen);
        }

        [SourceCommandAttribute("ow_reflection_fall", "tests reflection overworld fall cutscene")]
        private static void CmdOWReflectionFall()
        {
            Scene = new OverworldReflectionsFallSequence(Process, null,
                delegate { Scene = CreateOverworldLoader(OverworldStartMode.Titlescreen); });
        }

        [SourceCommandAttribute("playback", "play back the file name")]
        private static void CmdPlayback(string filename)
        {
            filename += ".bin";
            if (File.Exists(filename))
            {
                Scene = ((IOriginalPreviewRecordingEnvironment)Process).PreviewRecordings.CreatePreviewRecording(
                    Process,
                    filename);
            }
            else
            {
                Console.Log("FILE NOT FOUND");
            }
        }

        [SourceCommandAttribute("mapedit", "edit a map")]
        private static void CmdMapEdit(int index = -1, int mode = 0)
        {
            OriginalAreaKey area = ((index != -1)
                ? AreaKeys.Create(index, mode)
                : ((!(Scene is OriginalLevelSceneRoot))
                    ? AreaKeys.Default
                    : AreaKeys.GetSessionArea((Scene as OriginalLevelSceneRoot).Session)));
            Scene = ((IOriginalMapEditorConstructionEnvironment)Process).MapEditors.Create(Process, area);
            Console.Open = false;
        }

        [SourceCommandAttribute("e", "edit a map")]
        private static void CmdE(int index = -1, int mode = 0)
        {
            CmdMapEdit(index, mode);
        }

        [SourceCommandAttribute("rename", "renames a level")]
        private static void CmdRename(string current, string newName)
        {
            if (!(Scene is MapEditorState mapEditor))
            {
                Console.Log("Must be in the Map Editor");
            }
            else
            {
                mapEditor.Rename(current, newName);
            }
        }

        [SourceCommandAttribute("unlock_doors", "unlock all lockblocks")]
        private static void CmdUnlockDoors()
        {
            foreach (OriginalLockBlockState item in (Scene as OriginalLevelSceneRoot).SourceScene.Entities
                     .FindAll<OriginalLockBlockState>())
            {
                item.RemoveSelf();
            }
        }
    }
}
