using System.Collections.Generic;
using System.IO;
using Celeste.Audio.Fmod.Banks;

namespace Celeste.Game.Audio.Banks
{
    public static class OriginalAudioBankProfile
    {
        public static IEnumerable<FmodBankLoadRequest> Create(string directory)
        {
            yield return new(Path.Combine(directory, "Master Bank.bank"), true);
            yield return new(Path.Combine(directory, "Master Bank.strings.bank"), false);
            yield return new(Path.Combine(directory, "music.bank"), true);
            yield return new(Path.Combine(directory, "sfx.bank"), true);
            yield return new(Path.Combine(directory, "ui.bank"), true);
            yield return new(Path.Combine(directory, "dlc_music.bank"), true);
            yield return new(Path.Combine(directory, "dlc_sfx.bank"), true);
        }
    }
}
