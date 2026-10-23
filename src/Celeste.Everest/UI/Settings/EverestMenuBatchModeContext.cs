using System;
using Celeste.Simulation.UI.Menus.Text;

namespace Celeste.Everest.UI.Settings
{
    public class EverestMenuBatchModeContext : IDisposable
    {
        private TextMenuPresentation menu;

        public EverestMenuBatchModeContext(TextMenuPresentation menu)
        {
            menu.BatchMode = true;
            this.menu = menu;
        }

        public void Dispose()
        {
            menu.BatchMode = false;
        }
    }
}
