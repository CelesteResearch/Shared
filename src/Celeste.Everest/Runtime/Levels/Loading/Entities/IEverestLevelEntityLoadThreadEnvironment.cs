namespace Celeste.Everest.Runtime.Levels.Loading.Entities
{
    public interface IEverestLevelEntityLoadThreadEnvironment
    {
        EverestLevelEntityLoadThreadState CurrentEntityLoadState { get; }
    }
}
