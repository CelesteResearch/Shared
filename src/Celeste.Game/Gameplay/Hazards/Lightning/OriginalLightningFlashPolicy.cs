using Celeste.Core.Scheduling;
using Celeste.Core.Settings.Lightning;
using Celeste.Game.Settings;

namespace Celeste.Game.Gameplay.Hazards.Lightning
{
    public sealed class OriginalLightningFlashPolicy : ISourceLightningFlashPolicy
    {
        private readonly ISourceEngineContext engine;

        public OriginalLightningFlashPolicy(ISourceEngineContext engine)
        {
            this.engine = engine;
        }

        public bool AllowLightning =>
            !((ISettingsRuntimeContext)engine).SettingsProcess.Instance.DisableFlashes;
    }
}
