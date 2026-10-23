using Celeste.Graphics.Rendering.Devices;

namespace Celeste.Framework.Startup
{
    public interface ISourceGameBeforeLoopPolicy
    {
        void AfterOriginalBeforeLoop(SourceGameWindow window);
    }
}
