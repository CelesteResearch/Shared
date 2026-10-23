using System;
using Celeste.Everest.Runtime;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : IEverestRestartEnvironment
    {
        private EverestRestartProcess sourceRestart;

        public EverestRestartProcess Restart => sourceRestart ??
                                                throw new InvalidOperationException(
                                                    "The installed restart process is not constructed.");

        internal void ConstructSourceInstalledRestart()
        {
            if (sourceRestart != null)
                throw new InvalidOperationException("The installed restart process is already constructed.");
            sourceRestart = new(this);
        }
    }
}
