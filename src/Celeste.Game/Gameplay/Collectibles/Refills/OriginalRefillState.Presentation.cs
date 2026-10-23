using System.Runtime.CompilerServices;

namespace Celeste.Game.Gameplay.Collectibles.Refills
{
    public partial class OriginalRefillState
    {
        private readonly IRefillPresentationBinding presentation;

        private readonly struct PresentationPhases(OriginalRefillState owner) : IRefillPresentationPhases
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public void UpdateTimerAndGlow<TContext>(in TContext context)
                where TContext : struct, IRefillPresentationContext
                => RefillPresentation.UpdateTimerAndGlow(owner, owner.engine, owner.level, ref owner.respawnTimer,
                    owner.respawnAction, owner.p_glow);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public void UpdateY() => owner.UpdateY();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public void UpdateLightAndFlash<TContext>(in TContext context)
                where TContext : struct, IRefillPresentationContext
                => RefillPresentation.UpdateLighting(owner, in context, owner.sprite, owner.flash, owner.light,
                    owner.bloom);
        }
    }
}
