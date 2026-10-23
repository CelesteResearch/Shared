using Celeste.Everest.Diagnostics.Logging;
using Celeste.Game.Chapters.Flow;

namespace Celeste.Everest.Content.Tiles.Autotiling
{
    public interface IEverestAutotilerSourceEnvironment
    {
        LevelEnterStaticState LevelEnterState { get; }
        EverestLoggerProcess Logger { get; }
    }
}
