using Celeste.Core.Display;
using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Simulation.Rendering;
using Celeste.Simulation;

namespace Celeste.Game.UI.Dialogue.Textboxes
{
    public sealed partial class TextboxState
    {
        // Original HUD coordinates, 1920 by 1080. Preserve list order and shared
        // Sprite mutations made by Render; logical entity depth remains zero.
        public override void Render(global::Celeste.Core.Rendering.ISourceRenderContext context)
        {
            if (Scene is Celeste.Game.Execution.Levels.OriginalLevelSceneRoot level && (level.FrozenOrPaused ||
                    level.RetryPlayerCorpse != null || level.Cutscene.SkippingCutscene))
                return;
            float amount =
                ((Celeste.Core.Mathematics.Easing.ISourceEasingEnvironment)engine).EasingArithmetic.CubeInOut(ease);
            if (amount < .05f) return;
            Vector2 at = new Vector2(116, 58) + RenderOffset;
            if (RenderOffset == Vector2.Zero)
            {
                if (anchor == global::Celeste.Graphics.Text.RichText.Nodes.TextAnchorPosition.Bottom)
                    at = new Vector2(116, 1080 - 58 - 272);
                else if (anchor == global::Celeste.Graphics.Text.RichText.Nodes.TextAnchorPosition.Middle)
                    at = new Vector2(116, 404);
                at.Y += (int)(136 * (1 - amount));
            }

            global::Celeste.Graphics.Rendering.SourceAtlasDrawing.DrawCentered(context, this, textbox,
                at + new Vector2(1688, 272 * amount) / 2, global::Celeste.Core.Display.PackedColor.White,
                new Vector2(1, amount));
            if (waitingForInput)
            {
                float right = portrait == null || PortraitSide(portrait) < 0 ? 1688 : 1432;
                Vector2 arrow = new Vector2(at.X + right, at.Y + 272) +
                                new Vector2(-48, -40 + (timer % 1 < .25f ? 6 : 0));
                global::Celeste.Graphics.Rendering.SourceAtlasDrawing.DrawCentered(context, this,
                    Graphics.GuiAtlas.Entries["textboxbutton"], arrow,
                    global::Celeste.Core.Display.PackedColor.White, Vector2.One);
            }

            if (portraitExists)
            {
                if (PortraitSide(portrait) > 0)
                {
                    portraitSprite.Position = new Vector2(at.X + 1688 - 240 - 16, at.Y);
                    portraitSprite.Scale.X = -portraitScale;
                }
                else
                {
                    portraitSprite.Position = new Vector2(at.X + 16, at.Y);
                    portraitSprite.Scale.X = portraitScale;
                }

                portraitSprite.Scale.X *= portrait.Flipped ? -1 : 1;
                portraitSprite.Scale.Y = portraitScale * ((272 * amount - 32) / 240) * (portrait.UpsideDown ? -1 : 1);
                portraitSprite.Scale *= .9f + portraitWiggle.Value * .1f;
                portraitSprite.Position += new Vector2(120, 272 * amount * .5f);
                portraitSprite.Color = global::Celeste.Core.Display.PackedColor.White * amount;
                if (Math.Abs(portraitSprite.Scale.Y) > .05f)
                {
                    portraitSprite.Render(context);
                    if (isPortraitGlitchy && portraitGlitchy != null)
                    {
                        portraitGlitchy.Position = portraitSprite.Position;
                        portraitGlitchy.Origin = portraitSprite.Origin;
                        portraitGlitchy.Scale = portraitSprite.Scale;
                        portraitGlitchy.Color = global::Celeste.Core.Display.PackedColor.White * .2f * amount;
                        portraitGlitchy.Render(context);
                    }
                }
            }

            if (textboxOverlay != null)
                global::Celeste.Graphics.Rendering.SourceAtlasDrawing.DrawCentered(context, this, textboxOverlay,
                    at + new Vector2(1688, 272 * amount) / 2, global::Celeste.Core.Display.PackedColor.White,
                    new Vector2(portrait != null && PortraitSide(portrait) > 0 ? -1 : 1, amount));
            ((Celeste.Core.Randomness.ISourceRandomProcessEnvironment)engine).RandomProcess.PushRandom(shakeSeed);
            int lines = 1;
            for (int i = Start; i < text.Nodes.Count; i++)
            {
                if (text.Nodes[i] is global::Celeste.Graphics.Text.RichText.Nodes.RichTextLineBreak) lines++;
                else if (text.Nodes[i] is global::Celeste.Graphics.Text.RichText.Nodes.RichTextPageBreak) break;
            }

            Vector2 padding = new Vector2(innerTextPadding + (portrait != null && PortraitSide(portrait) < 0 ? 256 : 0),
                innerTextPadding);
            Vector2 half = new Vector2(portrait == null ? maxLineWidthNoPortrait : maxLineWidth,
                linesPerPage * lineHeight * amount) / 2;
            float scale = lines >= 4 ? .75f : 1;
            text.Draw(context, this,
                (global::Celeste.Graphics.Text.RichText.Drawing.ISourceRichTextDrawProcess)engine,
                at + padding + half, new Vector2(.5f), new Vector2(1, amount) * scale, amount, Start);
            ((Celeste.Core.Randomness.ISourceRandomProcessEnvironment)engine).RandomProcess.PopRandom();
        }
    }
}
