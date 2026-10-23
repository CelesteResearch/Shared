using System;
using System.Xml;
using Celeste.Core.Scheduling;
using Celeste.Game.Presentation.Completion;
using Celeste.Graphics.Content.Atlas;
using Celeste.Simulation.Runtime.Session;

namespace Celeste.Game.Chapters.Flow
{
    public interface IInstalledAreaCompleteConstruction
    {
        string GetCustomCompleteScreenTitle(ChapterCompletionSession session);

        CompleteRendererState CreateCompleteRenderer(ISourceEngineContext engine, XmlElement xml,
            AtlasData atlas, float delay, Action onDoneSlide);
    }
}
