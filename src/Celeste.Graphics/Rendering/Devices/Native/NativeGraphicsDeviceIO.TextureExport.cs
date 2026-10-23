using System;
using Celeste.Graphics.Rendering.Devices.Native.Submission;

namespace Celeste.Graphics.Rendering.Devices.Native;

public unsafe partial class NativeGraphicsDeviceIO
{
    public void ReleaseTextureExportOutput(IntPtr output) => api->ReleaseOutput(output);

    /// <summary>Copies textures into borrowed output images in one host submission.</summary>
    public void ExportTextures(ReadOnlySpan<IntPtr> textures, ReadOnlySpan<IntPtr> outputs,
        INativeTextureExportBatch batch)
    {
        if (batch == null) throw new ArgumentNullException(nameof(batch));
        if (textures.Length != outputs.Length)
            throw new ArgumentException("Texture and output counts must match.", nameof(outputs));
        if (textures.Length == 0) return;
        if (device == IntPtr.Zero)
            throw new InvalidOperationException("The Native graphics device is not initialized.");
        bool resume = packet != IntPtr.Zero && !transferOnlyPacket;
        // The active game packet belongs to its original host outputs, never this batch.
        FlushPhysicalPrefix(false);
        try
        {
            BeforeDraw();
            for (int i = 0; i < textures.Length; i++)
                RequireSuccess(api->Present(packet, textures[i], outputs[i], null, null));
            IntPtr completed = packet;
            packet = IntPtr.Zero;
            try
            {
                batch.Submit(completed);
            }
            finally
            {
                api->ReleasePacket(completed);
            }

            if (resume) BeforeDraw();
        }
        catch
        {
            AbortUnsubmittedPhysicalPrefix();
            throw;
        }
    }
}
