using System;
using Celeste.Everest.Runtime.Boot;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : IEverestBootProcessEnvironment
    {
        private EverestBootProcess sourceBootProcess;

        public EverestBootProcess BootProcess => sourceBootProcess ??
                                                 throw new InvalidOperationException(
                                                     "The actual source Boot process is not constructed.");

        internal void ConstructSourceInstalledBootProcess()
        {
            if (sourceBootProcess != null)
                throw new InvalidOperationException("The actual source Boot process is already constructed.");
            sourceBootProcess = new(PhysicalIO.BootProcessIO);
        }
    }
}
