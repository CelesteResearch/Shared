namespace Celeste.Game.Save.Runtime
{
    public interface IOriginalSaveTimeEnvironment
    {
        IOriginalSaveTimePolicy SaveTime { get; }
    }
}
