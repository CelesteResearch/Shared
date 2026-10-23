using Celeste.Core.Threading;

namespace Celeste.Everest.Runtime.Levels.Loading.Entities
{
    public sealed class EverestLevelEntityLoadThreadEnvironment : IEverestLevelEntityLoadThreadEnvironment
    {
        private readonly SourceThreadLocal<EverestLevelEntityLoadThreadState> storage =
            new(() => new());

        public EverestLevelEntityLoadThreadState CurrentEntityLoadState => storage.Value;
    }
}
