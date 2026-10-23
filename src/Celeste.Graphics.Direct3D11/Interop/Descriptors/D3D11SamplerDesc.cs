using System;
using System.Runtime.InteropServices;

namespace Celeste.Graphics.Direct3D11.Interop.Descriptors
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct D3D11SamplerDesc
    {
        public uint Filter;
        public uint AddressU;
        public uint AddressV;
        public uint AddressW;
        public float MipBias;
        public uint MaxAnisotropy;
        public uint ComparisonFunction;
        public float Border0;
        public float Border1;
        public float Border2;
        public float Border3;
        public float MinLOD;
        public float MaxLOD;
    }
}
