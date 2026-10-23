using Celeste.Game.Chapters.Flow;
using Celeste.Everest.Diagnostics.Logging;

namespace Celeste.Everest.Content.Tiles.Autotiling
{
    public interface IEverestAutotilerSourceEnvironment
    {
        LevelEnterStaticState LevelEnterState { get; }
        EverestLoggerProcess Logger { get; }
    }
}
