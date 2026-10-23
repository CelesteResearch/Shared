using Celeste.Game.Execution.Startup;

namespace Celeste.Game.Execution
{
    public partial class GameRuntime
    {
        protected override void LoadContent()
        {
            base.LoadContent();
            ((IOriginalLoadContentEnvironment)Process).SourceLoadContent.LoadContent();
        }

        protected override void UnloadContent()
        {
            base.UnloadContent();
            ((IOriginalLoadContentEnvironment)Process).SourceLoadContent.UnloadContent();
        }
    }
}
