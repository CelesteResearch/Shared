using System;
using Celeste.Everest.Modules.Dependencies;
using Celeste.Everest.Modules.Runtime;
using Celeste.Simulation.UI.Menus.Text;

namespace Celeste.Everest.UI.Updating.Mods
{
    internal class EverestModUpdateHolder
    {
        public EverestModUpdateInfo update;

        public EverestModuleMetadata metadata;

        public Func<TextMenuPresentation.Button> buttonGenerator;

        private TextMenuPresentation.Button _button;

        public TextMenuPresentation.Button button
        {
            get
            {
                if (_button == null) _button = buttonGenerator();

                return _button;
            }
        }

        public EverestModUpdateHolder(EverestModUpdateInfo update, EverestModuleMetadata metadata,
            Func<TextMenuPresentation.Button> buttonGenerator)
        {
            this.update = update;
            this.metadata = metadata;
            this.buttonGenerator = buttonGenerator;
        }

        public void RemoveButton()
        {
            _button = null;
        }
    }
}
