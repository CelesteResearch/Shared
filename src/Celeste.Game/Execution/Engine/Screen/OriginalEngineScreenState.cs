using System;
using Celeste.Core.Framework.Graphics;

namespace Celeste.Game.Execution.Engine.Screen
{
    public sealed class OriginalEngineScreenState
    {
        public bool Resizing;
        private readonly ISourceScreenGraphicsManager graphics;

        public OriginalEngineScreenState(ISourceScreenGraphicsManager actualGraphics)
        {
            graphics = actualGraphics;
        }

        public void SetWindowed(int width, int height)
        {
            if (width > 0 && height > 0)
            {
                Resizing = true;
                graphics.PreferredBackBufferWidth = width;
                graphics.PreferredBackBufferHeight = height;
                graphics.IsFullScreen = false;
                graphics.ApplyChanges();
                Console.WriteLine("WINDOW-" + width + "x" + height);
                Resizing = false;
            }
        }

        public void SetFullscreen()
        {
            Resizing = true;
            graphics.PreferredBackBufferWidth = graphics.GraphicsDevice.Adapter.CurrentDisplayMode.Width;
            graphics.PreferredBackBufferHeight = graphics.GraphicsDevice.Adapter.CurrentDisplayMode.Height;
            graphics.IsFullScreen = true;
            graphics.ApplyChanges();
            Console.WriteLine("FULLSCREEN");
            Resizing = false;
        }
    }
}
