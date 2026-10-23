using System;
using Celeste.Core.Scheduling;

namespace Celeste.Simulation.Presentation.Player.Death
{
    // Implemented by the actual level captured by the corpse, never the current host room.
    public interface IPlayerDeathLevel : ISourceEngineContextScene
    {
        PlayerDeathPresentation RetryPlayerCorpse { get; set; }
        void Reload();
        void WipeOut(Action onComplete);
    }
}
