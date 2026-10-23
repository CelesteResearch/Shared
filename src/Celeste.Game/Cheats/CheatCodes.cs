namespace Celeste.Game.Cheats
{
    /// <summary>
    ///     The one code this port registers, kept in the pure layer so the differential and the host
    ///     provably use the same string.
    ///     Celeste/UnlockEverythingThingy.cs:17 <c>AddCheat("lrLRuudlRA", EnteredCheat)</c>.
    /// </summary>
    public static class CheatCodes
    {
        public const string UnlockEverything = "lrLRuudlRA"; // UnlockEverythingThingy.cs:17
    }
}
