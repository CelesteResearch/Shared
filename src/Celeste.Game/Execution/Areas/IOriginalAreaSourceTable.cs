using System.Collections.Generic;

namespace Celeste.Game.Execution.Areas
{
    public interface IOriginalAreaSourceTable
    {
        IReadOnlyList<IOriginalAreaData> Areas { get; }
    }
}
