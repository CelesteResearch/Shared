using System;
using System.Xml;
using Celeste.Everest.Presentation.Completion;
using Celeste.Game.Presentation.Completion;
using Celeste.Game.Profiles;
using Celeste.Graphics.Content.Atlas;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : IOriginalCompleteRendererConstruction
    {
        CompleteRendererState IOriginalCompleteRendererConstruction.CreateCompleteRenderer(XmlElement xml,
            AtlasData atlas, float delay, Action onDoneSlide) => SourceProfile == GameProfile.Original
            ? new CompleteRendererState(this, xml, atlas, delay, onDoneSlide)
            : new EverestCompleteRendererState(this, xml, atlas, delay, onDoneSlide);
    }
}
