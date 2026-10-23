using Celeste.Input.Devices.Keyboard;
using Celeste.Input.Devices.GamePads;
using Celeste.Everest.Settings;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using Keys = Celeste.Input.Devices.Keyboard.SourceKeys;
using Buttons = Celeste.Input.Devices.GamePads.SourceGamePadButtonFlags;
using Celeste.Everest.Modules.Settings;
using Celeste.Everest.Input.Bindings;
using Celeste.Everest.Settings.Metadata;
using Celeste.Everest.Content.Registry;
using Celeste.Everest.Diagnostics.Logging;
using Celeste.Game.Settings;
using Celeste.Game.Execution.Engine;
using Celeste.Game.Execution.Startup;
using Celeste.Game.Menus.Overworld;
using Celeste.Game.Menus.Title;
using YamlDotNet.Serialization;
using global::Celeste.Game.Execution;

namespace Celeste.Everest
{
    [SettingMenuName("CoreModuleSettings")]
    [SettingName("modoptions_coremodule_title")]
    public partial class EverestCoreSettings : EverestModuleSettings
    {
        private static global::Celeste.Core.Scheduling.ISourceEngineContext ActualEngine =>
            EngineRuntime.Instance.Process;

        private static SettingsState OriginalSettings =>
            ((ISettingsRuntimeContext)ActualEngine).SettingsProcess.Instance;

        private static global::Celeste.Framework.Diagnostics.Commands.SourceCommands ActualCommands =>
            ((global::Celeste.Framework.Diagnostics.Commands.ISourceCommandsPublicationEnvironment)ActualEngine)
            .CommandsOrNull;

        private static EverestContentRegistry ActualContent =>
            ((IEverestContentRegistryEnvironment)ActualEngine).SourceContentRegistry;

        private static EverestLoggerProcess ActualLogger => ((IEverestLoggerProcessEnvironment)ActualEngine).Logger;

        private bool _DebugModeInEverest;

        private string _MainMenuMode = "";

        private bool _WarnOnEverestYamlErrors;

        private bool _ColorizedLogging = true;

        private string _CurrentBranch;

        private Dictionary<string, EverestLogLevel> _LogLevels = new Dictionary<string, EverestLogLevel>();

        [YamlIgnore]
        public EverestVanillaTristate DebugMode
        {
            get
            {
                if (!OriginalSettings.LaunchInDebugMode)
                {
                    if (!DebugModeInEverest)
                    {
                        return EverestVanillaTristate.Never;
                    }

                    return EverestVanillaTristate.Everest;
                }

                return EverestVanillaTristate.Always;
            }
            set
            {
                switch (value)
                {
                    default:
                        DebugModeInEverest = false;
                        OriginalSettings.LaunchInDebugMode = false;
                        break;
                    case EverestVanillaTristate.Everest:
                        DebugModeInEverest = true;
                        OriginalSettings.LaunchInDebugMode = false;
                        break;
                    case EverestVanillaTristate.Always:
                        DebugModeInEverest = true;
                        OriginalSettings.LaunchInDebugMode = true;
                        break;
                }
            }
        }

        [YamlIgnore]
        [SettingIgnore]
        [Obsolete("Use DebugMode instead.")]
        public bool DebugModeOld
        {
            get { return DebugMode != EverestVanillaTristate.Never; }
            set { DebugMode = (value ? EverestVanillaTristate.Always : EverestVanillaTristate.Never); }
        }

        [SettingIgnore]
        public bool DebugModeInEverest
        {
            get
            {
                if (!_DebugModeInEverest)
                {
                    return OriginalSettings.LaunchInDebugMode;
                }

                return true;
            }
            set
            {
                _DebugModeInEverest = value;
                if (GameRuntime.PlayMode == GameRuntime.PlayModes.Debug == value)
                {
                    return;
                }

                if (value)
                {
                    GameRuntime.PlayMode = GameRuntime.PlayModes.Debug;
                    if (ActualCommands != null)
                    {
                        ActualCommands.Enabled = true;
                    }
                }
                else
                {
                    GameRuntime.PlayMode = GameRuntime.PlayModes.Normal;
                    if (ActualCommands != null)
                    {
                        ActualCommands.Enabled = false;
                    }
                }

                ((ActualEngine.Frame.Scenes.CurrentScene as OverworldSequence)
                    ?.GetUI<global::Celeste.Everest.Menus.Title.EverestMainMenuSequence>())?.NeedsRebuild();
            }
        }

