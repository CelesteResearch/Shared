using Celeste.Graphics.Rendering.Devices.Native.Interop;
using Celeste.Graphics.Rendering.Devices.Native.Submission;
using System;
using Celeste.Graphics.Rendering.Devices;
using Celeste.Graphics.Direct3D12.Interop;

namespace Celeste.Graphics.Direct3D12.Submission;

public sealed unsafe class OwnedDirect3D12GraphicsSubmission : INativeGraphicsSubmission, IDisposable
{
    private readonly CelesteGraphicsDeviceApi* api;
    private readonly INativeGraphicsPresentation presentation;
    private IntPtr device;

    public OwnedDirect3D12GraphicsSubmission(CelesteDirect3D12OwnedDeviceInfo info,
        INativeGraphicsPresentation presentation)
    {
        this.presentation = presentation ?? throw new ArgumentNullException(nameof(presentation));
        api = Direct3D12Native.GetDeviceApi();
        Direct3D12Native.RequireSuccess(Direct3D12Native.CelesteDirect3D12CreateOwnedDevice(&info, out device));
    }

    public IntPtr AcquireDevice()
        => device != IntPtr.Zero
            ? device
            : throw new ObjectDisposedException(nameof(OwnedDirect3D12GraphicsSubmission));

    public void ReleaseDevice(IntPtr actualDevice)
    {
        if (actualDevice != device)
            throw new ArgumentException("The device belongs to a different Direct3D12 submission.",
                nameof(actualDevice));
        Dispose();
    }

    public void PrepareDraw() => presentation.PrepareDraw();

    public void SetPresentationInterval(SourcePresentInterval interval) =>
        presentation.SetPresentationInterval(interval);

    public IntPtr AcquireOutput(IntPtr actualDevice) => presentation.AcquireOutput(actualDevice);
    public void PresentCompleted() => presentation.PresentCompleted();

    public void Submit(IntPtr packet, bool waitForCompletion)
    {
        IntPtr submitted;
        Direct3D12Native.RequireSuccess(api->Submit(packet, &submitted));
        try
        {
            if (waitForCompletion) Direct3D12Native.RequireSuccess(api->Wait(submitted));
        }
        finally
        {
            api->ReleaseSubmission(submitted);
        }
    }

    public void Dispose()
    {
        if (device == IntPtr.Zero) return;
        Direct3D12Native.RequireSuccess(api->DestroyDevice(device));
        device = IntPtr.Zero;
    }
}
