using System;
using Celeste.Scene.Components.Oscillation;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : ISourceWigglerPoolScope
    {
        private WigglerComponentPool sourceWigglerPool;

        public WigglerComponentPool WigglerPool => sourceWigglerPool ??
                                                   throw new InvalidOperationException(
                                                       "The actual Wiggler pool is not constructed.");

        public void ConstructSourceWigglerPool()
        {
            if (sourceWigglerPool != null)
                throw new InvalidOperationException("The actual Wiggler pool is already constructed.");
            sourceWigglerPool = new(engine);
        }
    }
}
