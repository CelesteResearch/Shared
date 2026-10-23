using System.Xml;
using Celeste.Core.Scheduling;
using Celeste.Game.Presentation.Environment;
using Celeste.Simulation.Runtime.Session;
using Celeste.Graphics.Content.Atlas;

namespace Celeste.Game.Chapters.Flow
{
    public sealed class OriginalAreaCompleteFactory : IOriginalAreaCompleteFactory
    {
        private readonly ISourceEngineContext engine;
        public OriginalAreaCompleteFactory(ISourceEngineContext engine) => this.engine = engine;

        public AreaCompleteSequence CreateAreaComplete(ChapterCompletionSession session,
            XmlElement xml, AtlasData atlas, HiresSnowState snow)
            => new AreaCompleteSequence(session, xml, atlas, snow, engine);
    }
}
