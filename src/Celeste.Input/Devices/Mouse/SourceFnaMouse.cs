using System;
using Celeste.Core.Display;

namespace Celeste.Input.Devices.Mouse
{
    public class SourceFnaMouse
    {
        private readonly SourceSDLMouseTouchPlatform platform;

        internal SourceFnaMouse(SourceSDLMouseTouchPlatform platform)
        {
            this.platform = platform;
        }

        public int INTERNAL_WindowWidth = SourceDisplayDefaults.BackBufferWidth;

        public int INTERNAL_WindowHeight = SourceDisplayDefaults.BackBufferHeight;

        public int INTERNAL_BackBufferWidth = SourceDisplayDefaults.BackBufferWidth;

        public int INTERNAL_BackBufferHeight = SourceDisplayDefaults.BackBufferHeight;

        public int INTERNAL_MouseWheel = 0;

        public Action<int> ClickedEXT;

        public IntPtr WindowHandle { get; set; }

        public bool IsRelativeMouseModeEXT
        {
            get => platform.GetRelativeMouseMode();
            set => platform.SetRelativeMouseMode(value);
        }

        public SourceMouseState GetState()
        {
            platform.GetMouseState(WindowHandle, out var x, out var y, out var left, out var middle, out var right,
                out var x2, out var x3);
            x = (int)(x * (double)INTERNAL_BackBufferWidth / INTERNAL_WindowWidth);
            y = (int)(y * (double)INTERNAL_BackBufferHeight / INTERNAL_WindowHeight);
            return new(x, y, INTERNAL_MouseWheel, left, middle, right, x2, x3);
        }

        public void SetPosition(int x, int y)
        {
            if (!IsRelativeMouseModeEXT)
            {
                x = (int)(x * (double)INTERNAL_WindowWidth / INTERNAL_BackBufferWidth);
                y = (int)(y * (double)INTERNAL_WindowHeight / INTERNAL_BackBufferHeight);
                platform.SetMousePosition(WindowHandle, x, y);
            }
        }

        internal void INTERNAL_onClicked(int button)
        {
            if (ClickedEXT != null) ClickedEXT(button);
        }
    }
}
