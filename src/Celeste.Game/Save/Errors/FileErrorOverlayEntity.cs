using System.Collections;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Game.Content.Dialogs;
using Celeste.Game.Execution.Processes;
using Celeste.Scene.Tracking;
using Celeste.Simulation.Presentation.Hud.Overlays;
using Celeste.Simulation.Presentation.Hud.Saving;
using Celeste.Simulation.UI.Menus.Text;

namespace Celeste.Game.Save.Errors
{
    public sealed class FileErrorOverlayEntity : OverlayPresentation
    {
        public enum Error
        {
            Load,
            Save
        }

        private readonly Error mode;
        private TextMenuPresentation menu;
        public bool Open { get; private set; }
        public bool TryAgain { get; private set; }
        public bool Ignore { get; private set; }

        public FileErrorOverlayEntity(Error mode, ISourceEngineContext engine) : base(engine)
        {
            Open = true;
            this.mode = mode;
            OwnedComponents.Add(new SimulationCoroutine(engine, Routine()));
            ((ISourceScene)engine.Frame.Scenes.CurrentScene).SourceScene.QueueSourceEntity(this);
        }

        private IEnumerator Routine()
        {
            yield return FadeIn();
            bool waiting = true;
            int option = 0;
            ((IOriginalGameplayProcess)EngineContext).AudioSession.Play("event:/ui/main/message_confirm");
            menu = new TextMenuPresentation(EngineContext);
            menu.Add(new TextMenuPresentation.Header(Clean("savefailed_title")));
            menu.Add(new TextMenuPresentation.Button(
                    Clean(mode == Error.Save ? "savefailed_retry" : "loadfailed_goback"))
                .Pressed(() =>
                {
                    option = 0;
                    waiting = false;
                }));
            menu.Add(new TextMenuPresentation.Button(Clean("savefailed_ignore")).Pressed(() =>
            {
                option = 1;
                waiting = false;
            }));
            while (waiting) yield return null;
            menu = null;
            Ignore = option == 1;
            TryAgain = option == 0;
            yield return FadeOut();
            Open = false;
            RemoveSelf();
        }

        private string Clean(string key) => ((IOriginalGameTextEnvironment)EngineContext).Text.CleanDialog(key);

        public override void Update()
        {
            base.Update();
            if (menu != null) menu.Update();
            var icons = ((ISaveLoadIconEnvironment)EngineContext).SaveLoadIconProcess;
            if (icons.Instance != null && icons.Instance.Scene == Scene)
                icons.Instance.Update();
        }

        public override void Render(ISourceRenderContext context)
        {
            RenderFade(context);
            if (menu != null) menu.Render(context);
            base.Render(context);
        }
    }
}
