namespace Celeste.Core.Scheduling
{
    public interface ISourceSceneClock : ISourceSceneTime
    {
        float RawTimeActive { get; }
    }
}
