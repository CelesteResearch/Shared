using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Numerics;
using System.Threading.Tasks;
using Celeste.Core.Scheduling;
using Celeste.Core.Rendering;
using Celeste.Core.Mathematics.Easing;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Audio.Runtime;
using Celeste.Game.Content.Dialogs;
using Celeste.Game.Controls.Source;
using Celeste.Game.Menus.Overworld;
using Celeste.Game.Execution.Scenes;
using Celeste.Scene.Tracking;
using Celeste.Graphics.Display;
using Celeste.Graphics.Rendering;
using Celeste.Simulation.UI.Menus.Text;
using Celeste.Simulation.Presentation.Scene.Transitions;
using Celeste.Everest.UI.Settings;
using Celeste.Everest.UI.ModOptions;
using Celeste.Everest.UI.Shutdown;
using Celeste.Everest.Modules.Runtime;
using Celeste.Everest.Modules.Updating;
using Celeste.Everest.Modules.Dependencies;
using Celeste.Everest.Runtime;
using Celeste.Everest.Runtime.Startup;
using Celeste.Everest.Diagnostics.Logging;

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
                if (_button == null)
                {
                    _button = buttonGenerator();
                }

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
