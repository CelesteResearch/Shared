using Celeste.Core.Scheduling;
using Celeste.Game.Menus.Overworld;
using Celeste.Everest.UI.ModOptions;

namespace Celeste.Everest.UI.SoundTest
{
// Entire installed OverworldLoaderToSoundTest source, with same source scene allocation.
    public class EverestOverworldLoaderToSoundTest : OverworldLoaderSequence
    {
        public EverestOverworldLoaderToSoundTest(ISourceEngineContext engine) : base(engine,
            OverworldStartMode.Titlescreen)
        {
        }

        public override void End()
        {
            base.End();
            ((IEverestModOptionsEnvironment)EngineContext).EverestUI.ModOptionsInstance.Overworld
                .Goto<EverestSoundTestState>();
        }
    }
}
