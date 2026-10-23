using System;
using System.Runtime.InteropServices;

namespace Celeste.Everest.Diagnostics.AutoSplitting
{
    [StructLayout(LayoutKind.Explicit)]
    public struct EverestAutoSplitterInfo
    {
        [FieldOffset(0)] private uint magic0;
        [FieldOffset(4)] private uint magic1;
        [FieldOffset(8)] private uint magic2;
        [FieldOffset(12)] private uint magic3;
        [FieldOffset(16)] private uint magic4;
        [FieldOffset(20)] public byte CelesteVersionMajor;
        [FieldOffset(21)] public byte CelesteVersionMinor;
        [FieldOffset(22)] public byte CelesteVersionBuild;
        [FieldOffset(23)] public byte InfoVersion;
        [FieldOffset(24)] public IntPtr EverestVersionStrPtr;
        [FieldOffset(32)] public IntPtr LevelSetStrPtr;
        [FieldOffset(40)] public IntPtr ChapterSIDStrPtr;
        [FieldOffset(48)] public int ChapterID;
        [FieldOffset(52)] public int ChapterMode;
        [FieldOffset(56)] public IntPtr RoomNameStrPtr;
        [FieldOffset(64)] public long ChapterTime;
        [FieldOffset(72)] public int ChapterStrawberries;
        [FieldOffset(76)] public EverestAutoSplitterChapterFlags ChapterFlags;
        [FieldOffset(80)] public long FileTime;
        [FieldOffset(88)] public int FileStrawberries;
        [FieldOffset(92)] public int FileGoldenStrawberries;
        [FieldOffset(96)] public int FileCassettes;
        [FieldOffset(100)] public int FileHearts;
        [FieldOffset(104)] public EverestAutoSplitterFileFlags FileFlags;
    }
}
