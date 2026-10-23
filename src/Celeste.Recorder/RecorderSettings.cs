using Celeste.Core.Display;
using System;
using System.IO;
using System.Numerics;
using System.Xml.Serialization;
using Celeste.Simulation.Rendering;

namespace Celeste.Recorder
{
    public sealed class RecorderSettings
    {
        private int fps = 60, resolution = 6, videoBitrate = 6500000, audioBitrate = 128000;
        private float speed = 1;
        private bool resetMute;
        [XmlIgnore] public Func<bool> IsRecording, LibraryActive, ReadMute, IsRestoringSettings;
        [XmlIgnore] public Action Refresh;
        [XmlIgnore] public Action<string> Warn;
        [XmlIgnore] public Action<bool> WriteMute;
        [XmlIgnore] public RecordingEffects Effects = new();
        public string Version { get; set; } = "unknown";

        public int FPS
        {
            get => fps;
            set
            {
                if (Frozen("FPS")) return;
                fps = Math.Max(1, value);
                Refresh?.Invoke();
            }
        }

        public int VideoResolution
        {
            get => resolution;
            set
            {
                if (Frozen("video resolution")) return;
                resolution = Math.Max(1, value);
                Refresh?.Invoke();
            }
        }

        public int VideoBitrate
        {
            get => videoBitrate;
            set
            {
                if (Frozen("video bitrate")) return;
                videoBitrate = Math.Max(100000, value);
                Refresh?.Invoke();
            }
        }

        public int AudioBitrate
        {
            get => audioBitrate;
            set
            {
                if (Frozen("audio bitrate")) return;
                audioBitrate = Math.Max(8000, value);
                Refresh?.Invoke();
            }
        }

        [XmlIgnore] public int VideoWidth => 320 * VideoResolution;
        [XmlIgnore] public int VideoHeight => 180 * VideoResolution;
        public string OutputDirectory { get; set; }
        public string FFmpegPath { get; set; }
        public string NativeLibraryDirectory { get; set; }
        public EncoderType EncoderType { get; set; } = EncoderType.FFmpegBinary;
        public HardwareAccelerationType HardwareAccelerationType { get; set; }
        public int VideoCodecOverwrite { get; set; } = -1;
        public int AudioCodecOverwrite { get; set; } = -1;
        public string H264Preset { get; set; } = "faster";
        public int H264Quality { get; set; } = 21;
        public string FFmpegBinaryEncoderOutputOverwrite { get; set; } = "";
        public string ContainerType { get; set; } = "mp4";
        public bool RecordingIndicator { get; set; } = true;
        public RecordingTimeIndicator RecordingTime { get; set; } = RecordingTimeIndicator.RegularFrames;
        public bool RecordingProgress { get; set; } = true;

        [XmlIgnore]
        public float Speed
        {
            get => speed;
            set
            {
                if (!DuringRecording("Speed")) return;
                speed = Math.Min(Math.Max(value, .1f), 30f);
                Refresh?.Invoke();
                if (LibraryActive?.Invoke() != true)
                    Warn?.Invoke("Tried to change the Speed while recording without using the FFmpeg Library Encoder");
            }
        }

        [XmlIgnore]
        public float BlackFade
        {
            get => float.NaN;
            set
            {
                if (!DuringRecording("BlackFade")) return;
                switch (Math.Sign(value))
                {
                    case 1:
                        Effects.BlackFadeStart = 0;
                        Effects.BlackFadeEnd = Math.Abs(value);
                        break;
                    case -1:
                        Effects.BlackFadeStart = Math.Abs(value);
                        Effects.BlackFadeEnd = 0;
                        break;
                }
            }
        }

        [XmlIgnore]
        public string BlackFadeText
        {
            get => Effects.Text;
            set
            {
                if (DuringRecording("BlackFadeText")) Effects.Text = value;
            }
        }

        [XmlIgnore]
        public Vector2 BlackFadeTextPosition
        {
            get => Effects.Position;
            set
            {
                if (DuringRecording("BlackFadeTextPosition")) Effects.Position = value;
            }
        }

        [XmlIgnore]
        public float BlackFadeTextScale
        {
            get => Effects.Scale;
            set
            {
                if (DuringRecording("BlackFadeTextScale")) Effects.Scale = value;
            }
        }

        [XmlIgnore]
        public global::Celeste.Core.Display.PackedColor BlackFadeTextColor
        {
            get => Effects.Color;
            set
            {
                if (DuringRecording("BlackFadeTextColor")) Effects.Color = value;
            }
        }

        [XmlIgnore]
        public bool MuteSFX
        {
            get => ReadMute?.Invoke() ?? false;
            set
            {
                if (!DuringRecording("MuteSFX")) return;
                WriteMute?.Invoke(value);
                resetMute = true;
            }
        }

        public void Stopped()
        {
            speed = 1;
            if (resetMute)
            {
                WriteMute?.Invoke(false);
                resetMute = false;
            }
        }

        private bool Frozen(string name)
        {
            if (IsRecording?.Invoke() != true || LibraryActive?.Invoke() == true) return false;
            Warn?.Invoke("Tried to change the " + name + " while recording without using the FFmpeg Library Encoder");
            return true;
        }

        private bool DuringRecording(string name)
        {
            if (IsRestoringSettings?.Invoke() == true) return false;
            if (IsRecording?.Invoke() == true) return true;
            Warn?.Invoke("Tried to \"Set, TASRecorder." + name + ", ...\" while not recording");
            return false;
        }

        public static RecorderSettings Load(string path)
        {
            if (!File.Exists(path)) return new RecorderSettings();
            using (var reader = File.OpenRead(path))
                return (RecorderSettings)new XmlSerializer(typeof(RecorderSettings)).Deserialize(reader);
        }

        public void Save(string path)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(Path.GetFullPath(path)));
            using (var writer = File.Create(path)) new XmlSerializer(typeof(RecorderSettings)).Serialize(writer, this);
        }
    }
}
