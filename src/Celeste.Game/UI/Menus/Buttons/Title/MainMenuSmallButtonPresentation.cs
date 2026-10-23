using Celeste.Core.Display;
using System;
using System.Numerics;
using Celeste.Core.Scheduling;
using Celeste.Core.Rendering;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Mathematics.Easing;
using Celeste.Game.Menus.Overworld;
using Celeste.Game.Menus.Title;
using Celeste.Game.Content.Dialogs;
using Celeste.Game.Profiles;
using Celeste.Scene.Components.Oscillation;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Display;

namespace Celeste.Game.UI.Menus.Buttons.Title
{
    public class MainMenuSmallButtonPresentation : MenuButtonPresentation
    {
        private const float IconWidth = 64f;
        private const float IconSpacing = 20f;
        private const float MaxLabelWidth = 400f;
        private AtlasEntry icon;
        private string label;
        private float labelScale;
        private float labelWidth;
        private WigglerComponent wiggler;
        private float ease;
        private readonly MainMenuAdditionalButton additionalButton;
        private readonly OuiState additionalOwner;
        public string LabelName;
        public string IconName;
        public override float ButtonHeight => ActiveFont.LineHeight * 1.25f;
        public float Ease => ease;
        public WigglerComponent Wiggler => wiggler;

        public MainMenuSmallButtonPresentation(string labelName, string iconName, OuiState owner,
            Vector2 targetPosition, Vector2 tweenFrom, Action onConfirm, AtlasData gui, ISourceEngineContext engine)
            : base(owner, targetPosition, tweenFrom, onConfirm, engine)
        {
            if (((IGameProfileEnvironment)engine).SourceProfile == GameProfile.InstalledEverest)
            {
                LabelName = labelName;
                IconName = iconName;
            }

            label = ((IOriginalGameTextEnvironment)engine).Text.CleanDialog(labelName);
            icon = gui[iconName];
            InitializePresentation(engine);
        }

        public MainMenuSmallButtonPresentation(MainMenuAdditionalButton button, OuiState owner,
            Vector2 targetPosition, Vector2 tweenFrom, ISourceEngineContext engine)
            : base(owner, targetPosition, tweenFrom,
                (button ?? throw new ArgumentNullException(nameof(button))).OnConfirm, engine)
        {
            additionalButton = button;
            additionalOwner = owner;
            label = button.Label;
            icon = button.ReadIcon() ?? throw new InvalidOperationException("The additional menu icon is not ready.");
            InitializePresentation(engine);
        }

        private void InitializePresentation(ISourceEngineContext engine)
        {
            labelScale = 1f;
            var x = ActiveFont.Measure(label).X;
            if (x > 400f)
            {
                labelScale = 400f / x;
            }

            labelWidth = x * labelScale;
            wiggler = ((ISourceWigglerPoolScope)engine).WigglerPool.Create(.25f, 4f);
            OwnedComponents.Add(wiggler);
        }

        public override void Update()
        {
            base.Update();
            if (additionalButton != null && !PointerActive())
            {
                additionalButton.PublishPointerRegion?.Invoke(0, 0, 0, 0);
            }

            ease = ScalarMath.Approach(ease, Selected ? 1 : 0, 6f * EngineContext.DeltaTime,
                ((ISourceExtremaEnvironment)EngineContext).ExtremaArithmetic);
        }

        public override void Render(ISourceRenderContext context)
        {
            base.Render(context);
            float scale = 64f / icon.FrameWidth;
            Vector2 at = new Vector2(((ISourceEasingEnvironment)EngineContext).EasingArithmetic.CubeInOut(ease) * 32f,
                ActiveFont.LineHeight / 2f + wiggler.Value * 8f);
            DrawIcon(context, icon, Position + at, new Vector2(0f, .5f), scale);
            ActiveFont.DrawOutline(context, this, label, Position + at + new Vector2(84f, 0f),
                new Vector2(0f, .5f), Vector2.One * labelScale, SelectionColor, 2f, PackedColor.Black);
            if (additionalButton?.PublishPointerRegion != null)
            {
                if (PointerActive())
                {
                    var height = Math.Max(64f * icon.FrameHeight / icon.FrameWidth,
                        ActiveFont.LineHeight * labelScale);
                    additionalButton.PublishPointerRegion(Position.X + at.X - 8, Position.Y + at.Y - height * .5f - 8,
                        84 + labelWidth + 16, height + 16);
                }
                else
                {
                    additionalButton.PublishPointerRegion(0, 0, 0, 0);
                }
            }
        }

        private bool PointerActive()
        {
            return additionalOwner != null && additionalOwner.Selected &&
                   additionalOwner.Focused && additionalOwner.Visible && Visible;
        }

        public override void Removed(object scene)
        {
            additionalButton?.PublishPointerRegion?.Invoke(0, 0, 0, 0);
            base.Removed(scene);
        }

        public override void OnSelect() => wiggler.Start();
    }
}
