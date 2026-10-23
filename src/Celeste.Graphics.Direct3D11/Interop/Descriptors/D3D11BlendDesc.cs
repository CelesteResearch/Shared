using System;
using System.Runtime.InteropServices;

namespace Celeste.Graphics.Direct3D11.Interop.Descriptors
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct D3D11BlendDesc
    {
        public int AlphaToCoverageEnable;
        public int IndependentBlendEnable;
        public D3D11RenderTargetBlendDesc Target0;
        public D3D11RenderTargetBlendDesc Target1;
        public D3D11RenderTargetBlendDesc Target2;
        public D3D11RenderTargetBlendDesc Target3;
        public D3D11RenderTargetBlendDesc Target4;
        public D3D11RenderTargetBlendDesc Target5;
        public D3D11RenderTargetBlendDesc Target6;
        public D3D11RenderTargetBlendDesc Target7;
    }
}
