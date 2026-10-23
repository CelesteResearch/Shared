using System.Xml;
using System.Xml.Serialization;

namespace Celeste.Formats.Settings
{
    // Storage schema only. Input initialization and display limits belong to the running host.
    [XmlRoot("Settings")]
    public sealed class FileSettingsXml
    {
        public string Version;
        public string DefaultFileName = "";
        public bool Fullscreen = true;
        public int WindowScale = 6;
        public int ViewportPadding;
        public bool VSync = true;
        public bool DisableFlashes;
        public FileScreenShake ScreenShake = FileScreenShake.Half;
        public FileRumble Rumble = FileRumble.On;
        public FileGrabMode GrabMode = FileGrabMode.Hold;
        public FileCrouchDashMode CrouchDashMode = FileCrouchDashMode.Press;
        public int MusicVolume = 10;
        public int SFXVolume = 10;
        public FileSpeedrunClock SpeedrunClock = FileSpeedrunClock.Off;
        public int LastSaveFile;
        public string Language = "english";
        public bool Pico8OnMainMenu;
        public bool SetViewportOnce;
        public bool VariantsUnlocked;
        public FileSettingsBindingXml Left = new();
        public FileSettingsBindingXml Right = new();
        public FileSettingsBindingXml Down = new();
        public FileSettingsBindingXml Up = new();
        public FileSettingsBindingXml MenuLeft = new();
        public FileSettingsBindingXml MenuRight = new();
        public FileSettingsBindingXml MenuDown = new();
        public FileSettingsBindingXml MenuUp = new();
        public FileSettingsBindingXml Grab = new();
        public FileSettingsBindingXml Jump = new();
        public FileSettingsBindingXml Dash = new();
        public FileSettingsBindingXml Talk = new();
        public FileSettingsBindingXml Pause = new();
        public FileSettingsBindingXml Confirm = new();
        public FileSettingsBindingXml Cancel = new();
        public FileSettingsBindingXml Journal = new();
        public FileSettingsBindingXml QuickRestart = new();
        public FileSettingsBindingXml DemoDash = new();
        public FileSettingsBindingXml RightMoveOnly = new();
        public FileSettingsBindingXml LeftMoveOnly = new();
        public FileSettingsBindingXml UpMoveOnly = new();
        public FileSettingsBindingXml DownMoveOnly = new();
        public FileSettingsBindingXml RightDashOnly = new();
        public FileSettingsBindingXml LeftDashOnly = new();
        public FileSettingsBindingXml UpDashOnly = new();
        public FileSettingsBindingXml DownDashOnly = new();
        public bool LaunchWithFMODLiveUpdate;
        public bool LaunchInDebugMode;

        [XmlAnyElement("LaunchInDebugModeComment")]
        public XmlComment DebugModeComment
        {
            get => new XmlDocument().CreateComment(
                "\n\t\tLaunchWithFMODLiveUpdate:\n\t\t\tThis Enables FMOD Studio Live Update so you can interact with the sounds in real time.\n\t\t\tNote this will also require access to the private network.\n\t\t\n\t\tLaunchInDebugMode:\n\t\t\tDebug Mode can destroy save files, crash the game, and do other unwanted behaviour.\n\t\t\tIt is not documented. Use at own risk.\n\t");
            set { }
        }
    }
}
