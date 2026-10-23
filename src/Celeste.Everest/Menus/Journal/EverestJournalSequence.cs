using System.Collections;
using Celeste.Core.Scheduling;
using Celeste.Everest.Content.Maps.Registry;
using Celeste.Everest.Runtime.Events;
using Celeste.Game.Execution.Areas;
using Celeste.Game.Menus.Journal;
using Celeste.Game.Menus.Overworld;

namespace Celeste.Everest.Menus.Journal
{
    public sealed class EverestJournalSequence : OuiJournalSequence
    {
        public EverestJournalSequence(ISourceEngineContext engine) : base(engine)
        {
        }

        public override IEnumerator Enter(OuiState from)
        {
            var orig = base.Enter(from);
            var flag = !orig.MoveNext();
            var obj = flag ? null : orig.Current;
            ((IEverestGameEventsEnvironment)engine).GameEvents.JournalEnter(this, from);
            var num = 0;
            foreach (var page in Pages)
                page.PageIndex = num++;
            if (!flag)
            {
                yield return obj;
                while (orig.MoveNext())
                    yield return orig.Current;
            }
        }

        public override bool GetAreaInterlude(IOriginalAreaData area)
        {
            return EverestAreaSafeQueries.GetInterlude(engine, area);
        }

        public override bool GetAreaIsFinal(IOriginalAreaData area)
        {
            return EverestAreaSafeQueries.GetIsFinal(engine, area);
        }
    }
}
