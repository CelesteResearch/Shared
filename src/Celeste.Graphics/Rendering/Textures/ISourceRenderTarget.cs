using Celeste.Core.Rendering;
using System;

namespace Celeste.Graphics.Rendering.Textures
{
    internal interface ISourceRenderTarget
    {
        int Width { get; }

        int Height { get; }

        int LevelCount { get; }

        SourceRenderTargetUsage RenderTargetUsage { get; }

        SourceDepthFormat DepthStencilFormat { get; }

        IntPtr DepthStencilBuffer { get; }

        IntPtr ColorBuffer { get; }

        int MultiSampleCount { get; }
    }
}
