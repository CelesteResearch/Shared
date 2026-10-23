namespace Celeste.Core.Rendering.Renderers
{
    public interface ISceneRenderer
    {
        bool Visible { get; }
        void Update(object scene);
        void BeforeRender(object scene);
        void Render(object scene);
        void AfterRender(object scene);
    }
}
