using System;
using System.IO;
using System.Runtime.InteropServices;
using FFmpeg;

namespace Celeste.Recorder.Native
{
    public class NativeVideoEncoder : Encoder
    {
        private const AVPixelFormat INPUT_PIX_FMT = AVPixelFormat.AV_PIX_FMT_RGBA;

        private uint AudioDataChannels;

        private uint AudioDataSamples;

        private uint AudioDataSize;

        private uint AudioDataBufferSize;

        private OutputStream VideoStream;

        private OutputStream AudioStream;

        private unsafe AVFormatContext* FormatCtx;
        private readonly bool headerWritten;
        private bool ended;

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void FreeResampler(SwrContext** value);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void FreeDictionary(AVDictionary** value);

        public unsafe NativeVideoEncoder(NativeEncoderSettings settings, string fileName = null)
            : base(settings, fileName)
        {
            AudioDataChannels = 0u;
            AudioDataSamples = 0u;
            AudioDataSize = 0u;
            AudioDataBufferSize = 0u;
            FormatCtx = null;
            VideoStream = default;
            AudioStream = default;
            try
            {
                fixed (AVFormatContext** formatCtx = &FormatCtx)
                {
                    AvCheck(FFmpeg.FFmpeg.avformat_alloc_output_context2(formatCtx, null, null, FilePath),
                        "Failed allocating format context");
                }

                var aVCodecId = FormatCtx->oformat->video_codec;
                var aVCodecId2 = FormatCtx->oformat->audio_codec;
                if (settings.VideoCodecOverwrite != -1) aVCodecId = (AVCodecID)settings.VideoCodecOverwrite;

                if (settings.AudioCodecOverwrite != -1) aVCodecId2 = (AVCodecID)settings.AudioCodecOverwrite;

                AVCodec* ptr;
                if (settings.VideoCodecOverwrite == -2)
                {
                    settings.Log?.Invoke("Using video codec: H.264 RGB");
                    ptr = FFmpeg.FFmpeg.avcodec_find_encoder_by_name("libx264rgb");
                    if (ptr == null) throw new InvalidOperationException("FFmpeg has no libx264rgb encoder.");
                    aVCodecId = ptr->id;
                }
                else
                {
                    settings.Log?.Invoke($"Using video codec: {aVCodecId}");
                    ptr = FFmpeg.FFmpeg.avcodec_find_encoder(aVCodecId);
                }

                if (ptr == null && aVCodecId != AVCodecID.AV_CODEC_ID_NONE)
                    settings.Log?.Invoke("Failed to create video codec!");

                settings.Log?.Invoke($"Using audio codec: {aVCodecId2}");
                var ptr2 = FFmpeg.FFmpeg.avcodec_find_encoder(aVCodecId2);
                if (ptr2 == null && aVCodecId2 != AVCodecID.AV_CODEC_ID_NONE)
                    settings.Log?.Invoke("Failed to create audio codec!");

                HasVideo = ptr != null;
                HasAudio = ptr2 != null;
                if (HasVideo || HasAudio)
                {
                    if (HasVideo) AddStream(ptr, ref VideoStream, aVCodecId);

                    if (HasAudio) AddStream(ptr2, ref AudioStream, aVCodecId2);

                    if (HasVideo) OpenVideo(ptr);

                    if (HasAudio) OpenAudio(ptr2);

                    if ((FormatCtx->oformat->flags & 1) == 0)
                        AvCheck(FFmpeg.FFmpeg.avio_open(&FormatCtx->pb, FilePath, 2),
                            "Failed opening output file");

                    AvCheck(FFmpeg.FFmpeg.avformat_write_header(FormatCtx, null),
                        "Failed writing header to output file");
                    headerWritten = true;
                }
            }
            catch
            {
                ReleaseResources();
                throw;
            }
        }

        public override unsafe void End()
        {
            if (ended) return;
            ended = true;
            try
            {
                if (headerWritten)
                {
                    if (HasVideo) WriteFrame(ref VideoStream, null);
                    if (HasAudio) WriteFrame(ref AudioStream, null);
                    AvCheck(FFmpeg.FFmpeg.av_write_trailer(FormatCtx), "Failed writing stream trailer");
                }
            }
            finally
            {
                ReleaseResources();
            }
        }

