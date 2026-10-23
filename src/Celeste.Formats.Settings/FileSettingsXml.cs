using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Celeste.Formats.Settings
{
    // Storage schema only. Input initialization and display limits belong to the running host.
    [XmlRoot("Settings")]
    public sealed class FileSettingsXml
    {
        public string Version = null;
        public string DefaultFileName = "";
        public bool Fullscreen = true;
        public int WindowScale = 6;
        public int ViewportPadding = 0;
        public bool VSync = true;
        public bool DisableFlashes = false;
        public FileScreenShake ScreenShake = FileScreenShake.Half;
        public FileRumble Rumble = FileRumble.On;
        public FileGrabMode GrabMode = FileGrabMode.Hold;
        public FileCrouchDashMode CrouchDashMode = FileCrouchDashMode.Press;
        public int MusicVolume = 10;
        public int SFXVolume = 10;
        public FileSpeedrunClock SpeedrunClock = FileSpeedrunClock.Off;
        public int LastSaveFile = 0;
        public string Language = "english";
        public bool Pico8OnMainMenu = false;
        public bool SetViewportOnce = false;
        public bool VariantsUnlocked = false;
        public FileSettingsBindingXml Left = new FileSettingsBindingXml();
        public FileSettingsBindingXml Right = new FileSettingsBindingXml();
        public FileSettingsBindingXml Down = new FileSettingsBindingXml();
        public FileSettingsBindingXml Up = new FileSettingsBindingXml();
        public FileSettingsBindingXml MenuLeft = new FileSettingsBindingXml();
        public FileSettingsBindingXml MenuRight = new FileSettingsBindingXml();
        public FileSettingsBindingXml MenuDown = new FileSettingsBindingXml();
        public FileSettingsBindingXml MenuUp = new FileSettingsBindingXml();
        public FileSettingsBindingXml Grab = new FileSettingsBindingXml();
        public FileSettingsBindingXml Jump = new FileSettingsBindingXml();
        public FileSettingsBindingXml Dash = new FileSettingsBindingXml();
        public FileSettingsBindingXml Talk = new FileSettingsBindingXml();
        public FileSettingsBindingXml Pause = new FileSettingsBindingXml();
        public FileSettingsBindingXml Confirm = new FileSettingsBindingXml();
        public FileSettingsBindingXml Cancel = new FileSettingsBindingXml();
        public FileSettingsBindingXml Journal = new FileSettingsBindingXml();
        public FileSettingsBindingXml QuickRestart = new FileSettingsBindingXml();
        public FileSettingsBindingXml DemoDash = new FileSettingsBindingXml();
        public FileSettingsBindingXml RightMoveOnly = new FileSettingsBindingXml();
        public FileSettingsBindingXml LeftMoveOnly = new FileSettingsBindingXml();
        public FileSettingsBindingXml UpMoveOnly = new FileSettingsBindingXml();
        public FileSettingsBindingXml DownMoveOnly = new FileSettingsBindingXml();
        public FileSettingsBindingXml RightDashOnly = new FileSettingsBindingXml();
        public FileSettingsBindingXml LeftDashOnly = new FileSettingsBindingXml();
        public FileSettingsBindingXml UpDashOnly = new FileSettingsBindingXml();
        public FileSettingsBindingXml DownDashOnly = new FileSettingsBindingXml();
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
