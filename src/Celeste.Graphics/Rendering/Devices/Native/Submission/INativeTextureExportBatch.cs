using System;

namespace Celeste.Graphics.Rendering.Devices.Native.Submission
{
    /// <summary>Host ownership for the outputs used by one texture export packet.</summary>
    public interface INativeTextureExportBatch
    {
        // Borrow the packet and submit every output through its actual host owner.
        // Return after enqueue/owner acceptance, without waiting for GPU idle.
        void Submit(IntPtr packet);
    }
}
