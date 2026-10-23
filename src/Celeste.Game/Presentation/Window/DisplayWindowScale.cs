using System;
using Celeste.Simulation;

namespace Celeste.Game.Presentation.Window
{
    public static class DisplayWindowScale
    {
        public static int Maximum(int screenWidth, int screenHeight)
            => Math.Min(screenWidth / 320, screenHeight / 180);

        public static int Clamp(int scale, int maximum)
            => Math.Max(3, Math.Min(10, Math.Min(scale, maximum)));
    }
}
