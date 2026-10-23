using System;
using System.Collections;
using Celeste.Core.Display;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Everest.UI.ModOptions;
using Celeste.Game.Audio.Runtime;
using Celeste.Game.Content.Dialogs;
using Celeste.Game.Controls.Source;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Menus.Overworld;
using Celeste.Graphics.Rendering;
using Celeste.Localization.Lookup;
using Celeste.Scene.Tracking;
using Celeste.Simulation.UI.Menus.Text;

namespace Celeste.Everest.UI.Menus
{
    public abstract class EverestGenericMenuState : OuiState
    {
        protected readonly ISourceEngineContext engine;

        protected EverestGenericMenuState(ISourceEngineContext engine) : base(engine)
        {
            this.engine = engine;
        }

        protected OriginalGameInputProcess Input => ((IOriginalGameInputProcessEnvironment)engine).InputSource;
        protected OriginalGameAudioSession Audio => ((IOriginalGameplayProcess)engine).AudioSession;
        protected DialogCatalog Dialog => ((IOriginalGameTextEnvironment)engine).Text.Dialog;

        private const float onScreenX = 960f;

        private const float offScreenX = 2880f;

        /// <summary>
        ///     The text menu this screen contains.
        /// </summary>
        protected TextMenuPresentation menu;

        /// <summary>
        ///     Optional parameters this menu can take.
        /// </summary>
        protected object[] parameters;

        /// <summary>
        ///     An action executed when the player presses Back.
        /// </summary>
        protected Action<OverworldSequence> backToParentMenu;

        /// <summary>
        ///     Whether the player can go back to the parent menu.
        /// </summary>
        protected bool canGoBack = true;

        private float alpha;

        /// <summary>
        ///     The title for the menu.
        /// </summary>
        public abstract string MenuName { get; }

        /// <summary>
        ///     Adds all the submenu options to the TextMenuPresentation given in parameter.
        /// </summary>
        protected abstract void addOptionsToMenu(TextMenuPresentation menu);

        public override IEnumerator Enter(OuiState from)
        {
            menu = new(engine);
            menu.Add(new TextMenuPresentation.Header(MenuName));
            addOptionsToMenu(menu);
            ((ISourceScene)Scene).SourceScene.QueueSourceEntity(menu);
            var textMenu = menu;
            var ouiGenericMenu = this;
            var visible = true;
            ouiGenericMenu.Visible = true;
            textMenu.Visible = visible;
            menu.Focused = false;
            for (var p = 0f; p < 1f; p += engine.DeltaTime * 4f)
            {
                menu.X = 2880f + -1920f * ((ISourceEasingEnvironment)engine).EasingArithmetic.CubeOut(p);
                alpha = ((ISourceEasingEnvironment)engine).EasingArithmetic.CubeOut(p);
                yield return null;
            }

            menu.Focused = true;
        }

        public override IEnumerator Leave(OuiState next)
        {
            Audio.Play("event:/ui/main/whoosh_large_out");
            menu.Focused = false;
            for (var p = 0f; p < 1f; p += engine.DeltaTime * 4f)
            {
                menu.X = 960f + 1920f * ((ISourceEasingEnvironment)engine).EasingArithmetic.CubeIn(p);
                alpha = 1f - ((ISourceEasingEnvironment)engine).EasingArithmetic.CubeIn(p);
                yield return null;
            }

            var textMenu = menu;
            var ouiGenericMenu = this;
            var visible = false;
            ouiGenericMenu.Visible = false;
            textMenu.Visible = visible;
            menu.RemoveSelf();
            menu = null;
        }

        public override void Update()
        {
            if (menu != null && menu.Focused && Selected && canGoBack && Input.MenuCancel.Pressed)
            {
                Audio.Play("event:/ui/main/button_back");
                backToParentMenu(Overworld);
            }

            base.Update();
        }

        public override void Render(ISourceRenderContext context)
        {
            if (alpha > 0f)
                SourcePrimitiveDrawing.Rect(context, this, -10f, -10f, 1940f, 1100f, PackedColor.Black * alpha * 0.4f);

            base.Render(context);
        }

        /// <summary>
        ///     Navigates from the current screen to a EverestGenericMenuState <b>in the overworld</b>. Does NOT work from the
        ///     pause menu.
        /// </summary>
        /// <typeparam name="T">The EverestGenericMenuState to navigate to</typeparam>
        /// <param name="backToParentMenu">
        ///     An action to come back to the current menu (generally
        ///     <code>overworld.Goto&lt;ParentMenuType&gt;()</code>
        /// </param>
        /// <param name="parameters">Optional parameters the menu will get in its "options" attribute</param>
        public static void Goto<T>(Action<OverworldSequence> backToParentMenu, params object[] parameters)
            where T : EverestGenericMenuState
        {
            var overworld = EverestModOptionsState.Instance.Overworld;
            var uI = overworld.GetUI<T>();
            uI.backToParentMenu = backToParentMenu;
            uI.parameters = parameters;
            overworld.Goto<T>();
        }
    }
}
