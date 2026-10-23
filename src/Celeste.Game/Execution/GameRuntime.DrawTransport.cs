using Celeste.Game.Execution.Startup;

namespace Celeste.Game.Execution
{
    public partial class GameRuntime
    {
        protected override bool BeginDraw()
        {
            var accepted = base.BeginDraw();
            if (accepted) ((IOriginalCelesteDrawTransportEnvironment)Process).BeginAcceptedSourceDraw();
            return accepted;
        }
    }
}
