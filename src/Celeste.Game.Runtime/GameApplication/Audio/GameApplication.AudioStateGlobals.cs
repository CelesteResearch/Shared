using System;
using Celeste.Game.Audio.State.Globals;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : IOriginalAudioStateGlobalsEnvironment
    {
        private OriginalAudioStateGlobals sourceAudioStateGlobals;

        public OriginalAudioStateGlobals AudioStateGlobals => sourceAudioStateGlobals ??
                                                              throw new InvalidOperationException(
                                                                  "The actual audio state globals have not been published.");

        public void ConstructSourceAudioStateGlobals()
        {
            if (sourceAudioStateGlobals != null)
                throw new InvalidOperationException("The actual audio state globals are already published.");
            sourceAudioStateGlobals = new OriginalAudioStateGlobals();
        }
    }
}
