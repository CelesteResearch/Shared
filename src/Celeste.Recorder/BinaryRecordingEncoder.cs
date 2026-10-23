using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Celeste.Recorder
{
    // FFmpeg receives the same raw RGBA and stereo PCM as the reference encoder. Loopback
    // streams replace platform-specific named pipes; no intermediate codec changes the pixels.
    public sealed class BinaryRecordingEncoder : IRecordingEncoder
    {
        private sealed class InputPipe
        {
            public readonly BlockingCollection<byte[]> Queue = new BlockingCollection<byte[]>();
            private readonly TcpListener listener = new TcpListener(IPAddress.Loopback, 0);
            public readonly Task Writer;
            public readonly string Url;

            public InputPipe()
            {
                listener.Start(1);
                Url = "tcp://127.0.0.1:" + ((IPEndPoint)listener.LocalEndpoint).Port;
                Writer = Task.Run(async () =>
                {
                    using (var client = await listener.AcceptTcpClientAsync())
                    using (var stream = client.GetStream())
                    {
                        listener.Stop();
                        foreach (var bytes in Queue.GetConsumingEnumerable())
                            await stream.WriteAsync(bytes, 0, bytes.Length);
                    }
                });
            }

            public void Close()
            {
                Queue.CompleteAdding();
            }

            public void Abort()
            {
                listener.Stop();
                Close();
            }
        }

        private readonly InputPipe video, audio;
        private readonly Process process;
        private readonly Task<string> errors;
        private readonly int width, height;
        private bool finished;
        public bool HasVideo { get; }
        public bool HasAudio { get; }
        public string OutputPath { get; }
        public long VideoFrames { get; private set; }
        public long AudioSamples { get; private set; }
        public int QueuedVideoFrames => video?.Queue.Count ?? 0;
        public int QueuedAudioFrames => audio?.Queue.Count ?? 0;

        public BinaryRecordingEncoder(RecorderSettings settings, string name, int channels = 2)
        {
            width = settings.VideoWidth;
            height = settings.VideoHeight;
            HasVideo = settings.VideoCodecOverwrite != 0;
            HasAudio = settings.AudioCodecOverwrite != 0;
            OutputPath = Path.GetFullPath(Path.Combine(settings.OutputDirectory,
                (name ?? DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss")) + "." + settings.ContainerType));
            Directory.CreateDirectory(Path.GetDirectoryName(OutputPath));
            if (!HasVideo && !HasAudio) return;
            try
            {
                string inputs = "";
                if (HasVideo)
                {
                    video = new InputPipe();
                    string accel = settings.HardwareAccelerationType == HardwareAccelerationType.QSV
                        ? " -hwaccel qsv -hwaccel_output_format qsv"
                        : settings.HardwareAccelerationType == HardwareAccelerationType.NVENC
                            ? " -hwaccel cuda"
                            : "";
                    inputs += accel + " -f rawvideo -pixel_format rgba -video_size " + width + "x" + height +
                              " -framerate " + settings.FPS + " -i " + Quote(video.Url);
                }

                if (HasAudio)
                {
                    audio = new InputPipe();
                    inputs += " -f f32le -ar 48000 -ac 2 -i " + Quote(audio.Url);
                }

                process = Start(settings.FFmpegPath,
                    "-hide_banner -loglevel error -nostdin -y" + inputs + OutputOptions(settings, HasVideo, HasAudio) +
                    " " + Quote(OutputPath), false);
                errors = process.StandardError.ReadToEndAsync();
            }
            catch
            {
                video?.Abort();
                audio?.Abort();
                throw;
            }
        }

        public void WriteVideo(byte[] rgba, int width, int height, bool bottomUp)
        {
            if (!HasVideo) return;
            CheckFailure();
            if (finished) throw new ObjectDisposedException(nameof(BinaryRecordingEncoder));
            if (width != this.width || height != this.height || rgba.Length != checked(width * height * 4))
                throw new ArgumentException("Video dimensions changed during binary recording");
            var copy = new byte[rgba.Length];
            if (bottomUp)
            {
                for (int y = 0; y < height; y++)
                    Buffer.BlockCopy(rgba, (height - y - 1) * width * 4, copy, y * width * 4, width * 4);
            }
            else Buffer.BlockCopy(rgba, 0, copy, 0, copy.Length);

            video.Queue.Add(copy);
            VideoFrames++;
        }

        public void WriteAudio(float[] pcm, int samples, int channels)
        {
            if (!HasAudio || finished) return;
            CheckFailure();
            if (channels != 1 && channels != 2)
                throw new ArgumentException("Invalid recording channel count! Expected 2, got " + channels);
            float[] stereo = pcm;
            if (channels == 1)
            {
                stereo = new float[samples * 2];
                for (int s = 0; s < samples; s++) stereo[s * 2] = stereo[s * 2 + 1] = pcm[s];
            }

            var bytes = new byte[checked(samples * 2 * 4)];
            Buffer.BlockCopy(stereo, 0, bytes, 0, bytes.Length);
            audio.Queue.Add(bytes);
            AudioSamples += samples;
        }

        public void RefreshSettings()
        {
        }

        public void Finish()
        {
            if (finished) return;
            finished = true;
            video?.Close();
            audio?.Close();
            if (process == null) return;
            process.WaitForExit();
            video?.Abort();
            audio?.Abort();
            string error = errors.GetAwaiter().GetResult();
            int code = process.ExitCode;
            process.Dispose();
            if (code != 0) throw new IOException("FFmpeg recording failed: " + error);
            video?.Writer.GetAwaiter().GetResult();
            audio?.Writer.GetAwaiter().GetResult();
        }

        private void CheckFailure()
        {
            if (process != null && process.HasExited)
                throw new IOException("FFmpeg recording stopped: " + errors.GetAwaiter().GetResult());
            if (video?.Writer.IsFaulted == true) video.Writer.GetAwaiter().GetResult();
            if (audio?.Writer.IsFaulted == true) audio.Writer.GetAwaiter().GetResult();
        }

        public static string OutputOptions(RecorderSettings s, bool video, bool audio)
        {
            if (!string.IsNullOrWhiteSpace(s.FFmpegBinaryEncoderOutputOverwrite))
                return " " + s.FFmpegBinaryEncoderOutputOverwrite;
            var text = new StringBuilder();
            if (video)
            {
                text.Append(" -b:v ").Append(s.VideoBitrate);
                switch (s.HardwareAccelerationType)
                {
                    case HardwareAccelerationType.QSV: text.Append(" -c:v h264_qsv"); break;
                    case HardwareAccelerationType.AMF: text.Append(" -c:v h264_amf"); break;
                    case HardwareAccelerationType.VideoToolbox: text.Append(" -c:v h264_videotoolbox"); break;
                    case HardwareAccelerationType.NVENC:
                        string preset = s.H264Preset == "veryslow"
                            ? "p7"
                            : s.H264Preset == "slower"
                                ? "p6"
                                : s.H264Preset == "slow"
                                    ? "p5"
                                    : s.H264Preset == "medium"
                                        ? "p4"
                                        : s.H264Preset == "fast"
                                            ? "p3"
                                            : s.H264Preset == "faster"
                                                ? "p2"
                                                : s.H264Preset == "veryfast" || s.H264Preset == "superfast" ||
                                                  s.H264Preset == "ultrafast"
                                                    ? "p1"
                                                    : throw new ArgumentOutOfRangeException(nameof(s.H264Preset));
                        text.Append(" -c:v h264_nvenc -preset:v ").Append(preset).Append(" -tune:v hq -rc:v vbr -cq:v ")
                            .Append(s.H264Quality);
                        break;
                    default:
                        if (s.VideoCodecOverwrite != -1) text.Append(" -c:v ").Append(CodecName(s.VideoCodecOverwrite));
                        if (s.VideoCodecOverwrite == 27 || s.VideoCodecOverwrite == -2 || s.VideoCodecOverwrite == -1 &&
                            (s.ContainerType == "mp4" || s.ContainerType == "mkv" || s.ContainerType == "mov"))
                            text.Append(" -preset ").Append(Quote(s.H264Preset)).Append(" -crf ").Append(s.H264Quality)
                                .Append(" -pix_fmt yuv420p");
                        break;
                }
            }

            if (audio)
            {
                text.Append(" -b:a ").Append(s.AudioBitrate);
                if (s.AudioCodecOverwrite != -1) text.Append(" -c:a ").Append(CodecName(s.AudioCodecOverwrite));
            }

            return text.ToString();
        }

        // Preserve the installed recorder's codec names, including its AAC override spelling.
        public static string CodecName(int id) => id == 27 ? "libx264" :
            id == -2 ? "libx264rgb" :
            id == 226 ? "av1" :
            id == 167 ? "vp9" :
            id == 139 ? "vp8" :
            id == 86018 ? "acc" :
            id == 86017 ? "mp3" :
            id == 86028 ? "flac" :
            id == 86076 ? "opus" :
            id == 86021 ? "vorbis" : throw new ArgumentOutOfRangeException(nameof(id), id, null);

        public void Dispose() => Finish();

        private static Process Start(string executable, string args, bool input)
        {
            var process = new Process
            {
                StartInfo = new ProcessStartInfo(executable, args)
                {
                    UseShellExecute = false, CreateNoWindow = true, RedirectStandardInput = input,
                    RedirectStandardError = true
                }
            };
            if (!process.Start()) throw new IOException("Cannot start FFmpeg");
            return process;
        }

        private static string Quote(string value)
        {
            var result = new StringBuilder("\"");
            int slashes = 0;
            foreach (char c in value)
            {
                if (c == '\\')
                {
                    slashes++;
                    continue;
                }

                if (c == '"')
                {
                    result.Append('\\', slashes * 2 + 1).Append(c);
                    slashes = 0;
                    continue;
                }

                result.Append('\\', slashes).Append(c);
                slashes = 0;
            }

            return result.Append('\\', slashes * 2).Append('"').ToString();
        }
    }
}
