using Celeste.Core.Display;
using System;
using System.Collections;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Scheduling;
using Celeste.Core.Rendering;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Mathematics.Easing;
using Celeste.Audio.Fmod.Events;
using Celeste.Input.Gameplay;
using Celeste.Game.Content.Dialogs;
using Celeste.Game.Controls.Source;
using Celeste.Game.Menus.Controls;
using Celeste.Game.Menus.Overworld;
using Celeste.Game.Execution.Engine;
using Celeste.Game.Execution.Graphics;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Execution.Startup;
using Celeste.Game.Settings;
using Celeste.Game.UI.Controls;
using Celeste.Scene.Entities;
using Celeste.Scene.Scenes;
using Celeste.Scene.Tracking;
using Celeste.Simulation.UI.Menus.Text;
using Celeste.Graphics.Content;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Display;
using Celeste.Graphics.Rendering;
using Celeste.Graphics.Text;
using DialogLanguage = Celeste.Localization.Languages.DialogLanguage;

namespace Celeste.Game.Menus.Overworld
{
    using Celeste.Game.Menus.Options;

    public class OptionsSequence : OuiState
    {
        protected readonly ISourceEngineContext engine;
        protected OriginalGameInputProcess Input => ((IOriginalGameInputProcessEnvironment)engine).InputSource;
        protected SettingsState Settings => ((ISettingsContext)engine).Settings;
        protected OriginalGameTextProcess Text => ((IOriginalGameTextEnvironment)engine).Text;

        protected OriginalGameGraphicsResources Graphics =>
            (OriginalGameGraphicsResources)((ISourceGameGraphicsEnvironment)engine).GameGraphics;

        protected Celeste.Localization.Lookup.DialogCatalog Dialog => Text.Dialog;

        protected Celeste.Game.Audio.Runtime.OriginalGameAudioSession Audio =>
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
            Vector2 position = Vector2.Zero;
            int num = -1;
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
            TextMenuPresentation textMenu = menu;
            OptionsSequence ouiOptions = this;
            bool visible = true;
            ouiOptions.Visible = true;
            textMenu.Visible = visible;
            menu.Focused = false;
            currentLanguage = (startLanguage = Settings.LanguageId);
            for (float p = 0f; p < 1f; p += engine.DeltaTime * 4f)
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
            ((Celeste.Game.Save.Runtime.IOriginalUserIOEnvironment)engine).UserIO.SaveHandler(file: false,
                settings: true);
            while (((Celeste.Game.Save.Runtime.IOriginalUserIOEnvironment)engine).UserIO.Saving)
            {
                yield return null;
            }

            for (float p = 0f; p < 1f; p += engine.DeltaTime * 4f)
            {
                menu.X = 960f + 1920f * Ease.CubeIn(p);
                alpha = 1f - Ease.CubeIn(p);
                yield return null;
            }

            if (startLanguage != Settings.LanguageId)
            {
                base.Overworld.ReloadMenus(OverworldStartMode.ReturnFromOptions);
                yield return null;
            }

            TextMenuPresentation textMenu = menu;
            OptionsSequence ouiOptions = this;
            bool visible = false;
            ouiOptions.Visible = false;
            textMenu.Visible = visible;
            menu.RemoveSelf();
            menu = null;
        }

        public override void Update()
        {
            if (menu != null && menu.Focused && base.Selected && Input.MenuCancel.Pressed)
            {
                Audio.Play("event:/ui/main/button_back");
                base.Overworld.Goto<Celeste.Game.Menus.Title.MainMenuSequence>();
            }

            if (base.Selected && currentLanguage != Settings.LanguageId)
            {
                currentLanguage = Settings.LanguageId;
                ReloadMenu();
            }

            base.Update();
        }

        public override void Render(ISourceRenderContext context)
        {
            if (alpha > 0f)
            {
                SourcePrimitiveDrawing.Rect(context, this, -10f, -10f, 1940f, 1100f, PackedColor.Black * alpha * 0.4f);
            }

            base.Render(context);
        }
    }
}
