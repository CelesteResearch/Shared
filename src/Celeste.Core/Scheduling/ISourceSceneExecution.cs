namespace Celeste.Core.Scheduling
{
    public interface ISourceSceneExecution
    {
        void Begin();
        void End();
        void BeforeUpdate();
        void Update();
        void AfterUpdate();
    }
}
