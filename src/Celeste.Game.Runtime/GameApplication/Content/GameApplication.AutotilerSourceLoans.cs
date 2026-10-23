using Celeste.Everest.Content.Tiles.Autotiling;
using Celeste.Everest.Diagnostics.Logging;
using Celeste.Game.Chapters.Flow;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : IEverestAutotilerSourceEnvironment
    {
        LevelEnterStaticState IEverestAutotilerSourceEnvironment.LevelEnterState => LevelEnterStatics;

        EverestLoggerProcess IEverestAutotilerSourceEnvironment.Logger =>
            ((IEverestLoggerProcessEnvironment)this).Logger;
    }
}
