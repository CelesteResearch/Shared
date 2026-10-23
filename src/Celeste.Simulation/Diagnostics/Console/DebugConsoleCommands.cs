using Celeste.Simulation.Audio;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Celeste.Simulation;

namespace Celeste.Simulation.Diagnostics.Console
{
    // =============================================================================================
    // Port of Celeste.Commands (Artifacts/Reference/Original/Celeste/Commands.cs) - the command
    // table the console registers by reflection.
    //
    // Every method keeps the original's name, help string, parameter list and defaults so that
    // `help <command>` prints what the original prints, and each one carries the original's
    // file:line. The original reaches the running game through Engine.Scene / SaveData.Instance /
    // Settings.Instance; this port reaches it through DebugConsole.Console.World
    // (IDebugConsoleWorld), which is the single seam between the table and the host.
    //
    // Commands whose engine facility this repo does not have are NOT stubbed: they say what they
    // cannot do and name the missing facility (see the Unsupported helper). SUMMARY.md carries the
    // full supported / unsupported table.
    // =============================================================================================
    public static class DebugConsoleCommands
    {
        private static global::Celeste.Simulation.Diagnostics.Console.DebugConsole C =>
            global::Celeste.Simulation.Diagnostics.Console.DebugConsole.Console;

        private static global::Celeste.Simulation.Diagnostics.Console.IDebugConsoleWorld W =>
            C != null ? C.World : null;

        private static void Say(object text)
        {
            if (C != null) C.Log(text);
        }

        private static void Say(object text, System.Numerics.Vector4 color)
        {
            if (C != null) C.Log(text, color);
        }

        private static void Warn(object text)
        {
            if (C != null) C.Log(text, global::Celeste.Simulation.Diagnostics.Console.DebugConsoleColors.Yellow);
        }

        private static void Unsupported(string command, string missing)
        {
            Warn(command + " is unsupported: " + missing);
            if (C != null) C.World?.Trace("unsupported: " + command);
        }

        private static string N(float value) => value.ToString("0.###", CultureInfo.InvariantCulture);
        private static string N(int value) => value.ToString(CultureInfo.InvariantCulture);

        // =========================================================================================
        // Level / room
        // =========================================================================================

        // Commands.cs:485-497 `load [id] [level]`.
        [DebugConsoleCommand("load", "test a level")]
        public static void CmdLoad(int id = 0, string level = null)
        {
            Say(W.LoadLevel(id, 0, Text(level), false));
        }

        // Commands.cs:451-455 `pico [x] [y]` — `Engine.Scene = new Emulator(null, roomX, roomY)`.
        // The NULL return target is the point of this command: Emulator.cs:401-412 then leaves to
        // `new OverworldLoader(Overworld.StartMode.Titlescreen)` instead of back into the game, and
        // Emulator.cs:99-105's levelX/levelY seeds the cart's boot room (Pico8Emulator.cs:407-409).
        // No echo: the original's CmdPico only performs the scene assignment.
        [DebugConsoleCommand("pico", "plays pico-8 game, optional room skip (x/y)")]
        public static void CmdPico(int roomX = 0, int roomY = 0)
        {
            W.PlayPico8(roomX, roomY);
        }

        // Commands.cs:499-511 `hard [id] [level]` (AreaMode.BSide).
        [DebugConsoleCommand("hard", "test a hard level")]
        public static void CmdHard(int id = 0, string level = null)
        {
            Say(W.LoadLevel(id, 1, Text(level), false));
        }

        // Commands.cs:519-531 `rmx2 [id] [level]` (AreaMode.CSide).
        [DebugConsoleCommand("rmx2", "test a RMX2 level")]
        public static void CmdRMX2(int id = 0, string level = null)
        {
            Say(W.LoadLevel(id, 2, Text(level), false));
        }

        // Not in the original (its `load` with no level reloads only through LevelLoader); this
        // rebuilds the room the view is already on, which is the reload the audit asked for.
        [DebugConsoleCommand("reload", "reload the current room")]
        public static void CmdReload()
        {
            var snapshot = W.Snapshot();
            Say(W.LoadLevel(snapshot.AreaId, snapshot.AreaMode, snapshot.RoomName, true));
        }

