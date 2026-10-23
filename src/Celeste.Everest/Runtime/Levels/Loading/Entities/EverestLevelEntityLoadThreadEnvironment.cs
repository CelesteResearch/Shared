using Celeste.Core.Threading;

namespace Celeste.Everest.Runtime.Levels.Loading.Entities
{
    public sealed class EverestLevelEntityLoadThreadEnvironment : IEverestLevelEntityLoadThreadEnvironment
    {
        private readonly SourceThreadLocal<EverestLevelEntityLoadThreadState> storage =
            new SourceThreadLocal<EverestLevelEntityLoadThreadState>(() => new EverestLevelEntityLoadThreadState());

        public EverestLevelEntityLoadThreadState CurrentEntityLoadState => storage.Value;
    }
}
