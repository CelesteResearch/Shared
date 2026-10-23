using System.Collections;
using System.Numerics;
using Celeste.Core.Display;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Game.Audio.Runtime;
using Celeste.Game.Content.Dialogs;
using Celeste.Game.Controls.Source;
using Celeste.Game.Execution.Graphics;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Menus.Options;
using Celeste.Game.Menus.Title;
using Celeste.Game.Save.Runtime;
using Celeste.Game.Settings;
using Celeste.Graphics.Content;
using Celeste.Graphics.Rendering;
using Celeste.Localization.Lookup;
using Celeste.Scene.Tracking;
using Celeste.Simulation.UI.Menus.Text;

namespace Celeste.Game.Menus.Overworld
{
    public class OptionsSequence : OuiState
    {
        protected readonly ISourceEngineContext engine;
        protected OriginalGameInputProcess Input => ((IOriginalGameInputProcessEnvironment)engine).InputSource;
        protected SettingsState Settings => ((ISettingsContext)engine).Settings;
        protected OriginalGameTextProcess Text => ((IOriginalGameTextEnvironment)engine).Text;

        protected OriginalGameGraphicsResources Graphics =>
            (OriginalGameGraphicsResources)((ISourceGameGraphicsEnvironment)engine).GameGraphics;

        protected DialogCatalog Dialog => Text.Dialog;

        protected OriginalGameAudioSession Audio =>
            ((IOriginalGameplayProcess)engine).AudioSession;

        private ISourceEasingArithmetic Ease => ((ISourceEasingEnvironment)engine).EasingArithmetic;

        public OptionsSequence(ISourceEngineContext engine) : base(engine)
        {
            this.engine = engine;
        }

        private TextMenuPresentation menu;

        private const float onScreenX = 960f;

        private const float offScreenX = 2880f;

        private string startLanguage;

        private string currentLanguage;

        private float alpha;

        public override void Added(object scene)
        {
            base.Added(scene);
        }

        private void ReloadMenu()
        {
            var position = Vector2.Zero;
            var num = -1;
            if (menu != null)
            {
                position = menu.Position;
                num = menu.Selection;
                ((ISourceScene)Scene).SourceScene.RemoveEntity(menu);
            }

            menu = ((IOriginalMenuOptionsEnvironment)engine).MenuOptions.Create();
            if (num >= 0)
            {
                menu.Selection = num;
                menu.Position = position;
            }

            ((ISourceScene)Scene).SourceScene.QueueSourceEntity(menu);
        }

        public override IEnumerator Enter(OuiState from)
        {
            ReloadMenu();
            var textMenu = menu;
            var ouiOptions = this;
            var visible = true;
            ouiOptions.Visible = true;
            textMenu.Visible = visible;
            menu.Focused = false;
            currentLanguage = startLanguage = Settings.LanguageId;
            for (var p = 0f; p < 1f; p += engine.DeltaTime * 4f)
            {
                menu.X = 2880f + -1920f * Ease.CubeOut(p);
                alpha = Ease.CubeOut(p);
                yield return null;
            }

            menu.Focused = true;
        }

        public override IEnumerator Leave(OuiState next)
        {
            Audio.Play("event:/ui/main/whoosh_large_out");
            menu.Focused = false;
            ((IOriginalUserIOEnvironment)engine).UserIO.SaveHandler(false,
                true);
            while (((IOriginalUserIOEnvironment)engine).UserIO.Saving) yield return null;

            for (var p = 0f; p < 1f; p += engine.DeltaTime * 4f)
            {
                menu.X = 960f + 1920f * Ease.CubeIn(p);
                alpha = 1f - Ease.CubeIn(p);
                yield return null;
            }

            if (startLanguage != Settings.LanguageId)
            {
                Overworld.ReloadMenus(OverworldStartMode.ReturnFromOptions);
                yield return null;
            }

            var textMenu = menu;
            var ouiOptions = this;
            var visible = false;
            ouiOptions.Visible = false;
            textMenu.Visible = visible;
            menu.RemoveSelf();
            menu = null;
        }

        public override void Update()
        {
            if (menu != null && menu.Focused && Selected && Input.MenuCancel.Pressed)
            {
                Audio.Play("event:/ui/main/button_back");
                Overworld.Goto<MainMenuSequence>();
            }

            if (Selected && currentLanguage != Settings.LanguageId)
            {
                currentLanguage = Settings.LanguageId;
                ReloadMenu();
            }

            base.Update();
        }

        public override void Render(ISourceRenderContext context)
        {
            if (alpha > 0f)
                SourcePrimitiveDrawing.Rect(context, this, -10f, -10f, 1940f, 1100f, PackedColor.Black * alpha * 0.4f);

            base.Render(context);
        }
    }
}
