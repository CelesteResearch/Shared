namespace Celeste.Game.Gameplay.Collectibles.Refills
{
    public static partial class RefillPresentation
    {
        public static IRefillPresentationBinding BindPresentation<TPhases>(IOriginalRefillProcess engine,
            in TPhases phases)
            where TPhases : struct, IRefillPresentationPhases
            => engine is IRefillPresentationBinder binder
                ? binder.Bind(in phases)
                : new DefaultBinding<TPhases>(engine, in phases);

        private sealed class DefaultBinding<TPhases> : IRefillPresentationBinding
            where TPhases : struct, IRefillPresentationPhases
        {
            private readonly DefaultRefillPresentationContext context;
            private TPhases phases;

            public DefaultBinding(IOriginalRefillProcess engine, in TPhases phases)
            {
                context = new(engine);
                this.phases = phases;
            }

            public void Update() => UpdatePresentation(in context, ref phases);
        }
    }
}
