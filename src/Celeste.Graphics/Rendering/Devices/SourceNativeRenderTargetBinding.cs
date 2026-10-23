using System;
using System.Runtime.InteropServices;

namespace Celeste.Graphics.Rendering.Devices
{
    [StructLayout(LayoutKind.Sequential)]
    public struct SourceNativeRenderTargetBinding
    {
        public byte type;
        public int data1;
        public int data2;
        public int levelCount;
        public int multiSampleCount;
        public IntPtr texture;
        public IntPtr colorBuffer;
    }
}
