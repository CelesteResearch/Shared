using Celeste.Everest.Runtime.Chapters.Flow;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : IEverestLevelEnterEventsEnvironment
    {
        public EverestLevelEnterEvents LevelEnterEvents { get; } = new();
    }
}
