using System;

namespace Celeste.Audio.IO
{
    public enum SourceTheoraPixelFormat
    {
        TH_PF_420,
        TH_PF_RSVD,
        TH_PF_422,
        TH_PF_444,
        TH_PF_NFORMATS
    }

    public interface ISourceTheoraIO
    {
        int tf_fopen(string fileName, out IntPtr decoder);

        void tf_videoinfo(IntPtr decoder, out int width, out int height, out double fps,
            out SourceTheoraPixelFormat format);

        int tf_setvideotrack(IntPtr decoder, int track);
        int tf_setaudiotrack(IntPtr decoder, int track);
        int tf_close(ref IntPtr decoder);
    }
}
