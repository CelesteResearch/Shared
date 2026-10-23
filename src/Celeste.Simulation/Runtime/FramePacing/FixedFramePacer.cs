using System;
using Celeste.Simulation;

namespace Celeste.Simulation.Runtime.FramePacing
{
    public static class FixedFramePacer
    {
        public static void Run(int outerUpdates,
            global::Celeste.Simulation.Runtime.FramePacing.IFixedFramePacerPort port)
        {
            if (outerUpdates < 0) throw new ArgumentOutOfRangeException(nameof(outerUpdates));
            if (port == null) throw new ArgumentNullException(nameof(port));
            for (int outer = 0; outer < outerUpdates; outer++)
            {
                int budget = port.FrameBudget();
                if (budget < 0) throw new InvalidOperationException("A frame budget cannot be negative.");
                for (int frame = 0; frame < budget; frame++)
                    if (!RunFrame(port))
                        return;
                while (port.DrainFreezeFrame())
                    if (!RunFrame(port))
                        return;
            }
        }

        private static bool RunFrame(global::Celeste.Simulation.Runtime.FramePacing.IFixedFramePacerPort port)
        {
            if (!port.BeginFrame()) return false;
            try
            {
                return port.StepFrame();
            }
            catch (Exception error)
            {
                if (port.HandleStepFailure(error)) return false;
                throw;
            }
        }
    }
}
