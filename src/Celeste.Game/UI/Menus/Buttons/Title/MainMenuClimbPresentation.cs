using System;
using System.Numerics;
using Celeste.Core.Display;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Game.Content.Dialogs;
using Celeste.Game.Controls.Source;
using Celeste.Game.Menus.Overworld;
using Celeste.Graphics.Content.Atlas;
using Celeste.Scene.Components.Oscillation;

namespace Celeste.Game.UI.Menus.Buttons.Title
{
    public class MainMenuClimbPresentation : MenuButtonPresentation
    {
        private const float MaxLabelWidth = 256f;

        private const float BaseLabelScale = 1.5f;

        private readonly string label;

        private readonly AtlasEntry icon;

        private readonly float labelScale;

        private readonly WigglerComponent bounceWiggler;

        private readonly WigglerComponent rotateWiggler;

        private readonly WigglerComponent bigBounceWiggler;

        private bool confirmed;

        public override float ButtonHeight => icon.FrameHeight + ActiveFont.LineHeight + 48f;

        public MainMenuClimbPresentation(OuiState oui, Vector2 targetPosition, Vector2 tweenFrom, Action onConfirm,
            AtlasData gui, ISourceEngineContext engine)
            : base(oui, targetPosition, tweenFrom, onConfirm, engine)
        {
            label = ((IOriginalGameTextEnvironment)engine).Text.CleanDialog("menu_begin");
            icon = gui["menu/start"];
            labelScale = 1f;
            var num = ActiveFont.Measure(label).X * 1.5f;
            if (num > 256f) labelScale = 256f / num;

            OwnedComponents.Add(bounceWiggler = ((ISourceWigglerPoolScope)engine).WigglerPool.Create(0.25f, 4f));
            OwnedComponents.Add(rotateWiggler = ((ISourceWigglerPoolScope)engine).WigglerPool.Create(0.3f, 6f));
            OwnedComponents.Add(bigBounceWiggler = ((ISourceWigglerPoolScope)engine).WigglerPool.Create(0.4f, 2f));
        }

        public override void OnSelect()
        {
            confirmed = false;
            bounceWiggler.Start();
        }

        public override void Confirm()
        {
            base.Confirm();
            confirmed = true;
            bounceWiggler.Start();
            bigBounceWiggler.Start();
            rotateWiggler.Start();
            ((IOriginalGameInputProcessEnvironment)EngineContext).InputSource.Rumble(RumbleStrength.Medium,
                RumbleLength.Medium);
        }

        public override void Render(ISourceRenderContext context)
        {
            var vector = new Vector2(0f, bounceWiggler.Value * 8f);
            var vector2 = Vector2.UnitY * icon.FrameHeight +
                          new Vector2(0f, 0f - Math.Abs(bigBounceWiggler.Value * 40f));
            if (!confirmed) vector2 += vector;

            DrawIcon(context, icon, Position + vector2, new(.5f, 1f), 1f,
                rotateWiggler.Value * 10f * ((float)Math.PI / 180f));
            ActiveFont.DrawOutline(context, this, label, Position + vector + new Vector2(0f, 48 + icon.FrameHeight),
                new(0.5f, 0.5f), Vector2.One * 1.5f * labelScale, SelectionColor, 2f, PackedColor.Black);
        }
    }
}
