using Celeste.Core.Threading;

namespace Celeste.Everest.Runtime.Levels.Loading.Entities
{
    public sealed class EverestLevelEntityLoadInitializationFactory :
        ISourceTypeInitializationFactory<EverestLevelEntityLoadProcess>
    {
        private readonly EverestLevelEntityLoadThreadEnvironment threads =
            new EverestLevelEntityLoadThreadEnvironment();

        public EverestLevelEntityLoadProcess Allocate()
            => new EverestLevelEntityLoadProcess(threads);

        public void Initialize(EverestLevelEntityLoadProcess instance)
            => instance.InitializeSourceFields();
    }
}
