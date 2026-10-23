using Celeste.Game.Chapters.Flow;
using Celeste.Game.Cheats;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Save.Data;

namespace Celeste.Everest.Cheats
{
    public sealed class EverestUnlockEverythingPolicy : IOriginalUnlockEverythingPolicy
    {
        public void UnlockEverything(OriginalLevelSceneRoot level, IOriginalUnlockEverythingProcess engine)
        {
            var save = engine.SaveContext.CurrentSave;
            if (engine.SaveLevelSets.GetLevelSet(save) == "Celeste")
            {
                foreach (var value in save.LevelSets)
                {
                    var stats = (OriginalLevelSetStats)value;
                    stats.UnlockedAreas = stats.MaxArea;
                }

                engine.SaveContext.CurrentSave.RevealedChapter9 = true;
                engine.MenuSettings.VariantsUnlocked = true;
                engine.MenuSettings.Pico8OnMainMenu = true;
            }
            else
            {
                engine.SaveLevelSets.GetLevelSetStats(save).UnlockedAreas =
                    engine.SaveLevelSets.GetLevelSetStats(save).MaxArea;
            }

            save.CheatMode = true;
            level.Session.InArea = false;
            engine.Frame.Scenes.NextScene = engine.LevelExits.CreateLevelExit(LevelExitMode.GiveUp, level.Session);
        }
    }
}
