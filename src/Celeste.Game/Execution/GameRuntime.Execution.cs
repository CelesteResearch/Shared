using System;
using Celeste.Core.Framework.Components;
using Celeste.Game.Execution.Engine.Rendering;
using Celeste.Game.Execution.Engine.Update;

namespace Celeste.Game.Execution
{
    public partial class GameRuntime
    {
        private OriginalCelesteUpdate actualUpdate;
        private OriginalCelesteDraw actualDraw;
        private IOriginalCelesteFrameLifecycle actualFrameLifecycle;

        public void BindSourceFrameExecution(OriginalCelesteUpdate update,
            OriginalCelesteDraw draw, IOriginalCelesteFrameLifecycle lifecycle)
        {
            if (actualUpdate != null)
                throw new InvalidOperationException("The actual Celeste frame execution is already bound.");
            if (update == null) throw new ArgumentNullException(nameof(update));
            if (draw == null) throw new ArgumentNullException(nameof(draw));
            if (lifecycle == null) throw new ArgumentNullException(nameof(lifecycle));
            actualDraw = draw;
            actualFrameLifecycle = lifecycle;
            actualUpdate = update;
        }

        protected override void Update(SourceGameTime gameTime)
        {
            if (actualUpdate == null)
                throw new InvalidOperationException("Bind the actual Celeste frame before running Game.Tick.");
            actualFrameLifecycle.BeginSourceFrame();
            try
            {
                actualUpdate.Update(gameTime);
                actualFrameLifecycle.CompleteSourceFrame();
            }
            catch
            {
                actualFrameLifecycle.AbortSourceFrame();
                GameLoop.Exit();
                throw;
            }
        }

        protected override void Draw(SourceGameTime gameTime)
        {
            if (actualDraw == null)
                throw new InvalidOperationException("Bind the actual Celeste draw before running Game.Tick.");
            actualDraw.Draw(gameTime);
        }
    }
}