        private unsafe void ReleaseResources()
        {
            CloseStream(ref VideoStream);
            CloseStream(ref AudioStream);
            if (AudioData != null)
            {
                Marshal.FreeHGlobal((IntPtr)AudioData);
                AudioData = null;
                AudioDataBufferSize = 0;
            }

            VideoData = null;
            if (FormatCtx != null)
            {
                if (FormatCtx->pb != null && (FormatCtx->oformat->flags & 1) == 0)
                    FFmpeg.FFmpeg.avio_closep(&FormatCtx->pb);
                FFmpeg.FFmpeg.avformat_free_context(FormatCtx);
                FormatCtx = null;
            }
        }

        public unsafe void RefreshSettings()
        {
            if (HasVideo)
                VideoStream.CodecCtx->framerate =
                    FFmpeg.FFmpeg.av_make_q((int)(settings.FPS * 1000f), 1000);
        }

        public override unsafe void PrepareVideo(int width, int height)
        {
            ref var videoStream = ref VideoStream;
            var codecCtx = videoStream.CodecCtx;
            if (videoStream.InFrame->width != width || videoStream.InFrame->height != height)
            {
                fixed (AVFrame** inFrame = &videoStream.InFrame)
                {
                    FFmpeg.FFmpeg.av_frame_free(inFrame);
                }

                videoStream.InFrame = AllocateVideoFrame(AVPixelFormat.AV_PIX_FMT_RGBA, width, height);
                FFmpeg.FFmpeg.sws_freeContext(videoStream.SwsCtx);
                videoStream.SwsCtx = FFmpeg.FFmpeg.sws_getContext(width, height, AVPixelFormat.AV_PIX_FMT_RGBA,
                    codecCtx->width, codecCtx->height, codecCtx->pix_fmt, 4, null, null, null);
                VideoRowStride = videoStream.InFrame->linesize[0u];
            }

            VideoData = videoStream.InFrame->data[0u];
        }

        public override unsafe void PrepareAudio(uint channelCount, uint sampleCount)
        {
            AudioDataSize = Math.Max(channelCount, 2u) * sampleCount * (uint)Marshal.SizeOf<float>();
            AudioDataSamples = sampleCount;
            AudioDataChannels = channelCount;
            if (AudioDataBufferSize < AudioDataSize)
            {
                AudioDataBufferSize = AudioDataSize * 2;
                AudioData = AudioData == null
                    ? (byte*)Marshal.AllocHGlobal((IntPtr)AudioDataBufferSize)
                    : (byte*)Marshal.ReAllocHGlobal((IntPtr)AudioData, (IntPtr)AudioDataBufferSize);
            }
        }

        public override unsafe void FinishVideo()
        {
            ref var videoStream = ref VideoStream;
            var codecCtx = videoStream.CodecCtx;
            AvCheck(FFmpeg.FFmpeg.av_frame_make_writable(videoStream.InFrame), "Failed making frame writable");
            AvCheck(
                FFmpeg.FFmpeg.sws_scale(videoStream.SwsCtx, videoStream.InFrame->data,
                    videoStream.InFrame->linesize, 0, videoStream.InFrame->height, videoStream.OutFrame->data,
                    videoStream.OutFrame->linesize), "Failed resampling video");
            videoStream.OutFrame->duration = (long)(codecCtx->framerate.den / (float)codecCtx->framerate.num *
                                                    codecCtx->time_base.den);
            videoStream.VideoPTS += videoStream.OutFrame->duration;
            videoStream.OutFrame->pts = videoStream.VideoPTS;
            WriteFrame(ref videoStream, videoStream.OutFrame);
        }

