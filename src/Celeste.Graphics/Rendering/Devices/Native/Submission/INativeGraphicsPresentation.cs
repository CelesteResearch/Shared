using System;
using Celeste.Graphics.Rendering.Devices;

namespace Celeste.Graphics.Rendering.Devices.Native.Submission;

public interface INativeGraphicsPresentation
{
    void PrepareDraw();
    void SetPresentationInterval(SourcePresentInterval interval);
    IntPtr AcquireOutput(IntPtr device);
    void PresentCompleted();
}
