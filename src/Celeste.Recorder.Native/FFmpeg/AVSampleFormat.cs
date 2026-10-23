namespace FFmpeg
{
    public enum AVSampleFormat
    {
        AV_SAMPLE_FMT_NONE = -1,
        AV_SAMPLE_FMT_U8,
        AV_SAMPLE_FMT_S16,
        AV_SAMPLE_FMT_S32,
        AV_SAMPLE_FMT_FLT,
        AV_SAMPLE_FMT_DBL,

        // ReSharper disable once InconsistentNaming
        AV_SAMPLE_FMT_U8P,

        // ReSharper disable once InconsistentNaming
        AV_SAMPLE_FMT_S16P,

        // ReSharper disable once InconsistentNaming
        AV_SAMPLE_FMT_S32P,
        AV_SAMPLE_FMT_FLTP,
        AV_SAMPLE_FMT_DBLP,
        AV_SAMPLE_FMT_S64,

        // ReSharper disable once InconsistentNaming
        AV_SAMPLE_FMT_S64P,
        AV_SAMPLE_FMT_NB,
    }
}