        public override unsafe void FinishAudio()
        {
            ref var audioStream = ref AudioStream;
            var codecCtx = audioStream.CodecCtx;
            var audioData = (float*)AudioData;
            var ptr = (float*)audioStream.InFrame->data[0u];
            for (var i = 0; i < AudioDataSamples; i++)
            {
                for (var j = 0; j < AudioDataChannels && j < codecCtx->ch_layout.nb_channels; j++)
                    ptr[audioStream.FrameSamplePos * codecCtx->ch_layout.nb_channels + j] =
                        audioData[i * AudioDataChannels + j];

                audioStream.FrameSamplePos++;
                if (audioStream.FrameSamplePos < audioStream.InFrame->nb_samples) continue;

                var outCount = (int)FFmpeg.FFmpeg.av_rescale_rnd(
                    FFmpeg.FFmpeg.swr_get_delay(audioStream.SwrCtx, codecCtx->sample_rate) +
                    audioStream.InFrame->nb_samples, codecCtx->sample_rate, codecCtx->sample_rate,
                    AVRounding.AV_ROUND_UP);
                AvCheck(FFmpeg.FFmpeg.av_frame_make_writable(audioStream.OutFrame),
                    "Failed making frame writable");
                fixed (byte** ptr2 = audioStream.InFrame->data.ToArray())
                {
                    fixed (byte** ptr3 = audioStream.OutFrame->data.ToArray())
                    {
                        AvCheck(
                            FFmpeg.FFmpeg.swr_convert(audioStream.SwrCtx, ptr3, outCount, ptr2,
                                audioStream.InFrame->nb_samples), "Failed resampling audio data");
                    }
                }

                audioStream.OutFrame->pts = FFmpeg.FFmpeg.av_rescale_q(audioStream.SamplesCount,
                    FFmpeg.FFmpeg.av_make_q(1, codecCtx->sample_rate), codecCtx->time_base);
                audioStream.SamplesCount += audioStream.OutFrame->nb_samples;
                audioStream.FrameSamplePos = 0;
                WriteFrame(ref audioStream, audioStream.OutFrame);
            }
        }

        private unsafe void AddStream(AVCodec* codec, ref OutputStream outStream, AVCodecID codecID)
        {
            outStream.Packet = FFmpeg.FFmpeg.av_packet_alloc();
            outStream.Stream = FFmpeg.FFmpeg.avformat_new_stream(FormatCtx, null);
            outStream.Stream->id = (int)(FormatCtx->nb_streams - 1);
            outStream.CodecCtx = FFmpeg.FFmpeg.avcodec_alloc_context3(codec);
            var codecCtx = outStream.CodecCtx;
            switch (codec->type)
            {
                case AVMediaType.AVMEDIA_TYPE_VIDEO:
                    codecCtx->codec_id = codecID;
                    codecCtx->bit_rate = settings.VideoBitrate;
                    codecCtx->width = settings.VideoWidth;
                    codecCtx->height = settings.VideoHeight;
                    codecCtx->time_base = FFmpeg.FFmpeg.av_make_q(1, 600000);
                    codecCtx->framerate = FFmpeg.FFmpeg.av_make_q((int)(settings.FPS * 1000f), 1000);
                    codecCtx->gop_size = 12;
                    codecCtx->pix_fmt =
                        codec->pix_fmts != null ? *codec->pix_fmts : AVPixelFormat.AV_PIX_FMT_YUV420P;
                    outStream.Stream->time_base = codecCtx->time_base;
                    break;
                case AVMediaType.AVMEDIA_TYPE_AUDIO:
                    codecCtx->sample_fmt = codec->sample_fmts != null
                        ? *codec->sample_fmts
                        : AVSampleFormat.AV_SAMPLE_FMT_FLTP;
                    codecCtx->bit_rate = settings.AudioBitrate;
                    codecCtx->sample_rate = 48000;
                    fixed (AVChannelLayout* aVChannelLayoutStereo = &FFmpeg.FFmpeg.AV_CHANNEL_LAYOUT_STEREO)
                    {
                        AvCheck(
                            FFmpeg.FFmpeg.av_channel_layout_copy(&codecCtx->ch_layout,
                                aVChannelLayoutStereo),
                            "Failed copying channel layout");
                    }

                    outStream.Stream->time_base = FFmpeg.FFmpeg.av_make_q(1, codecCtx->sample_rate);
                    break;
            }

            if ((FormatCtx->oformat->flags & 0x40) != 0) codecCtx->flags |= 4194304;
        }

