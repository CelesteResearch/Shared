namespace Celeste.Game.Save.Runtime
{
    public interface IOriginalSaveProgressionEnvironment
    {
        IOriginalSaveProgressionPolicy SaveProgression { get; }
    }
}
