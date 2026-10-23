using System;

namespace Celeste.Audio.Fmod.Banks
{
    public readonly struct FmodBankLoadRequest
    {
        public readonly string Path;
        public readonly bool LoadSamples;

        public FmodBankLoadRequest(string path, bool loadSamples)
        {
            Path = path ?? throw new ArgumentNullException(nameof(path));
            LoadSamples = loadSamples;
        }
    }
}
