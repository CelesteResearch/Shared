using System.Linq;
using Celeste.Core.Scheduling;
using Celeste.Everest.Runtime.Events;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Menus.Pause;
using Celeste.Simulation.UI.Menus.Text;

namespace Celeste.Everest.Menus.Pause
{
    public sealed class EverestLevelPausePolicy : IOriginalLevelPausePolicy
    {
        // Installed PatchLevelCanPause discards get_Saving and substitutes false.
        public bool IsPauseBlockedBySaving(bool saving)
        {
            return false;
        }

        public void Pause(OriginalLevelSceneRoot level, int startIndex, bool minimal, bool quickReset)
        {
            level.PauseOriginalGame(startIndex, minimal, quickReset);
            if (level.Scheduler.GetToAdd().FirstOrDefault(e => e is TextMenuPresentation) is TextMenuPresentation
                textMenu)
            {
                textMenu.OnPause += Unpause;
                textMenu.OnESC += Unpause;
                if (!quickReset)
                {
                    textMenu.OnCancel += Unpause;
                    ((IEverestGameEventsEnvironment)level.EngineContext).GameEvents.CreatePauseMenuButtons(level,
                        textMenu,
                        minimal);
                }
            }

            ((IEverestGameEventsEnvironment)level.EngineContext).GameEvents.Pause(level, startIndex, minimal,
                quickReset);

            void Unpause()
            {
                ((IEverestGameEventsEnvironment)level.EngineContext).GameEvents.Unpause(level);
            }
        }

        public ReturnMapHintPresentation CreateReturnMapHint(ISourceEngineContext engine)
        {
            return new EverestReturnMapHintState(engine);
        }
    }
}
