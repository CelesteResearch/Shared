using Celeste.Game.Credits;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : IOriginalCreditsProcessEnvironment
    {
        private readonly OriginalCreditsProcessState sourceCreditsProcess = new();

        public OriginalCreditsProcessState CreditsProcess => sourceCreditsProcess;
    }
}
