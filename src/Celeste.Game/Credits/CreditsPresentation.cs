using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Display;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Game.Content.Dialogs;
using Celeste.Game.Execution.Graphics;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Rendering;
using Celeste.Graphics.Text;
using Celeste.Input.Gameplay;
using JetBrains.Annotations;

namespace Celeste.Game.Credits
{
    public sealed partial class CreditsPresentation
    {
        public const float CreditSpacing = 64f;

        public const float AutoScrollSpeed = 100f;

        public const float InputScrollSpeed = 600f;

        public const float ScrollResumeDelay = 1f;

        public const float ScrollAcceleration = 1800f;

        private readonly List<CreditNode> credits;

        public float AutoScrollSpeedMultiplier = 1f;

        [UsedImplicitly(ImplicitUseKindFlags.Access |
                        ImplicitUseKindFlags.Assign)]
        private float scrollSpeed = 100f;

        [UsedImplicitly(ImplicitUseKindFlags.Access |
                        ImplicitUseKindFlags.Assign)]
        private float scroll;

        [UsedImplicitly(ImplicitUseKindFlags.Access |
                        ImplicitUseKindFlags.Assign)]
        private float height;

        [UsedImplicitly(ImplicitUseKindFlags.Access |
                        ImplicitUseKindFlags.Assign)]
        private float scrollDelay;

        [UsedImplicitly(ImplicitUseKindFlags.Access |
                        ImplicitUseKindFlags.Assign)]
        private float scrollbarAlpha;

        [UsedImplicitly(ImplicitUseKindFlags.Access |
                        ImplicitUseKindFlags.Assign)]
        private float alignment;

        [UsedImplicitly(ImplicitUseKindFlags.Access |
                        ImplicitUseKindFlags.Assign)]
        private float scale;

        public float BottomTimer;

        public bool Enabled = true;

        public bool AllowInput = true;

        private readonly ISourceEngineContext engine;
        private OriginalCreditsProcessState Process => ((IOriginalCreditsProcessEnvironment)engine).CreditsProcess;

        private OriginalGameGraphicsResources Graphics =>
            ((IOriginalCreditsGraphicsEnvironment)engine).GraphicsResources;

        private ActiveBitmapFont ActiveFont => ((ISourceActiveFontScope)engine).ActiveFont;
        public float LineHeight => Process.LineHeight;
        public float Scroll => scroll;
        public float Height => height;
        public float ScrollSpeed => scrollSpeed;
        public float ScrollDelay => scrollDelay;
        public float ScrollbarAlpha => scrollbarAlpha;
        public float Alignment => alignment;
        public float Scale => scale;
        public int NodeCount => credits.Count;

        public IReadOnlyList<float> NodeHeights
        {
            get
            {
                var result = new List<float>();
                foreach (var node in credits) result.Add(node.Height(this, scale));
                return result;
            }
        }

        public IReadOnlyList<string> NodeKinds
        {
            get
            {
                var result = new List<string>();
                foreach (var node in credits) result.Add(node.GetType().Name);
                return result;
            }
        }

        private static Vector2 Floor(Vector2 v)
        {
            return new((float)Math.Floor(v.X), (float)Math.Floor(v.Y));
        }

        private void DrawText(ISourceRenderContext context, bool active, string text, Vector2 at,
            Vector2 justify, Vector2 scale, PackedColor color, float stroke, PackedColor outline)
        {
            if (active)
                ActiveFont.DrawOutline(context, this, text, at, justify, scale,
                    color, stroke, outline);
            else
                Process.Font.DrawOutline(context, this, Process.FontSize, text, at, justify, scale,
                    color, stroke, outline);
        }

        private void DrawTexture(ISourceRenderContext context, AtlasEntry texture, Vector2 at,
            Vector2 justify, PackedColor color, float imageScale, float rotation)
        {
            SourceAtlasDrawing.DrawJustified(context, this, texture, at, justify,
                color, imageScale, rotation);
        }

        private void DrawRect(ISourceRenderContext context, float x, float y, float width,
            float height, PackedColor color)
        {
            SourcePrimitiveDrawing.Rect(context, this, x, y, width, height, color);
        }

