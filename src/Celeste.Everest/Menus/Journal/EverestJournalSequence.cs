using Celeste.Game.Execution.Areas;
using Celeste.Everest.Content.Maps.Registry;
using System.Collections;
using Celeste.Core.Scheduling;
using Celeste.Everest.Runtime.Events;
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
            IEnumerator orig = base.Enter(from);
            bool flag = !orig.MoveNext();
            object obj = flag ? null : orig.Current;
            ((IEverestGameEventsEnvironment)engine).GameEvents.JournalEnter(this, from);
            int num = 0;
            foreach (OuiJournalPage page in Pages)
                page.PageIndex = num++;
            if (!flag)
            {
                yield return obj;
                while (orig.MoveNext())
                    yield return orig.Current;
            }
        }

        public override bool GetAreaInterlude(IOriginalAreaData area) =>
            EverestAreaSafeQueries.GetInterlude(engine, area);

        public override bool GetAreaIsFinal(IOriginalAreaData area) => EverestAreaSafeQueries.GetIsFinal(engine, area);
    }
}
