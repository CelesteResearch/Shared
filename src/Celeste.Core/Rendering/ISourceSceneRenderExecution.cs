namespace Celeste.Core.Rendering
{
    public interface ISourceSceneRenderExecution
    {
        void BeforeRender();
        void Render();
        void AfterRender();
    }
}