        private unsafe void CloseStream(ref OutputStream outStream)
        {
            if (outStream.SwsCtx != null)
            {
                FFmpeg.FFmpeg.sws_freeContext(outStream.SwsCtx);
                outStream.SwsCtx = null;
            }

            if (outStream.SwrCtx != null)
                fixed (SwrContext** value = &outStream.SwrCtx)
                {
                    NativeBindings.Get<FreeResampler>("swresample", "swr_free")(value);
                }

            fixed (AVCodecContext** codecCtx = &outStream.CodecCtx)
            {
                FFmpeg.FFmpeg.avcodec_free_context(codecCtx);
            }

            fixed (AVFrame** inFrame = &outStream.InFrame)
            {
                FFmpeg.FFmpeg.av_frame_free(inFrame);
            }

            fixed (AVFrame** inFrame = &outStream.OutFrame)
            {
                FFmpeg.FFmpeg.av_frame_free(inFrame);
            }

            fixed (AVPacket** packet = &outStream.Packet)
            {
                FFmpeg.FFmpeg.av_packet_free(packet);
            }
        }

        private unsafe void OpenVideo(AVCodec* codec)
        {
            ref var videoStream = ref VideoStream;
            var codecCtx = videoStream.CodecCtx;
            if (codec->id == AVCodecID.AV_CODEC_ID_H264)
            {
                AVDictionary* ptr = null;
                AvCheck(FFmpeg.FFmpeg.av_dict_set(&ptr, "preset", settings.H264Preset, 0),
                    "Failed setting H.264 preset");
                AvCheck(FFmpeg.FFmpeg.av_dict_set(&ptr, "crf", settings.H264Quality.ToString(), 0),
                    "Failed setting H.264 quality");
                try
                {
                    AvCheck(FFmpeg.FFmpeg.avcodec_open2(codecCtx, codec, &ptr),
                        $"Could not open video codec with H.264 present: {settings.H264Preset} | CRF: {settings.H264Quality}");
                }
                finally
                {
                    NativeBindings.Get<FreeDictionary>("avutil", "av_dict_free")(&ptr);
                }
            }
            else
            {
                AvCheck(FFmpeg.FFmpeg.avcodec_open2(codecCtx, codec, null), "Could not open video codec");
            }

            videoStream.InFrame = AllocateVideoFrame(AVPixelFormat.AV_PIX_FMT_RGBA, codecCtx->width, codecCtx->height);
            videoStream.OutFrame = AllocateVideoFrame(codecCtx->pix_fmt, codecCtx->width, codecCtx->height);
            videoStream.FrameSamplePos = 0;
            VideoRowStride = videoStream.InFrame->linesize[0u];
            videoStream.SwsCtx = FFmpeg.FFmpeg.sws_getContext(codecCtx->width, codecCtx->height,
                AVPixelFormat.AV_PIX_FMT_RGBA, codecCtx->width, codecCtx->height, codecCtx->pix_fmt, 4, null, null,
                null);
            AvCheck(FFmpeg.FFmpeg.avcodec_parameters_from_context(videoStream.Stream->codecpar, codecCtx),
                "Failed copying parameters from context");
        }

