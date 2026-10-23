using System;

namespace Celeste.Simulation.Presentation.Player.Death
{
    // Implemented by the actual level captured by the corpse, never the current host room.
    public interface IPlayerDeathLevel : global::Celeste.Core.Scheduling.ISourceEngineContextScene
    {
        PlayerDeathPresentation RetryPlayerCorpse { get; set; }
        void Reload();
        void WipeOut(Action onComplete);
    }
}
