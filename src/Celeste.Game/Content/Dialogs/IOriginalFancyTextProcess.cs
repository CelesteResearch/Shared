using Celeste.Core.Randomness;
using Celeste.Game.Execution.Graphics;
using Celeste.Game.Execution.Processes;

namespace Celeste.Game.Content.Dialogs
{
    public interface IOriginalFancyTextProcess : IOriginalGameTextEnvironment,
        ISourceRandomEnvironment, IOriginalGameplayProcess
    {
        OriginalGameGraphicsResources Graphics { get; }
    }
}
