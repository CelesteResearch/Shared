using System;
using System.Runtime.InteropServices;

namespace Celeste.Audio.Interop
{
    [StructLayout(LayoutKind.Sequential)]
    public struct SourceCaptureAudioSpec
    {
        public int Frequency;
        public ushort Format;
        public byte Channels;
        public byte Silence;
        public ushort Samples;
        public uint Size;
        public IntPtr Callback;
        public IntPtr UserData;
    }
}
