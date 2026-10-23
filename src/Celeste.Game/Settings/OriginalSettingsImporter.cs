using System;
using Celeste.Formats.Settings;
using Celeste.Input.Bindings;
using Celeste.Input.Devices.GamePads;
using Celeste.Input.Devices.Keyboard;
using Celeste.Input.Gameplay;

namespace Celeste.Game.Settings
{
    // Original Settings XML is translated only here; runtime models and ports
    // consume the shared original preferences instead of duplicating this map.
    public static class OriginalSettingsImporter
    {
        public static void Read(byte[] bytes, SettingsState settings, bool fullscreenWhenMissing)
        {
            Import(FileSettingsCodec.Deserialize(bytes, fullscreenWhenMissing), settings);
        }

        public static void Import(FileSettingsXml data, SettingsState settings)
        {
            if (data == null) throw new ArgumentNullException(nameof(data));
            if (settings == null) throw new ArgumentNullException(nameof(settings));
            settings.Version = data.Version;
            settings.DefaultFileName = data.DefaultFileName;
            settings.Fullscreen = data.Fullscreen;
            settings.WindowScale = data.WindowScale;
            settings.ViewportPadding = data.ViewportPadding;
            settings.VSync = data.VSync;
            settings.DisableFlashes = data.DisableFlashes;
            settings.ScreenShake = (int)data.ScreenShake;
            settings.Rumble = (int)data.Rumble;
            settings.GrabMode = (GrabMode)data.GrabMode;
            settings.CrouchDashMode = (CrouchDashMode)data.CrouchDashMode;
            settings.MusicVolume = data.MusicVolume;
            settings.SFXVolume = data.SFXVolume;
            settings.SpeedrunClock = (int)data.SpeedrunClock;
            settings.LastSaveFile = data.LastSaveFile;
            settings.Pico8OnMainMenu = data.Pico8OnMainMenu;
            settings.SetViewportOnce = data.SetViewportOnce;
            settings.VariantsUnlocked = data.VariantsUnlocked;
            settings.LaunchInDebugMode = data.LaunchInDebugMode;
            settings.LaunchWithFMODLiveUpdate = data.LaunchWithFMODLiveUpdate;
            settings.LanguageId = data.Language;
            ReadBinding(data.Left, settings.Left);
            ReadBinding(data.Right, settings.Right);
            ReadBinding(data.Down, settings.Down);
            ReadBinding(data.Up, settings.Up);
            ReadBinding(data.MenuLeft, settings.MenuLeft);
            ReadBinding(data.MenuRight, settings.MenuRight);
            ReadBinding(data.MenuDown, settings.MenuDown);
            ReadBinding(data.MenuUp, settings.MenuUp);
            ReadBinding(data.Grab, settings.Grab);
            ReadBinding(data.Jump, settings.Jump);
            ReadBinding(data.Dash, settings.Dash);
            ReadBinding(data.Talk, settings.Talk);
            ReadBinding(data.Pause, settings.Pause);
            ReadBinding(data.Confirm, settings.Confirm);
            ReadBinding(data.Cancel, settings.Cancel);
            ReadBinding(data.Journal, settings.Journal);
            ReadBinding(data.QuickRestart, settings.QuickRestart);
            ReadBinding(data.DemoDash, settings.DemoDash);
            ReadBinding(data.RightMoveOnly, settings.RightMoveOnly);
            ReadBinding(data.LeftMoveOnly, settings.LeftMoveOnly);
            ReadBinding(data.UpMoveOnly, settings.UpMoveOnly);
            ReadBinding(data.DownMoveOnly, settings.DownMoveOnly);
            ReadBinding(data.RightDashOnly, settings.RightDashOnly);
            ReadBinding(data.LeftDashOnly, settings.LeftDashOnly);
            ReadBinding(data.UpDashOnly, settings.UpDashOnly);
            ReadBinding(data.DownDashOnly, settings.DownDashOnly);
        }

        public static byte[] Write(SettingsState settings, string languageId)
        {
            return FileSettingsCodec.Serialize(Export(settings, languageId));
        }

