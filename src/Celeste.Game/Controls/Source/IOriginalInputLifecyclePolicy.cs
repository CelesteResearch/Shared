namespace Celeste.Game.Controls.Source
{
    public interface IOriginalInputLifecyclePolicy
    {
        void AfterInitialize(OriginalGameInputProcess input);
        void AfterDeregister(OriginalGameInputProcess input);
    }
}