        [YamlIgnore]
        [SettingNeedsRelaunch]
        [SettingInGame(false)]
        public EverestVanillaTristate LaunchWithFMODLiveUpdate
        {
            get
            {
                if (!OriginalSettings.LaunchWithFMODLiveUpdate)
                {
                    if (!LaunchWithFMODLiveUpdateInEverest)
                    {
                        return EverestVanillaTristate.Never;
                    }

                    return EverestVanillaTristate.Everest;
                }

                return EverestVanillaTristate.Always;
            }
            set
            {
                switch (value)
                {
                    default:
                        LaunchWithFMODLiveUpdateInEverest = false;
                        OriginalSettings.LaunchWithFMODLiveUpdate = false;
                        break;
                    case EverestVanillaTristate.Everest:
                        LaunchWithFMODLiveUpdateInEverest = true;
                        OriginalSettings.LaunchWithFMODLiveUpdate = false;
                        break;
                    case EverestVanillaTristate.Always:
                        LaunchWithFMODLiveUpdateInEverest = true;
                        OriginalSettings.LaunchWithFMODLiveUpdate = true;
                        break;
                }
            }
        }

        [SettingIgnore] public bool LaunchWithFMODLiveUpdateInEverest { get; set; }

        [SettingNeedsRelaunch]
        [SettingInGame(false)]
        public bool LaunchWithoutIntro { get; set; }

        [SettingInGame(false)] public bool ShowModOptionsInGame { get; set; } = true;

        [YamlIgnore]
        [SettingInGame(false)]
        public bool ShowEverestTitleScreen
        {
            get
            {
                if (DateTime.Now.Month == 4 && DateTime.Now.Day == 1)
                {
                    return TitleScreenType != "vanilla";
                }

                return TitleScreenType == "everest";
            }
            set { TitleScreenType = (value ? "everest" : "vanilla"); }
        }

        [SettingIgnore] public string TitleScreenType { get; set; }

        [SettingIgnore] public bool LazyLoading_Yes_I_Know_This_Can_Cause_Bugs { get; set; }

        [SettingNeedsRelaunch]
        [SettingInGame(false)]
        [SettingIgnore]
        [YamlIgnore]
        public bool LazyLoading
        {
            get { return LazyLoading_Yes_I_Know_This_Can_Cause_Bugs; }
            set { LazyLoading_Yes_I_Know_This_Can_Cause_Bugs = value; }
        }

        [SettingIgnore] public string DefaultStartingLevelSet { get; set; } = "Celeste";

        [SettingIgnore] public int LogHistoryCountToKeep { get; set; } = 3;

        [SettingNeedsRelaunch]
        [SettingInGame(false)]
        [SettingIgnore]
        public bool? ThreadedGL { get; set; }

        [YamlMember(Alias = "FastTextureLoading")]
        [SettingIgnore]
        public bool? _FastTextureLoading { get; set; }

        [YamlIgnore]
        [SettingNeedsRelaunch]
        [SettingInGame(false)]
        [SettingIgnore]
        public bool? FastTextureLoading
        {
            get
            {
                if (!ActualContent.DumpOnLoad && !ActualContent.DumpAllRequested)
                {
                    return _FastTextureLoading;
                }

                return false;
            }
            set { _FastTextureLoading = value; }
        }

        [SettingNeedsRelaunch]
        [SettingInGame(false)]
        [SettingIgnore]
        public float FastTextureLoadingMaxMB { get; set; }

        [SettingNeedsRelaunch]
        [SettingInGame(false)]
        [SettingIgnore]
        public bool UnpackFMODBanks { get; set; } = true;

        [SettingNeedsRelaunch]
        [SettingInGame(false)]
        [SettingIgnore]
        public bool UnloadUnusedAudio { get; set; } = true;

        [SettingNeedsRelaunch]
        [SettingInGame(false)]
        [SettingIgnore]
        public bool DisableAntiSoftlock { get; set; }

        [SettingNeedsRelaunch]
        [SettingInGame(false)]
        [SettingIgnore]
        public bool? MultithreadedGC { get; set; }

        [SettingNeedsRelaunch]
        [SettingInGame(false)]
        [SettingIgnore]
        public bool RestartAppDomain_WIP { get; set; }

        [SettingInGame(false)] [SettingIgnore] public int? MaxSaveSlots { get; set; }

        [SettingInGame(false)] [SettingIgnore] public int ExtraCommandHistoryLines { get; set; } = 50;

        [SettingInGame(false)] [SettingIgnore] public bool? SaveDataFlush { get; set; }

        [SettingInGame(false)] [SettingIgnore] public bool? WhitelistFullOverride { get; set; }

        [SettingInGame(false)] [SettingIgnore] public bool OpenErrorLogOnCrash { get; set; } = true;

        public string InputGui { get; set; } = "";

