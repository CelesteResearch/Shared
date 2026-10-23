using System;

namespace Celeste.Graphics.Rendering.Devices
{
    // Optional GPU-only access to the physical backbuffer. The caller owns the destination texture.
    public interface ISourceGraphicsBackbufferCopyIO
    {
        bool HasPresentedBackbuffer { get; }
        void CopyBackbufferTo(IntPtr destination);
        void RestoreBackbufferFrom(IntPtr source);
    }
}
