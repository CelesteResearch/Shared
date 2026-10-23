using System.IO;
using Celeste.Core.Scheduling;
using Celeste.Everest.Content.Registry;
using Celeste.Everest.Content.Types.Text;
using Celeste.Game.Minigames.CelesteClassic.Emulation;

namespace Celeste.Everest.Minigames.CelesteClassic.Emulation
{
    public sealed class EverestClassicConsolePolicy : IOriginalClassicConsolePolicy
    {
        private readonly ISourceEngineContext engine;

        public EverestClassicConsolePolicy(ISourceEngineContext engine)
        {
            this.engine = engine;
        }

        public void AfterConstructor(ClassicConsoleRuntime emulator)
        {
            if (!((IEverestContentRegistryEnvironment)engine).SourceContentRegistry.TryGet<AssetTypeText>(
                    "Pico8Tilemap",
                    out var metadata)) return;
            using (var reader = new StreamReader(metadata.Stream))
                emulator.InstallTilemapText(reader.ReadToEnd());
        }
    }
}
