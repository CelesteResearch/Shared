namespace Celeste.Recorder
{
    public readonly struct RecordingLoadingState
    {
        public readonly RecordingSceneKind Scene;

        public readonly bool AutoSavingEndCinematic,
            SummitReady,
            StartingGame,
            NextChapterSelect,
            NextMainMenu,
            Saving,
            SavingSettings,
            Pico8Ready;

        public RecordingLoadingState(RecordingSceneKind scene, bool autoSavingEndCinematic = false,
            bool summitReady = false, bool startingGame = false, bool nextChapterSelect = false,
            bool nextMainMenu = false, bool saving = false, bool savingSettings = false, bool pico8Ready = false)
        {
            Scene = scene;
            AutoSavingEndCinematic = autoSavingEndCinematic;
            SummitReady = summitReady;
            StartingGame = startingGame;
            NextChapterSelect = nextChapterSelect;
            NextMainMenu = nextMainMenu;
            Saving = saving;
            SavingSettings = savingSettings;
            Pico8Ready = pico8Ready;
        }

        public bool IsLoading => Scene switch
        {
            RecordingSceneKind.Level => AutoSavingEndCinematic,
            RecordingSceneKind.SummitVignette => !SummitReady,
            RecordingSceneKind.Overworld => StartingGame || (NextChapterSelect && Saving) ||
                                            (NextMainMenu && (Saving || SavingSettings)),
            RecordingSceneKind.Emulator => !Pico8Ready,
            RecordingSceneKind.LevelExit => true,
            RecordingSceneKind.LevelLoader => true,
            RecordingSceneKind.GameLoader => true,
            RecordingSceneKind.LevelExitToLobby => true,
            _ => false,
        };
    }
}
