namespace Celeste.Game.Save.Runtime
{
    public interface IOriginalSaveCheckpointEnvironment
    {
        IOriginalSaveCheckpointQueries SaveCheckpoints { get; }
    }
}
