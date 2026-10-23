using Celeste.Core.Scheduling;
using Celeste.Core.Settings.Lightning;
using Celeste.Everest.Modules.Settings;

namespace Celeste.Everest.Gameplay.Hazards.Lightning
{
    public sealed class EverestLightningFlashPolicy : ISourceLightningFlashPolicy
    {
        private readonly ISourceEngineContext engine;

        public EverestLightningFlashPolicy(ISourceEngineContext engine)
        {
            this.engine = engine;
        }

        public bool AllowLightning =>
            ((IEverestCurrentCoreSettingsEnvironment)engine).CurrentCoreSettings.AllowLightning;
    }
}