        // Commands.cs:773-790 `level_count` and :106-158 `detailed_levels` count levels; the useful
        // in-console form is the room list itself (also used by the tab completion of load/hard).
        [DebugConsoleCommand("rooms", "list the rooms of the current chapter (or of [area] [mode])")]
        public static void CmdRooms(int area = -1, int mode = 0)
        {
            if (area < 0)
            {
                var snapshot = W.Snapshot();
                area = snapshot.AreaId;
                mode = snapshot.AreaMode;
            }

            string[] rooms = W.RoomsOf(area, mode);
            if (rooms == null || rooms.Length == 0)
            {
                Warn("rooms: chapter " + N(area) + " mode " + N(mode) + " has no room list");
                return;
            }

            Say("chapter " + N(area) + " mode " + N(mode) + ": " + rooms.Length + " rooms");
            Say(string.Join(", ", rooms));
        }

        // RoomPresentation.RetryRoom (RoomPresentation.cs:654) - the original kills the player to
        // reload a room (Player.Die + Reload in Level.cs); this is that path, not a rebuild.
        [DebugConsoleCommand("retry", "kill the player and reload the room the way the game does")]
        public static void CmdRetry()
        {
            W.RetryRoom();
            Say("retry: player death requested");
        }

        // =========================================================================================
        // Flags and counters
        // =========================================================================================

        // Commands.cs:657-661 `flag [flag] [setTo]` - SaveData.Instance.CurrentSession.SetFlag.
        [DebugConsoleCommand("flag", "set a session flag")]
        public static void CmdFlag(string flag, bool setTo = true)
        {
            W.SetFlag(global::Celeste.Simulation.Diagnostics.Console.DebugConsoleFlagKind.Session, flag, setTo);
            Say("session flag " + flag + "=" + setTo);
        }

        // Commands.cs:623-634 `dflag [flag] [setTo]` - SaveData.Instance.SetFlag / Flags.Remove.
        [DebugConsoleCommand("dflag", "Set a savedata flag")]
        public static void CmdDFlag(string flag, bool setTo = true)
        {
            W.SetFlag(global::Celeste.Simulation.Diagnostics.Console.DebugConsoleFlagKind.Save, flag, setTo);
            Say("save flag " + flag + "=" + setTo);
        }

        // Commands.cs:636-655 writes the two Theo flags independently.
        [DebugConsoleCommand("meet", "Sets flags as though you met Theo")]
        public static void CmdMeet(bool met = true, bool knowsName = true)
        {
            W.SetFlag(global::Celeste.Simulation.Diagnostics.Console.DebugConsoleFlagKind.Save, "MetTheo", met);
            W.SetFlag(global::Celeste.Simulation.Diagnostics.Console.DebugConsoleFlagKind.Save, "TheoKnowsName",
                knowsName);
        }

        // Commands.cs:663-667 `level_flag [flag]`.
        [DebugConsoleCommand("level_flag", "set a session load flag")]
        public static void CmdLevelFlag(string flag)
        {
            W.SetFlag(global::Celeste.Simulation.Diagnostics.Console.DebugConsoleFlagKind.Level, flag, true);
            Say("level flag " + flag + "=True");
        }

        // Commands.cs:692-696 `sd_clearflags`.
        [DebugConsoleCommand("sd_clearflags", "clears all flags from the save file")]
        public static void CmdClearSave()
        {
            W.ClearSaveFlags();
            Say("save flags cleared");
        }

        // Not in the original: the audit asked for flag read-back, and the original had no reader at
        // all (its `flag`/`dflag` are setters only, Commands.cs:657/:623).
        [DebugConsoleCommand("get", "read a flag or counter: session, save, level and counters are all checked")]
        public static void CmdGet(string name)
        {
            var snapshot = W.Snapshot();
            bool found = false;
            foreach (var kind in new[]
                     {
                         global::Celeste.Simulation.Diagnostics.Console.DebugConsoleFlagKind.Session,
                         global::Celeste.Simulation.Diagnostics.Console.DebugConsoleFlagKind.Save,
                         global::Celeste.Simulation.Diagnostics.Console.DebugConsoleFlagKind.Level
                     })
            {
                if (!W.GetFlag(kind, name)) continue;
                Say(KindName(kind) + " flag " + name + "=True",
                    global::Celeste.Simulation.Diagnostics.Console.DebugConsoleColors.Lime);
                found = true;
            }

            if (!found)
                Say("flag " + name + " is not set (session/save/level)",
                    global::Celeste.Simulation.Diagnostics.Console.DebugConsoleColors.Red);
            int counter = W.GetCounter(name);
            if (counter != 0)
                Say("counter " + name + "=" + N(counter),
                    global::Celeste.Simulation.Diagnostics.Console.DebugConsoleColors.Lime);
        }

