using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Simulation.Rendering;

namespace Celeste.Simulation.UI.Menus.Text
{
    public sealed class TextMenuResources
    {
        public readonly global::Celeste.Core.Scheduling.ISourceEngineContext EngineContext;

        public TextMenuResources(global::Celeste.Core.Scheduling.ISourceEngineContext engine)
            => EngineContext = engine ?? throw new ArgumentNullException(nameof(engine));

        public Func<global::Celeste.Localization.Languages.DialogLanguage,
            global::Celeste.Graphics.Content.Atlas.AtlasEntry> LanguageIcon;

        public Func<string, global::Celeste.Graphics.Content.Atlas.AtlasEntry> Gui;
        public Func<string, bool> HasGui;
        public Func<int, global::Celeste.Graphics.Content.Atlas.AtlasEntry> GuiKey, GuiControllerButton;
    }
}
