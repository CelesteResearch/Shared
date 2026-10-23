using System;

namespace Celeste.Graphics.Direct3D11.Submission
{
    /// <summary>Executes source GPU packets and presents their completed host output.</summary>
    public interface IDirect3D11GraphicsSubmission
    {
        // The host chooses its physical device ownership and initialization thread.
        IntPtr AcquireDevice();

        // Borrows the caller's reference. Each asynchronous host retains and releases
        // its own event and observation loans. The caller always releases its owner loan.
        // Return only after completion=1; propagate completion=-1 through the error path.
        void SubmitAndWait(IntPtr sealedPhysicalPacket);
        void SetPresentationSyncInterval(int count);

        // Resize/configure the actual host output before the source TLS packet begins.
        void PrepareDraw();

        // Called once after a successful source Present, never for intermediate uploads
        // or synchronous texture reads. The native Present has already applied cropping
        // and output scaling. Hosts can transfer that complete output to their renderer.
        void PresentCompleted();
    }
}