        // The audit's `Set`: writes the session flag, which is what `flag` does in the original; it
        // exists so a reader can type the pair `set <name> <value>` / `get <name>`.
        [DebugConsoleCommand("set", "write a session flag (same target as 'flag')")]
        public static void CmdSet(string name, bool value = true)
        {
            W.SetFlag(global::Celeste.Simulation.Diagnostics.Console.DebugConsoleFlagKind.Session, name, value);
            Say("session flag " + name + "=" + value);
        }

        [DebugConsoleCommand("flags", "list the session, save and level flags")]
        public static void CmdFlags()
        {
            var snapshot = W.Snapshot();
            Say("session flags (" + Count(snapshot.SessionFlags) + "): " + Join(snapshot.SessionFlags));
            Say("save flags (" + Count(snapshot.SaveFlags) + "): " + Join(snapshot.SaveFlags));
            Say("level flags (" + Count(snapshot.LevelFlags) + "): " + Join(snapshot.LevelFlags));
        }

        [DebugConsoleCommand("counter", "read or write a session counter: counter <name> [value]")]
        public static void CmdCounter(string name, int value = int.MinValue)
        {
            if (value == int.MinValue)
            {
                Say("counter " + name + "=" + N(W.GetCounter(name)));
                return;
            }

            W.SetCounter(name, value);
            Say("counter " + name + "=" + N(value));
        }

        // =========================================================================================
        // Inventory / abilities
        // =========================================================================================

        // Commands.cs:712-716 `p_dreamdash [set]` - Session.Inventory.DreamDash.
        [DebugConsoleCommand("p_dreamdash", "enable dream dashing")]
        public static void CmdDreamDash(bool set = true)
        {
            W.SetDreamDash(set);
            Say("session inventory DreamDash=" + set);
        }

        // Commands.cs:718-722 `p_twodashes [set]` - Session.Inventory.Dashes = set ? 2 : 1.
        [DebugConsoleCommand("p_twodashes", "enable two dashes")]
        public static void CmdTwoDashes(bool set = true)
        {
            W.SetDashes(set ? 2 : 1);
            Say("session inventory Dashes=" + N(set ? 2 : 1));
        }

        // Not in the original (its dashes knobs are the two above); this is the direct "give dash".
        [DebugConsoleCommand("dashes", "set the session's dash count: dashes [amount]")]
        public static void CmdDashes(int amount = int.MinValue)
        {
            if (amount == int.MinValue)
            {
                Say("dashes=" + N(W.Snapshot().Dashes));
                return;
            }

            W.SetDashes(amount);
            Say("session inventory Dashes=" + N(amount));
        }

        // Not in the original: INVINCIBLE is an assist/variant setting there (Player.cs reads
        // SaveData variants); the audit asked for god mode, and PlayerSettings.Invincible is the
        // flag the simulation already honours.
        [DebugConsoleCommand("god", "toggle invincibility (PlayerSettings.Invincible)")]
        public static void CmdGod(bool set = true)
        {
            W.SetInvincible(set);
            Say("player invincible=" + set);
        }

        [DebugConsoleCommand("infinite_stamina", "toggle infinite stamina (PlayerSettings.InfiniteStamina)")]
        public static void CmdInfiniteStamina(bool set = true)
        {
            W.SetInfiniteStamina(set);
            Say("player infiniteStamina=" + set);
        }

        [DebugConsoleCommand("no_refills", "toggle the no-refills session inventory flag")]
        public static void CmdNoRefills(bool set = true)
        {
            W.SetNoRefills(set);
            Say("session inventory NoRefills=" + set);
        }

        // Commands.cs:160-184 `hearts [amount]` (default 24).
        [DebugConsoleCommand("hearts", "gives a certain number of hearts (default all)")]
        public static void CmdHearts(int amount = 24)
        {
            for (int mode = 0; mode < 3; mode++)
            {
                for (int area = 0; area < 11; area++)
                {
                    bool gem = mode * 11 + area < amount;
                    W.GiveHeartGem(area, mode, gem);
                }
            }

            Say("heart gems written, requested " + N(amount));
        }

        // Commands.cs:353-357 `heartgem [area] [mode] [gem]`.
        [DebugConsoleCommand("heartgem", "give heart gem")]
        public static void CmdHeartGem(int area, int mode, bool gem = true)
        {
            W.GiveHeartGem(area, mode, gem);
            Say("heartgem area " + N(area) + " mode " + N(mode) + "=" + gem);
        }