        public string MainMenuMode
        {
            get { return _MainMenuMode; }
            set
            {
                string mainMenuMode = _MainMenuMode;
                _MainMenuMode = value;
                if (value != mainMenuMode)
                {
                    ((ActualEngine.Frame.Scenes.CurrentScene as OverworldSequence)
                        ?.GetUI<global::Celeste.Everest.Menus.Title.EverestMainMenuSequence>())?.NeedsRebuild();
                }
            }
        }

        public EverestCompatMode CompatibilityMode { get; set; }

        [SettingNeedsRelaunch]
        [SettingName("MODOPTIONS_COREMODULE_D3D11EXCLUSIVEFULLSCREEN")]
        [SettingSubText("MODOPTIONS_COREMODULE_D3D11EXCLUSIVEFULLSCREEN_DESC")]
        [SettingInGame(false)]
        public bool D3D11UseExclusiveFullscreen { get; set; }

        [SettingInGame(false)] public bool UseKeyboardForTextInput { get; set; } = true;

        [SettingInGame(false)] public bool AutoUpdateModsOnStartup { get; set; }

        [SettingSubText("MODOPTIONS_COREMODULE_WARNONEVERESTYAMLERRORS_DESC")]
        [SettingInGame(false)]
        public bool WarnOnEverestYamlErrors
        {
            get { return _WarnOnEverestYamlErrors; }
            set
            {
                _WarnOnEverestYamlErrors = value;
                ((ActualEngine.Frame.Scenes.CurrentScene as OverworldSequence)
                    ?.GetUI<global::Celeste.Everest.Menus.Title.EverestMainMenuSequence>())?.NeedsRebuild();
            }
        }

        [SettingSubText("MODOPTIONS_COREMODULE_COLORIZEDLOGGING_DESC")]
        [SettingInGame(false)]
        public bool ColorizedLogging
        {
            get { return _ColorizedLogging; }
            set
            {
                if (value && RuntimeInformation.IsOSPlatform(OSPlatform.Windows) &&
                    !ActualLogger.TryEnableWindowsVTSupport())
                {
                    ActualLogger.Log(EverestLogLevel.Error, "core", "Failed to enable Windows VT support!");
                }

                _ColorizedLogging = value;
            }
        }

        public string MirrorPreferences { get; set; } = "gb,jade,risingsunlight,otobot,wegfan";

        [SettingSubText("MODOPTIONS_COREMODULE_USEAPIMIRROR_DESC")]
        public bool UseAPIMirror { get; set; }

        public bool DiscordRichPresence { get; set; } = true;

        [SettingIgnore] public bool DiscordShowIcon { get; set; } = true;

        [SettingIgnore] public bool DiscordShowMap { get; set; } = true;

        [SettingIgnore] public bool DiscordShowSide { get; set; } = true;

        [SettingIgnore] public bool DiscordShowRoom { get; set; }

        [SettingIgnore] public bool DiscordShowBerries { get; set; } = true;

        [SettingIgnore] public bool DiscordShowDeaths { get; set; } = true;

        [SettingIgnore] public int DebugRCPort { get; set; } = 32270;

