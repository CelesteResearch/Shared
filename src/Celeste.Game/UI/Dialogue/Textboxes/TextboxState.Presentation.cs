using System;
using System.Numerics;
using Celeste.Core.Display;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Randomness;
using Celeste.Core.Rendering;
using Celeste.Game.Execution.Levels;
using Celeste.Graphics.Rendering;
using Celeste.Graphics.Text.RichText.Drawing;
using Celeste.Graphics.Text.RichText.Nodes;

namespace Celeste.Game.UI.Dialogue.Textboxes
{
    public sealed partial class TextboxState
    {
        // Original HUD coordinates, 1920 by 1080. Preserve list order and shared
        // Sprite mutations made by Render; logical entity depth remains zero.
        public override void Render(ISourceRenderContext context)
        {
            if (Scene is OriginalLevelSceneRoot level && (level.FrozenOrPaused ||
                                                          level.RetryPlayerCorpse != null ||
                                                          level.Cutscene.SkippingCutscene))
                return;
            var amount =
                ((ISourceEasingEnvironment)engine).EasingArithmetic.CubeInOut(Ease);
            if (amount < .05f) return;
            var at = new Vector2(116, 58) + RenderOffset;
            if (RenderOffset == Vector2.Zero)
            {
                if (Anchor == TextAnchorPosition.Bottom)
                    at = new(116, 1080 - 58 - 272);
                else if (Anchor == TextAnchorPosition.Middle)
                    at = new(116, 404);
                at.Y += (int)(136 * (1 - amount));
            }

            SourceAtlasDrawing.DrawCentered(context, this, textbox,
                at + new Vector2(1688, 272 * amount) / 2, PackedColor.White,
                new Vector2(1, amount));
            if (WaitingForInput)
            {
                float right = portrait == null || PortraitSide(portrait) < 0 ? 1688 : 1432;
                var arrow = new Vector2(at.X + right, at.Y + 272) +
                            new Vector2(-48, -40 + (timer % 1 < .25f ? 6 : 0));
                SourceAtlasDrawing.DrawCentered(context, this,
                    Graphics.GuiAtlas.Entries["textboxbutton"], arrow,
                    PackedColor.White, Vector2.One);
            }

            if (portraitExists)
            {
                if (PortraitSide(portrait) > 0)
                {
                    PortraitSprite.Position = new(at.X + 1688 - 240 - 16, at.Y);
                    PortraitSprite.Scale.X = -portraitScale;
                }
                else
                {
                    PortraitSprite.Position = new(at.X + 16, at.Y);
                    PortraitSprite.Scale.X = portraitScale;
                }

                PortraitSprite.Scale.X *= portrait.Flipped ? -1 : 1;
                PortraitSprite.Scale.Y = portraitScale * ((272 * amount - 32) / 240) * (portrait.UpsideDown ? -1 : 1);
                PortraitSprite.Scale *= .9f + portraitWiggle.Value * .1f;
                PortraitSprite.Position += new Vector2(120, 272 * amount * .5f);
                PortraitSprite.Color = PackedColor.White * amount;
                if (Math.Abs(PortraitSprite.Scale.Y) > .05f)
                {
                    PortraitSprite.Render(context);
                    if (isPortraitGlitchy && PortraitGlitchy != null)
                    {
                        PortraitGlitchy.Position = PortraitSprite.Position;
                        PortraitGlitchy.Origin = PortraitSprite.Origin;
                        PortraitGlitchy.Scale = PortraitSprite.Scale;
                        PortraitGlitchy.Color = PackedColor.White * .2f * amount;
                        PortraitGlitchy.Render(context);
                    }
                }
            }

            if (textboxOverlay != null)
                SourceAtlasDrawing.DrawCentered(context, this, textboxOverlay,
                    at + new Vector2(1688, 272 * amount) / 2, PackedColor.White,
                    new Vector2(portrait != null && PortraitSide(portrait) > 0 ? -1 : 1, amount));
            ((ISourceRandomProcessEnvironment)engine).RandomProcess.PushRandom(shakeSeed);
            var lines = 1;
            for (var i = Start; i < Text.Nodes.Count; i++)
                if (Text.Nodes[i] is RichTextLineBreak) lines++;
                else if (Text.Nodes[i] is RichTextPageBreak) break;

            var padding = new Vector2(innerTextPadding + (portrait != null && PortraitSide(portrait) < 0 ? 256 : 0),
                innerTextPadding);
            var half = new Vector2(portrait == null ? maxLineWidthNoPortrait : maxLineWidth,
                linesPerPage * lineHeight * amount) / 2;
            var scale = lines >= 4 ? .75f : 1;
            Text.Draw(context, this,
                (ISourceRichTextDrawProcess)engine,
                at + padding + half, new(.5f), new Vector2(1, amount) * scale, amount, Start);
            ((ISourceRandomProcessEnvironment)engine).RandomProcess.PopRandom();
        }
    }
}