        // Commands.cs:359-373 `summitgem [gem]`.
        [DebugConsoleCommand("summitgem", "gives summit gem")]
        public static void CmdSummitGem(string gem)
        {
            if (gem == "all")
            {
                W.GiveSummitGem(-1);
                Say("summit gems: all six set");
                return;
            }

            if (!int.TryParse(gem, NumberStyles.Integer, CultureInfo.InvariantCulture, out int index) || index < 0 ||
                index > 5)
            {
                Warn("summitgem: expected 0-5 or 'all'");
                return;
            }

            W.GiveSummitGem(index);
            Say("summit gem " + N(index) + " set");
        }

        // Commands.cs:391-402: create a follower Key and immediately register its session ID.
        [DebugConsoleCommand("givekey", "creates a key on the player")]
        public static void CmdGiveKey() => W.GiveKey();

        // Commands.cs:38-54 `give_golden`.
        [DebugConsoleCommand("give_golden", "gives you a golden strawb")]
        public static void CmdGiveGolden() => W.GiveGolden();

        // Commands.cs:56-63 `unlock_doors`.
        [DebugConsoleCommand("unlock_doors", "unlock all lockblocks")]
        public static void CmdUnlockDoors() => W.UnlockDoors();

        // =========================================================================================
        // Save-file modes
        // =========================================================================================

        // Commands.cs:803-808 `assist`.
        [DebugConsoleCommand("assist", "toggle assist mode for current savefile")]
        public static void CmdAssist() => Say("assist=" +
                                              W.ToggleSaveMode(global::Celeste.Simulation.Diagnostics.Console
                                                  .DebugConsoleSaveMode.Assist));

        // Commands.cs:810-815 `variants`.
        [DebugConsoleCommand("variants", "toggle varaint mode for current savefile")]
        public static void CmdVariants() => Say("variants=" +
                                                W.ToggleSaveMode(global::Celeste.Simulation.Diagnostics.Console
                                                    .DebugConsoleSaveMode.Variants));

        // Commands.cs:817-821 `cheat`.
        [DebugConsoleCommand("cheat", "toggle cheat mode for the current savefile")]
        public static void CmdCheat() => Say("cheat=" +
                                             W.ToggleSaveMode(global::Celeste.Simulation.Diagnostics.Console
                                                 .DebugConsoleSaveMode.Cheat));

        // =========================================================================================
        // Level / world knobs
        // =========================================================================================

        // Commands.cs:479-483 `time [rate]` - Engine.TimeRate.
        [DebugConsoleCommand("time", "set the time speed")]
        public static void CmdTime(float rate = 1f)
        {
            W.SetTimeRate(rate);
            Say("time rate=" + N(rate));
        }

        // Not in the original (Engine.FreezeTimer is driven by the game); a console freeze is the
        // same Celeste.Freeze the player uses (RoomPlayerSession.Freeze).
        [DebugConsoleCommand("freeze", "freeze the world for [seconds] (default 1)")]
        public static void CmdFreeze(float seconds = 1f)
        {
            W.Freeze(seconds);
            Say("frozen for " + N(seconds) + "s");
        }

        // Commands.cs:323-331 `core [mode] [session]`.
        [DebugConsoleCommand("core", "set the core mode of the level")]
        public static void CmdCore(int mode = 0, bool session = false)
        {
            W.SetCoreMode(mode, session);
            Say("core mode=" + N(mode) + (session ? " (session too)" : ""));
        }

        // Commands.cs:65-69 `ltng [disabled]` - Session.SetFlag("disable_lightning", disabled).
        [DebugConsoleCommand("ltng", "disable lightning")]
        public static void CmdLightning(bool disabled = true)
        {
            W.SetFlag(global::Celeste.Simulation.Diagnostics.Console.DebugConsoleFlagKind.Session, "disable_lightning",
                disabled);
            Say("session flag disable_lightning=" + disabled);
        }

        // Commands.cs:375-382 `screenpadding [value]` - Level.ScreenPadding.
        [DebugConsoleCommand("screenpadding", "sets level screenpadding")]
        public static void CmdScreenPadding(int value)
        {
            W.SetScreenPadding(value);
            Say("screen padding=" + N(value));
        }

