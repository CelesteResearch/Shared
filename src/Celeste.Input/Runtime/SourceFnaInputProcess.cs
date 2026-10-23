using System;
using Celeste.Core.Mathematics;
using Celeste.Input.Devices.Mouse;
using Celeste.Input.Devices.Touch;

namespace Celeste.Input.Runtime
{
    public class SourceFnaInputProcess : ISourceGraphicsDeviceInputMetrics, ISourceWindowInputMetrics
    {
        public SourceFnaMouse Mouse { get; }
        public SourceFnaTouchPanel TouchPanel { get; }

        public SourceFnaInputProcess(ISourceSDLMouseTouchDevice device, ISourceFnaInputClock clock,
            ISourceVectorArithmetic arithmetic, bool supportsGlobalMouse)
        {
            var platform = new SourceSDLMouseTouchPlatform(device, supportsGlobalMouse);
            Mouse = new(platform);
            TouchPanel = new(platform, clock, arithmetic);
        }

        public void OnMouseButtonDown(byte button)
        {
            Mouse.INTERNAL_onClicked(button - 1);
        }

        public void OnMouseWheel(int y)
        {
            Mouse.INTERNAL_MouseWheel = unchecked(Mouse.INTERNAL_MouseWheel + unchecked(y * 120));
        }

        public void OnFingerDown(long fingerId, float x, float y)
        {
            TouchPanel.TouchDeviceExists = true;
            TouchPanel.INTERNAL_onTouchEvent(unchecked((int)fingerId), SourceTouchLocationState.Pressed, x, y, 0f, 0f);
        }

        public void OnFingerMotion(long fingerId, float x, float y, float dx, float dy)
        {
            TouchPanel.INTERNAL_onTouchEvent(unchecked((int)fingerId), SourceTouchLocationState.Moved, x, y, dx, dy);
        }

        public void OnFingerUp(long fingerId, float x, float y)
        {
            TouchPanel.INTERNAL_onTouchEvent(unchecked((int)fingerId), SourceTouchLocationState.Released, x, y, 0f, 0f);
        }

        public void UpdateTouchPanel()
        {
            TouchPanel.Update();
        }

        public int MouseBackBufferWidth
        {
            get => Mouse.INTERNAL_BackBufferWidth;
            set => Mouse.INTERNAL_BackBufferWidth = value;
        }

        public int MouseBackBufferHeight
        {
            get => Mouse.INTERNAL_BackBufferHeight;
            set => Mouse.INTERNAL_BackBufferHeight = value;
        }

        public int TouchDisplayWidth
        {
            get => TouchPanel.DisplayWidth;
            set => TouchPanel.DisplayWidth = value;
        }

        public int TouchDisplayHeight
        {
            get => TouchPanel.DisplayHeight;
            set => TouchPanel.DisplayHeight = value;
        }

        public IntPtr MouseWindowHandle
        {
            get => Mouse.WindowHandle;
            set => Mouse.WindowHandle = value;
        }

        public IntPtr TouchWindowHandle
        {
            get => TouchPanel.WindowHandle;
            set => TouchPanel.WindowHandle = value;
        }

        public int MouseWindowWidth
        {
            get => Mouse.INTERNAL_WindowWidth;
            set => Mouse.INTERNAL_WindowWidth = value;
        }

        public int MouseWindowHeight
        {
            get => Mouse.INTERNAL_WindowHeight;
            set => Mouse.INTERNAL_WindowHeight = value;
        }
    }
}