        private List<CreditNode> CreateCredits(bool title, bool polaroids)
        {
            var list = new List<CreditNode>();
            if (title) list.Add(new Image(Graphics.GuiAtlas, "title", 320f));

            list.AddRange(new List<CreditNode>
            {
                new Role("Maddy Thorson", "Director", "Designer", "Writer", "Gameplay Coder"),
                new Role("Noel Berry", "Co-Creator", "Programmer", "Artist"),
                new Role("Amora B.", "Concept Artist", "High Res Artist"),
                new Role("Pedro Medeiros", "Pixel Artist", "UI Artist"),
                new Role("Lena Raine", "Composer"),
                new Team("Power Up Audio",
                    ["Kevin Regamey", "Jeff Tangsoc", "Joey Godard", "Cole Verderber"],
                    "Sound Designers"),
            });
            if (polaroids) list.Add(new Image(Graphics.PortraitsAtlas, "credits/a", 64f, -0.05f));

            list.AddRange(new List<CreditNode>
            {
                new Role("Gabby DaRienzo", "3D Artist"),
                new Role("Sven Bergström", "3D Lighting Artist"),
            });
            list.AddRange(new List<CreditNode>
            {
                new Thanks("Writing Assistance", "Noel Berry", "Amora B.", "Greg Lobanov", "Lena Raine",
                    "Nick Suttner"),
                new Thanks("Script Editor", "Nick Suttner"),
                new Thanks("Narrative Consulting", "Silverstring Media", "Claris Cyarron", "with Lucas JW Johnson",
                    "and Tanya Kan"),
            });
            list.Add(new Thanks("Remixers", Process.Remixers));
            list.Add(new MultiCredit("Musical Performances",
                new MultiCredit.Section("Violin, Viola", "Michaela Nachtigall"),
                new MultiCredit.Section("Cello", "SungHa Hong"), new MultiCredit.Section("Drums", "Doug Perry")));
            if (polaroids) list.Add(new Image(Graphics.PortraitsAtlas, "credits/b", 64f, 0.05f));

            list.Add(new Thanks("Operations Manager", "Heidy Motta"));
            list.Add(new Thanks("Porting", "Sickhead Games, LLC", "Ethan Lee"));
            list.Add(new MultiCredit("Localization",
                new MultiCredit.Section(
                    "French, Italian, Korean, Russian,\nSimplified Chinese, Spanish,\nBrazilian Portuguese, German",
                    "EDS Wordland, Ltd."),
                new MultiCredit.Section("Japanese", "8-4, Ltd", "Keiko Fukuichi", "Graeme Howard", "John Ricciardi"),
                new MultiCredit.Section("German, Additional Brazilian Portuguese", "Shloc, Ltd.", "Oli Chance",
                    "Isabel Sterner", "Nadine Leonhardt"),
                new MultiCredit.Section("Additional Brazilian Portuguese", "Amora B.")));
            list.Add(new Thanks("Contributors & Playtesters", "Nels Anderson", "Liam & Graeme Berry", "Tamara Bruketta",
                "Allan Defensor", "Grayson Evans", "Jada Gibbs", "Em Halberstadt", "Justin Jaffray",
                "Chevy Ray Johnston", "Will Lacerda", "Myriame Lachapelle", "Greg Lobanov", "Rafinha Martinelli",
                "Shane Neville", "Kyle Pulver", "Murphy Pyan", "Garret Randell", "Kevin Regamey", "Atlas Regaudie",
                "Stefano Strapazzon", "Nick Suttner", "Ryan Thorson", "Greg Wohlwend", "Justin Yngelmo", "baldjared",
                "zep", "DevilSquirrel", "Covert_Muffin", "buhbai", "Chaikitty", "Msushi", "TGH"));
            list.Add(new Thanks("Community", "Speedrunners & Tool Assisted Speedrunners", "Everest Modding Community",
                "The Celeste Discord"));
            list.Add(new Thanks("Special Thanks", "Fe Angelo", "Bruce Berry & Marilyn Firth", "Josephine Baird",
                "Liliane Carpinski", "Yvonne Hanson", "Katherine Elaine Jones", "Clint 'halfcoordinated' Lexa",
                "Greg Lobanov", "Gabi 'Platy' Madureira", "Rodrigo Monteiro", "Fernando Piovesan", "Paulo Szyszko Pita",
                "Zoe Si", "Julie, Richard, & Ryan Thorson", "Davey Wreden"));
            if (polaroids) list.Add(new Image(Graphics.PortraitsAtlas, "credits/c", 64f, -0.05f));

            list.Add(new Thanks("Production Kitties", "Jiji, Mr Satan, Peridot", "Azzy, Phil, Furiosa",
                "Fred, Bastion, Meredith", "Bobbin, Finn"));
            list.AddRange(new List<CreditNode>
            {
                new Image(Graphics.MiscAtlas, "fmod"),
                new Image(Graphics.MiscAtlas, "monogame"),
                new ImageRow(new Image(Graphics.MiscAtlas, "fna"), new Image(Graphics.MiscAtlas, "xna")),
            });
            list.Add(new Break(540f));
            if (polaroids) list.Add(new Image(Graphics.PortraitsAtlas, "credits/d", 0f, 0.05f, true));

            list.Add(
                new Ending(((IOriginalGameTextEnvironment)engine).Text.CleanDialog("CREDITS_THANKYOU"), !polaroids));
            return list;
        }

