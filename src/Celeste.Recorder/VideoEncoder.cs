using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Celeste.Recorder
{
    // The compressed video spool keeps recording memory bounded; PCM is muxed without changing
    // its DSP block count. Encoding runs independently of engine wall-clock speed.
    public sealed class VideoEncoder : IDisposable
    {
        private readonly VideoEncoderSettings settings;
        private readonly BlockingCollection<byte[]> frames = new(60);
        private readonly object audioLock = new();
        private readonly CancellationTokenSource failed = new();
        private readonly Process video;
        private readonly Task<string> videoErrors;
        private readonly Task writer;
        private readonly FileStream audio;
        private readonly string workDirectory, videoPath, audioPath;
        private Exception failure;
        private bool finished;
        public string OutputPath { get; }
        public long VideoFrames { get; private set; }
        public long AudioSamples { get; private set; }

        public VideoEncoder(VideoEncoderSettings settings, string fileName, bool bottomUp = false)
        {
            this.settings = settings ?? throw new ArgumentNullException(nameof(settings));
            if (settings.Width < 1 || settings.Height < 1 || settings.FramesPerSecond < 1 || settings.SampleRate < 1 ||
                settings.AudioChannels < 1)
                throw new ArgumentOutOfRangeException(nameof(settings));
            var directory = Path.GetFullPath(settings.OutputDirectory);
            Directory.CreateDirectory(directory);
            // Same filename rule as TAS Recorder: append the selected container extension.
            OutputPath = Path.GetFullPath(Path.Combine(directory,
                (fileName ?? DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss", CultureInfo.InvariantCulture)) + "." +
                settings.Container));
            Directory.CreateDirectory(Path.GetDirectoryName(OutputPath));
            workDirectory = Path.Combine(Path.GetDirectoryName(OutputPath),
                ".recording-" + Guid.NewGuid().ToString("N"));
            Directory.CreateDirectory(workDirectory);
            // MP4 keeps an exact frame-rate timescale. Matroska's default millisecond
            // timestamps would make a nominal 60 Hz video 120000/1999 Hz after remuxing.
            videoPath = Path.Combine(workDirectory, "video.mp4");
            audioPath = Path.Combine(workDirectory, "audio.f32le");
            audio = new(audioPath, FileMode.CreateNew, FileAccess.Write, FileShare.Read);
            try
            {
                video = StartProcess(settings.FFmpegPath,
                    "-hide_banner -loglevel error -nostdin -y -f rawvideo -pixel_format rgba -video_size " +
                    settings.Width + "x" + settings.Height + " -framerate " + settings.FramesPerSecond +
                    " -i pipe:0 -an " +
                    (bottomUp ? "-vf vflip " : "") + "-c:v libx264 -preset " + Quote(settings.H264Preset) + " -crf " +
                    settings.Quality +
                    " -b:v " + settings.VideoBitrate + " -pix_fmt yuv420p " + Quote(videoPath), true);
                videoErrors = video.StandardError.ReadToEndAsync();
                writer = Task.Run(() =>
                {
                    try
                    {
                        foreach (var frame in frames.GetConsumingEnumerable())
                            video.StandardInput.BaseStream.Write(frame, 0, frame.Length);
                    }
                    catch (Exception ex)
                    {
                        failure = ex;
                        failed.Cancel();
                    }
                    finally
                    {
                        try
                        {
                            video.StandardInput.Close();
                        }
                        catch (IOException)
                        {
                        }
                    }
                });
            }
            catch
            {
                audio.Dispose();
                throw;
            }
        }

        public void WriteVideo(byte[] rgba)
        {
            if (finished) throw new ObjectDisposedException(nameof(VideoEncoder));
            if (rgba == null || rgba.Length != checked(settings.Width * settings.Height * 4))
                throw new ArgumentException("RGBA frame dimensions do not match the recording.", nameof(rgba));
            CheckFailure();
            try
            {
                frames.Add((byte[])rgba.Clone(), failed.Token);
            }
            catch (OperationCanceledException)
            {
                CheckFailure();
                throw;
            }

            VideoFrames++;
        }

        public void WriteAudio(float[] pcm, int samples, int channels)
        {
            if (channels != settings.AudioChannels)
                throw new InvalidOperationException("FMOD channel layout changed during recording.");
            var count = checked(samples * channels);
            if (pcm == null || pcm.Length < count) throw new ArgumentException("PCM block is too small.", nameof(pcm));
            var bytes = new byte[checked(count * 4)];
            Buffer.BlockCopy(pcm, 0, bytes, 0, bytes.Length);
            lock (audioLock)
            {
                if (finished) return;
                audio.Write(bytes, 0, bytes.Length);
                AudioSamples += samples;
            }
        }

        public void Finish()
        {
            lock (audioLock)
            {
                if (finished) return;
                finished = true;
                audio.Dispose();
            }

            frames.CompleteAdding();
            writer.GetAwaiter().GetResult();
            video.WaitForExit();
            var errors = videoErrors.GetAwaiter().GetResult();
            var exit = video.ExitCode;
            video.Dispose();
            CheckFailure();
            if (exit != 0)
                throw new IOException("FFmpeg video encoding failed (" + exit + "): " + errors +
                                      "\nRecording files retained at " + workDirectory);
            // No -shortest: the original encoder preserves complete FMOD DSP blocks, whose
            // accumulated rounding error can leave audio slightly longer than video.
            var audioArgs = AudioSamples == 0
                ? " -an "
                : " -f f32le -ar " + settings.SampleRate + " -ac " + settings.AudioChannels + " -i " +
                  Quote(audioPath) +
                  " -map 0:v:0 -map 1:a:0 -c:a aac -b:a " + settings.AudioBitrate + " ";
            using (var mux = StartProcess(settings.FFmpegPath,
                       "-hide_banner -loglevel error -nostdin -y -i " + Quote(videoPath) + audioArgs + " -c:v copy " +
                       Quote(OutputPath), false))
            {
                var stderr = mux.StandardError.ReadToEndAsync();
                mux.WaitForExit();
                var message = stderr.GetAwaiter().GetResult();
                if (mux.ExitCode != 0)
                    throw new IOException("FFmpeg audio/video mux failed: " + message +
                                          "\nRecording files retained at " + workDirectory);
            }

            // Delete only the two files this instance created, never recursively remove a path
            // derived from a TAS filename. Failed recordings remain available for recovery.
            File.Delete(videoPath);
            File.Delete(audioPath);
            Directory.Delete(workDirectory, false);
        }

        public void Dispose()
        {
            Finish();
        }

        private void CheckFailure()
        {
            if (failure != null) throw new IOException("FFmpeg input stream failed.", failure);
        }

        private static Process StartProcess(string executable, string arguments, bool input)
        {
            var process = new Process
            {
                StartInfo = new(executable, arguments)
                {
                    UseShellExecute = false, CreateNoWindow = true,
                    RedirectStandardInput = input, RedirectStandardError = true,
                },
            };
            if (!process.Start()) throw new IOException("Could not start FFmpeg.");
            return process;
        }

        private static string Quote(string value)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));
            // ProcessStartInfo.Arguments uses the same quoting on .NET and Unity Mono. These
            // arguments go directly to FFmpeg, never through cmd.exe or another shell.
            var result = new StringBuilder("\"");
            var slashes = 0;
            foreach (var c in value)
            {
                if (c == '\\')
                {
                    slashes++;
                    continue;
                }

                if (c == '"')
                {
                    result.Append('\\', slashes * 2 + 1);
                    result.Append(c);
                    slashes = 0;
                    continue;
                }

                result.Append('\\', slashes);
                slashes = 0;
                result.Append(c);
            }

            result.Append('\\', slashes * 2);
            return result.Append('"').ToString();
        }
    }
}
