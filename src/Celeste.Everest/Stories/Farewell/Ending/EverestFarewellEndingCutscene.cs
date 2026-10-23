using System.Collections;
using Celeste.Core.Scheduling;
using Celeste.Everest.Chapters.Flow;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Stories.Farewell.Ending;
using Player = Celeste.Simulation.RoomPlayerSession;

namespace Celeste.Everest.Stories.Farewell.Ending
{
    public class EverestFarewellEndingCutscene : OriginalFarewellEndingCutscene
    {
        public EverestFarewellEndingCutscene(ISourceEngineContext engine, Player player) : base(engine, player)
        {
        }

        protected override IEnumerator EndingRoutine()
        {
            ((EverestAreaCompleteInfoState)Info).InitializeInstalled(false,
                (Scene as OriginalLevelSceneRoot)?.Session);
            var orig = base.EndingRoutine();
            while (orig.MoveNext())
                yield return orig.Current;
            ((EverestAreaCompleteInfoState)Info).DisposeInstalled();
        }
    }
}