        public static FileSettingsXml Export(SettingsState settings, string languageId)
        {
            if (settings == null) throw new ArgumentNullException(nameof(settings));
            var data = new FileSettingsXml();
            data.Version = settings.Version;
            data.DefaultFileName = settings.DefaultFileName;
            data.Fullscreen = settings.Fullscreen;
            data.WindowScale = settings.WindowScale;
            data.ViewportPadding = settings.ViewportPadding;
            data.VSync = settings.VSync;
            data.DisableFlashes = settings.DisableFlashes;
            data.ScreenShake = (FileScreenShake)settings.ScreenShake;
            data.Rumble = (FileRumble)settings.Rumble;
            data.GrabMode = (FileGrabMode)settings.GrabMode;
            data.CrouchDashMode = (FileCrouchDashMode)settings.CrouchDashMode;
            data.MusicVolume = settings.MusicVolume;
            data.SFXVolume = settings.SFXVolume;
            data.SpeedrunClock = (FileSpeedrunClock)settings.SpeedrunClock;
            data.LastSaveFile = settings.LastSaveFile;
            data.Pico8OnMainMenu = settings.Pico8OnMainMenu;
            data.SetViewportOnce = settings.SetViewportOnce;
            data.VariantsUnlocked = settings.VariantsUnlocked;
            data.Language = languageId;
            data.LaunchInDebugMode = settings.LaunchInDebugMode;
            data.LaunchWithFMODLiveUpdate = settings.LaunchWithFMODLiveUpdate;
            WriteBinding(settings.Left, data.Left);
            WriteBinding(settings.Right, data.Right);
            WriteBinding(settings.Down, data.Down);
            WriteBinding(settings.Up, data.Up);
            WriteBinding(settings.MenuLeft, data.MenuLeft);
            WriteBinding(settings.MenuRight, data.MenuRight);
            WriteBinding(settings.MenuDown, data.MenuDown);
            WriteBinding(settings.MenuUp, data.MenuUp);
            WriteBinding(settings.Grab, data.Grab);
            WriteBinding(settings.Jump, data.Jump);
            WriteBinding(settings.Dash, data.Dash);
            WriteBinding(settings.Talk, data.Talk);
            WriteBinding(settings.Pause, data.Pause);
            WriteBinding(settings.Confirm, data.Confirm);
            WriteBinding(settings.Cancel, data.Cancel);
            WriteBinding(settings.Journal, data.Journal);
            WriteBinding(settings.QuickRestart, data.QuickRestart);
            WriteBinding(settings.DemoDash, data.DemoDash);
            WriteBinding(settings.RightMoveOnly, data.RightMoveOnly);
            WriteBinding(settings.LeftMoveOnly, data.LeftMoveOnly);
            WriteBinding(settings.UpMoveOnly, data.UpMoveOnly);
            WriteBinding(settings.DownMoveOnly, data.DownMoveOnly);
            WriteBinding(settings.RightDashOnly, data.RightDashOnly);
            WriteBinding(settings.LeftDashOnly, data.LeftDashOnly);
            WriteBinding(settings.UpDashOnly, data.UpDashOnly);
            WriteBinding(settings.DownDashOnly, data.DownDashOnly);
            return data;
        }

        private static void ReadBinding(FileSettingsBindingXml data, SourceInputBinding binding)
        {
            if (data == null) return;
            binding.Keyboard.Clear();
            binding.Controller.Clear();
            foreach (var key in data.Keyboard) binding.Keyboard.Add((SourceKeys)(int)key);
            foreach (var button in data.Controller) binding.Controller.Add((SourceGamePadButtonFlags)(int)button);
        }

        private static void WriteBinding(SourceInputBinding binding, FileSettingsBindingXml data)
        {
            foreach (var key in binding.Keyboard) data.Keyboard.Add((FileSettingsKey)(int)key);
            foreach (var button in binding.Controller) data.Controller.Add((FileSettingsButton)(int)button);
        }
    }
}
