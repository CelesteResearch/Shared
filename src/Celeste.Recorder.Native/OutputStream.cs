using FFmpeg;

namespace Celeste.Recorder.Native
{
    internal struct OutputStream
    {
        public unsafe AVStream* Stream;

        public unsafe AVCodecContext* CodecCtx;

        public unsafe AVFrame* InFrame;

        public unsafe AVFrame* OutFrame;

        public unsafe AVPacket* Packet;

        public unsafe SwsContext* SwsCtx;

        public unsafe SwrContext* SwrCtx;

        public long VideoPTS;

        public int SamplesCount;

        public int FrameSamplePos;
    }
}
