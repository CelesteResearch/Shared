using System;
using System.IO;
using Celeste.Audio.Fmod.Banks;
using Celeste.Audio.Fmod.Interop;
using Celeste.Game.Audio.Runtime;

namespace Celeste.Game.Audio.Banks
{
    public class OriginalAudioBanks
    {
        private readonly OriginalGameAudioSession audio;
        public FmodBankReference Master, Music, Sfxs, UI, DlcMusic, DlcSfxs;

        public OriginalAudioBanks(OriginalGameAudioSession actualAudio)
        {
            audio = actualAudio ?? throw new ArgumentNullException(nameof(actualAudio));
        }

        public virtual FmodBankReference Load(string contentDirectory, string name, bool loadStrings)
        {
            var path = Path.Combine(contentDirectory, "FMOD", "Desktop", name);
            Check(audio.Runtime.LoadSourceBankNative(path + ".bank", out var bank));
            bank.LoadSampleDataNative();
            if (loadStrings) Check(audio.Runtime.LoadSourceBankNative(path + ".strings.bank", out _));
            return bank;
        }

        private static void Check(FmodResult result)
        {
            if (result != FmodResult.OK) throw new Exception("FMOD Failed: " + result);
        }
    }
}
