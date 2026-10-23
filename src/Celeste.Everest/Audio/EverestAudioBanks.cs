using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using Celeste.Audio.Fmod.Banks;
using Celeste.Audio.Fmod.Interop;
using Celeste.Core.Scheduling;
using Celeste.Everest.Content.Assets;
using Celeste.Everest.Content.Registry;
using Celeste.Everest.Content.Types.Audio;
using Celeste.Everest.Runtime;
using Celeste.Game.Audio.Banks;
using Celeste.Game.Execution;

namespace Celeste.Everest.Audio
{
    public sealed class EverestAudioBanks : OriginalAudioBanks
    {
        private readonly EverestGameAudioSession audio;
        private readonly ISourceEngineContext engine;
        public Dictionary<string, FmodBankReference> Banks = new();

        public Dictionary<EverestContentAsset, FmodBankReference> ModCache = new();

        public static readonly int SizeOfBankInfo = Marshal.SizeOf(typeof(FmodBankInfo));

        public EverestAudioBanks(EverestGameAudioSession audio, ISourceEngineContext engine) : base(audio)
        {
            this.audio = audio;
            this.engine = engine;
        }

        public override FmodBankReference Load(string contentDirectory, string name, bool loadStrings)
        {
            if (((IEverestHeadlessEnvironment)engine).IsHeadless)
                return new(IntPtr.Zero, audio.Device.StudioDeviceIO);
            if (Banks == null) Banks = new();
            if (Banks.TryGetValue(name, out var value)) return value;
            var content = ((IEverestContentRegistryEnvironment)engine).SourceContentRegistry;
            if (content.TryGet<AssetTypeBank>("Audio/" + name, out var metadata)) value = audio.IngestBank(metadata);
            else
                audio.Runtime
                    .LoadSourceBankNative(
                        Path.Combine(EngineRuntime.ContentDirectory,
                            "FMOD", "Desktop", name + ".bank"), out value).CheckInstalledFmodResult();
            if (loadStrings)
            {
                if (content.TryGet<AssetTypeBank>("Audio/" + name + ".strings", out metadata))
                    audio.IngestBank(metadata);
                else
                    audio.Runtime
                        .LoadSourceBankNative(
                            Path.Combine(EngineRuntime.ContentDirectory,
                                "FMOD", "Desktop", name + ".strings.bank"), out _).CheckInstalledFmodResult();
            }

            return Banks[name] = value;
        }
    }
}
