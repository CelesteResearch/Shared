using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Display;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Display.Colors;
using Celeste.Graphics.Rendering;
using Celeste.Input.Bindings;
using Celeste.Scene.Entities;
using Celeste.Scene.Scheduling;

namespace Celeste.Simulation.Presentation.Hud.Tutorials.Birds
{
    public sealed class BirdTutorialGuiState : SceneEntityState
    {
        public ISourceEntityPosition Entity;
        public bool Open;
        public float Scale;
        public BirdTutorialPointerDirection PointerDirection { get; set; } = BirdTutorialPointerDirection.Down;
        public bool MirrorPointer { get; set; } = true;
        private readonly object info;
        private readonly List<object> controls;
        private float controlsWidth;
        private readonly float infoWidth;
        private float infoHeight;
        private readonly float buttonPadding = 8f;
        private readonly PackedColor bgColor = SourceHexColor.HexToColor("061526");
        private readonly PackedColor lineColor = new(1f, 1f, 1f);
        private readonly PackedColor textColor = SourceHexColor.HexToColor("6179e2");
        private readonly IBirdTutorialResources resources;
        private readonly ISourceEngineContext engine;

        public BirdTutorialGuiState(ISourceEngineContext engine, int hudTag, IBirdTutorialResources resources,
            ISourceEntityPosition entity,
            Vector2 position, object info, params object[] controls)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration)
        {
            this.engine = engine;
            this.resources = resources;
            Tags |= new SceneTagSet(hudTag);
            Entity = entity;
            Position = position;
            this.info = info;
            for (var i = 0; i < controls.Length; i++)
                if (controls[i] is SourceVirtualButton button)
                    controls[i] = resources.RegisterButton(button);
            this.controls = [.. controls];
            if (info is string text)
            {
                infoWidth = resources.ActiveFont.Measure(text).X;
                infoHeight = resources.ActiveFont.LineHeight;
            }
            else if (info is AtlasEntry texture)
            {
                infoWidth = texture.FrameWidth;
                infoHeight = texture.FrameHeight;
            }

            UpdateControlsSize();
        }

        public void ApplyCustomTutorialSpacing(bool hideInfo, int controlSpacing)
        {
            if (hideInfo) infoHeight = 0f;
            controlsWidth += controlSpacing;
        }

        public void UpdateControlsSize()
        {
            controlsWidth = 0f;
            foreach (var control in controls)
                if (control is BirdTutorialButton prompt)
                    controlsWidth += resources.GuiButton(prompt).FrameWidth + buttonPadding * 2f;
                else if (control is Vector2 direction)
                    controlsWidth += resources.GuiDirection(direction).FrameWidth + buttonPadding * 2f;
                else if (control is string)
                    controlsWidth += resources.ActiveFont.Measure(control.ToString()).X;
                else if (control is AtlasEntry texture)
                    controlsWidth += texture.FrameWidth;
        }

