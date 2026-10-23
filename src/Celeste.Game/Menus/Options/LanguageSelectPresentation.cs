using Celeste.Core.Display;
using System;
using System.Collections;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Scheduling;
using Celeste.Core.Rendering;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Mathematics.Easing;
using Celeste.Audio.Fmod.Events;
using Celeste.Input.Gameplay;
using Celeste.Game.Content.Dialogs;
using Celeste.Game.Controls.Source;
using Celeste.Game.Menus.Controls;
using Celeste.Game.Menus.Overworld;
using Celeste.Game.Execution.Engine;
using Celeste.Game.Execution.Graphics;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Execution.Startup;
using Celeste.Game.Settings;
using Celeste.Game.UI.Controls;
using Celeste.Scene.Entities;
using Celeste.Scene.Scenes;
using Celeste.Scene.Tracking;
using Celeste.Simulation.UI.Menus.Text;
using Celeste.Graphics.Content;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Display;
using Celeste.Graphics.Rendering;
using Celeste.Graphics.Text;
using DialogLanguage = Celeste.Localization.Languages.DialogLanguage;

namespace Celeste.Game.Menus.Options
{
    public class LanguageSelectPresentation : TextMenuPresentation
    {
        protected readonly ISourceEngineContext engine;
        protected OriginalGameInputProcess Input => ((IOriginalGameInputProcessEnvironment)engine).InputSource;
        protected SettingsState Settings => ((ISettingsContext)engine).Settings;
        protected OriginalGameTextProcess Text => ((IOriginalGameTextEnvironment)engine).Text;

        protected OriginalGameGraphicsResources Graphics =>
            (OriginalGameGraphicsResources)((ISourceGameGraphicsEnvironment)engine).GameGraphics;

        protected Celeste.Localization.Lookup.DialogCatalog Dialog => Text.Dialog;

        protected Celeste.Game.Audio.Runtime.OriginalGameAudioSession Audio =>
            ((IOriginalGameplayProcess)engine).AudioSession;

        private ISourceExtremaArithmetic Extrema => ((ISourceExtremaEnvironment)engine).ExtremaArithmetic;
        private ISourceEasingArithmetic Ease => ((ISourceEasingEnvironment)engine).EasingArithmetic;

        private class LanguageOption : Item
        {
            public DialogLanguage Language;

            private float selectedEase;

            public bool Selected => Container.Current == this;

            public LanguageOption(DialogLanguage language)
            {
                Selectable = true;
                Language = language;
            }

            public override void Added()
            {
                Container.InnerContent = InnerContentMode.OneColumn;
                if (((LanguageSelectPresentation)Container).Dialog.Language == Language)
                {
                    Container.Current = this;
                }
            }

            public override float LeftWidth()
            {
                return Language.Icon.FrameWidth;
            }

            public override float Height()
            {
                return Language.Icon.FrameHeight;
            }

            public override void Update()
            {
                selectedEase = ScalarMath.Approach(selectedEase, Selected ? 1f : 0f,
                    ((LanguageSelectPresentation)Container).engine.DeltaTime * 5f,
                    ((LanguageSelectPresentation)Container).Extrema);
            }

            public override void Render(ISourceRenderContext context, Vector2 position, bool highlighted)
            {
                PackedColor color = (Disabled
                    ? new PackedColor(47, 79, 79, 255)
                    : ((highlighted ? Container.HighlightColor : PackedColor.White) * Container.Alpha));
                position += (1f - ((LanguageSelectPresentation)Container).Ease.CubeOut(Container.Alpha)) *
                            Vector2.UnitY *
                            32f;
                if (Selected)
                {
                    SourceAtlasDrawing.DrawCentered(context, Container,
                        ((LanguageSelectPresentation)Container).Graphics.GuiAtlas["dotarrow_outline"], position, color);
                }

                position += Vector2.UnitX * ((LanguageSelectPresentation)Container).Ease.CubeInOut(selectedEase) * 32f;
                SourceAtlasDrawing.DrawJustified(context, Container, Language.Icon, position, new Vector2(0f, 0.5f),
                    PackedColor.White * Container.Alpha, 1f);
            }
        }

        private bool open = true;

        public LanguageSelectPresentation(ISourceEngineContext engine) : base(engine)
        {
            this.engine = engine;
            Tags = ((IOriginalGameTagsEnvironment)engine).Tags.HUD.Value |
                   ((IOriginalGameTagsEnvironment)engine).Tags.PauseUpdate.Value;
            Alpha = 0f;
            foreach (DialogLanguage language in Dialog.OrderedLanguages)
            {
                Add(new LanguageOption(language).Pressed(delegate
                {
                    open = false;
                    SetNextLanguage(language);
                }));
            }

            OnESC = (OnPause = (OnCancel = delegate
            {
                open = false;
                Focused = false;
            }));
        }

        private void SetNextLanguage(DialogLanguage next)
        {
            if (Settings.LanguageId != next.Id)
            {
                DialogLanguage language = Dialog.Languages[Settings.LanguageId];
                DialogLanguage language2 = Dialog.Languages["english"];
                if (language.FontFace != language2.FontFace)
                {
                    Text.Fonts.Unload(language.FontFace);
                }

                Text.Fonts.Load(next.FontFace);
                Settings.LanguageId = next.Id;
                Text.ApplyLanguage(Settings);
            }
        }

        public override void Update()
        {
            if (Alpha > 0f)
            {
                base.Update();
            }

            if (!open && Alpha <= 0f)
            {
                Close();
            }

            Alpha = ScalarMath.Approach(Alpha, open ? 1 : 0, engine.DeltaTime * 8f, Extrema);
        }

        public override void Render(ISourceRenderContext context)
        {
            if (Alpha > 0f)
            {
                SourcePrimitiveDrawing.Rect(context, this, -10f, -10f, 1940f, 1100f,
                    PackedColor.Black * Ease.CubeOut(Alpha));
                base.Render(context);
            }
        }
    }
}
