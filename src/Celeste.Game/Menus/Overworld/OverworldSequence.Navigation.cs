using System.Collections;
using System.Runtime.CompilerServices;
using Celeste.Core.Scheduling;

namespace Celeste.Game.Menus.Overworld
{
    public partial class OverworldSequence
    {
        public T Goto<T>() where T : OuiState
        {
            T ui = GetUI<T>();
            if (ui != null)
                routineEntity.Components.Add(new SimulationCoroutine(EngineContext, GotoRoutine(ui)));
            return ui;
        }

        public bool IsCurrent<T>() where T : OuiState
        {
            if (Current != null)
                return Current is T;
            return Last is T;
        }

        public T GetUI<T>() where T : OuiState
        {
            OuiState ui = null;
            foreach (OuiState candidate in UIs)
                if (candidate is T)
                    ui = candidate;
            return ui as T;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public IEnumerator GotoRoutine(OuiState next)
        {
            while (Current == null)
                yield return null;
            transitioning = true;
            Next = next;
            Last = Current;
            Current = null;
            Last.Focused = false;
            yield return Last.Leave(next);
            if (next.Scene != null)
            {
                yield return next.Enter(Last);
                next.Focused = true;
                Current = next;
                transitioning = false;
            }

            Next = null;
        }
    }
}
