using Celeste.Everest.UI.Settings;
using JetBrains.Annotations;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : IEverestModOptionStringEnvironment
    {
        [UsedImplicitly(ImplicitUseKindFlags.Access)]
        private readonly EverestModOptionStringProcessState modOptionStringProcess = new();

        public EverestModOptionStringProcessState ModOptionStringProcess => modOptionStringProcess;
    }
}
