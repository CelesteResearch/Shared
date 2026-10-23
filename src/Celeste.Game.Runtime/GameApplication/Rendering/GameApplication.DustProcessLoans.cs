using System;
using Celeste.Core.Threading;
using Celeste.Simulation.Gameplay.Hazards.Spinners.Dust;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : ISourceDustProcessEnvironment
    {
        private SourceTypeInitialization<SourceDustProcessState> sourceDustProcessInitialization;

        SourceDustProcessState ISourceDustProcessEnvironment.DustProcess => (sourceDustProcessInitialization ??
                                                                             throw new InvalidOperationException(
                                                                                 "The actual dust edges type initialization has not been constructed."))
            .Value;

        bool ISourceDustProcessEnvironment.Invincible => SaveContext.CurrentSave.Assists.Invincible;

        internal void ConstructSourceDustProcessTypeInitialization()
        {
            if (sourceDustProcessInitialization != null)
                throw new InvalidOperationException(
                    "The actual dust edges type initialization is already constructed.");
            sourceDustProcessInitialization = new(
                "Celeste.DustEdges", new DustProcessSourceTypeInitialization());
        }

        private sealed class
            DustProcessSourceTypeInitialization : ISourceTypeInitializationFactory<SourceDustProcessState>
        {
            public SourceDustProcessState Allocate()
            {
                return new();
            }

            // DustEdges has only the zero-initialized counter; there is no remaining initializer body.
            public void Initialize(SourceDustProcessState instance)
            {
            }
        }
    }
}
