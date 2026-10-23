using System;
using System.Numerics;
using Celeste.Simulation;

namespace Celeste.Simulation.Story.Events.Finale
{
    // The host side of the five EventTrigger cases. Each Add* builds the original
    // cutscene class for the currently tracked Player; the gates stay in
    // FarewellFinaleEvent so they run in the original order.
    public interface IFarewellFinaleHost
    {
        bool GetFlag(string flag);
        void AddFarewellReflection1();
        void AddFarewellReflection6(float targetX);
        void AddFarewellGrannyCutscene();
        void AddFarewellEnding();
        void EnterFarewellGoldenSnapshot();
    }
}
