namespace Celeste.Game.Gameplay.Collectibles.Refills
{
    public static partial class RefillPresentation
    {
        private readonly struct IdentityReturnSound : IRefillReturnSound
        {
            public string Resolve(string defaultSound) => defaultSound;
        }
    }
}
