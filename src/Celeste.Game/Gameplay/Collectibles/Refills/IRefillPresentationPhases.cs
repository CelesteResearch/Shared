namespace Celeste.Game.Gameplay.Collectibles.Refills
{
    public interface IRefillPresentationPhases
    {
        void UpdateTimerAndGlow<TContext>(in TContext context)
            where TContext : struct, IRefillPresentationContext;

        void UpdateY();

        void UpdateLightAndFlash<TContext>(in TContext context)
            where TContext : struct, IRefillPresentationContext;
    }
}
