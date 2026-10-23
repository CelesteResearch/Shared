using System.Xml;
using Celeste.Game.Presentation.Environment;
using Celeste.Simulation.Runtime.Session;
using Celeste.Graphics.Content.Atlas;

namespace Celeste.Game.Chapters.Flow
{
    public interface IOriginalAreaCompleteFactory
    {
        AreaCompleteSequence CreateAreaComplete(ChapterCompletionSession session,
            XmlElement xml, AtlasData atlas, HiresSnowState snow);
    }
}