        public override void Update()
        {
            UpdateControlsSize();
            Scale = ScalarMath.Approach(Scale, Open ? 1 : 0, engine.RawDeltaTime * 8f,
                ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
            base.Update();
        }

        public override void Render(ISourceRenderContext context)
        {
            var level = (IBirdTutorialLevelScene)Scene;
            if (level.FrozenOrPaused || level.RetryPlayerCorpse != null || Scale <= 0f) return;
            var cameraPosition = level.CameraPosition;
            var at = Entity.Position + Position -
                     Vector2Geometry.Floor(cameraPosition);
            var pointerAt = at * 6f;
            if (resources.MirrorMode) at.X = 320f - at.X;
            at.X *= 6f;
            at.Y *= 6f;
            var lineHeight = resources.ActiveFont.LineHeight;
            var width = (((ISourceExtremaEnvironment)engine).ExtremaArithmetic.Max(controlsWidth, infoWidth) + 64f) *
                        Scale;
            var height = infoHeight + lineHeight + 32f;
            var left = at.X - width / 2f;
            var top = at.Y - height - 32f;
            SourcePrimitiveDrawing.Rect(context, this, left - 6f, top - 6f, width + 12f, height + 12f, lineColor);
            SourcePrimitiveDrawing.Rect(context, this, left, top, width, height, bgColor);
            RenderPointer(context, MirrorPointer ? at : pointerAt, width, height);

            if (!(width > 3f)) return;
            var textAt = new Vector2(at.X, top + 16f);
            var scale = new Vector2(Scale, 1f);
            if (info is string text)
                resources.ActiveFont.Draw(context, this, text, textAt, new(.5f, 0f), scale, textColor);
            else if (info is AtlasEntry texture)
                DrawTexture(context, texture, textAt, new(texture.FrameWidth * .5f, 0f), scale);
            textAt.Y += infoHeight + lineHeight * .5f;
            var cursor = new Vector2(-controlsWidth / 2f, 0f);
            foreach (var control in controls)
                if (control is BirdTutorialButton prompt)
                {
                    var image = resources.GuiButton(prompt);
                    cursor.X += buttonPadding;
                    DrawTexture(context, image, textAt, new(-cursor.X, image.FrameHeight / 2), scale);
                    cursor.X += image.FrameWidth + buttonPadding;
                }
                else if (control is Vector2 direction)
                {
                    if (resources.MirrorMode) direction.X = -direction.X;
                    var image = resources.GuiDirection(direction);
                    cursor.X += buttonPadding;
                    DrawTexture(context, image, textAt, new(-cursor.X, image.FrameHeight / 2), scale);
                    cursor.X += image.FrameWidth + buttonPadding;
                }
                else if (control is string)
                {
                    var controlText = control.ToString();
                    var textWidth = resources.ActiveFont.Measure(controlText).X;
                    resources.ActiveFont.Draw(context, this, controlText, textAt + new Vector2(1f, 2f),
                        new(-cursor.X / textWidth, .5f), scale, textColor);
                    resources.ActiveFont.Draw(context, this, controlText, textAt + new Vector2(1f, -2f),
                        new(-cursor.X / textWidth, .5f), scale, PackedColor.White);
                    cursor.X += textWidth + 1f;
                }
                else if (control is AtlasEntry image)
                {
                    DrawTexture(context, image, textAt, new(-cursor.X, image.FrameHeight / 2), scale);
                    cursor.X += image.FrameWidth;
                }
        }

        private void RenderPointer(ISourceRenderContext context, Vector2 at, float width, float height)
        {
            if (PointerDirection == BirdTutorialPointerDirection.None) return;
            var left = at.X - width / 2f;
            var top = at.Y - height - 32f;
            for (var i = 0; i <= 36; i++)
            {
                var span = (73 - i * 2) * Scale;
                switch (PointerDirection)
                {
                    case BirdTutorialPointerDirection.Down:
                        SourcePrimitiveDrawing.Rect(context, this, at.X - span / 2f, top + height + i, span, 1f,
                            lineColor);
                        if (span > 12f)
                            SourcePrimitiveDrawing.Rect(context, this, at.X - span / 2f + 6f, top + height + i,
                                span - 12f, 1f, bgColor);
                        break;
                    case BirdTutorialPointerDirection.Up:
                        SourcePrimitiveDrawing.Rect(context, this, at.X - span / 2f, top - i - 1, span, 1f, lineColor);
                        if (span > 12f)
                            SourcePrimitiveDrawing.Rect(context, this, at.X - span / 2f + 6f, top - i, span - 12f, 1f,
                                bgColor);
                        break;
                    case BirdTutorialPointerDirection.Left:
                        SourcePrimitiveDrawing.Rect(context, this, left - i - 1, top + height / 2f - span / 2f, 1f,
                            span, lineColor);
                        if (span > 12f)
                            SourcePrimitiveDrawing.Rect(context, this, left - i, top + height / 2f - span / 2f + 6f, 1f,
                                span - 12f, bgColor);
                        break;
                    case BirdTutorialPointerDirection.Right:
                        SourcePrimitiveDrawing.Rect(context, this, left + width + i, top + height / 2f - span / 2f, 1f,
                            span, lineColor);
                        if (span > 12f)
                            SourcePrimitiveDrawing.Rect(context, this, left + width + i,
                                top + height / 2f - span / 2f + 6f, 1f, span - 12f, bgColor);
                        break;
                }
            }
        }

        private void DrawTexture(ISourceRenderContext context, AtlasEntry texture, Vector2 at, Vector2 origin,
            Vector2 scale)
        {
            SourceAtlasDrawing.Draw(context, this, texture, at, origin, PackedColor.White, scale);
        }
    }
}
