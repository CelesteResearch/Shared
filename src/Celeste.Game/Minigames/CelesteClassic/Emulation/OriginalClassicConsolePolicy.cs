namespace Celeste.Game.Minigames.CelesteClassic.Emulation
{
    public sealed class OriginalClassicConsolePolicy : IOriginalClassicConsolePolicy
    {
        public void AfterConstructor(ClassicConsoleRuntime emulator)
        {
            // Original Emulator has no post-constructor tilemap replacement.
        }
    }
}
