namespace Celeste.Game.Save.Runtime
{
    public interface IOriginalSaveInitializationEnvironment
    {
        IOriginalSaveInitializationPolicy SaveInitialization { get; }
        IOriginalSaveInitializationServices SaveInitializationServices { get; }
    }
}
