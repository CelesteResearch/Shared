using System;
using System.Collections;
using System.Numerics;
using Celeste.Core.Display;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Rendering;
using Celeste.Core.Rendering.States;
using Celeste.Core.Scheduling;
using Celeste.Game.Content.Dialogs;
using Celeste.Game.Controls.Source;
using Celeste.Game.Execution;
using Celeste.Game.Execution.Engine;
using Celeste.Game.Execution.LevelLoader;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Execution.Startup;
using Celeste.Game.Menus.Overworld;
using Celeste.Game.Presentation.Environment;
using Celeste.Game.Presentation.Hud;
using Celeste.Game.Save.Runtime;
using Celeste.Graphics.Rendering;
using Celeste.Graphics.Text.RichText.Drawing;
using Celeste.Graphics.Text.RichText.Layout;
using Celeste.Graphics.Text.RichText.Nodes;
using Celeste.Scene.Scenes;
using Celeste.Scene.Scheduling;
using Celeste.Scene.Tracking;
using Celeste.Simulation.Presentation.Scene.Transitions;
using Celeste.Simulation.Runtime.Session;
using Celeste.Simulation.UI.Menus.Text;

namespace Celeste.Game.Vignettes
{
    public class CoreVignetteSequence : SourceSceneState
    {
        private readonly ISourceEngineContext engine;
        private IOriginalGameplayProcess Process => (IOriginalGameplayProcess)engine;
        private OriginalGameInputProcess Input => ((IOriginalGameInputProcessEnvironment)engine).InputSource;
        private OriginalGameTextProcess Text => ((IOriginalGameTextEnvironment)engine).Text;
        private ISourceExtremaArithmetic Extrema => ((ISourceExtremaEnvironment)engine).ExtremaArithmetic;
        private readonly ChapterCompletionSession session;

        private SimulationCoroutine textCoroutine;

        private readonly RichTextLayout text;

        private int textStart;

        private float textAlpha;

        private readonly HiresSnowState snow;

        private readonly HudRendererState hud;

        private TextMenuPresentation menu;

        private float fade;

        private float pauseFade;

        private bool started;

        private bool exiting;

        public bool CanPause => menu == null;

        public CoreVignetteSequence(ChapterCompletionSession session, ISourceEngineContext engine,
            HiresSnowState snow = null)
            : base(engine, ((ISourceSceneCatalogEnvironment)engine).SceneCatalog,
                ((ISourceSceneUpdatePolicyEnvironment)engine).PlainScenePolicy)
        {
            this.engine = engine;
            this.session = session;
            if (snow == null) snow = new(engine);

            Renderers.Add(hud = new());
            Renderers.Add(this.snow = snow);
            Renderers.UpdateLists();
            text = OriginalFancyTextParser.Parse(Text.Dialog.Get("APP_INTRO"), 960, 8, 0f,
                context: OriginalFancyTextContext.Create((IOriginalFancyTextProcess)engine));
            textCoroutine = new(engine, TextSequence());
        }

        private IEnumerator TextSequence()
        {
            yield return 1f;
            while (textStart < text.Count)
            {
                textAlpha = 1f;
                var charactersOnPage = text.GetCharactersOnPage(textStart);
                var fadeTimePerCharacter = 1f / charactersOnPage;
                for (var i = textStart; i < text.Count && !(text[i] is RichTextPageBreak); i++)
                    if (text[i] is RichTextGlyph c)
                    {
                        while ((c.Fade += engine.Frame.DeltaTime / fadeTimePerCharacter) < 1f) yield return null;

                        c.Fade = 1f;
                    }

                yield return 2.5f;
                while (textAlpha > 0f)
                {
                    textAlpha -= 1f * engine.Frame.DeltaTime;
                    yield return null;
                }

                textAlpha = 0f;
                textStart = text.GetNextPageStart(textStart);
                yield return 0.5f;
            }

            if (!started) StartGame();

            textStart = int.MaxValue;
        }

