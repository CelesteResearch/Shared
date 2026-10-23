using System;
using System.IO;
using Celeste.Audio.IO;
using Celeste.Audio.Media;
using Celeste.Core.Framework.Time;
using Celeste.Graphics.Rendering.Devices;

namespace Celeste.Graphics.Media
{
    public sealed class SourceVideo
    {
        private readonly ISourceTheoraIO io;
        internal IntPtr theora;

        internal int yWidth;

        internal int yHeight;

        internal int uvWidth;

        internal int uvHeight;

        internal double fps;

        internal bool needsDurationHack;

        public int Width => yWidth;

        public int Height => yHeight;

        public float FramesPerSecond => (float)fps;

        public SourceVideoSoundtrackType VideoSoundtrackType { get; private set; }

        public TimeSpan Duration { get; set; }

        internal SourceGraphicsDevice GraphicsDevice { get; private set; }

        public SourceVideo(string fileName, SourceGraphicsDevice device, ISourceTheoraIO io)
        {
            GraphicsDevice = device;
            this.io = io;
            io.tf_fopen(fileName, out theora);
            io.tf_videoinfo(theora, out yWidth, out yHeight, out fps, out var fmt);
            switch (fmt)
            {
                case SourceTheoraPixelFormat.TH_PF_420:
                    uvWidth = yWidth / 2;
                    uvHeight = yHeight / 2;
                    break;
                case SourceTheoraPixelFormat.TH_PF_422:
                    uvWidth = yWidth / 2;
                    uvHeight = yHeight;
                    break;
                case SourceTheoraPixelFormat.TH_PF_444:
                    uvWidth = yWidth;
                    uvHeight = yHeight;
                    break;
                default:
                    throw new NotSupportedException("Unrecognized YUV format!");
            }

            Duration = TimeSpan.MaxValue;
            needsDurationHack = true;
        }

        public SourceVideo(string fileName, SourceGraphicsDevice device, ISourceTheoraIO io,
            ISourceTimeSpanPolicy timeSpans, int durationMS, int width, int height,
            float framesPerSecond, SourceVideoSoundtrackType soundtrackType)
            : this(fileName, device, io)
        {
            if (width != Width || height != Height)
                throw new InvalidOperationException("XNB/OGV width/height mismatch! Width: " + Width + " Height: " +
                                                    Height);

            if (Math.Abs(FramesPerSecond - framesPerSecond) >= 1f)
                throw new InvalidOperationException("XNB/OGV framesPerSecond mismatch! FPS: " + FramesPerSecond);

            Duration = timeSpans.FromMilliseconds(durationMS);
            needsDurationHack = false;
            VideoSoundtrackType = soundtrackType;
        }

        public static SourceVideo FromUriEXT(Uri uri, SourceGraphicsDevice graphicsDevice, ISourceTheoraIO io,
            ISourceAudioFileEnvironment environment)
        {
            string fileName;
            if (uri.IsAbsoluteUri)
            {
                if (!uri.IsFile) throw new InvalidOperationException("Only local file URIs are supported for now");

                fileName = uri.LocalPath;
            }
            else
            {
                fileName = Path.Combine(environment.TitleDirectory, uri.ToString());
            }

            return new(fileName, graphicsDevice, io);
        }

        public void SetAudioTrackEXT(int track)
        {
            if (theora != IntPtr.Zero) io.tf_setaudiotrack(theora, track);
        }

        public void SetVideoTrackEXT(int track)
        {
            if (theora != IntPtr.Zero) io.tf_setvideotrack(theora, track);
        }

        ~SourceVideo()
        {
            if (theora != IntPtr.Zero) io.tf_close(ref theora);
        }
    }
}
