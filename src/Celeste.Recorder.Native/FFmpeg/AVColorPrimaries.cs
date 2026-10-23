namespace FFmpeg
{
    public enum AVColorPrimaries
    {
        AVCOL_PRI_RESERVED0 = 0,
        AVCOL_PRI_BT709 = 1,
        AVCOL_PRI_UNSPECIFIED = 2,
        AVCOL_PRI_RESERVED = 3,

        // ReSharper disable once InconsistentNaming
        AVCOL_PRI_BT470M = 4,

        // ReSharper disable once InconsistentNaming
        AVCOL_PRI_BT470BG = 5,

        // ReSharper disable once InconsistentNaming
        AVCOL_PRI_SMPTE170M = 6,

        // ReSharper disable once InconsistentNaming
        AVCOL_PRI_SMPTE240M = 7,
        AVCOL_PRI_FILM = 8,
        AVCOL_PRI_BT2020 = 9,
        AVCOL_PRI_SMPTE428 = 10,
        AVCOL_PRI_SMPTEST428_1 = 10,
        AVCOL_PRI_SMPTE431 = 11,
        AVCOL_PRI_SMPTE432 = 12,
        AVCOL_PRI_EBU3213 = 22,
        AVCOL_PRI_JEDEC_P22 = 22,
        AVCOL_PRI_NB = 23,
    }
}
