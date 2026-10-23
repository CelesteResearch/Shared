using System.Collections;
using Celeste.Everest.Content.Maps.Registry;
using Celeste.Everest.Diagnostics.Logging;
using Celeste.Game.Chapters.Flow;

namespace Celeste.Everest.Runtime.Chapters.Flow
{
    public sealed partial class EverestLevelEnterPolicy : IOriginalLevelEnterPolicy
    {
        private readonly IOriginalLevelEnterProcess process;
        public EverestLevelEnterPolicy(IOriginalLevelEnterProcess process) => this.process = process;

        // This is deliberately not an iterator: clearing the static source error
        // happens when LevelEnter's constructor calls Routine.
        public IEnumerator SelectRoutine(LevelEnterSequence scene)
        {
            if (process.LevelEnterStatics.ErrorMessage != null)
            {
                string message = process.LevelEnterStatics.ErrorMessage;
                process.LevelEnterStatics.ErrorMessage = null;
                return scene.ErrorRoutine(message);
            }

            if (process.AreaKeys.GetArea(process.AreaKeys.GetSessionArea(scene.Session)) == null)
            {
                ((IEverestLoggerProcessEnvironment)process).Logger.Log(
                    EverestLogLevel.Warn, "LevelEnter", "Failed to find map");
                return scene.ErrorRoutine(process.Text.Dialog.Get("postcard_levelgone")
                    .Replace("((player))", process.SaveContext.CurrentSave.Name)
                    .Replace("((sid))", process.AreaKeys.GetSID(process.AreaKeys.GetSessionArea(scene.Session))));
            }

            var area = (EverestArea)process.AreaKeys.GetArea(process.AreaKeys.GetSessionArea(scene.Session));
            var metadata = area.Metadata;
            string suffix = "";
            int mode = 0;
            if (scene.Session.Mode == 1)
            {
                suffix = "_b";
                mode = 1;
            }
            else if (scene.Session.Mode == 2)
            {
                suffix = "_c";
                mode = 2;
            }

            string name = area.Name + suffix + "_postcard";
            if (metadata != null && area.LevelSet != "Celeste" && process.Text.Dialog.Has(name) &&
                scene.Session.StartedFromBeginning && !scene.FromSaveData &&
                (!process.SaveCounters.GetAreasSafe(process.SaveContext.CurrentSave)[scene.Session.AreaID].Modes[mode]
                     .Completed ||
                 process.SaveContext.CurrentSave.DebugMode))
                return EnterWithPostcardRoutine(scene, process.Text.Dialog.Get(name), metadata.PostcardSoundID);
            return scene.OriginalRoutine();
        }

        private IEnumerator EnterWithPostcardRoutine(LevelEnterSequence scene, string message, string soundId)
            => scene.EnterWithPostcardRoutine(message, soundId,
                ((EverestArea)process.AreaKeys.GetArea(process.AreaKeys.GetSessionArea(scene.Session)))?.Metadata
                ?.Postcard
                ?.Texture);
    }
}