        // Commands.cs:97-104 `lighting` printed level light values; this repo keeps them in
        // RoomEnvironmentState, which the console seam does not expose.
        [DebugConsoleCommand("lighting", "checks lightiing values")]
        public static void CmdLighting()
        {
            string value = W.LightingState();
            if (value != null) Say(value);
        }

        // Commands.cs:333-351 `audio` printed session audio; this repo's music/ambience parameters
        // live on RoomAudioState/RoomAudioDriver, which the console seam does not expose.
        [DebugConsoleCommand("audio", "checks audio state of session")]
        public static void CmdAudio()
            => Unsupported("audio",
                "session audio lives on RoomAudioState/RoomAudioDriver, which the console seam does not expose");

        // Commands.cs:686-690 `music [song]`.
        [DebugConsoleCommand("music", "play a music track")]
        public static void CmdMusic(string song)
            => Unsupported("music",
                "playing a track needs the FMOD event path and the room's audio driver; the console seam does not own it");

        // Commands.cs:186-194 `logsession` (XmlSerializer over Session); this repo serializes a save
        // file, not a live session.
        [DebugConsoleCommand("logsession", "log session to output")]
        public static void CmdLogSession()
            => Unsupported("logsession",
                "the original XmlSerializer-dumped Monocle's Session; this repo has no session serializer (use 'state')");

        // Commands.cs:71-76 `bounce`.
        [DebugConsoleCommand("bounce", "bounces the player!")]
        public static void CmdBounce() => W.BouncePlayer();

        // =========================================================================================
        // Camera
        // =========================================================================================

        // Commands.cs:614-621 `mapedit` / :669 `e` / :853 `rename` all need Celeste.Editor.MapEditor.
        [DebugConsoleCommand("mapedit", "edit a map")]
        public static void CmdMapEdit(int index = -1, int mode = 0)
            => Unsupported("mapedit", "Celeste.Editor.MapEditor is not ported");

        [DebugConsoleCommand("e", "edit a map")]
        public static void CmdE(int index = -1, int mode = 0) => CmdMapEdit(index, mode);

        // Not in the original console: the camera was read with Engine.Scene cameras. `camera`
        // reports where the room camera is; `zoom` sets the level zoom the game's own routines use.
        [DebugConsoleCommand("camera", "print the room camera position and zoom")]
        public static void CmdCamera()
        {
            var snapshot = W.Snapshot();
            Say("camera=" + N(snapshot.CameraX) + "," + N(snapshot.CameraY) + " zoom=" + N(snapshot.Zoom) +
                " padding=" + N(snapshot.ScreenPadding));
        }

        [DebugConsoleCommand("zoom", "set the level zoom (LevelZoomState.Zoom)")]
        public static void CmdZoom(float zoom)
        {
            W.SetZoom(zoom);
            Say("zoom=" + N(zoom));
        }

        // Not in the original (it teleports through `load`/level entities); this is the direct
        // teleport the audit asked for, in the room's pixel coordinates (see 'state').
        [DebugConsoleCommand("teleport", "teleport the player to room pixel [x] [y]")]
        public static void CmdTeleport(float x, float y)
        {
            W.Teleport(x, y);
            var snapshot = W.Snapshot();
            Say("player at " + N(snapshot.PlayerX) + "," + N(snapshot.PlayerY));
        }

        // =========================================================================================
        // State introspection
        // =========================================================================================

        [DebugConsoleCommand("state", "print session, player and room state")]
        public static void CmdState()
        {
            var snapshot = W.Snapshot();
            Say("map=" + snapshot.Map + " room=" + snapshot.Room + " level=" + snapshot.RoomName
                + " area=" + N(snapshot.AreaId) + " mode=" + N(snapshot.AreaMode) + " frame=" +
                snapshot.SceneFrame.ToString(CultureInfo.InvariantCulture));
            Say("player x=" + N(snapshot.PlayerX) + " y=" + N(snapshot.PlayerY)
                + " speed=" + N(snapshot.PlayerSpeedX) + "," + N(snapshot.PlayerSpeedY)
                + " dashes=" + N(snapshot.Dashes) + "/" + N(snapshot.MaxDashes)
                + " stamina=" + N(snapshot.Stamina)
                + " invincible=" + snapshot.Invincible + " dreamDash=" + snapshot.DreamDash + " noRefills=" +
                snapshot.NoRefills);
            Say("entities=" + N(snapshot.EntityCount) + " pending=" + N(snapshot.PendingEntityCount)
                + " deaths=" + N(snapshot.Deaths) + " timeRate=" + N(snapshot.TimeRate)
                + " debugMode=" + snapshot.DebugMode);
        }

