using Celeste.Core.Display;
using Celeste.Graphics.Display;
using Celeste.Scene.Components.Oscillation;
using Celeste.Scene.Scheduling;
using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Simulation.Rendering;

namespace Celeste.Game.UI.Menus.Buttons
{
    public abstract class MenuButtonPresentation : global::Celeste.Scene.Entities.SceneEntityState
    {
        public global::Celeste.Core.Scheduling.ISourceEngineContext EngineContext { get; }
        private global::Celeste.Game.Menus.Overworld.OuiState oui;
        public Vector2 TargetPosition, TweenFrom;

        public global::Celeste.Game.UI.Menus.Buttons.MenuButtonPresentation LeftButton,
            RightButton,
            UpButton,
            DownButton;

        public Action OnConfirm;
        private bool canAcceptInput;
        private global::Celeste.Core.Components.Animation.SourceTweenState tween;
        bool selected;
        public abstract float ButtonHeight { get; }

        public static readonly PackedColor HighlightColorA =
            Celeste.Graphics.Display.Colors.SourceHexColor.HexToColor("84FF54");

        public static readonly PackedColor HighlightColorB =
            Celeste.Graphics.Display.Colors.SourceHexColor.HexToColor("FCFF59");

        public PackedColor SelectionColor => selected
            ? (((IOriginalMenuHighlightEnvironment)EngineContext).MenuHighlightAllowed &&
               !((global::Celeste.Scene.Tracking.ISourceScene)Scene).SourceScene.Clock.BetweenInterval(.1f)
                ? HighlightColorB
                : HighlightColorA)
            : PackedColor.White;

        public bool Selected
        {
            get => selected;
            set
            {
                if (Scene == null) throw new Exception("Cannot set Selected while MenuButton is not in a Scene.");
                if (!selected && value)
                {
                    var old = GetSelection(Scene);
                    if (old != null) old.Selected = false;
                    selected = true;
                    canAcceptInput = false;
                    OnSelect();
                }
                else if (selected && !value)
                {
                    selected = false;
                    OnDeselect();
                }
            }
        }

        protected MenuButtonPresentation(global::Celeste.Game.Menus.Overworld.OuiState owner,
            Vector2 targetPosition, Vector2 tweenFrom, Action onConfirm,
            global::Celeste.Core.Scheduling.ISourceEngineContext engine) : base(
            ((global::Celeste.Core.Components.ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration,
            tweenFrom)
        {
            oui = owner;
            TargetPosition = targetPosition;
            TweenFrom = tweenFrom;
            OnConfirm = onConfirm;
            EngineContext = engine;
        }

        public static MenuButtonPresentation GetSelection(object scene)
        {
            var entities =
                ((global::Celeste.Scene.Tracking.ISourceScene)scene).SourceScene.Entities.GetTrackedEntities(
                    "Celeste.MenuButton");
            foreach (var entry in entities)
            {
                var button = (MenuButtonPresentation)entry;
                if (button.Selected) return button;
            }

            return null;
        }

        public static void ClearSelection(object scene)
        {
            var selection = GetSelection(scene);
            if (selection != null) selection.Selected = false;
        }

        public override void Update()
        {
            base.Update();
            if (!canAcceptInput) canAcceptInput = true;
            else if (oui.Selected && oui.Focused && selected)
            {
                var i =
                    ((global::Celeste.Game.Controls.Source.IOriginalGameInputProcessEnvironment)EngineContext)
                    .InputSource;
                if (i.MenuConfirm.Pressed) Confirm();
                else if (i.MenuLeft.Pressed && LeftButton != null)
                {
                    ((global::Celeste.Game.Execution.Processes.IOriginalGameplayProcess)EngineContext)
                        .AudioSession.Play("event:/ui/main/rollover_up");
                    LeftButton.Selected = true;
                }
                else if (i.MenuRight.Pressed && RightButton != null)
                {
                    ((global::Celeste.Game.Execution.Processes.IOriginalGameplayProcess)EngineContext)
                        .AudioSession.Play("event:/ui/main/rollover_down");
                    RightButton.Selected = true;
                }
                else if (i.MenuUp.Pressed && UpButton != null)
                {
                    ((global::Celeste.Game.Execution.Processes.IOriginalGameplayProcess)EngineContext)
                        .AudioSession.Play("event:/ui/main/rollover_up");
                    UpButton.Selected = true;
                }
                else if (i.MenuDown.Pressed && DownButton != null)
                {
                    ((global::Celeste.Game.Execution.Processes.IOriginalGameplayProcess)EngineContext)
                        .AudioSession.Play("event:/ui/main/rollover_down");
                    DownButton.Selected = true;
                }
            }
        }

        public void TweenIn(float time) => StartTween(time, true);
        public void TweenOut(float time) => StartTween(time, false);

        void StartTween(float time, bool inward)
        {
            if (tween != null && ReferenceEquals(tween.Entity, this))
                tween.RemoveSelf();
            var from = Position;
            var easing = ((global::Celeste.Core.Mathematics.Easing.ISourceEasingEnvironment)
                EngineContext).EasingArithmetic;
            tween = global::Celeste.Core.Components.Animation.SourceTweenState.Create(EngineContext.TweenPool,
                global::Celeste.Core.Components.Animation.SourceTweenState.TweenMode.Oneshot,
                inward ? (Func<float, float>)easing.CubeOut : easing.CubeIn, time, start: true);
            OwnedComponents.Add(tween);
            tween.OnUpdate = t => Position = global::Celeste.Core.Mathematics.Vector2Interpolation.Lerp(
                from, inward ? TargetPosition : TweenFrom, t.Eased,
                ((global::Celeste.Core.Mathematics.ISourceScalarEnvironment)EngineContext).ScalarArithmetic);
            if (((global::Celeste.Game.Profiles.IGameProfileEnvironment)
                    EngineContext).SourceProfile == global::Celeste.Game.Profiles
                    .GameProfile.InstalledEverest)
                tween.OnComplete = t =>
                {
                    t.RemoveSelf();
                    tween = null;
                };
        }

        public virtual void OnSelect()
        {
        }

        public virtual void OnDeselect()
        {
        }

        public virtual void Confirm()
        {
            OnConfirm();
        }

        public virtual void StartSelected()
        {
            selected = true;
        }

        internal void SetSourceSelected(bool value) => selected = value;

        protected global::Celeste.Graphics.Text.ActiveBitmapFont ActiveFont
            => ((global::Celeste.Graphics.Text.ISourceActiveFontScope)EngineContext).ActiveFont;

        protected void DrawIcon(global::Celeste.Core.Rendering.ISourceRenderContext context,
            global::Celeste.Graphics.Content.Atlas.AtlasEntry texture, Vector2 position,
            Vector2 justify, float scale = 1f, float rotation = 0f)
        {
            var origin = new Vector2(texture.FrameWidth * justify.X, texture.FrameHeight * justify.Y);
            global::Celeste.Graphics.Rendering.SourceAtlasDrawing.DrawOutline(context, this, texture,
                position, origin, PackedColor.White, scale, rotation);
        }
    }
}
