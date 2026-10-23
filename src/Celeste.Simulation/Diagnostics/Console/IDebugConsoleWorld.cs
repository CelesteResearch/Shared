using System;
using System.Numerics;
using Celeste.Simulation;

namespace Celeste.Simulation.Diagnostics.Console
{
    public interface IDebugConsoleWorld
    {
        // ---- ambient state -------------------------------------------------------------------
        global::Celeste.Simulation.Diagnostics.Console.DebugConsoleSnapshot Snapshot();

        // ---- flags and counters --------------------------------------------------------------
        bool GetFlag(global::Celeste.Simulation.Diagnostics.Console.DebugConsoleFlagKind kind, string name);
        void SetFlag(global::Celeste.Simulation.Diagnostics.Console.DebugConsoleFlagKind kind, string name, bool value);
        void ClearSaveFlags();
        int GetCounter(string name);
        void SetCounter(string name, int value);

        // ---- level / room --------------------------------------------------------------------
        // The original `load`/`hard`/`rmx2` (Commands.cs:485/:499/:519) build `new Session(new
        // AreaKey(id, mode))`, optionally set Session.Level, then replace Engine.Scene with a
        // LevelLoader. Here the room view is reused, so the host rebinds the session and rebuilds.
        // Returns the line the console echoes.
        string LoadLevel(int area, int mode, string level, bool reload);
        string[] RoomsOf(int area, int mode);
        void RetryRoom();

        /// <summary>Commands.cs:451-455 `pico [x] [y]`: the original replaces the scene with
        /// `new Emulator(null, roomX, roomY)`, i.e. a console with NO return target that exits to the
        /// title screen (Emulator.cs:401-412) and boots the cart in room (x,y) when non-zero
        /// (Emulator.cs:99-105 -> Pico8Emulator.cs:407-409).</summary>
        void PlayPico8(int roomX, int roomY);

        // ---- player --------------------------------------------------------------------------
        void Teleport(float x, float y);
        void SetDashes(int dashes);
        void SetDreamDash(bool value);
        void SetNoRefills(bool value);
        void SetInvincible(bool value);
        void SetInfiniteStamina(bool value);

        // ---- world knobs ---------------------------------------------------------------------
        void SetTimeRate(float rate);
        void Freeze(float seconds);
        void SetCoreMode(int mode, bool session);
        void SetZoom(float zoom);
        void SetScreenPadding(float padding);

        // ---- inventory -----------------------------------------------------------------------
        void GiveHeartGem(int area, int mode, bool value);
        void GiveSummitGem(int index); // -1 = all six, as Commands.cs:362 `summitgem all`
        void GiveKey();
        void GiveGolden();
        void UnlockDoors();
        void BouncePlayer();
        string LightingState();
        void GoToTitleScreen(bool ensureSave);
        void CompleteChapter(int index, int mode, int deaths, int strawberries, bool gem);

        void CompleteOverworld(int index, int mode, int deaths, int strawberries, bool cassette,
            bool heartGem, float beatBestTimeBy, float beatBestFullClearTimeBy);

        // Commands.cs:803/:810/:817 - assist / variants / cheat each clear the other mode, and the
        // return value is the mode's new state.
        bool ToggleSaveMode(global::Celeste.Simulation.Diagnostics.Console.DebugConsoleSaveMode mode);

        // Host-side trace of everything the console did, so evidence can be read back verbatim.
        void Trace(string note);
    }
}
