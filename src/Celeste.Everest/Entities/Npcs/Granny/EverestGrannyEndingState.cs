using System.Numerics;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Content.Dialogs;
using Celeste.Game.Entities.Npcs.Granny;

namespace Celeste.Everest.Entities.Npcs.Granny
{
    public class EverestGrannyEndingState : OriginalGrannyEndingState
    {
        public EverestGrannyEndingState(ISourceEngineContext engine, EntityData data, Vector2 offset,
            bool ch9EasterEgg = false) : base(engine, data, offset, ch9EasterEgg)
        {
        }

        protected override string GetDebugModeDialog(string vanillaDialog)
        {
            if (((IOriginalGameTextEnvironment)Engine).Text.Dialog.Has("CH10_GRANNY_EASTEREGG"))
                return ((IOriginalGameTextEnvironment)Engine).Text.Dialog.Get("CH10_GRANNY_EASTEREGG");
            return vanillaDialog;
        }
    }
}
