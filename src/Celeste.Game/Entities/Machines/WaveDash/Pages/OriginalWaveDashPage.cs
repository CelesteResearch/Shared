using System.Collections;
using Celeste.Core.Display;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Game.Execution.Processes;
using Celeste.Input.Gameplay;

namespace Celeste.Game.Entities.Machines.WaveDash.Pages
{
    public abstract class OriginalWaveDashPage
    {
        protected readonly ISourceEngineContext engine;

        protected OriginalWaveDashPage(ISourceEngineContext engine)
        {
            this.engine = engine;
        }

        public enum Transitions
        {
            ScaleIn,
            FadeIn,
            Rotate3D,
            Blocky,
            Spiral,
        }

        public OriginalWaveDashPresentationState Presentation;

        public PackedColor ClearColor;

        public Transitions Transition;

        public bool AutoProgress;

        public bool WaitingForInput;

        public int Width => Presentation.ScreenWidth;

        public int Height => Presentation.ScreenHeight;

        public abstract IEnumerator Routine();

        public virtual void Added(OriginalWaveDashPresentationState presentation)
        {
            Presentation = presentation;
        }

        public virtual void Update()
        {
        }

        public virtual void Render(ISourceRenderContext context)
        {
        }

        protected IEnumerator PressButton()
        {
            WaitingForInput = true;
            while (!((ISourceGameInputEnvironment)engine).Input.MenuConfirm.Pressed) yield return null;

            WaitingForInput = false;
            ((IOriginalGameplayProcess)engine).AudioSession.Play("event:/new_content/game/10_farewell/ppt_mouseclick");
        }
    }
}
