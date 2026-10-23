namespace Celeste.Game.Save.Runtime
{
    public interface IOriginalSavePreparationEnvironment
    {
        IOriginalSavePreparationPolicy SavePreparation { get; }
    }
}
