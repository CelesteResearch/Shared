using System;

namespace Celeste.Simulation.Runtime.FramePacing
{
    // One fixed outer update can contain several complete game updates. The budget is read
    // after each preceding outer update, because a breakpoint or scene change can alter it.
    // This runner has no TAS dependency and is also usable by the ordinary engine clock.
    public interface IFixedFramePacerPort
    {
        int FrameBudget();
        bool BeginFrame();
        bool StepFrame();
        bool DrainFreezeFrame();
        bool HandleStepFailure(Exception error);
    }
}
