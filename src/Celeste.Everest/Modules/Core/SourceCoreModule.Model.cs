using System;
using Celeste.Core.Scheduling;
using Celeste.Everest.Modules.Runtime;
using Celeste.Everest.Runtime;
using Celeste.Everest.Runtime.Discord;
using Celeste.Everest.Runtime.Startup;

namespace Celeste.Everest.Modules.Core
{
    public partial class SourceCoreModule : SourceEverestModule
    {
        public const string NETCoreMetaName = "EverestCore";
        public static SourceCoreModule Instance;
        public override Type SettingsType => typeof(EverestCoreSettings);
        public static EverestCoreSettings Settings => (EverestCoreSettings)Instance._Settings;
        public override Type SaveDataType => typeof(SourceCoreModuleSaveData);
        public static SourceCoreModuleSaveData SaveData => (SourceCoreModuleSaveData)Instance._SaveData;
        public override Type SessionType => typeof(SourceCoreModuleSession);
        public static SourceCoreModuleSession Session => (SourceCoreModuleSession)Instance._Session;

        public SourceCoreModule(ISourceEngineContext engine) : base(engine)
        {
            Instance = this;
            Metadata = new()
            {
                Name = "Everest",
                VersionString = ((IEverestStartupRuntimeEnvironment)engine)
                    .EverestRuntime.VersionString,
            };
        }

        public override void LoadSettings()
        {
            base.LoadSettings();
            if (Settings.DiscordRichPresence &&
                !((IEverestHeadlessEnvironment)SourceEngine).IsHeadless)
                ((IEverestDiscordSdkEnvironment)SourceEngine).DiscordSdk
                    ?.CreateInstance();
        }

        public override void SaveSettings()
        {
            Settings.CurrentVersion =
                ((IEverestStartupRuntimeEnvironment)SourceEngine).EverestRuntime
                .Version.ToString();
            base.SaveSettings();
        }

        public override void OnInputInitialize()
        {
            base.OnInputInitialize();
            Settings.MenuPageUp.Button.SetRepeat(0.4f, 0.1f);
            Settings.MenuPageDown.Button.SetRepeat(0.4f, 0.1f);
        }
    }
}
