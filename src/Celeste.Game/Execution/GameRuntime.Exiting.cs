using System;
using Celeste.Game.Execution.Startup;

namespace Celeste.Game.Execution
{
    public partial class GameRuntime
    {
        public void InvokeSourceOnExiting(object sender, EventArgs args)
        {
            OnExiting(sender, args);
        }

        protected override void OnExiting(object sender, EventArgs args)
        {
            base.OnExiting(sender, args);
            ((IOriginalCelesteExitingEnvironment)Process).AfterSourceGameExiting();
        }
    }
}
