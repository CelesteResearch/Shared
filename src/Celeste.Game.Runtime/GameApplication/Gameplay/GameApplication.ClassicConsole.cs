using System;
using Celeste.Game.Minigames.CelesteClassic.Emulation;
using Celeste.Game.Profiles;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : IOriginalClassicConsolePolicyEnvironment
    {
        private IOriginalClassicConsolePolicy sourceClassicConsolePolicy;

        public IOriginalClassicConsolePolicy ClassicConsolePolicy => sourceClassicConsolePolicy ??
                                                                     throw new InvalidOperationException(
                                                                         "The actual classic console policy is not constructed.");

        private void ConstructSourceClassicConsolePolicy()
        {
            if (sourceClassicConsolePolicy != null)
                throw new InvalidOperationException("The actual classic console policy is already constructed.");
            sourceClassicConsolePolicy = SourceProfile == GameProfile.Original
                ? new OriginalClassicConsolePolicy()
                : new Celeste.Everest.Minigames.CelesteClassic.Emulation.EverestClassicConsolePolicy(this);
        }
    }
}
