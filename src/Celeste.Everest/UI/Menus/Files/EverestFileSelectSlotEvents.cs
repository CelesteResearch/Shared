using System.Collections.Generic;
using Celeste.Core.Scheduling;
using Celeste.Everest.Modules.Persistence;
using Celeste.Everest.Modules.Runtime;

namespace Celeste.Everest.UI.Menus.Files
{
    public sealed class EverestFileSelectSlotEvents
    {
        private readonly ISourceEngineContext engine;

        public EverestFileSelectSlotEvents(ISourceEngineContext engine)
        {
            this.engine = engine;
        }

        public delegate void CreateButtonsHandler(List<EverestFileSelectSlotState.Button> buttons,
            EverestFileSelectSlotState slot, EverestModuleSaveData modSaveData, bool fileExists);

        public event CreateButtonsHandler OnCreateButtons;

        public void HandleCreateButtons(List<EverestFileSelectSlotState.Button> buttons,
            EverestFileSelectSlotState slot, bool fileExists)
        {
            if (OnCreateButtons == null) return;
            var invocationList = OnCreateButtons.GetInvocationList();
            foreach (var handler in invocationList)
            {
                var module = ((ISourceEverestModulesEnvironment)engine).Modules.Find(candidate =>
                    candidate.GetType().Assembly == handler.Method.DeclaringType.Assembly);
                EverestModuleSaveData save = null;
                if (module != null) save = module._SaveData;
                handler.DynamicInvoke(buttons, slot, save, fileExists);
            }
        }
    }
}
