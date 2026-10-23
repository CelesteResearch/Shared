using Celeste.Core.Rendering;
using Celeste.Simulation.Runtime.Session;

namespace Celeste.Game.Chapters.Flow
{
    public interface IOriginalAreaCompleteInfoHooksEnvironment
    {
        void AfterSourceAreaCompleteInfoInitialized(bool pieScreen, ChapterCompletionSession session);
        void AfterSourceCS08EndingRendered(ISourceRenderContext context, object owner, float versionAlpha);
        void AfterSourceAreaCompleteInfoRendered(ISourceRenderContext context, object owner, float ease);
    }
}
