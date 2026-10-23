using System;
using Celeste.Core.Threading;
using Celeste.Game.Presentation.Effects.Dust;
using Celeste.Simulation.Gameplay.Hazards.Spinners.Dust;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : ISourceDustStyleEnvironment
    {
        private SourceTypeInitialization<OriginalDustStyleProvider> sourceDustStyleInitialization;

        public IDustStyleProvider DustStyles => (sourceDustStyleInitialization ??
                                                 throw new InvalidOperationException(
                                                     "The actual dust style type initialization has not been constructed."))
            .Value;

        internal void ConstructSourceDustStyleTypeInitialization()
        {
            if (sourceDustStyleInitialization != null)
                throw new InvalidOperationException(
                    "The actual dust style type initialization is already constructed.");
            sourceDustStyleInitialization = new SourceTypeInitialization<OriginalDustStyleProvider>(
                "Celeste.DustStyles", new DustStyleSourceTypeInitialization());
        }

        private sealed class
            DustStyleSourceTypeInitialization : ISourceTypeInitializationFactory<OriginalDustStyleProvider>
        {
            // The complete original dictionary initializer executes in this one source constructor.
            public OriginalDustStyleProvider Allocate() => new OriginalDustStyleProvider();

            // There is no second initializer body after the source constructor's field initializers.
            public void Initialize(OriginalDustStyleProvider instance)
            {
            }
        }
    }
}
