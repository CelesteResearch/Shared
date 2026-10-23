using System;

namespace Celeste.Game.Presentation.Window
{
    public static class DisplayWindowScale
    {
        public static int Maximum(int screenWidth, int screenHeight)
        {
            return Math.Min(screenWidth / 320, screenHeight / 180);
        }

        public static int Clamp(int scale, int maximum)
        {
            return Math.Max(3, Math.Min(10, Math.Min(scale, maximum)));
        }
    }
}
