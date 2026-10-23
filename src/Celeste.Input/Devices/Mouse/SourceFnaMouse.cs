using System;

namespace Celeste.Input.Devices.Mouse
{
    public class SourceFnaMouse
    {
        private readonly SourceSDLMouseTouchPlatform platform;

        internal SourceFnaMouse(SourceSDLMouseTouchPlatform platform)
        {
            this.platform = platform;
        }

        public int INTERNAL_WindowWidth = global::Celeste.Core.Display.SourceDisplayDefaults.BackBufferWidth;

        public int INTERNAL_WindowHeight = global::Celeste.Core.Display.SourceDisplayDefaults.BackBufferHeight;

        public int INTERNAL_BackBufferWidth = global::Celeste.Core.Display.SourceDisplayDefaults.BackBufferWidth;

        public int INTERNAL_BackBufferHeight = global::Celeste.Core.Display.SourceDisplayDefaults.BackBufferHeight;

        public int INTERNAL_MouseWheel = 0;

        public Action<int> ClickedEXT;

        public IntPtr WindowHandle { get; set; }

        public bool IsRelativeMouseModeEXT
        {
            get { return platform.GetRelativeMouseMode(); }
            set { platform.SetRelativeMouseMode(value); }
        }

        public SourceMouseState GetState()
        {
            platform.GetMouseState(WindowHandle, out var x, out var y, out var left, out var middle, out var right,
                out var x2, out var x3);
            x = (int)((double)x * (double)INTERNAL_BackBufferWidth / (double)INTERNAL_WindowWidth);
            y = (int)((double)y * (double)INTERNAL_BackBufferHeight / (double)INTERNAL_WindowHeight);
            return new SourceMouseState(x, y, INTERNAL_MouseWheel, left, middle, right, x2, x3);
        }

        public void SetPosition(int x, int y)
        {
            if (!IsRelativeMouseModeEXT)
            {
                x = (int)((double)x * (double)INTERNAL_WindowWidth / (double)INTERNAL_BackBufferWidth);
                y = (int)((double)y * (double)INTERNAL_WindowHeight / (double)INTERNAL_BackBufferHeight);
                platform.SetMousePosition(WindowHandle, x, y);
            }
        }

        internal void INTERNAL_onClicked(int button)
        {
            if (ClickedEXT != null)
            {
                ClickedEXT(button);
            }
        }
    }
}
