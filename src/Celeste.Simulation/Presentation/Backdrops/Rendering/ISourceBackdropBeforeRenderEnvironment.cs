namespace Celeste.Simulation.Presentation.Backdrops.Rendering
{
    public interface ISourceBackdropBeforeRenderEnvironment
    {
        ISourceBackdropBeforeRenderPolicy BackdropBeforeRender { get; }
    }
}
