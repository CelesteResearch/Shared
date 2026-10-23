using Celeste.Core.Scheduling;
using Celeste.Game.Save.Runtime;

namespace Celeste.Game.Diagnostics.Speedrun
{
    public sealed class OriginalAutoSplitterInfo
    {
        private readonly SourceEngineSceneState scenes;
        private readonly IOriginalGameSaveContext saves;
        private readonly IOriginalSaveCounterQueries counters;

        public int Chapter;
        public int Mode;
        public string Level;
        public bool TimerActive;
        public bool ChapterStarted;
        public bool ChapterComplete;
        public long ChapterTime;
        public int ChapterStrawberries;
        public bool ChapterCassette;
        public bool ChapterHeart;
        public long FileTime;
        public int FileStrawberries;
        public int FileCassettes;
        public int FileHearts;

        public OriginalAutoSplitterInfo(SourceEngineSceneState actualScenes,
            IOriginalGameSaveContext actualSaves, IOriginalSaveCounterQueries actualCounters)
        {
            scenes = actualScenes ?? throw new System.ArgumentNullException(nameof(actualScenes));
            saves = actualSaves ?? throw new System.ArgumentNullException(nameof(actualSaves));
            counters = actualCounters ?? throw new System.ArgumentNullException(nameof(actualCounters));
        }

        public void Update()
        {
            var level = scenes.CurrentScene as IOriginalAutoSplitterLevel;
            ChapterStarted = level != null;
            ChapterComplete = ChapterStarted && level.AutoSplitterCompleted;
            TimerActive = ChapterStarted && !level.AutoSplitterCompleted;
            Chapter = ChapterStarted ? level.AutoSplitterSession.AreaID : -1;
            Mode = ChapterStarted ? level.AutoSplitterSession.Mode : -1;
            Level = ChapterStarted ? level.AutoSplitterSession.Level : "";
            ChapterTime = ChapterStarted ? level.AutoSplitterSession.Time : 0;
            FileTime = saves.CurrentSave != null ? saves.CurrentSave.Time : 0;
            ChapterStrawberries = ChapterStarted ? level.AutoSplitterSession.Strawberries.Count : 0;
            FileStrawberries = saves.CurrentSave != null ? saves.CurrentSave.TotalStrawberries : 0;
            ChapterHeart = ChapterStarted && level.AutoSplitterSession.HeartGem;
            FileHearts = saves.CurrentSave != null ? counters.TotalHeartGems(saves.CurrentSave) : 0;
            ChapterCassette = ChapterStarted && level.AutoSplitterSession.Cassette;
            FileCassettes = saves.CurrentSave != null ? counters.TotalCassettes(saves.CurrentSave) : 0;
        }
    }
}
