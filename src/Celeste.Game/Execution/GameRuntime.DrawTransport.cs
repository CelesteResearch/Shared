using global::Celeste.Game.Execution.Startup;
using global::Celeste.Game.Execution;

namespace Celeste.Game.Execution
{
    public partial class GameRuntime
    {
        protected override bool BeginDraw()
        {
            bool accepted = base.BeginDraw();
            if (accepted) ((IOriginalCelesteDrawTransportEnvironment)Process).BeginAcceptedSourceDraw();
            return accepted;
        }
    }
}
