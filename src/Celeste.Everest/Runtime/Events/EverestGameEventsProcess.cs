using System;
using System.Collections.Generic;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Menus.Title;
using Celeste.Game.UI.Menus.Buttons;
using Celeste.Game.Chapters.Flow;
using Celeste.Simulation.Gameplay.Player.Intro;
using Celeste.Simulation.Runtime.Session;
using Celeste.Game.Presentation.Environment;

namespace Celeste.Everest.Runtime.Events
{
    public sealed class EverestGameEventsProcess
    {
        public global::Celeste.Everest.UI.Menus.Files.EverestFileSelectSlotEvents FileSelectSlotEvents { get; }

        public EverestGameEventsProcess(global::Celeste.Core.Scheduling.ISourceEngineContext engine)
        {
            FileSelectSlotEvents = new global::Celeste.Everest.UI.Menus.Files.EverestFileSelectSlotEvents(engine);
        }

        public event Action<OriginalLevelSceneRoot, Celeste.Simulation.UI.Menus.Text.TextMenuPresentation, bool>
            OnCreatePauseMenuButtons;

        public event Action<OriginalLevelSceneRoot, int, bool, bool> OnPause;
        public event Action<OriginalLevelSceneRoot> OnUnpause;
        public event Action<OriginalLevelSceneRoot> OnComplete;

        public event
            Action<global::Celeste.Core.Scheduling.ISourceSceneExecution,
                global::Celeste.Core.Scheduling.ISourceSceneExecution> OnSceneTransition;

        public event Action OnExiting;
        public event Action OnShutdown;
        public event Action<MainMenuSequence, List<MenuButtonPresentation>> OnCreateButtons;
        public event Action<OriginalLevelSceneRoot, PlayerIntroType, bool> OnLoadLevel;

        public event Action<OriginalLevelSceneRoot, LevelExitSequence, LevelExitMode, ChapterCompletionSession,
            HiresSnowState> OnExit;

        public void CreatePauseMenuButtons(OriginalLevelSceneRoot level,
            Celeste.Simulation.UI.Menus.Text.TextMenuPresentation menu, bool minimal)
            => OnCreatePauseMenuButtons?.Invoke(level, menu, minimal);

        public void Pause(OriginalLevelSceneRoot level, int startIndex, bool minimal, bool quickReset)
            => OnPause?.Invoke(level, startIndex, minimal, quickReset);

        public void Unpause(OriginalLevelSceneRoot level) => OnUnpause?.Invoke(level);
        public void Complete(OriginalLevelSceneRoot level) => OnComplete?.Invoke(level);

        public void SceneTransition(global::Celeste.Core.Scheduling.ISourceSceneExecution previous,
            global::Celeste.Core.Scheduling.ISourceSceneExecution next)
            => OnSceneTransition?.Invoke(previous, next);

        public void Exiting() => OnExiting?.Invoke();
        public void Shutdown() => OnShutdown?.Invoke();

        public void CreateButtons(MainMenuSequence menu, List<MenuButtonPresentation> buttons)
            => OnCreateButtons?.Invoke(menu, buttons);

        public void LoadLevel(OriginalLevelSceneRoot level, PlayerIntroType playerIntro, bool isFromLoader)
            => OnLoadLevel?.Invoke(level, playerIntro, isFromLoader);

        public void Exit(OriginalLevelSceneRoot level, LevelExitSequence exit, LevelExitMode mode,
            ChapterCompletionSession session, HiresSnowState snow)
            => OnExit?.Invoke(level, exit, mode, session, snow);

        public event
            System.Action<Celeste.Game.Menus.Journal.OuiJournalSequence,
                Celeste.Game.Menus.Overworld.OuiState> OnJournalEnter;

        public void JournalEnter(Celeste.Game.Menus.Journal.OuiJournalSequence journal,
            Celeste.Game.Menus.Overworld.OuiState from)
            => OnJournalEnter?.Invoke(journal, from);
    }
}
