using System;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Display;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Game.Audio.Runtime;
using Celeste.Game.Content.Dialogs;
using Celeste.Game.Controls.Source;
using Celeste.Game.Execution;
using Celeste.Game.Execution.Graphics;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Execution.Startup;
using Celeste.Game.Menus.Overworld;
using Celeste.Game.Settings;
using Celeste.Game.UI.Controls;
using Celeste.Graphics.Content;
using Celeste.Graphics.Rendering;
using Celeste.Graphics.Text;
using Celeste.Localization.Lookup;
using Celeste.Scene.Entities;
using Celeste.Scene.Scenes;

namespace Celeste.Game.Menus.Options
{
    public class ViewportAdjustmentPresentation : SceneEntityState
    {
        protected readonly ISourceEngineContext engine;
        protected OriginalGameInputProcess Input => ((IOriginalGameInputProcessEnvironment)engine).InputSource;
        protected SettingsState Settings => ((ISettingsContext)engine).Settings;
        protected OriginalGameTextProcess Text => ((IOriginalGameTextEnvironment)engine).Text;

        protected OriginalGameGraphicsResources Graphics =>
            (OriginalGameGraphicsResources)((ISourceGameGraphicsEnvironment)engine).GameGraphics;

        protected DialogCatalog Dialog => Text.Dialog;

        protected OriginalGameAudioSession Audio =>
            ((IOriginalGameplayProcess)engine).AudioSession;

        private ISourceExtremaArithmetic Extrema => ((ISourceExtremaEnvironment)engine).ExtremaArithmetic;
        private ISourceEasingArithmetic Ease => ((ISourceEasingEnvironment)engine).EasingArithmetic;
        private ActiveBitmapFont Font => ((ISourceActiveFontScope)engine).ActiveFont;
        private const float minPadding = 0f;

        private const float maxPadding = 128f;

        private readonly float originalPadding;

        private float viewPadding;

        private float inputDelay;

        private bool closing;

        private bool canceling;

        private float leftAlpha = 1f;

        private float rightAlpha = 1f;

        public Action OnClose;

        public float Alpha { get; private set; }

        public bool Open { get; private set; }

        public ViewportAdjustmentPresentation(ISourceEngineContext engine) : base(
            ((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration)
        {
            this.engine = engine;
            originalPadding = EngineRuntime.ViewPadding;
            viewPadding = EngineRuntime.ViewPadding;
            Open = true;
            Tags = ((IOriginalGameTagsEnvironment)engine).Tags.HUD.Value |
                   ((IOriginalGameTagsEnvironment)engine).Tags.PauseUpdate.Value;
        }

        public override void Added(object scene)
        {
            base.Added(scene);
            if (scene is OverworldSequence) (scene as OverworldSequence).Mountain.Model.LockBufferResizing = true;
        }

        public override void Removed(object scene)
        {
            if (scene is OverworldSequence) (scene as OverworldSequence).Mountain.Model.LockBufferResizing = false;

            base.Removed(scene);
        }

        public override void Update()
        {
            base.Update();
            if (!closing)
            {
                inputDelay += engine.RawDeltaTime;
                if (inputDelay > 0.25f)
                {
                    if (Input.MenuCancel.Pressed || Input.ESC.Pressed)
                        closing = canceling = true;
                    else if (Input.MenuConfirm.Pressed) closing = true;
                }
            }
            else if (Alpha <= 0f)
            {
                if (canceling)
                    EngineRuntime.ViewPadding = (int)originalPadding;
                else
                    Settings.ViewportPadding = (int)viewPadding;

                Settings.SetViewportOnce = true;
                Open = false;
                RemoveSelf();
                if (OnClose != null) OnClose();

                return;
            }

            Alpha = ScalarMath.Approach(Alpha, !closing ? 1 : 0, engine.RawDeltaTime * 4f, Extrema);
            viewPadding -= Input.Aim.Value.X * 48f * engine.RawDeltaTime;
            viewPadding = ScalarMath.Clamp(viewPadding, 0f, 128f, Extrema);
            leftAlpha = ScalarMath.Approach(leftAlpha, viewPadding < 128f ? 1f : 0.25f, engine.DeltaTime * 4f,
                Extrema);
            rightAlpha = ScalarMath.Approach(rightAlpha, viewPadding > 0f ? 1f : 0.25f, engine.DeltaTime * 4f,
                Extrema);
            EngineRuntime.ViewPadding = (int)viewPadding;
        }

        public override void Render(ISourceRenderContext context)
        {
            var num = Ease.SineInOut(Alpha);
            var color = PackedColor.Black * 0.75f * num;
            var color2 = PackedColor.White * num;
            if (!(Scene is OriginalLevelSceneRoot))
                SourcePrimitiveDrawing.Rect(context, this, -1f, -1f, EngineRuntime.Width + 2,
                    EngineRuntime.Height + 2, color);

            SourcePrimitiveDrawing.Rect(context, this, 0f, 0f, EngineRuntime.Width, 16f, color2);
            SourcePrimitiveDrawing.Rect(context, this, 0f, 16f, 16f, EngineRuntime.Height - 32, color2);
            SourcePrimitiveDrawing.Rect(context, this, EngineRuntime.Width - 16, 16f, 16f,
                EngineRuntime.Height - 32, color2);
            SourcePrimitiveDrawing.Rect(context, this, 0f, EngineRuntime.Height - 16, EngineRuntime.Width,
                16f, color2);
            SourcePrimitiveDrawing.LineAngle(context, this, new(8f, 8f), (float)Math.PI / 4f, 128f, color2,
                16f);
            SourcePrimitiveDrawing.LineAngle(context, this, new(EngineRuntime.Width - 8, 8f),
                (float)Math.PI * 3f / 4f, 128f, color2, 16f);
            SourcePrimitiveDrawing.LineAngle(context, this, new(8f, EngineRuntime.Height - 8),
                -(float)Math.PI / 4f, 128f, color2, 16f);
            SourcePrimitiveDrawing.LineAngle(context, this,
                new(EngineRuntime.Width - 8, EngineRuntime.Height - 8), (float)Math.PI * -3f / 4f,
                128f, color2, 16f);
            var text = Dialog.Clean("OPTIONS_VIEWPORT_PC");
            Font.Measure(text);
            var num2 = (float)Math.Sin(((SourceSceneState)Scene).RawTimeActive * 2f) * 16f;
            var vector = new Vector2(EngineRuntime.Width, EngineRuntime.Height) * 0.5f;
            Font.Draw(context, this, text, vector + new Vector2(0f, -60f), new(0.5f, 0.5f), Vector2.One * 1.2f,
                color2);
            var num3 = OriginalButtonUi.Width(engine, Dialog.Clean("ui_confirm"), Input.MenuConfirm) * 0.8f;
            OriginalButtonUi.Render(context, this, engine, vector + new Vector2(0f, 60f), Dialog.Clean("ui_confirm"),
                Input.MenuConfirm, 0.8f, 0.5f, 0f, num);
            var vector2 = vector + new Vector2(num3 * 0.6f + 80f + num2, 60f);
            SourceAtlasDrawing.DrawCentered(context, this, Graphics.GuiAtlas["adjustarrowright"],
                vector2 + new Vector2(8f, 4f), color2 * rightAlpha, Vector2.One);
            var vector3 = vector + new Vector2(0f - (num3 * 0.6f + 80f + num2), 60f);
            SourceAtlasDrawing.DrawCentered(context, this, Graphics.GuiAtlas["adjustarrowleft"],
                vector3 + new Vector2(-8f, 4f), color2 * leftAlpha, Vector2.One);
        }
    }
}
