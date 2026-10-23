using System;

namespace Celeste.Everest.Diagnostics.AutoSplitting
{
    [Flags]
    public enum EverestAutoSplitterChapterFlags : uint
    {
        ChapterStarted = 1,
        ChapterComplete = 2,
        ChapterCassette = 4,
        ChapterHeart = 8,
        GrabbedGolden = 16,
        TimerActive = 0x80000000,
    }
}
