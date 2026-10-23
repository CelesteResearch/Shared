using System;
using Celeste.Core.Reflection;
using Celeste.Scene.Tracking;

namespace Celeste.Game.Reflection.Commands
{
    public static partial class OriginalDeclaredCommandMethodFacts
    {
        private static void RegisterPart20(SceneEntityCatalog catalog)
        {
            catalog.PublishDeclaredCommandMethods("Celeste.OuiMainMenu+<>c",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.OuiOptions", Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.OuiOptions+<Enter>d__8",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.OuiOptions+<Leave>d__9",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.OuiTitleScreen",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.OuiTitleScreen+<>c__DisplayClass14_0",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.OuiTitleScreen+<Enter>d__14",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.OuiTitleScreen+<>c__DisplayClass15_0",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.OuiTitleScreen+<Leave>d__15",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.OuiTitleScreen+<FadeBgTo>d__16",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Oui", Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Poem", Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Poem+Particle", Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.TestWipes", Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.TestWipes+<routine>d__3",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.SummitVignette",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.FancyText", new ISourceCommandMethodMetadata[]
            {
                new SourceCommandMethodFacts(100669471, "FancyText", "Parse", Array.Empty<string>(),
                    Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>())
            });
            catalog.PublishDeclaredCommandMethods("Celeste.FancyText+Node",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.FancyText+Char",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.FancyText+Portrait",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.FancyText+Wait",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.FancyText+Trigger",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.FancyText+NewLine",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.FancyText+NewPage",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.FancyText+Anchors",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.FancyText+Anchor",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.FancyText+Text",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.MTN", new ISourceCommandMethodMetadata[]
            {
                new SourceCommandMethodFacts(100669479, "MTN", "get_Loaded", Array.Empty<string>(),
                    Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669480, "MTN", "set_Loaded", Array.Empty<string>(),
                    Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669481, "MTN", "get_DataLoaded", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669482, "MTN", "set_DataLoaded", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669483, "MTN", "Load", Array.Empty<string>(), Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669484, "MTN", "LoadData", Array.Empty<string>(), Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669485, "MTN", "Unload", Array.Empty<string>(), Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669486, "MTN", "UnloadData", Array.Empty<string>(),
                    Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>())
            });
            catalog.PublishDeclaredCommandMethods("Celeste.PlaybackData", new ISourceCommandMethodMetadata[]
            {
                new SourceCommandMethodFacts(100669487, "PlaybackData", "Load", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669488, "PlaybackData", "Export", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669489, "PlaybackData", "Import", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>())
            });
            catalog.PublishDeclaredCommandMethods("Celeste.GameplayBuffers", new ISourceCommandMethodMetadata[]
            {
                new SourceCommandMethodFacts(100669491, "GameplayBuffers", "Create", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669492, "GameplayBuffers", "Create", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669493, "GameplayBuffers", "Unload", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>())
            });
            catalog.PublishDeclaredCommandMethods("Celeste.ClutterBlockGenerator", new ISourceCommandMethodMetadata[]
            {
                new SourceCommandMethodFacts(100669495, "ClutterBlockGenerator", "Init", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669496, "ClutterBlockGenerator", "Dispose", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669497, "ClutterBlockGenerator", "Add", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669498, "ClutterBlockGenerator", "Generate", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669499, "ClutterBlockGenerator", "SetAboveToOnGround",
                    Array.Empty<string>(), Array.Empty<string>(), Array.Empty<SourceCommandParameter>())
            });
            catalog.PublishDeclaredCommandMethods("Celeste.ClutterBlockGenerator+Tile",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.ClutterBlockGenerator+TextureSet",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.ClutterBlockGenerator+<>c",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.ColorGrade", new ISourceCommandMethodMetadata[]
            {
                new SourceCommandMethodFacts(100669501, "ColorGrade", "get_Effect", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669502, "ColorGrade", "Set", Array.Empty<string>(),
                    Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669503, "ColorGrade", "Set", Array.Empty<string>(),
                    Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669504, "ColorGrade", "get_Percent", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669505, "ColorGrade", "set_Percent", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>())
            });
            catalog.PublishDeclaredCommandMethods("Celeste.Commands", new ISourceCommandMethodMetadata[]
            {
                new SourceCommandMethodFacts(100669507, "Commands", "CmdGlobalStats", new string[] { "global_stats" },
                    new string[] { "logs global steam stats" }, Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669508, "Commands", "CmdExportDialog", new string[] { "export_dialog" },
                    new string[] { "export dialog files to binary format" }, Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669509, "Commands", "CmdGiveGolden", new string[] { "give_golden" },
                    new string[] { "gives you a golden strawb" }, Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669510, "Commands", "CmdUnlockDoors", new string[] { "unlock_doors" },
                    new string[] { "unlock all lockblocks" }, Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669511, "Commands", "CmdLightning", new string[] { "ltng" },
                    new string[] { "disable lightning" },
                    new SourceCommandParameter[] { new SourceCommandParameter("disabled", "System.Boolean", true) }),
                new SourceCommandMethodFacts(100669512, "Commands", "CmdBounce", new string[] { "bounce" },
                    new string[] { "bounces the player!" }, Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669513, "Commands", "CmdSounds", new string[] { "sound_instances" },
                    new string[] { "gets active sound count" }, Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669514, "Commands", "CmdLighting", new string[] { "lighting" },
                    new string[] { "checks lightiing values" }, Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669515, "Commands", "CmdDetailedLevels",
                    new string[] { "detailed_levels" },
                    new string[] { "counts detailed levels" },
                    new SourceCommandParameter[]
                    {
                        new SourceCommandParameter("area", "System.Int32", -1),
                        new SourceCommandParameter("mode", "System.Int32", 0)
                    }),
                new SourceCommandMethodFacts(100669516, "Commands", "CmdHearts", new string[] { "hearts" },
                    new string[] { "gives a certain number of hearts (default all)" },
                    new SourceCommandParameter[] { new SourceCommandParameter("amount", "System.Int32", 24) }),
                new SourceCommandMethodFacts(100669517, "Commands", "CmdLogSession", new string[] { "logsession" },
                    new string[] { "log session to output" }, Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669518, "Commands", "CmdPostcard", new string[] { "postcard" },
                    new string[] { "views a postcard" },
                    new SourceCommandParameter[]
                    {
                        new SourceCommandParameter("id", "System.String", DBNull.Value),
                        new SourceCommandParameter("area", "System.Int32", 1)
                    }),
                new SourceCommandMethodFacts(100669519, "Commands", "CmdPostcardCside",
                    new string[] { "postcard_cside" },
                    new string[] { "views a postcard" }, Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669520, "Commands", "CmdPostcardVariants",
                    new string[] { "postcard_variants" }, new string[] { "views a postcard" },
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669521, "Commands", "CmdCheckLangauges",
                    new string[] { "check_all_languages" }, new string[] { "compares all langauges to english" },
                    new SourceCommandParameter[]
                        { new SourceCommandParameter("compareContent", "System.Boolean", false) }),
                new SourceCommandMethodFacts(100669522, "Commands", "CmdCheckLangauge",
                    new string[] { "check_language" },
                    new string[] { "compares all langauges to english" },
                    new SourceCommandParameter[]
                    {
                        new SourceCommandParameter("id", "System.String", DBNull.Value),
                        new SourceCommandParameter("compareContent", "System.Boolean", false)
                    }),
                new SourceCommandMethodFacts(100669523, "Commands", "CmdTextCharacters", new string[] { "characters" },
                    new string[] { "gets all the characters of each text file (writes to console" },
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669524, "Commands", "CmdBerriesOrder", new string[] { "berries_order" },
                    new string[] { "checks strawbs order" }, Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669525, "Commands", "CmdOWReflectionFall",
                    new string[] { "ow_reflection_fall" }, new string[] { "tests reflection overworld fall cutscene" },
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669526, "Commands", "CmdCore", new string[] { "core" },
                    new string[] { "set the core mode of the level" },
                    new SourceCommandParameter[]
                    {
                        new SourceCommandParameter("mode", "System.Int32", 0),
                        new SourceCommandParameter("session", "System.Boolean", false)
                    }),
                new SourceCommandMethodFacts(100669527, "Commands", "CmdAudio", new string[] { "audio" },
                    new string[] { "checks audio state of session" }, Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669528, "Commands", "CmdHeartGem", new string[] { "heartgem" },
                    new string[] { "give heart gem" },
                    new SourceCommandParameter[]
                    {
                        new SourceCommandParameter("area", "System.Int32", DBNull.Value),
                        new SourceCommandParameter("mode", "System.Int32", DBNull.Value),
                        new SourceCommandParameter("gem", "System.Boolean", true)
                    }),
                new SourceCommandMethodFacts(100669529, "Commands", "CmdSummitGem", new string[] { "summitgem" },
                    new string[] { "gives summit gem" },
                    new SourceCommandParameter[] { new SourceCommandParameter("gem", "System.String", DBNull.Value) }),
                new SourceCommandMethodFacts(100669530, "Commands", "CmdScreenPadding",
                    new string[] { "screenpadding" },
                    new string[] { "sets level screenpadding" },
                    new SourceCommandParameter[] { new SourceCommandParameter("value", "System.Int32", DBNull.Value) }),
                new SourceCommandMethodFacts(100669531, "Commands", "CmdTextures", new string[] { "textures" },
                    new string[] { "counts textures in memory" }, Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669532, "Commands", "CmdGiveKey", new string[] { "givekey" },
                    new string[] { "creates a key on the player" }, Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669533, "Commands", "CmdRefFall", new string[] { "ref_fall" },
                    new string[] { "test the reflection fall sequence" }, Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669534, "Commands", "CmdLines", new string[] { "lines" },
                    new string[] { "Counts Dialog Lines" },
                    new SourceCommandParameter[]
                        { new SourceCommandParameter("language", "System.String", DBNull.Value) }),
                new SourceCommandMethodFacts(100669535, "Commands", "CmdLeaf", new string[] { "leaf" },
                    new string[] { "play the leaf minigame" }, Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669536, "Commands", "CmdWipes", new string[] { "wipes" },
                    new string[] { "plays screen wipes for kert" }, Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669537, "Commands", "CmdPico", new string[] { "pico" },
                    new string[] { "plays pico-8 game, optional room skip (x/y)" },
                    new SourceCommandParameter[]
                    {
                        new SourceCommandParameter("roomX", "System.Int32", 0),
                        new SourceCommandParameter("roomY", "System.Int32", 0)
                    }),
                new SourceCommandMethodFacts(100669538, "Commands", "CmdColorGrading", new string[] { "colorgrading" },
                    new string[] { "sets color grading enabled (true/false)" },
                    new SourceCommandParameter[]
                        { new SourceCommandParameter("enabled", "System.Boolean", DBNull.Value) }),
                new SourceCommandMethodFacts(100669539, "Commands", "CmdPortraits", new string[] { "portraits" },
                    new string[] { "portrait debugger" }, Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669540, "Commands", "CmdDialog", new string[] { "dialog" },
                    new string[] { "dialog debugger" }, Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669541, "Commands", "CmdTitlescreen", new string[] { "titlescreen" },
                    new string[] { "go to the titlescreen" }, Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669542, "Commands", "CmdTime", new string[] { "time" },
                    new string[] { "set the time speed" },
                    new SourceCommandParameter[] { new SourceCommandParameter("rate", "System.Single", 1f) }),
                new SourceCommandMethodFacts(100669543, "Commands", "CmdLoad", new string[] { "load" },
                    new string[] { "test a level" },
                    new SourceCommandParameter[]
                    {
                        new SourceCommandParameter("id", "System.Int32", 0),
                        new SourceCommandParameter("level", "System.String", null)
                    }),
                new SourceCommandMethodFacts(100669544, "Commands", "CmdHard", new string[] { "hard" },
                    new string[] { "test a hard level" },
                    new SourceCommandParameter[]
                    {
                        new SourceCommandParameter("id", "System.Int32", 0),
                        new SourceCommandParameter("level", "System.String", null)
                    }),
                new SourceCommandMethodFacts(100669545, "Commands", "CmdMusProgress", new string[] { "music_progress" },
                    new string[] { "set music progress value" },
                    new SourceCommandParameter[]
                        { new SourceCommandParameter("progress", "System.Int32", DBNull.Value) }),
                new SourceCommandMethodFacts(100669546, "Commands", "CmdRMX2", new string[] { "rmx2" },
                    new string[] { "test a RMX2 level" },
                    new SourceCommandParameter[]
                    {
                        new SourceCommandParameter("id", "System.Int32", 0),
                        new SourceCommandParameter("level", "System.String", null)
                    }),
                new SourceCommandMethodFacts(100669547, "Commands", "CmdComplete", new string[] { "complete" },
                    new string[] { "test the complete screen for an area" },
                    new SourceCommandParameter[]
                    {
                        new SourceCommandParameter("index", "System.Int32", 1),
                        new SourceCommandParameter("mode", "System.Int32", 0),
                        new SourceCommandParameter("deaths", "System.Int32", 0),
                        new SourceCommandParameter("strawberries", "System.Int32", 0),
                        new SourceCommandParameter("gem", "System.Boolean", false)
                    }),
                new SourceCommandMethodFacts(100669548, "Commands", "CmdOWComplete", new string[] { "ow_complete" },
                    new string[] { "test the completion sequence on the overworld after a level" },
                    new SourceCommandParameter[]
                    {
                        new SourceCommandParameter("index", "System.Int32", 1),
                        new SourceCommandParameter("mode", "System.Int32", 0),
                        new SourceCommandParameter("deaths", "System.Int32", 0),
                        new SourceCommandParameter("strawberries", "System.Int32", -1),
                        new SourceCommandParameter("cassette", "System.Boolean", true),
                        new SourceCommandParameter("heartGem", "System.Boolean", true),
                        new SourceCommandParameter("beatBestTimeBy", "System.Single", 1.7921f),
                        new SourceCommandParameter("beatBestFullClearTimeBy", "System.Single", 1.7921f)
                    }),
                new SourceCommandMethodFacts(100669549, "Commands", "CmdMapEdit", new string[] { "mapedit" },
                    new string[] { "edit a map" },
                    new SourceCommandParameter[]
                    {
                        new SourceCommandParameter("index", "System.Int32", -1),
                        new SourceCommandParameter("mode", "System.Int32", 0)
                    }),
                new SourceCommandMethodFacts(100669550, "Commands", "CmdDFlag", new string[] { "dflag" },
                    new string[] { "Set a savedata flag" },
                    new SourceCommandParameter[]
                    {
                        new SourceCommandParameter("flag", "System.String", DBNull.Value),
                        new SourceCommandParameter("setTo", "System.Boolean", true)
                    }),
                new SourceCommandMethodFacts(100669551, "Commands", "CmdMeet", new string[] { "meet" },
                    new string[] { "Sets flags as though you met Theo" },
                    new SourceCommandParameter[]
                    {
                        new SourceCommandParameter("met", "System.Boolean", true),
                        new SourceCommandParameter("knowsName", "System.Boolean", true)
                    }),
                new SourceCommandMethodFacts(100669552, "Commands", "CmdFlag", new string[] { "flag" },
                    new string[] { "set a session flag" },
                    new SourceCommandParameter[]
                    {
                        new SourceCommandParameter("flag", "System.String", DBNull.Value),
                        new SourceCommandParameter("setTo", "System.Boolean", true)
                    }),
                new SourceCommandMethodFacts(100669553, "Commands", "CmdLevelFlag", new string[] { "level_flag" },
                    new string[] { "set a session load flag" },
                    new SourceCommandParameter[] { new SourceCommandParameter("flag", "System.String", DBNull.Value) }),
                new SourceCommandMethodFacts(100669554, "Commands", "CmdE", new string[] { "e" },
                    new string[] { "edit a map" },
                    new SourceCommandParameter[]
                    {
                        new SourceCommandParameter("index", "System.Int32", -1),
                        new SourceCommandParameter("mode", "System.Int32", 0)
                    }),
                new SourceCommandMethodFacts(100669555, "Commands", "CmdOverworld", new string[] { "overworld" },
                    new string[] { "go to the overworld" }, Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669556, "Commands", "CmdMusic", new string[] { "music" },
                    new string[] { "play a music track" },
                    new SourceCommandParameter[] { new SourceCommandParameter("song", "System.String", DBNull.Value) }),
                new SourceCommandMethodFacts(100669557, "Commands", "CmdClearSave", new string[] { "sd_clearflags" },
                    new string[] { "clears all flags from the save file" }, Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669558, "Commands", "CmdMusicVol", new string[] { "music_vol" },
                    new string[] { "set the music volume" },
                    new SourceCommandParameter[] { new SourceCommandParameter("num", "System.Int32", DBNull.Value) }),
                new SourceCommandMethodFacts(100669559, "Commands", "CmdSFXVol", new string[] { "sfx_vol" },
                    new string[] { "set the sfx volume" },
                    new SourceCommandParameter[] { new SourceCommandParameter("num", "System.Int32", DBNull.Value) }),
                new SourceCommandMethodFacts(100669560, "Commands", "CmdDreamDash", new string[] { "p_dreamdash" },
                    new string[] { "enable dream dashing" },
                    new SourceCommandParameter[] { new SourceCommandParameter("set", "System.Boolean", true) }),
                new SourceCommandMethodFacts(100669561, "Commands", "CmdTwoDashes", new string[] { "p_twodashes" },
                    new string[] { "enable two dashes" },
                    new SourceCommandParameter[] { new SourceCommandParameter("set", "System.Boolean", true) }),
                new SourceCommandMethodFacts(100669562, "Commands", "CmdStrawberries", new string[] { "berries" },
                    new string[] { "check how many strawberries are in the given chapter, or the entire game" },
                    new SourceCommandParameter[] { new SourceCommandParameter("chapterID", "System.Int32", -1) }),
                new SourceCommandMethodFacts(100669563, "Commands", "CmdSay", new string[] { "say" },
                    new string[] { "initiate a dialog message" },
                    new SourceCommandParameter[] { new SourceCommandParameter("id", "System.String", DBNull.Value) }),
                new SourceCommandMethodFacts(100669564, "Commands", "CmdTotalLevels", new string[] { "level_count" },
                    new string[] { "print out total level count!" },
                    new SourceCommandParameter[]
                    {
                        new SourceCommandParameter("areaID", "System.Int32", -1),
                        new SourceCommandParameter("mode", "System.Int32", 0)
                    }),
                new SourceCommandMethodFacts(100669565, "Commands", "CmdInputGui", new string[] { "input_gui" },
                    new string[] { "override input gui" },
                    new SourceCommandParameter[]
                        { new SourceCommandParameter("prefix", "System.String", DBNull.Value) }),
                new SourceCommandMethodFacts(100669566, "Commands", "GetLevelsInArea", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669567, "Commands", "CmdAssist", new string[] { "assist" },
                    new string[] { "toggle assist mode for current savefile" }, Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669568, "Commands", "CmdVariants", new string[] { "variants" },
                    new string[] { "toggle varaint mode for current savefile" }, Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669569, "Commands", "CmdCheat", new string[] { "cheat" },
                    new string[] { "toggle cheat mode for the current savefile" },
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669570, "Commands", "CmdCapture", new string[] { "capture" },
                    new string[] { "capture the last ~200 frames of player movement to a file" },
                    new SourceCommandParameter[]
                        { new SourceCommandParameter("filename", "System.String", DBNull.Value) }),
                new SourceCommandMethodFacts(100669571, "Commands", "CmdPlayback", new string[] { "playback" },
                    new string[] { "play back the file name" },
                    new SourceCommandParameter[]
                        { new SourceCommandParameter("filename", "System.String", DBNull.Value) }),
                new SourceCommandMethodFacts(100669572, "Commands", "CmdFonts", new string[] { "fonts" },
                    new string[] { "check loaded fonts" }, Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669573, "Commands", "CmdRename", new string[] { "rename" },
                    new string[] { "renames a level" },
                    new SourceCommandParameter[]
                    {
                        new SourceCommandParameter("current", "System.String", DBNull.Value),
                        new SourceCommandParameter("newName", "System.String", DBNull.Value)
                    }),
                new SourceCommandMethodFacts(100669574, "Commands", "CmdBlackHoleStrength",
                    new string[] { "blackhole_strength" }, new string[] { "value 0 - 3" },
                    new SourceCommandParameter[]
                        { new SourceCommandParameter("strength", "System.Int32", DBNull.Value) })
            });
            catalog.PublishDeclaredCommandMethods("Celeste.Commands+<>c", Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Depths", Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Dialog", new ISourceCommandMethodMetadata[]
            {
                new SourceCommandMethodFacts(100669575, "Dialog", "Load", Array.Empty<string>(), Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669576, "Dialog", "LoadLanguage", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669577, "Dialog", "Unload", Array.Empty<string>(),
                    Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669578, "Dialog", "Has", Array.Empty<string>(), Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669579, "Dialog", "Get", Array.Empty<string>(), Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669580, "Dialog", "Clean", Array.Empty<string>(), Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669581, "Dialog", "Time", Array.Empty<string>(), Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669582, "Dialog", "FileTime", Array.Empty<string>(),
                    Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669583, "Dialog", "Deaths", Array.Empty<string>(),
                    Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669584, "Dialog", "CheckCharacters", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669585, "Dialog", "CheckLanguageFontCharacters", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669586, "Dialog", "CompareLanguages", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>())
            });
            catalog.PublishDeclaredCommandMethods("Celeste.Dialog+<>c", Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Audio", new ISourceCommandMethodMetadata[]
            {
                new SourceCommandMethodFacts(100669588, "Audio", "Init", Array.Empty<string>(), Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669589, "Audio", "Update", Array.Empty<string>(), Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669590, "Audio", "Unload", Array.Empty<string>(), Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669591, "Audio", "SetListenerPosition", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669592, "Audio", "SetCamera", Array.Empty<string>(),
                    Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669593, "Audio", "CheckFmod", Array.Empty<string>(),
                    Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669594, "Audio", "Play", Array.Empty<string>(), Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669595, "Audio", "Play", Array.Empty<string>(), Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669596, "Audio", "Play", Array.Empty<string>(), Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669597, "Audio", "Play", Array.Empty<string>(), Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669598, "Audio", "Play", Array.Empty<string>(), Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669599, "Audio", "Loop", Array.Empty<string>(), Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669600, "Audio", "Loop", Array.Empty<string>(), Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669601, "Audio", "Loop", Array.Empty<string>(), Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669602, "Audio", "Loop", Array.Empty<string>(), Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669603, "Audio", "Pause", Array.Empty<string>(), Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669604, "Audio", "Resume", Array.Empty<string>(), Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669605, "Audio", "Position", Array.Empty<string>(),
                    Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669606, "Audio", "SetParameter", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669607, "Audio", "Stop", Array.Empty<string>(), Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669608, "Audio", "CreateInstance", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669609, "Audio", "GetEventDescription", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669610, "Audio", "ReleaseUnusedDescriptions", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669611, "Audio", "GetEventName", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669612, "Audio", "IsPlaying", Array.Empty<string>(),
                    Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669613, "Audio", "BusPaused", Array.Empty<string>(),
                    Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669614, "Audio", "BusMuted", Array.Empty<string>(),
                    Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669615, "Audio", "BusStopAll", Array.Empty<string>(),
                    Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669616, "Audio", "VCAVolume", Array.Empty<string>(),
                    Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669617, "Audio", "CreateSnapshot", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669618, "Audio", "ResumeSnapshot", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669619, "Audio", "IsSnapshotRunning", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669620, "Audio", "EndSnapshot", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669621, "Audio", "ReleaseSnapshot", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669622, "Audio", "get_CurrentMusicEventInstance", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669623, "Audio", "get_CurrentAmbienceEventInstance",
                    Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669624, "Audio", "SetMusic", Array.Empty<string>(),
                    Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669625, "Audio", "SetAmbience", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669626, "Audio", "SetMusicParam", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669627, "Audio", "SetAltMusic", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669628, "Audio", "StartMainDownSnapshot", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669629, "Audio", "EndMainDownSnapshot", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669630, "Audio", "get_MusicVolume", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669631, "Audio", "set_MusicVolume", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669632, "Audio", "get_SfxVolume", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669633, "Audio", "set_SfxVolume", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669634, "Audio", "get_PauseMusic", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669635, "Audio", "set_PauseMusic", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669636, "Audio", "get_PauseGameplaySfx", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669637, "Audio", "set_PauseGameplaySfx", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669638, "Audio", "get_PauseUISfx", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669639, "Audio", "set_PauseUISfx", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669640, "Audio", "get_MusicUnderwater", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669641, "Audio", "set_MusicUnderwater", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>())
            });
            catalog.PublishDeclaredCommandMethods("Celeste.Audio+Banks", new ISourceCommandMethodMetadata[]
            {
                new SourceCommandMethodFacts(100674852, "Banks", "Load", Array.Empty<string>(), Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>())
            });
            catalog.PublishDeclaredCommandMethods("Celeste.Fonts", new ISourceCommandMethodMetadata[]
            {
                new SourceCommandMethodFacts(100669643, "Fonts", "Load", Array.Empty<string>(), Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669644, "Fonts", "Get", Array.Empty<string>(), Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669645, "Fonts", "Unload", Array.Empty<string>(), Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669646, "Fonts", "Reload", Array.Empty<string>(), Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669647, "Fonts", "Prepare", Array.Empty<string>(),
                    Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669648, "Fonts", "Log", Array.Empty<string>(), Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>())
            });
            catalog.PublishDeclaredCommandMethods("Celeste.ActiveFont", new ISourceCommandMethodMetadata[]
            {
                new SourceCommandMethodFacts(100669650, "ActiveFont", "get_Font", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669651, "ActiveFont", "get_FontSize", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669652, "ActiveFont", "get_BaseSize", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669653, "ActiveFont", "get_LineHeight", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669654, "ActiveFont", "Measure", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669655, "ActiveFont", "Measure", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669656, "ActiveFont", "WidthToNextLine", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669657, "ActiveFont", "HeightOf", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669658, "ActiveFont", "Draw", Array.Empty<string>(),
                    Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669659, "ActiveFont", "Draw", Array.Empty<string>(),
                    Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669660, "ActiveFont", "Draw", Array.Empty<string>(),
                    Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669661, "ActiveFont", "Draw", Array.Empty<string>(),
                    Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669662, "ActiveFont", "DrawOutline", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669663, "ActiveFont", "DrawEdgeOutline", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>())
            });
            catalog.PublishDeclaredCommandMethods("Celeste.GameplayRenderer", new ISourceCommandMethodMetadata[]
            {
                new SourceCommandMethodFacts(100669665, "GameplayRenderer", "Begin", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669667, "GameplayRenderer", "End", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>())
            });
            catalog.PublishDeclaredCommandMethods("Celeste.HudRenderer", Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Glitch", new ISourceCommandMethodMetadata[]
            {
                new SourceCommandMethodFacts(100669670, "Glitch", "Apply", Array.Empty<string>(), Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>())
            });
            catalog.PublishDeclaredCommandMethods("Celeste.MenuOptions", new ISourceCommandMethodMetadata[]
            {
                new SourceCommandMethodFacts(100669672, "MenuOptions", "Create", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669673, "MenuOptions", "CreateRumble", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669674, "MenuOptions", "CreateGrabMode", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669675, "MenuOptions", "CreateCrouchDashMode", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669676, "MenuOptions", "SetFullscreen", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669677, "MenuOptions", "SetVSync", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669678, "MenuOptions", "SetWindow", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669679, "MenuOptions", "SetMusic", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669680, "MenuOptions", "SetSfx", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669681, "MenuOptions", "SetSpeedrunClock", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669682, "MenuOptions", "OpenViewportAdjustment", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669683, "MenuOptions", "SelectLanguage", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669684, "MenuOptions", "OpenKeyboardConfig", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669685, "MenuOptions", "OpenButtonConfig", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669686, "MenuOptions", "EnterSound", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669687, "MenuOptions", "LeaveSound", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669688, "MenuOptions", "UpdateCrouchDashModeVisibility",
                    Array.Empty<string>(), Array.Empty<string>(), Array.Empty<SourceCommandParameter>())
            });
            catalog.PublishDeclaredCommandMethods("Celeste.MenuOptions+<>c",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.ParticleTypes", new ISourceCommandMethodMetadata[]
            {
                new SourceCommandMethodFacts(100669689, "ParticleTypes", "Load", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>())
            });
            catalog.PublishDeclaredCommandMethods("Celeste.DeathData", Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.PlayerInventory",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.SaveData", new ISourceCommandMethodMetadata[]
            {
                new SourceCommandMethodFacts(100669696, "SaveData", "Start", Array.Empty<string>(),
                    Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669697, "SaveData", "GetFilename", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669698, "SaveData", "GetFilename", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669699, "SaveData", "InitializeDebugMode", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669700, "SaveData", "TryDelete", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669703, "SaveData", "NoFileAssistChecks", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>())
            });
            catalog.PublishDeclaredCommandMethods("Celeste.Session", Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Session+Counter",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Session+CoreModes",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.EntityID", Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.RumbleAmount", Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.SpeedrunType", Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.ScreenshakeAmount",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.GrabModes", Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.CrouchDashModes",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Settings", new ISourceCommandMethodMetadata[]
            {
                new SourceCommandMethodFacts(100669766, "Settings", "Initialize", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100669767, "Settings", "Reload", Array.Empty<string>(),
                    Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>())
            });
            catalog.PublishDeclaredCommandMethods("Celeste.Assists", new ISourceCommandMethodMetadata[]
            {
                new SourceCommandMethodFacts(100669768, "Assists", "get_Default", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>())
            });
            catalog.PublishDeclaredCommandMethods("Celeste.Assists+DashModes",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.StaminaDisplay",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.ExitBlock", Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.MovingPlatform",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.MovingPlatformLine",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.RotatingPlatform",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.HangingLamp", Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.CameraOffsetTrigger",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.CameraTargetTrigger",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.RespawnTargetTrigger",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.DustRotateSpinner",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.TriggerSpikes", new ISourceCommandMethodMetadata[]
            {
                new SourceCommandMethodFacts(100669820, "TriggerSpikes", "GetSize", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>())
            });
            catalog.PublishDeclaredCommandMethods("Celeste.TriggerSpikes+Directions",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.TriggerSpikes+SpikeInfo",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.DashBlock", Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.DashBlock+Modes",
                Array.Empty<ISourceCommandMethodMetadata>());
        }
    }
}
