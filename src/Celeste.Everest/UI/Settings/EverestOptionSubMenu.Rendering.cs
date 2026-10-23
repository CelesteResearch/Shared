using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Celeste.Core.Display;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Reflection.Runtime;
using Celeste.Core.Rendering;
using Celeste.Game.Controls.Source;
using Celeste.Game.Execution;
using Celeste.Game.Execution.Engine;
using Celeste.Game.Execution.Processes;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Rendering;
using Celeste.Scene.Components.Oscillation;
using Celeste.Scene.Tracking;
using Celeste.Simulation.UI.Menus.Text;

namespace Celeste.Everest.UI.Settings
{
    public partial class EverestOptionSubMenu
    {
        public override void Render(ISourceRenderContext context, Vector2 position, bool highlighted)
        {
            Vector2 vector = new Vector2(position.X, position.Y - Height() / 2f);
            float alpha = Container.Alpha;
            PackedColor color = (Disabled
                ? PackedColor.DarkSlateGray
                : ((highlighted ? Container.HighlightColor : PackedColor.White) * alpha));
            PackedColor strokePackedColor = PackedColor.Black * (alpha * alpha * alpha);
            bool flag = Container.InnerContent == TextMenuPresentation.InnerContentMode.TwoColumn && !AlwaysCenter;
            Vector2 vector2 = vector + Vector2.UnitY * TitleHeight / 2f +
                              (flag ? Vector2.Zero : new Vector2(Container.Width * 0.5f, 0f));
            Vector2 justify = (flag ? new Vector2(0f, 0.5f) : new Vector2(0.5f, 0.5f));
            Vector2 justify2 = (flag
                ? new Vector2(ActiveFont.Measure(Label).X + (float)Icon.FrameWidth, 5f)
                : new Vector2(ActiveFont.Measure(Label).X / 2f + (float)Icon.FrameWidth, 5f));
            AtlasEntry icon = Icon;
            PackedColor iconColor = Disabled || CurrentMenu is { Count: < 1 }
                ? PackedColor.DarkSlateGray
                : Focused
                    ? Container.HighlightColor
                    : PackedColor.White;
            DrawIcon(context, vector2, icon, justify2, outline: true, iconColor * alpha, 0.8f);
            ActiveFont.DrawOutline(context, Container, Label, vector2, justify, Vector2.One, color, 2f,
                strokePackedColor);
            if (Menus.Count > 0)
            {
                float num = RightWidth();
                ActiveFont.DrawOutline(context, Container, Menus[MenuIndex].Item1,
                    vector2 + new Vector2(Container.Width - num * 0.5f + (float)lastDir * ValueWiggler.Value * 8f, 0f),
                    new Vector2(0.5f, 0.5f), Vector2.One * 0.8f, color, 2f, strokePackedColor);
                Vector2 vector3 = Vector2.UnitX * (highlighted ? ((float)Math.Sin(sine * 4f) * 4f) : 0f);
                PackedColor color2 = ((MenuIndex > 0) ? color : (PackedColor.DarkSlateGray * alpha));
                Vector2 position2 = vector2 +
                    new Vector2(Container.Width - num + 40f + ((lastDir < 0) ? ((0f - ValueWiggler.Value) * 8f) : 0f),
                        0f) - ((MenuIndex > 0) ? vector3 : Vector2.Zero);
                ActiveFont.DrawOutline(context, Container, "<", position2, new Vector2(0.5f, 0.5f), Vector2.One, color2,
                    2f, strokePackedColor);
                color2 = ((MenuIndex < Menus.Count - 1) ? color : (PackedColor.DarkSlateGray * alpha));
                position2 = vector2 +
                            new Vector2(Container.Width - 40f + ((lastDir > 0) ? (ValueWiggler.Value * 8f) : 0f), 0f) +
                            ((MenuIndex < Menus.Count - 1) ? vector3 : Vector2.Zero);
                ActiveFont.DrawOutline(context, Container, ">", position2, new Vector2(0.5f, 0.5f), Vector2.One, color2,
                    2f, strokePackedColor);
            }

            if (CurrentMenu == null)
            {
                return;
            }

            Vector2 vector4 = new Vector2(vector.X + ItemIndent, vector.Y + TitleHeight + ItemSpacing);
            float y = vector4.Y;
            RecalculateSize();
            foreach (TextMenuPresentation.Item item in CurrentMenu)
            {
                if (item.Visible)
                {
                    float num2 = item.Height();
                    Vector2 position3 = vector4 + new Vector2(0f, num2 * 0.5f + item.SelectWiggler.Value * 8f);
                    if (position3.Y - y < MenuHeight && position3.Y + num2 * 0.5f > 0f &&
                        position3.Y - num2 * 0.5f < (float)EngineRuntime.Height)
                    {
                        item.Render(context, position3, Focused && Current == item);
                    }

                    vector4.Y += num2 + ItemSpacing;
                }
            }
        }

        private void DrawIcon(ISourceRenderContext context, Vector2 position, AtlasEntry icon, Vector2 justify,
            bool outline, PackedColor color, float scale)
        {
            if (outline)
            {
                SourceAtlasDrawing.DrawOutline(context, Container, icon, position + justify, icon.Center, color);
            }
            else
            {
                SourceAtlasDrawing.DrawCentered(context, Container, icon, position + justify, color, scale);
            }
        }
    }
}
