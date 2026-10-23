using System;
using Celeste.Simulation.Gameplay.Collectibles.Strawberry;
using Celeste.Simulation.Runtime.Session;

namespace Celeste.Simulation.Gameplay.Player.Death
{
    public interface ISourceGoldenBerryRestartScene
    {
        ChapterCompletionSession GoldenRestartSession { get; }

        Action CreateGoldenRestartAction(ChapterCompletionSession actualCapturedSession,
            ISourceStrawberryFollower actualGoldenBerry);
    }
}