        public override void Update()
        {
            if (menu == null)
            {
                base.Update();
                if (!exiting)
                {
                    if (textCoroutine != null && textCoroutine.Active) textCoroutine.Update();

                    if (menu == null && (Input.Pause.Pressed || Input.ESC.Pressed))
                    {
                        Input.Pause.ConsumeBuffer();
                        Input.ESC.ConsumeBuffer();
                        OpenMenu();
                    }
                }
            }
            else if (!exiting)
            {
                menu.Update();
            }

            pauseFade = ScalarMath.Approach(pauseFade, menu != null ? 1 : 0, engine.Frame.DeltaTime * 8f, Extrema);
            hud.BackgroundFade = ScalarMath.Approach(hud.BackgroundFade, menu != null ? 0.6f : 0f,
                engine.Frame.DeltaTime * 3f, Extrema);
            fade = ScalarMath.Approach(fade, 0f, engine.Frame.DeltaTime, Extrema);
        }

        public void OpenMenu()
        {
            Process.AudioSession.Play("event:/ui/game/pause");
            SourceScene.QueueSourceEntity(menu = new(engine));
            menu.Add(new TextMenuPresentation.Button(Text.Dialog.Clean("intro_vignette_resume")).Pressed(CloseMenu));
            menu.Add(new TextMenuPresentation.Button(Text.Dialog.Clean("intro_vignette_skip")).Pressed(StartGame));
            menu.Add(new TextMenuPresentation.Button(Text.Dialog.Clean("intro_vignette_quit")).Pressed(ReturnToMap));
            menu.OnCancel = menu.OnESC = menu.OnPause = CloseMenu;
        }

        private void CloseMenu()
        {
            Process.AudioSession.Play("event:/ui/game/unpause");
            if (menu != null) menu.RemoveSelf();

            menu = null;
        }

        private void StartGame()
        {
            textCoroutine = null;
            if (menu != null)
            {
                menu.RemoveSelf();
                menu = null;
            }

            new FadeWipePresentation(this, false,
                delegate
                {
                    engine.Frame.Scenes.NextScene =
                        ((IOriginalLevelLoaderEnvironment)engine).LevelLoaders.CreateLevelLoader(session);
                }).OnUpdate = delegate(float f) { textAlpha = Math.Min(textAlpha, 1f - f); };
            started = true;
            exiting = true;
        }

        private void ReturnToMap()
        {
            menu.RemoveSelf();
            menu = null;
            exiting = true;
            var toAreaQuit =
                ((IOriginalSaveCounterEnvironment)engine).SaveCounters.GetAreasSafe(Process.SaveContext.CurrentSave)[0]
                .Modes[0].Completed && ((IOriginalGamePlayModeEnvironment)engine).PlayMode !=
                GameRuntime.PlayModes.Event;
            new FadeWipePresentation(this, false, delegate
            {
                if (toAreaQuit)
                    engine.Frame.Scenes.NextScene =
                        ((IOriginalOverworldLoaderEnvironment)engine).OverworldLoaders.CreateOverworldLoader(
                            OverworldStartMode.AreaQuit, snow);
                else
                    engine.Frame.Scenes.NextScene =
                        ((IOriginalOverworldLoaderEnvironment)engine).OverworldLoaders.CreateOverworldLoader(
                            OverworldStartMode.Titlescreen, snow);
            }).OnUpdate = delegate(float f) { textAlpha = Math.Min(textAlpha, 1f - f); };
            Renderers.UpdateLists();
            Renderers.MoveToFront(snow);
        }

        public override void Render()
        {
            base.Render();
            var context = ((ISourceRenderEnvironment)engine).CurrentContext;
            if (fade > 0f || textAlpha > 0f)
            {
                context.BeginBatch(new(SourceSpriteSortMode.Deferred,
                    SourceBlendState.AlphaBlend,
                    SourceSamplerState.LinearClamp, null, SourceRasterizerState.CullNone, null,
                    ((IOriginalEngineGraphicsEnvironment)engine).EngineGraphics.ScreenMatrix));
                if (fade > 0f)
                    SourcePrimitiveDrawing.Rect(context, this, -1f, -1f, 1922f, 1082f, PackedColor.Black * fade);

                if (textStart < text.Nodes.Count && textAlpha > 0f)
                    text.Draw(context, this, (ISourceRichTextDrawProcess)engine, new Vector2(1920f, 1080f) * 0.5f,
                        new(0.5f, 0.5f), Vector2.One, textAlpha * (1f - pauseFade), textStart);

                context.EndBatch();
            }
        }
    }
}
