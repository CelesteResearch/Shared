using Celeste.Game.Execution.Areas;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : IOriginalAreaInterludeEnvironment
    {
        IOriginalAreaInterludePolicy IOriginalAreaInterludeEnvironment.AreaInterlude =>
            (IOriginalAreaInterludePolicy)SaveCounters;
    }
}
