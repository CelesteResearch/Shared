namespace Celeste.Simulation
{
    public static class OriginalSceneTags
    {
        public const int None = 0;
        public const int PauseUpdate = 1;
        public const int FrozenUpdate = 2;
        public const int TransitionUpdate = 4;
        public const int HUD = 8;
        public const int Persistent = 16;
        public const int Global = 32;
        public const int SubHUD = 64;
        public const int FreezeFrameUpdate = 128;
    }
}
