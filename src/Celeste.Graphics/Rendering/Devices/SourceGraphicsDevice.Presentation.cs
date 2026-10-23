using System;
using Celeste.Core.Geometry;
using Celeste.Core.Rendering;

namespace Celeste.Graphics.Rendering.Devices
{
    public partial class SourceGraphicsDevice
    {
        public event EventHandler<EventArgs> DeviceResetting;
        public event EventHandler<EventArgs> DeviceReset;

        public void Present()
        {
            PhysicalIO.SwapBuffers(IntPtr.Zero, IntPtr.Zero, PresentationParameters.DeviceWindowHandle);
        }

        public void Present(IntRect? sourceRectangle, IntRect? destinationRectangle, IntPtr overrideWindowHandle)
        {
            if (overrideWindowHandle == IntPtr.Zero) overrideWindowHandle = PresentationParameters.DeviceWindowHandle;

            if (sourceRectangle.HasValue && destinationRectangle.HasValue)
            {
                var sourceRectangle2 = sourceRectangle.Value;
                var destinationRectangle2 = destinationRectangle.Value;
                PhysicalIO.SwapBuffers(ref sourceRectangle2, ref destinationRectangle2, overrideWindowHandle);
            }
            else if (sourceRectangle.HasValue)
            {
                var sourceRectangle3 = sourceRectangle.Value;
                PhysicalIO.SwapBuffers(ref sourceRectangle3, IntPtr.Zero, overrideWindowHandle);
            }
            else if (destinationRectangle.HasValue)
            {
                var destinationRectangle3 = destinationRectangle.Value;
                PhysicalIO.SwapBuffers(IntPtr.Zero, ref destinationRectangle3, overrideWindowHandle);
            }
            else
            {
                PhysicalIO.SwapBuffers(IntPtr.Zero, IntPtr.Zero, overrideWindowHandle);
            }
        }

        public void Reset()
        {
            Reset(PresentationParameters, Adapter);
        }

        public void Reset(SourcePresentationParameters presentationParameters)
        {
            Reset(presentationParameters, Adapter);
        }

        public void Reset(SourcePresentationParameters presentationParameters, SourceGraphicsAdapter graphicsAdapter)
        {
            if (presentationParameters == null) throw new ArgumentNullException("presentationParameters");

            PresentationParameters = presentationParameters;
            Adapter = graphicsAdapter;
            PresentationParameters.MultiSampleCount = TextureIO.GetMaxMultiSampleCount(
                PresentationParameters.BackBufferFormat,
                SourceMultisampleMath.ClosestMSAAPower(PresentationParameters.MultiSampleCount));
            if (DeviceResetting != null) DeviceResetting(this, EventArgs.Empty);

            PhysicalIO.ResetBackbuffer(ref PresentationParameters.parameters);
            inputMetrics.MouseBackBufferWidth = PresentationParameters.BackBufferWidth;
            inputMetrics.MouseBackBufferHeight = PresentationParameters.BackBufferHeight;
            inputMetrics.TouchDisplayWidth = PresentationParameters.BackBufferWidth;
            inputMetrics.TouchDisplayHeight = PresentationParameters.BackBufferHeight;
            Viewport = new(0, 0, PresentationParameters.BackBufferWidth,
                PresentationParameters.BackBufferHeight);
            ScissorRectangle = new(0, 0, PresentationParameters.BackBufferWidth,
                PresentationParameters.BackBufferHeight);
            if (DeviceReset != null) DeviceReset(this, EventArgs.Empty);
        }
    }
}
