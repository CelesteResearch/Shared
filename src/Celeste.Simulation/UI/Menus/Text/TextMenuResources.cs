using System;
using Celeste.Core.Scheduling;
using Celeste.Graphics.Content.Atlas;
using Celeste.Localization.Languages;

namespace Celeste.Simulation.UI.Menus.Text
{
    public sealed class TextMenuResources
    {
        public readonly ISourceEngineContext EngineContext;

        public TextMenuResources(ISourceEngineContext engine)
        {
            EngineContext = engine ?? throw new ArgumentNullException(nameof(engine));
        }

        public Func<DialogLanguage,
            AtlasEntry> LanguageIcon;

        public Func<string, AtlasEntry> Gui;
        public Func<string, bool> HasGui;
        public Func<int, AtlasEntry> GuiKey, GuiControllerButton;
    }
}
