using Celeste.Game.Content.Dialogs;
using Celeste.Game.Execution.Graphics;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : IOriginalFancyTextProcess
    {
        OriginalGameGraphicsResources IOriginalFancyTextProcess.Graphics => GraphicsResources;
    }
}
