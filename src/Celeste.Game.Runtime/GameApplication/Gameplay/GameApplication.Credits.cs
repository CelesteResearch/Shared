using Celeste.Game.Credits;
using JetBrains.Annotations;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : IOriginalCreditsProcessEnvironment
    {
        [UsedImplicitly(ImplicitUseKindFlags.Access)]
        private readonly OriginalCreditsProcessState sourceCreditsProcess = new();

        public OriginalCreditsProcessState CreditsProcess => sourceCreditsProcess;
    }
}
