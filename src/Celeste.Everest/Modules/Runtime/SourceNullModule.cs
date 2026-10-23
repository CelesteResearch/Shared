using System;
using Celeste.Core.Scheduling;
using Celeste.Everest.Diagnostics.Logging;
using Celeste.Simulation.UI.Menus.Text;
using Celeste.Audio.Fmod.Events;

namespace Celeste.Everest.Modules.Runtime
{
    public class SourceNullModule : SourceEverestModule
    {
        public override Type SettingsType => null;
        public override Type SaveDataType => null;

        public SourceNullModule(ISourceEngineContext engine, EverestModuleMetadata metadata) : base(engine)
        {
            Metadata = metadata;
        }

        public override void Load()
        {
        }

        public override void Unload()
        {
        }

        public override void CreateModMenuSection(TextMenuPresentation menu, bool inGame, FmodEventReference snapshot)
        {
        }

        public override void LogRegistration()
        {
            var message =
                ((IEverestLoggerProcessEnvironment)SourceEngine).Logger.BeginEnabledMessage("core",
                    EverestLogLevel.Info);
            if (message.ShouldLog)
                message.Write("Non-code module " + Metadata + " registered.");
        }

        public override void LogUnregistration()
        {
            var message =
                ((IEverestLoggerProcessEnvironment)SourceEngine).Logger.BeginEnabledMessage("core",
                    EverestLogLevel.Info);
            if (message.ShouldLog)
                message.Write("Non-code module " + Metadata + " unregistered.");
        }
    }
}
