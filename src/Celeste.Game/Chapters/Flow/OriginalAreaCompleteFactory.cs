using System.Xml;
using Celeste.Core.Scheduling;
using Celeste.Game.Presentation.Environment;
using Celeste.Graphics.Content.Atlas;
using Celeste.Simulation.Runtime.Session;

namespace Celeste.Game.Chapters.Flow
{
    public sealed class OriginalAreaCompleteFactory : IOriginalAreaCompleteFactory
    {
        private readonly ISourceEngineContext engine;

        public OriginalAreaCompleteFactory(ISourceEngineContext engine)
        {
            this.engine = engine;
        }

        public AreaCompleteSequence CreateAreaComplete(ChapterCompletionSession session,
            XmlElement xml, AtlasData atlas, HiresSnowState snow)
        {
            return new(session, xml, atlas, snow, engine);
        }
    }
}
