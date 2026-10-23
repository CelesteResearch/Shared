using System;
using System.Xml;
using Celeste.Core.Scheduling;
using Celeste.Everest.Content.Maps.Metadata.Completion;
using Celeste.Everest.Presentation.Completion;
using Celeste.Everest.Presentation.Completion.SceneFactories;
using Celeste.Everest.Presentation.Completion.Titles;
using Celeste.Game.Chapters.Flow;
using Celeste.Game.Content.Dialogs;
using Celeste.Game.Execution.Areas;
using Celeste.Game.Presentation.Completion;
using Celeste.Game.Presentation.Environment;
using Celeste.Graphics.Content.Atlas;
using Celeste.Simulation.Runtime.Session;

namespace Celeste.Everest.Chapters.Flow
{
    public sealed class EverestAreaCompleteFactory : IInstalledAreaCompleteFactory
    {
        private readonly ISourceEngineContext engine;
        private readonly IOriginalAreaDataResolver areas;
        private readonly OriginalGameTextProcess text;

        public EverestAreaCompleteFactory(ISourceEngineContext engine, IOriginalAreaDataResolver areas,
            OriginalGameTextProcess text)
        {
            this.engine = engine;
            this.areas = areas;
            this.text = text;
        }

        private sealed class Construction : IInstalledAreaCompleteConstruction
        {
            private readonly MapMetaCompleteScreen meta;
            private readonly IOriginalAreaDataResolver areas;
            private readonly OriginalGameTextProcess text;

            public Construction(MapMetaCompleteScreen meta, IOriginalAreaDataResolver areas,
                OriginalGameTextProcess text)
            {
                this.meta = meta;
                this.areas = areas;
                this.text = text;
            }

            public string GetCustomCompleteScreenTitle(ChapterCompletionSession session)
            {
                return EverestAreaCompleteTitle.GetCustomTitle(session, areas, text);
            }

            public CompleteRendererState CreateCompleteRenderer(ISourceEngineContext engine, XmlElement xml,
                AtlasData atlas, float delay, Action onDoneSlide)
            {
                return new EverestCompleteRendererState(engine, xml, atlas, delay, onDoneSlide, meta);
            }
        }

        public AreaCompleteSequence CreateAreaComplete(ChapterCompletionSession session, XmlElement xml,
            AtlasData atlas, HiresSnowState snow)
        {
            return CreateAreaComplete(session, xml, atlas, snow, null);
        }

        public AreaCompleteSequence CreateAreaComplete(ChapterCompletionSession session, XmlElement xml,
            AtlasData atlas, HiresSnowState snow, MapMetaCompleteScreen metadata)
        {
            return new EverestAreaCompleteSequence(session, xml, atlas, snow, engine,
                new Construction(metadata, areas, text));
        }
    }
}
