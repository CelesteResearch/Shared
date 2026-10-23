using Celeste.Core.Components;
using Celeste.Core.Scheduling;
using Celeste.Game.Execution.Processes;
using Celeste.Graphics.Animation;

namespace Celeste.Game.Stories.Farewell.Effects
{
    public class OriginalGrannyLaughSfxState : SourceComponentState
    {
        public bool FirstPlay;

        private Sprite sprite;

        private bool ready = true;

        private readonly ISourceEngineContext engine;

        public OriginalGrannyLaughSfxState(ISourceEngineContext engine, Sprite sprite)
            : base(true, false)
        {
            this.engine = engine;
            this.sprite = sprite;
        }

        public override void Update()
        {
            if (sprite.CurrentAnimationID == "laugh" && sprite.CurrentAnimationFrame == 0 && ready)
            {
                if (FirstPlay)
                {
                    ((IOriginalGameplayProcess)engine).AudioSession.Play("event:/char/granny/laugh_firstphrase",
                        ((ISourceEntityPosition)Entity).Position, ((IOriginalGameplayProcess)engine).SaveContext);
                }
                else
                {
                    ((IOriginalGameplayProcess)engine).AudioSession.Play("event:/char/granny/laugh_oneha",
                        ((ISourceEntityPosition)Entity).Position, ((IOriginalGameplayProcess)engine).SaveContext);
                }

                ready = false;
            }

            if (!FirstPlay && (sprite.CurrentAnimationID != "laugh" || sprite.CurrentAnimationFrame > 0))
            {
                ready = true;
            }
        }
    }
}
