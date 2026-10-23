using Celeste.Core.Display;
using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Scheduling;
using Celeste.Core.Rendering;
using Celeste.Game.Content.Dialogs;
using Celeste.Game.Execution.Graphics;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Content.VirtualAssets;
using Celeste.Graphics.Display;
using Celeste.Graphics.Rendering;

namespace Celeste.Game.Menus.Journal
{
    public abstract partial class OuiJournalPage
    {
        public class Table
        {
            private const float headerHeight = 80f;

            private const float headerBottomMargin = 20f;

            private const float rowHeight = 60f;

            private List<Row> rows = new List<Row>();

            public int Rows => rows.Count;

            public Row Header
            {
                get
                {
                    if (rows.Count <= 0)
                    {
                        return null;
                    }

                    return rows[0];
                }
            }

            public Table AddColumn(Cell label)
            {
                if (rows.Count == 0)
                {
                    AddRow();
                }

                rows[0].Add(label);
                return this;
            }

            public Row AddRow()
            {
                Row row = new Row();
                rows.Add(row);
                return row;
            }

            public float Height()
            {
                return 100f + 60f * (float)(rows.Count - 1);
            }

            public void Render(ISourceRenderContext context, object owner, Vector2 position)
            {
                if (Header == null)
                {
                    return;
                }

                float num = 0f;
                float num2 = 0f;
                for (int i = 0; i < Header.Count; i++)
                {
                    num2 += Header[i].Width() + 20f;
                }

                for (int j = 0; j < Header.Count; j++)
                {
                    float num3 = Header[j].Width();
                    Header[j].Render(context, owner, position + new Vector2(num + num3 * 0.5f, 40f), num3);
                    int num4 = 1;
                    float num5 = 130f;
                    for (int k = 1; k < rows.Count; k++)
                    {
                        Vector2 center = position + new Vector2(num + num3 * 0.5f, num5);
                        if (rows[k].Count > 0)
                        {
                            if (num4 % 2 == 0)
                            {
                                SourcePrimitiveDrawing.Rect(context, owner, center.X - num3 * 0.5f, center.Y - 27f,
                                    num3 + 20f, 54f, PackedColor.Black * 0.08f);
                            }

                            if (j < rows[k].Count && rows[k][j] != null)
                            {
                                Cell cell = rows[k][j];
                                if (cell.SpreadOverColumns > 1)
                                {
                                    for (int l = j + 1; l < j + cell.SpreadOverColumns; l++)
                                    {
                                        center.X += Header[l].Width() * 0.5f;
                                    }

                                    center.X += (float)(cell.SpreadOverColumns - 1) * 20f * 0.5f;
                                }

                                rows[k][j].Render(context, owner, center, num3);
                            }

                            num4++;
                            num5 += 60f;
                        }
                        else
                        {
                            SourcePrimitiveDrawing.Rect(context, owner, center.X - num3 * 0.5f, center.Y - 25.5f,
                                num3 + 20f, 6f, PackedColor.Black * 0.3f);
                            num5 += 15f;
                        }
                    }

                    num += num3 + 20f;
                }
            }
        }

        public class Row
        {
            public List<Cell> Entries = new List<Cell>();

            public int Count => Entries.Count;

            public Cell this[int index] => Entries[index];

            public Row Add(Cell entry)
            {
                Entries.Add(entry);
                return this;
            }
        }

        public abstract class Cell
        {
            protected readonly ISourceEngineContext engine;

            protected Cell(ISourceEngineContext engine)
            {
                this.engine = engine;
            }

            protected OriginalGameTextProcess Text => ((IOriginalGameTextEnvironment)engine).Text;

            protected OriginalMountainResources MountainResources =>
                ((IOriginalMountainEnvironment)engine).MountainResources;

            public int SpreadOverColumns = 1;

            public virtual float Width()
            {
                return 0f;
            }

            public virtual void Render(ISourceRenderContext context, object owner, Vector2 center, float columnWidth)
            {
            }
        }

        public class EmptyCell : Cell
        {
            private float width;

            public EmptyCell(ISourceEngineContext engine, float width) : base(engine)
            {
                this.width = width;
            }

            public override float Width()
            {
                return width;
            }
        }

        public class TextCell : Cell
        {
            private string text;

            private Vector2 justify;

            private float scale;

            private PackedColor color;

            private float width;

            private bool forceWidth;

            public TextCell(ISourceEngineContext engine, string text, Vector2 justify, float scale, PackedColor color,
                float width = 0f, bool forceWidth = false) : base(engine)
            {
                this.text = text;
                this.justify = justify;
                this.scale = scale;
                this.color = color;
                this.width = width;
                this.forceWidth = forceWidth;
            }

            public override float Width()
            {
                if (forceWidth)
                {
                    return width;
                }

                return Math.Max(width, Text.ActiveFont.Measure(text).X * scale);
            }

            public override void Render(ISourceRenderContext context, object owner, Vector2 center, float columnWidth)
            {
                float num = Text.ActiveFont.Measure(text).X * scale;
                float num2 = 1f;
                if (!forceWidth && num > columnWidth)
                {
                    num2 = columnWidth / num;
                }

                Text.ActiveFont.Draw(context, owner, text,
                    center + new Vector2((0f - columnWidth) / 2f + columnWidth * justify.X, 0f), justify,
                    Vector2.One * scale * num2, color);
            }
        }

        public class IconCell : Cell
        {
            private string icon;

            private float width;

            public IconCell(ISourceEngineContext engine, string icon, float width = 0f) : base(engine)
            {
                this.icon = icon;
                this.width = width;
            }

            public override float Width()
            {
                return Math.Max(MountainResources.Journal[icon].FrameWidth, width);
            }

            public override void Render(ISourceRenderContext context, object owner, Vector2 center, float columnWidth)
            {
                SourceAtlasDrawing.DrawCentered(context, owner, MountainResources.Journal[icon], center,
                    PackedColor.White);
            }
        }

        public class IconsCell : Cell
        {
            private float iconSpacing = 4f;

            private string[] icons;

            public IconsCell(ISourceEngineContext engine, float iconSpacing, params string[] icons) : base(engine)
            {
                this.iconSpacing = iconSpacing;
                this.icons = icons;
            }

            public IconsCell(ISourceEngineContext engine, params string[] icons) : base(engine)
            {
                this.icons = icons;
            }

            public override float Width()
            {
                float num = 0f;
                for (int i = 0; i < icons.Length; i++)
                {
                    num += (float)MountainResources.Journal[icons[i]].FrameWidth;
                }

                return num + (float)(icons.Length - 1) * iconSpacing;
            }

            public override void Render(ISourceRenderContext context, object owner, Vector2 center, float columnWidth)
            {
                float num = Width();
                Vector2 position = center + new Vector2((0f - num) * 0.5f, 0f);
                for (int i = 0; i < icons.Length; i++)
                {
                    AtlasEntry mTexture = MountainResources.Journal[icons[i]];
                    SourceAtlasDrawing.DrawJustified(context, owner, mTexture, position, new Vector2(0f, 0.5f),
                        PackedColor.White);
                    position.X += (float)mTexture.FrameWidth + iconSpacing;
                }
            }
        }
    }
}
