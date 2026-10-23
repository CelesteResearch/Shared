using System;
using System.Xml;
using Celeste.Graphics.Content.Atlas;

namespace Celeste.Game.Presentation.Completion
{
    public interface IOriginalCompleteRendererConstruction
    {
        CompleteRendererState CreateCompleteRenderer(XmlElement xml, AtlasData atlas, float delay,
            Action onDoneSlide = null);
    }
}