        [DebugConsoleCommand("entities", "count the loaded entity visuals, optionally per name")]
        public static void CmdEntities(string name = null)
        {
            var snapshot = W.Snapshot();
            Say("entities=" + N(snapshot.EntityCount) + " pending=" + N(snapshot.PendingEntityCount));
            string[] counts = snapshot.EntityCounts;
            if (counts == null || counts.Length == 0) return;
            if (!string.IsNullOrEmpty(name))
            {
                var match = counts.Where(c => c.StartsWith(name + "=", StringComparison.Ordinal)).ToArray();
                Say(match.Length == 0 ? name + ": none" : string.Join(" ", match));
                return;
            }

            Say(string.Join(" ", counts));
        }

        [DebugConsoleCommand("session", "print the session's chapter, flags and inventory")]
        public static void CmdSession()
        {
            var snapshot = W.Snapshot();
            Say("area=" + N(snapshot.AreaId) + " mode=" + N(snapshot.AreaMode) + " level=" + snapshot.RoomName
                + " sessionFlags=" + Count(snapshot.SessionFlags) + " levelFlags=" + Count(snapshot.LevelFlags));
            Say("inventory dashes=" + N(snapshot.Dashes) + " max=" + N(snapshot.MaxDashes)
                + " dreamDash=" + snapshot.DreamDash + " noRefills=" + snapshot.NoRefills);
        }

        // =========================================================================================
        // Not ported (named so the console answers instead of staying silent)
        // =========================================================================================

        // Commands.cs:473-477 `titlescreen`, :675-684 `overworld`.
        [DebugConsoleCommand("titlescreen", "go to the titlescreen")]
        public static void CmdTitlescreen() => W.GoToTitleScreen(false);

        [DebugConsoleCommand("overworld", "go to the overworld")]
        public static void CmdOverworld() => W.GoToTitleScreen(true);

        // Commands.cs:533-553 `complete`, :555-613 `ow_complete`.
        [DebugConsoleCommand("complete", "test the complete screen for an area")]
        public static void CmdComplete(int index = 1, int mode = 0, int deaths = 0, int strawberries = 0,
            bool gem = false)
            => W.CompleteChapter(index, mode, deaths, strawberries, gem);

        [DebugConsoleCommand("ow_complete", "test the completion sequence on the overworld after a level")]
        public static void CmdOWComplete(int index = 1, int mode = 0, int deaths = 0, int strawberries = -1,
            bool cassette = true, bool heartGem = true, float beatBestTimeBy = 1.7921f,
            float beatBestFullClearTimeBy = 1.7921f)
            => W.CompleteOverworld(index, mode, deaths, strawberries, cassette, heartGem,
                beatBestTimeBy, beatBestFullClearTimeBy);

        // Commands.cs:823-845 `capture` / `playback` need PlaybackData and PreviewRecording.
        [DebugConsoleCommand("capture", "capture the last ~200 frames of player movement to a file")]
        public static void CmdCapture(string filename)
            => Unsupported("capture",
                "PlaybackData.Export and the .bin recording format are not ported (the TAS package covers recording)");

        [DebugConsoleCommand("playback", "play back the file name")]
        public static void CmdPlayback(string filename)
            => Unsupported("playback", "PreviewRecording and the .bin playback format are not ported");

        // Commands.cs:455-459 `colorgrading`.
        [DebugConsoleCommand("colorgrading", "sets color grading enabled (true/false)")]
        public static void CmdColorGrading(bool enabled)
            => Unsupported("colorgrading",
                "ColorGrade.Enabled has no equivalent; colour grading is applied through the room's buffers");

        private static string Text(string value) => string.IsNullOrEmpty(value) ? null : value;
        private static int Count(string[] values) => values == null ? 0 : values.Length;

        private static string Join(string[] values) =>
            values == null || values.Length == 0 ? "(none)" : string.Join(", ", values);

        private static string KindName(global::Celeste.Simulation.Diagnostics.Console.DebugConsoleFlagKind kind)
            => kind == global::Celeste.Simulation.Diagnostics.Console.DebugConsoleFlagKind.Session ? "session" :
                kind == global::Celeste.Simulation.Diagnostics.Console.DebugConsoleFlagKind.Save ? "save" : "level";
    }
}
