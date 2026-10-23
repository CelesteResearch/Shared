namespace Celeste.Game.Save.Runtime
{
    public interface IOriginalSaveInitializationServices
    {
        string CleanDialog(string key);
        void SetInputInversion(bool mirrorMode);
    }
}
