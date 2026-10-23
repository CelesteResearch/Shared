using System.Collections.Generic;

namespace Celeste.Everest.UI.SoundTest
{
    public sealed class EverestSoundTestEvent
    {
        public string Path;
        public IReadOnlyList<EverestSoundTestParameter> Parameters;
    }
}
