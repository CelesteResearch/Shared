using System;
using Celeste.Core.Geometry;
using Celeste.Core.Rendering;
using Celeste.Graphics.Geometry.TwoD.Camera;

namespace Celeste.Graphics.Rendering.Devices
{
    public partial class SourceGraphicsDevice
    {
        public event EventHandler<EventArgs> DeviceResetting;
        public event EventHandler<EventArgs> DeviceReset;

        public void Present()
        {
            deviceIO.SwapBuffers(IntPtr.Zero, IntPtr.Zero, PresentationParameters.DeviceWindowHandle);
        }

        public void Present(IntRect? sourceRectangle, IntRect? destinationRectangle, IntPtr overrideWindowHandle)
        {
            if (overrideWindowHandle == IntPtr.Zero)
            {
                overrideWindowHandle = PresentationParameters.DeviceWindowHandle;
            }

            if (sourceRectangle.HasValue && destinationRectangle.HasValue)
            {
                IntRect sourceRectangle2 = sourceRectangle.Value;
                IntRect destinationRectangle2 = destinationRectangle.Value;
                deviceIO.SwapBuffers(ref sourceRectangle2, ref destinationRectangle2, overrideWindowHandle);
            }
            else if (sourceRectangle.HasValue)
            {
                IntRect sourceRectangle3 = sourceRectangle.Value;
                deviceIO.SwapBuffers(ref sourceRectangle3, IntPtr.Zero, overrideWindowHandle);
            }
            else if (destinationRectangle.HasValue)
            {
                IntRect destinationRectangle3 = destinationRectangle.Value;
                deviceIO.SwapBuffers(IntPtr.Zero, ref destinationRectangle3, overrideWindowHandle);
            }
            else
            {
                deviceIO.SwapBuffers(IntPtr.Zero, IntPtr.Zero, overrideWindowHandle);
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
            if (presentationParameters == null)
            {
                throw new ArgumentNullException("presentationParameters");
            }

            PresentationParameters = presentationParameters;
            Adapter = graphicsAdapter;
            PresentationParameters.MultiSampleCount = TextureIO.GetMaxMultiSampleCount(
                PresentationParameters.BackBufferFormat,
                SourceMultisampleMath.ClosestMSAAPower(PresentationParameters.MultiSampleCount));
            if (this.DeviceResetting != null)
            {
                this.DeviceResetting(this, EventArgs.Empty);
            }

            deviceIO.ResetBackbuffer(ref PresentationParameters.parameters);
            inputMetrics.MouseBackBufferWidth = PresentationParameters.BackBufferWidth;
            inputMetrics.MouseBackBufferHeight = PresentationParameters.BackBufferHeight;
            inputMetrics.TouchDisplayWidth = PresentationParameters.BackBufferWidth;
            inputMetrics.TouchDisplayHeight = PresentationParameters.BackBufferHeight;
            Viewport = new CameraViewport(0, 0, PresentationParameters.BackBufferWidth,
                PresentationParameters.BackBufferHeight);
            ScissorRectangle = new IntRect(0, 0, PresentationParameters.BackBufferWidth,
                PresentationParameters.BackBufferHeight);
            if (this.DeviceReset != null)
            {
                this.DeviceReset(this, EventArgs.Empty);
            }
        }
    }
}
