using System.Runtime.CompilerServices;

namespace Celeste.Game.Gameplay.Collectibles.Refills
{
    public static partial class RefillPresentation
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void UpdatePresentation<TContext, TPhases>(in TContext context, ref TPhases phases)
            where TContext : struct, IRefillPresentationContext
            where TPhases : struct, IRefillPresentationPhases
        {
            phases.UpdateTimerAndGlow(in context);
            phases.UpdateY();
            phases.UpdateLightAndFlash(in context);
        }
    }
}
