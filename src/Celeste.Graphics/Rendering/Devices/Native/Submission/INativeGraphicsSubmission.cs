using System;
using Celeste.Graphics.Rendering.Devices;

namespace Celeste.Graphics.Rendering.Devices.Native.Submission;

public interface INativeGraphicsSubmission
{
    // Returns an owned backend device or a backend wrapper around a borrowed device.
    IntPtr AcquireDevice();
    void ReleaseDevice(IntPtr device);
    void PrepareDraw();

    void SetPresentationInterval(SourcePresentInterval interval);

    // One output loan per presentation; the caller releases it after packet submission.
    IntPtr AcquireOutput(IntPtr device);

    // Borrows packet. Ordinary submission must not wait for GPU idle. Synchronous
    // readback requires completion; borrowed hosts must submit/complete their own buffer.
    void Submit(IntPtr packet, bool waitForCompletion);
    void PresentCompleted();
}
