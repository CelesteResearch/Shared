using Celeste.Game.Chapters.Flow;
using Celeste.Game.Execution.Levels;

namespace Celeste.Game.Cheats
{
    public sealed class OriginalUnlockEverythingPolicy : IOriginalUnlockEverythingPolicy
    {
        public void UnlockEverything(OriginalLevelSceneRoot level, IOriginalUnlockEverythingProcess engine)
        {
            engine.SaveContext.CurrentSave.RevealedChapter9 = true;
            engine.SaveContext.CurrentSave.UnlockedAreas =
                engine.SaveProgression.GetMaxArea(engine.SaveContext.CurrentSave);
            engine.SaveContext.CurrentSave.CheatMode = true;
            engine.MenuSettings.Pico8OnMainMenu = true;
            engine.MenuSettings.VariantsUnlocked = true;
            level.Session.InArea = false;
            engine.Frame.Scenes.NextScene = engine.LevelExits.CreateLevelExit(LevelExitMode.GiveUp, level.Session);
        }
    }
}
