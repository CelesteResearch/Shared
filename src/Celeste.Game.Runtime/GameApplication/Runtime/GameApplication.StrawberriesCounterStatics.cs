using System;
using Celeste.Game.Presentation.Hud.Counters;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : IStrawberriesCounterStaticEnvironment
    {
        private StrawberriesCounterStaticState sourceStrawberriesCounterStatics;

        public StrawberriesCounterStaticState StrawberriesCounterStatics => sourceStrawberriesCounterStatics ??
                                                                            throw new InvalidOperationException(
                                                                                "The source strawberries counter fields are not published.");

        public void InitializeSourceStrawberriesCounterStatics()
        {
            if (sourceStrawberriesCounterStatics != null)
                throw new InvalidOperationException("The source strawberries counter fields are already published.");
            sourceStrawberriesCounterStatics = new StrawberriesCounterStaticState();
        }
    }
}
