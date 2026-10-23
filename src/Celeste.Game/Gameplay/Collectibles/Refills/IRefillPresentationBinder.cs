namespace Celeste.Game.Gameplay.Collectibles.Refills
{
    public interface IRefillPresentationBinder
    {
        IRefillPresentationBinding Bind<TPhases>(in TPhases phases)
            where TPhases : struct, IRefillPresentationPhases;
    }
}
