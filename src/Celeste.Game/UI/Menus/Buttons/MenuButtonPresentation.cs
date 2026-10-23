using System;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Components.Animation;
using Celeste.Core.Display;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Game.Controls.Source;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Menus.Overworld;
using Celeste.Game.Profiles;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Display.Colors;
using Celeste.Graphics.Rendering;
using Celeste.Graphics.Text;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;

namespace Celeste.Game.UI.Menus.Buttons
{
    public abstract class MenuButtonPresentation : SceneEntityState
    {
        public ISourceEngineContext EngineContext { get; }
        private readonly OuiState oui;
        public Vector2 TargetPosition, TweenFrom;

        public MenuButtonPresentation LeftButton,
            RightButton,
            UpButton,
            DownButton;

        public Action OnConfirm;
        private bool canAcceptInput;
        private SourceTweenState tween;
        private bool selected;
        public abstract float ButtonHeight { get; }

        public static readonly PackedColor HighlightColorA =
            SourceHexColor.HexToColor("84FF54");

        public static readonly PackedColor HighlightColorB =
            SourceHexColor.HexToColor("FCFF59");

        public PackedColor SelectionColor => selected
            ? ((IOriginalMenuHighlightEnvironment)EngineContext).MenuHighlightAllowed &&
              !((ISourceScene)Scene).SourceScene.Clock.BetweenInterval(.1f)
                ? HighlightColorB
                : HighlightColorA
            : PackedColor.White;

        public bool Selected
        {
            get => selected;
            set
            {
                if (Scene == null) throw new("Cannot set Selected while MenuButton is not in a Scene.");
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

        protected MenuButtonPresentation(OuiState owner,
            Vector2 targetPosition, Vector2 tweenFrom, Action onConfirm,
            ISourceEngineContext engine) : base(
            ((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration,
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
                ((ISourceScene)scene).SourceScene.Entities.GetTrackedEntities(
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
            if (!canAcceptInput)
            {
                canAcceptInput = true;
            }
            else if (oui.Selected && oui.Focused && selected)
            {
                var i =
                    ((IOriginalGameInputProcessEnvironment)EngineContext)
                    .InputSource;
                if (i.MenuConfirm.Pressed)
                {
                    Confirm();
                }
                else if (i.MenuLeft.Pressed && LeftButton != null)
                {
                    ((IOriginalGameplayProcess)EngineContext)
                        .AudioSession.Play("event:/ui/main/rollover_up");
                    LeftButton.Selected = true;
                }
                else if (i.MenuRight.Pressed && RightButton != null)
                {
                    ((IOriginalGameplayProcess)EngineContext)
                        .AudioSession.Play("event:/ui/main/rollover_down");
                    RightButton.Selected = true;
                }
                else if (i.MenuUp.Pressed && UpButton != null)
                {
                    ((IOriginalGameplayProcess)EngineContext)
                        .AudioSession.Play("event:/ui/main/rollover_up");
                    UpButton.Selected = true;
                }
                else if (i.MenuDown.Pressed && DownButton != null)
                {
                    ((IOriginalGameplayProcess)EngineContext)
                        .AudioSession.Play("event:/ui/main/rollover_down");
                    DownButton.Selected = true;
                }
            }
        }

        public void TweenIn(float time)
        {
            StartTween(time, true);
        }

        public void TweenOut(float time)
        {
            StartTween(time, false);
        }

        private void StartTween(float time, bool inward)
        {
            if (tween != null && ReferenceEquals(tween.Entity, this))
                tween.RemoveSelf();
            var from = Position;
            var easing = ((ISourceEasingEnvironment)
                EngineContext).EasingArithmetic;
            tween = SourceTweenState.Create(EngineContext.TweenPool,
                SourceTweenState.TweenMode.Oneshot,
                inward ? easing.CubeOut : easing.CubeIn, time, true);
            OwnedComponents.Add(tween);
            tween.OnUpdate = t => Position = Vector2Interpolation.Lerp(
                from, inward ? TargetPosition : TweenFrom, t.Eased,
                ((ISourceScalarEnvironment)EngineContext).ScalarArithmetic);
            if (((IGameProfileEnvironment)
                    EngineContext).SourceProfile == GameProfile.InstalledEverest)
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

        internal void SetSourceSelected(bool value)
        {
            selected = value;
        }

        protected ActiveBitmapFont ActiveFont
            => ((ISourceActiveFontScope)EngineContext).ActiveFont;

        protected void DrawIcon(ISourceRenderContext context,
            AtlasEntry texture, Vector2 position,
            Vector2 justify, float scale = 1f, float rotation = 0f)
        {
            var origin = new Vector2(texture.FrameWidth * justify.X, texture.FrameHeight * justify.Y);
            SourceAtlasDrawing.DrawOutline(context, this, texture,
                position, origin, PackedColor.White, scale, rotation);
        }
    }
}
