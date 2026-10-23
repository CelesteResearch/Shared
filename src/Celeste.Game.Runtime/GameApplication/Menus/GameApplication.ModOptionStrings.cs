using Celeste.Everest.UI.Settings;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : IEverestModOptionStringEnvironment
    {
        private readonly EverestModOptionStringProcessState modOptionStringProcess = new();

        public EverestModOptionStringProcessState ModOptionStringProcess => modOptionStringProcess;
    }
}