        [SettingIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool PhotosensitivityDistortOverride { get; set; }

        /// <summary>
        ///       Whether a distortion effect should be rendered, respecting Everest's photosensitivity setting overrides.
        ///       </summary>
        [SettingIgnore]
        [YamlIgnore]
        public bool AllowDistort
        {
            get
            {
                if (OriginalSettings.DisableFlashes)
                {
                    return PhotosensitivityDistortOverride;
                }

                return true;
            }
        }

        [SettingIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool PhotosensitivityGlitchOverride { get; set; }

        /// <summary>
        ///       Whether a glitch effect should be rendered, respecting Everest's photosensitivity setting overrides.
        ///       </summary>
        [SettingIgnore]
        [YamlIgnore]
        public bool AllowGlitch
        {
            get
            {
                if (OriginalSettings.DisableFlashes)
                {
                    return PhotosensitivityGlitchOverride;
                }

                return true;
            }
        }

        [SettingIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool PhotosensitivityLightningOverride { get; set; }

        /// <summary>
        ///       Whether lightning should have internal flashes, respecting Everest's photosensitivity setting overrides.
        ///       </summary>
        [SettingIgnore]
        [YamlIgnore]
        public bool AllowLightning
        {
            get
            {
                if (OriginalSettings.DisableFlashes)
                {
                    return PhotosensitivityLightningOverride;
                }

                return true;
            }
        }

        [SettingIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool PhotosensitivityScreenFlashOverride { get; set; }

        /// <summary>
        ///       Whether to render a screenwide flash, respecting Everest's photosensitivity setting overrides.
        ///       </summary>
        [SettingIgnore]
        [YamlIgnore]
        public bool AllowScreenFlash
        {
            get
            {
                if (OriginalSettings.DisableFlashes)
                {
                    return PhotosensitivityScreenFlashOverride;
                }

                return true;
            }
        }

        [SettingIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool PhotosensitivityTextHighlightOverride { get; set; }

        /// <summary>
        ///       Whether text in menus should flash when selected, respecting Everest's photosensitivity setting overrides.
        ///       </summary>
        [SettingIgnore]
        [YamlIgnore]
        public bool AllowTextHighlight
        {
            get
            {
                if (OriginalSettings.DisableFlashes)
                {
                    return PhotosensitivityTextHighlightOverride;
                }

                return true;
            }
        }

        [SettingIgnore] public int? QuickRestart { get; set; }

        [SettingIgnore] public bool ShowManualTextOnDebugMap { get; set; } = true;

        [SettingIgnore] public bool CodeReload_WIP { get; set; }

        [SettingIgnore]
        [YamlIgnore]
        public bool CodeReload
        {
            get { return CodeReload_WIP; }
            set { CodeReload_WIP = value; }
        }

        [SettingIgnore] public bool UseInGameCrashHandler { get; set; } = true;

        [SettingIgnore] public bool CrashHandlerAlwaysTeabag { get; set; }

        [SettingIgnore] public string CurrentVersion { get; set; }

        [SettingIgnore]
        public string CurrentBranch
        {
            get { return _CurrentBranch; }
            set
            {
                bool flag;
                switch (value)
                {
                    case "dev":
                    case "beta":
                    case "stable":
                        flag = true;
                        break;
                    default:
                        flag = false;
                        break;
                }

                _CurrentBranch = (flag ? ("updater_src_" + value) : value);
            }
        }

        [SettingIgnore]
        public Dictionary<string, EverestLogLevel> LogLevels
        {
            get { return _LogLevels; }
            set { _LogLevels = value ?? new Dictionary<string, EverestLogLevel>(); }
        }

        [SettingSubHeader("MODOPTIONS_COREMODULE_MENUNAV_SUBHEADER")]
        [SettingInGame(false)]
        public EverestButtonBinding MenuPageUp { get; set; }

        [SettingInGame(false)] public EverestButtonBinding MenuPageDown { get; set; }

        [SettingSubHeader("MODOPTIONS_COREMODULE_DEBUGMODE_SUBHEADER")]
        [SettingInGame(false)]
        [DefaultButtonBinding((Buttons)0, Keys.OemTilde)]
        public EverestButtonBinding ToggleDebugConsole { get; set; }

        [SettingInGame(false)]
        [DefaultButtonBinding((Buttons)0, Keys.OemPeriod)]
        public EverestButtonBinding DebugConsole { get; set; }

        [SettingInGame(false)]
        [DefaultButtonBinding((Buttons)0, Keys.F6)]
        public EverestButtonBinding DebugMap { get; set; }

        [SettingSubHeader("MODOPTIONS_COREMODULE_MOUNTAINCAM_SUBHEADER")]
        [SettingInGame(false)]
        [DefaultButtonBinding(Buttons.RightThumbstickUp, Keys.W)]
        public EverestButtonBinding CameraForward { get; set; }

        [SettingInGame(false)]
        [DefaultButtonBinding(Buttons.RightThumbstickDown, Keys.S)]
        public EverestButtonBinding CameraBackward { get; set; }

        [SettingInGame(false)]
        [DefaultButtonBinding(Buttons.RightThumbstickRight, Keys.D)]
        public EverestButtonBinding CameraRight { get; set; }

        [SettingInGame(false)]
        [DefaultButtonBinding(Buttons.RightThumbstickLeft, Keys.A)]
        public EverestButtonBinding CameraLeft { get; set; }

        [SettingInGame(false)]
        [DefaultButtonBinding((Buttons)0, Keys.Q)]
        public EverestButtonBinding CameraUp { get; set; }

        [SettingInGame(false)]
        [DefaultButtonBinding((Buttons)0, Keys.Z)]
        public EverestButtonBinding CameraDown { get; set; }

        [SettingInGame(false)]
        [DefaultButtonBinding((Buttons)0, Keys.LeftShift)]
        public EverestButtonBinding CameraSlow { get; set; }

        [SettingInGame(false)]
        [DefaultButtonBinding((Buttons)0, Keys.P)]
        public EverestButtonBinding CameraPrint { get; set; }

        [SettingInGame(false)]
        [DefaultButtonBinding((Buttons)0, Keys.Space)]
        public EverestButtonBinding ToggleMountainFreeCam { get; set; }
    }
}
