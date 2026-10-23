using Celeste.Core.Display;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Input.Gameplay;
using Celeste.Game.Content.Dialogs;
using Celeste.Game.Execution.Graphics;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Display;
using Celeste.Graphics.Rendering;
using Celeste.Graphics.Text;
using Celeste.Simulation;
using Celeste.Physics.Collision;
using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Simulation.Rendering;

namespace Celeste.Game.Credits
{
    public sealed partial class CreditsPresentation
    {
        private class MultiCredit : CreditNode
        {
            public class Section
            {
                public string Subtitle;

                public int SubtitleLines;

                public string[] Credits;

                public Section(string subtitle, params string[] credits)
                {
                    Subtitle = subtitle.ToUpper();
                    SubtitleLines = subtitle.Split('\n').Length;
                    Credits = credits;
                }
            }

            public const float TitleScale = 1.4f;

            public const float SubtitleScale = 0.7f;

            public const float CreditsScale = 1.15f;

            public const float Spacing = 8f;

            public const float SectionSpacing = 32f;

            public readonly PackedColor TitleColor = PackedColor.White;

            public readonly PackedColor SubtitleColor = new PackedColor(168, 166, 148);

            public readonly PackedColor CreditsColor = PackedColor.White * .8f;

            public int TopPadding;

            public string Title;

            public Section[] Sections;

            public MultiCredit(string title, params Section[] to)
                : this(0, title, to)
            {
            }

            public MultiCredit(int topPadding, string title, Section[] to)
            {
                TopPadding = topPadding;
                Title = title;
                Sections = to;
            }

            public override void Render(ISourceRenderContext context,
                global::Celeste.Game.Credits.CreditsPresentation owner, Vector2 position,
                float alignment = 0.5f,
                float scale = 1f)
            {
                position.Y += (float)TopPadding * scale;
                owner.DrawText(context, false, Title, Floor(position), new Vector2(alignment, 0f),
                    Vector2.One * 1.4f * scale,
                    TitleColor, 2f, owner.Process.BorderColor);
                position.Y += (owner.LineHeight * 1.4f + 8f) * scale;
                for (int i = 0; i < Sections.Length; i++)
                {
                    Section section = Sections[i];
                    _ = section.Subtitle;
                    owner.DrawText(context, false, section.Subtitle, Floor(position), new Vector2(alignment, 0f),
                        Vector2.One * 0.7f * scale, SubtitleColor, 2f, owner.Process.BorderColor);
                    position.Y += (float)section.SubtitleLines * owner.LineHeight * 0.7f * scale;
                    for (int j = 0; j < section.Credits.Length; j++)
                    {
                        owner.DrawText(context, false, section.Credits[j], Floor(position), new Vector2(alignment, 0f),
                            Vector2.One * 1.15f * scale, CreditsColor, 2f, owner.Process.BorderColor);
                        position.Y += owner.LineHeight * 1.15f * scale;
                    }

                    position.Y += 32f * scale;
                }
            }

            public override float Height(global::Celeste.Game.Credits.CreditsPresentation owner,
                float scale = 1f)
            {
                float num = 0f;
                num += (float)TopPadding;
                num += owner.LineHeight * 1.4f + 8f;
                for (int i = 0; i < Sections.Length; i++)
                {
                    num += (float)Sections[i].SubtitleLines * owner.LineHeight * 0.7f;
                    num += owner.LineHeight * 1.15f * (float)Sections[i].Credits.Length;
                }

                num += 32f * (float)(Sections.Length - 1);
                return num * scale;
            }
        }
    }
}