        private unsafe void OpenAudio(AVCodec* codec)
        {
            ref var audioStream = ref AudioStream;
            var codecCtx = audioStream.CodecCtx;
            AvCheck(FFmpeg.FFmpeg.avcodec_open2(codecCtx, codec, null), "Could not open audio codec");
            var frameSize = codecCtx->frame_size;
            audioStream.InFrame = AllocateAudioFrame(AVSampleFormat.AV_SAMPLE_FMT_FLT, &codecCtx->ch_layout,
                codecCtx->sample_rate, frameSize);
            audioStream.OutFrame =
                AllocateAudioFrame(codecCtx->sample_fmt, &codecCtx->ch_layout, codecCtx->sample_rate, frameSize);
            audioStream.VideoPTS = 0L;
            audioStream.SwrCtx = FFmpeg.FFmpeg.swr_alloc();
            AvCheck(
                FFmpeg.FFmpeg.av_opt_set_chlayout(audioStream.SwrCtx, "in_chlayout", &codecCtx->ch_layout, 0),
                "Failed setting in_chlayout");
            AvCheck(
                FFmpeg.FFmpeg.av_opt_set_int(audioStream.SwrCtx, "in_sample_rate", codecCtx->sample_rate, 0),
                "Failed setting in_sample_rate");
            AvCheck(
                FFmpeg.FFmpeg.av_opt_set_sample_fmt(audioStream.SwrCtx, "in_sample_fmt",
                    AVSampleFormat.AV_SAMPLE_FMT_FLT, 0), "Failed setting in_sample_fmt");
            AvCheck(
                FFmpeg.FFmpeg.av_opt_set_chlayout(audioStream.SwrCtx, "out_chlayout", &codecCtx->ch_layout, 0),
                "Failed setting out_chlayout");
            AvCheck(
                FFmpeg.FFmpeg.av_opt_set_int(audioStream.SwrCtx, "out_sample_rate", codecCtx->sample_rate, 0),
                "Failed setting out_sample_rate");
            AvCheck(
                FFmpeg.FFmpeg.av_opt_set_sample_fmt(audioStream.SwrCtx, "out_sample_fmt", codecCtx->sample_fmt,
                    0),
                "Failed setting out_sample_fmt");
            AvCheck(FFmpeg.FFmpeg.swr_init(audioStream.SwrCtx), "Failed initializing resampling context");
            AvCheck(FFmpeg.FFmpeg.avcodec_parameters_from_context(audioStream.Stream->codecpar, codecCtx),
                "Failed copying parameters from context");
        }

        private unsafe AVFrame* AllocateVideoFrame(AVPixelFormat fmt, int width, int height)
        {
            var ptr = FFmpeg.FFmpeg.av_frame_alloc();
            ptr->format = (int)fmt;
            ptr->width = width;
            ptr->height = height;
            AvCheck(FFmpeg.FFmpeg.av_frame_get_buffer(ptr, 0), "Failed allocating frame buffer");
            return ptr;
        }

        private unsafe AVFrame* AllocateAudioFrame(AVSampleFormat fmt, AVChannelLayout* chLayout, int sampleRate,
            int sampleCount)
        {
            var ptr = FFmpeg.FFmpeg.av_frame_alloc();
            ptr->format = (int)fmt;
            ptr->sample_rate = sampleRate;
            ptr->nb_samples = sampleCount;
            AvCheck(FFmpeg.FFmpeg.av_channel_layout_copy(&ptr->ch_layout, chLayout),
                "Failed copying channel layout");
            AvCheck(FFmpeg.FFmpeg.av_frame_get_buffer(ptr, 0), "Failed allocating frame buffer");
            return ptr;
        }

        private unsafe void WriteFrame(ref OutputStream outStream, AVFrame* frame)
        {
            AvCheck(FFmpeg.FFmpeg.avcodec_send_frame(outStream.CodecCtx, frame),
                "Error sending the frame to the encoder");
            while (true)
            {
                var num = FFmpeg.FFmpeg.avcodec_receive_packet(outStream.CodecCtx, outStream.Packet);
                if (num == FFmpeg.FFmpeg.AVERROR(FFmpeg.FFmpeg.EAGAIN) ||
                    num == FFmpeg.FFmpeg.AVERROR_EOF)
                    break;

                AvCheck(num, "Failed encoding frame");
                if (frame != null) outStream.Packet->duration = frame->duration;

                FFmpeg.FFmpeg.av_packet_rescale_ts(outStream.Packet, outStream.CodecCtx->time_base,
                    outStream.Stream->time_base);
                outStream.Packet->stream_index = outStream.Stream->index;
                AvCheck(FFmpeg.FFmpeg.av_interleaved_write_frame(FormatCtx, outStream.Packet),
                    "Failed writing output packet");
            }
        }

        private unsafe void AvCheck(int code, string operation)
        {
            if (code >= 0) return;
            var bytes = new byte[256];
            string detail;
            fixed (byte* pointer = bytes)
            {
                FFmpeg.FFmpeg.av_strerror(code, pointer, 256);
                detail = Marshal.PtrToStringUTF8((IntPtr)pointer);
            }

            throw new IOException(operation + ": " + detail + " (" + code + ")");
        }
    }
}
