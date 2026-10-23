using System;
using Celeste.Core.Scheduling;
using Celeste.Everest.Modules.Runtime;

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
            Metadata = new EverestModuleMetadata
            {
                Name = "Everest",
                VersionString = ((global::Celeste.Everest.Runtime.Startup.IEverestStartupRuntimeEnvironment)engine)
                    .EverestRuntime.VersionString
            };
        }

        public override void LoadSettings()
        {
            base.LoadSettings();
            if (Settings.DiscordRichPresence &&
                !((global::Celeste.Everest.Runtime.IEverestHeadlessEnvironment)SourceEngine).IsHeadless)
                ((global::Celeste.Everest.Runtime.Discord.IEverestDiscordSdkEnvironment)SourceEngine).DiscordSdk
                    ?.CreateInstance();
        }

        public override void SaveSettings()
        {
            Settings.CurrentVersion =
                ((global::Celeste.Everest.Runtime.Startup.IEverestStartupRuntimeEnvironment)SourceEngine).EverestRuntime
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