        public CreditsPresentation(ISourceEngineContext engine, float alignment = 0.5f, float scale = 1f,
            bool haveTitle = true, bool havePolaroids = false)
        {
            this.engine = engine ?? throw new ArgumentNullException(nameof(engine));
            this.alignment = alignment;
            this.scale = scale;
            credits = CreateCredits(haveTitle, havePolaroids);
            var text = ((IOriginalGameTextEnvironment)engine).Text;
            Process.Font = text.Fonts.Get(text.Dialog.Languages["english"].FontFace);
            Process.FontSize = text.Dialog.Languages["english"].FontFaceSize;
            Process.LineHeight = Process.Font.Get(Process.FontSize).LineHeight;
            height = 0f;
            foreach (var credit in credits) height += credit.Height(this, scale) + 64f * scale;

            height += 476f;
            if (havePolaroids) height -= 280f;
        }

        public void Update()
        {
            if (Enabled)
            {
                scroll += scrollSpeed * engine.Frame.DeltaTime * scale;
                if (scrollDelay <= 0f)
                    scrollSpeed =
                        ScalarMath.Approach(scrollSpeed,
                            100f * AutoScrollSpeedMultiplier, 1800f * engine.Frame.DeltaTime,
                            ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
                else
                    scrollDelay -= engine.Frame.DeltaTime;

                if (AllowInput)
                {
                    if (((IGameInputEnvironment)engine).Input[GameAction.MenuDown].Check)
                    {
                        scrollDelay = 1f;
                        scrollSpeed = ScalarMath.Approach(scrollSpeed, 600f,
                            1800f * engine.Frame.DeltaTime, ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
                    }
                    else if (((IGameInputEnvironment)engine).Input[GameAction.MenuUp].Check)
                    {
                        scrollDelay = 1f;
                        scrollSpeed = ScalarMath.Approach(scrollSpeed, -600f,
                            1800f * engine.Frame.DeltaTime, ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
                    }
                    else if (scrollDelay > 0f)
                    {
                        scrollSpeed = ScalarMath.Approach(scrollSpeed, 0f,
                            1800f * engine.Frame.DeltaTime, ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
                    }
                }

                if (scroll < 0f || scroll > height) scrollSpeed = 0f;

                scroll = ScalarMath.Clamp(scroll, 0f, height);
                if (scroll >= height)
                    BottomTimer += engine.Frame.DeltaTime;
                else
                    BottomTimer = 0f;
            }

            scrollbarAlpha =
                ScalarMath.Approach(scrollbarAlpha,
                    Enabled && scrollDelay > 0f ? 1f : 0f, engine.Frame.DeltaTime * 2f,
                    ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
        }

        public void Render(ISourceRenderContext context, Vector2 position)
        {
            var position2 = position + Floor(new(0f, 1080f - scroll));
            foreach (var credit in credits)
            {
                var num = credit.Height(this, scale);
                if (position2.Y > 0f - num && position2.Y < 1080f)
                    credit.Render(context, this, position2, alignment, scale);

                position2.Y += num + 64f * scale;
            }

            if (scrollbarAlpha > 0f)
            {
                var num2 = 64;
                var num3 = 1080 - num2 * 2;
                var num4 = num3 * (num3 / height);
                var num5 = scroll / height * (num3 - num4);
                DrawRect(context, 1844f, num2, 12f, num3,
                    PackedColor.White * .2f * scrollbarAlpha);
                DrawRect(context, 1844f, num2 + num5, 12f, num4,
                    PackedColor.White * .5f * scrollbarAlpha);
            }
        }
    }
}
