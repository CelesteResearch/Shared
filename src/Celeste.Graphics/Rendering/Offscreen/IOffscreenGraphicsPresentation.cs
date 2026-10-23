namespace Celeste.Graphics.Rendering.Offscreen;

public interface IOffscreenGraphicsPresentation
{
    void InvalidateOutput();
    void PrepareDraw();
    void PresentCompleted();
}
