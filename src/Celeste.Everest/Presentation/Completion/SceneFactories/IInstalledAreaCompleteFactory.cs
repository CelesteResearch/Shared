using System.Xml;
using Celeste.Everest.Content.Maps.Metadata.Completion;
using Celeste.Game.Chapters.Flow;
using Celeste.Game.Presentation.Environment;
using Celeste.Simulation.Runtime.Session;
using Celeste.Graphics.Content.Atlas;

namespace Celeste.Everest.Presentation.Completion.SceneFactories
{
    public interface IInstalledAreaCompleteFactory : IOriginalAreaCompleteFactory
    {
        AreaCompleteSequence CreateAreaComplete(ChapterCompletionSession session,
            XmlElement xml, AtlasData atlas, HiresSnowState snow, MapMetaCompleteScreen metadata);
    }
}
