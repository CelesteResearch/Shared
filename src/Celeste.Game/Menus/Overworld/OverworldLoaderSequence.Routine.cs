using System.Collections;
using Celeste.Game.Content.Dialogs;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Save.Runtime;
using Celeste.Game.Settings;
using Celeste.Simulation.Presentation.Hud.Saving;
using Celeste.Simulation.Runtime.Session;

namespace Celeste.Game.Menus.Overworld
{
    public partial class OverworldLoaderSequence
    {
        protected IEnumerator Routine(ChapterCompletionSession session)
        {
            var process = (IOriginalGameplayProcess)EngineContext;
            var settings = ((ISettingsContext)EngineContext).Settings;
            if ((StartMode == OverworldStartMode.AreaComplete || StartMode == OverworldStartMode.AreaQuit)
                && session != null)
            {
                if (((IOriginalOverworldLoaderPostcardEnvironment)EngineContext).OverworldLoaderPostcards
                    .ShouldShowCSide(
                        session, EngineContext))
                    showUnlockCSidePostcard = true;
                if (!settings.VariantsUnlocked && process.SaveContext.CurrentSave != null
                                               && ((IOriginalOverworldLoaderPostcardEnvironment)EngineContext)
                                               .OverworldLoaderPostcards
                                               .GetVariantHeartCount(process.SaveContext.CurrentSave, EngineContext) >=
                                               24)
                    showVariantPostcard = true;
            }

            if (showUnlockCSidePostcard)
            {
                yield return 3f;
                postcard = new(EngineContext,
                    ((IOriginalGameTextEnvironment)EngineContext).Text.Dialog.Get("POSTCARD_CSIDES"),
                    "event:/ui/main/postcard_csides_in", "event:/ui/main/postcard_csides_out");
                SourceScene.QueueSourceEntity(postcard);
                yield return postcard.DisplayRoutine();
            }

            while (!loaded)
                yield return null;
            if (showVariantPostcard)
            {
                yield return 3f;
                settings.VariantsUnlocked = true;
                postcard = new(EngineContext,
                    ((IOriginalGameTextEnvironment)EngineContext).Text.Dialog.Get("POSTCARD_VARIANTS"),
                    "event:/new_content/ui/postcard_variants_in", "event:/new_content/ui/postcard_variants_out");
                SourceScene.QueueSourceEntity(postcard);
                yield return postcard.DisplayRoutine();
                var userIO = ((IOriginalUserIOEnvironment)EngineContext).UserIO;
                userIO.SaveHandler(false, true);
                while (userIO.Saving)
                    yield return null;
                while (((ISaveLoadIconEnvironment)EngineContext).SaveLoadIconProcess.Instance != null)
                    yield return null;
            }

            EngineContext.Frame.Scenes.NextScene = overworld;
        }
    }
}
