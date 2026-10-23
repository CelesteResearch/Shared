using System.Collections;
using Celeste.Core.Scheduling;

namespace Celeste.Game.Menus.Files
{
    public interface IOriginalFileSlotFirstAreaPolicy
    {
        IEnumerator EnterFirstArea(FileSelectSequence fileSelect, ISourceEngineContext engine);
    }
}
