using Celeste.Core.Display;
using Celeste.Core.Mathematics.Extrema;
using System;
using System.Collections;
using System.Numerics;
using Celeste.Core.Mathematics;
using Celeste.Core.Randomness;
using Celeste.Core.Rendering;
using Celeste.Core.Rendering.States;
using Celeste.Core.Scheduling;
using Celeste.Everest.Content.Maps.Metadata;
using Celeste.Audio.Fmod.Events;
using Celeste.Input.Gameplay;
using Celeste.Game.Audio;
using Celeste.Game.Chapters.Flow;
using Celeste.Game.Content.Dialogs;
using Celeste.Game.Entities;
using Celeste.Game.Menus.Overworld;
using Celeste.Game.Presentation.Environment;
using Celeste.Game.Presentation.Hud;
using Celeste.Game.Execution.Engine;
using Celeste.Game.Execution.Graphics;
using Celeste.Game.Execution.Startup;
using Celeste.Scene.Scenes;
using Celeste.Scene.Tracking;
using Celeste.Simulation.Presentation.Scene.Transitions;
using Celeste.Simulation.Runtime.Session;
using Celeste.Simulation.UI.Menus.Text;
using Celeste.Graphics.Content;
using Celeste.Graphics.Display;
using Celeste.Graphics.Rendering;
using Celeste.Graphics.Rendering.Drawing;
using Celeste.Graphics.Text.RichText.Drawing;
using Celeste.Graphics.Text.RichText.Layout;
using Celeste.Graphics.Text.RichText.Nodes;
using global::Celeste.Game.Execution;

namespace Celeste.Everest.Runtime.Chapters.Flow
{
    public sealed class CustomTextVignetteScene : SourceSceneState
    {
        private ChapterCompletionSession session;
        private FmodEventReference sfx;
        private string areaMusic;
        private TextMenuPresentation menu;
        private bool started, exiting;
        private float fade, pauseFade, initialDelay, finalDelay;
        private RichTextLayout text;
        private int textStart;
        private float textAlpha;
        private SimulationCoroutine textCoroutine;
        private HudRendererState renderer;
        private HiresSnowState snow;
        private readonly IOriginalLevelEnterProcess process;
        public bool CanPause => menu == null;

        public CustomTextVignetteScene(ChapterCompletionSession session, MapMetaTextVignette meta,
            HiresSnowState snow, IOriginalLevelEnterProcess process)
            : base(process, ((ISourceSceneCatalogEnvironment)process).SceneCatalog,
                ((global::Celeste.Scene.Scheduling.ISourceSceneUpdatePolicyEnvironment)process).PlainScenePolicy)
        {
            this.process = process;
            this.session = session;
            areaMusic = session.Audio.Music.Event;
            session.Audio.Music.Event = null;
            OriginalAudioSession.Apply(session.Audio, process.AudioSession.ChannelOutput, process.AudioApplyPolicy,
                false);
            sfx = process.AudioSession.Play(meta.Audio);
            if (snow == null)
            {
                fade = 1f;
                snow = new HiresSnowState(process);
            }

            snow.Direction = meta.SnowDirection;
            Renderers.Add(renderer = new HudRendererState());
            Renderers.Add(this.snow = snow);
            Renderers.UpdateLists();
            initialDelay = meta.InitialDelay;
            finalDelay = meta.FinalDelay;
            text = OriginalFancyTextParser.Parse(process.Text.Dialog.Get(meta.Dialog), 960, 8, 0f,
                context: OriginalFancyTextContext.Create((IOriginalFancyTextProcess)process));
            textCoroutine = new SimulationCoroutine(process, TextSequence());
        }

        public CustomTextVignetteScene(ChapterCompletionSession session, string text,
            HiresSnowState snow, IOriginalLevelEnterProcess process)
            : this(session, new MapMetaTextVignette { Dialog = text }, snow, process)
        {
        }

        private IEnumerator TextSequence()
        {
            yield return initialDelay;
            while (textStart < text.Count)
            {
                textAlpha = 1f;
                int charactersOnPage = text.GetCharactersOnPage(textStart);
                float fadeTimePerCharacter = 1f / (float)charactersOnPage;
                for (int i = textStart; i < text.Count && !(text[i] is RichTextPageBreak); i++)
                {
                    RichTextNode node = text[i];
                    if (node is RichTextGlyph character)
                    {
                        while ((character.Fade += process.Frame.DeltaTime / fadeTimePerCharacter) < 1f)
                            yield return null;
                        character.Fade = 1f;
                    }
                }

                yield return 2.5f;
                while (textAlpha > 0f)
                {
                    textAlpha -= 1f * process.Frame.DeltaTime;
                    yield return null;
                }

                textAlpha = 0f;
                textStart = text.GetNextPageStart(textStart);
                yield return .5f;
            }

            if (finalDelay > 0f)
                yield return finalDelay;
            if (!started)
                StartGame();
            textStart = int.MaxValue;
        }

        public override void Update()
        {
            if (menu == null)
            {
                base.Update();
                if (!exiting)
                {
                    if (textCoroutine != null && textCoroutine.Active)
                        textCoroutine.Update();
                    var input = ((IGameInputEnvironment)process).Input;
                    if (menu == null && (input[GameAction.Pause].Pressed || input[GameAction.Escape].Pressed))
                    {
                        input[GameAction.Pause].ConsumeBuffer();
                        input[GameAction.Escape].ConsumeBuffer();
                        OpenMenu();
                    }
                }
            }
            else if (!exiting)
                menu.Update();

            var extrema = ((ISourceExtremaEnvironment)process).ExtremaArithmetic;
            pauseFade = ScalarMath.Approach(pauseFade, menu != null ? 1 : 0, process.Frame.DeltaTime * 8f, extrema);
            renderer.BackgroundFade = ScalarMath.Approach(renderer.BackgroundFade, menu != null ? .6f : 0f,
                process.Frame.DeltaTime * 3f, extrema);
            fade = ScalarMath.Approach(fade, 0f, process.Frame.DeltaTime, extrema);
        }

        public void OpenMenu()
        {
            process.AudioSession.Play("event:/ui/game/pause");
            process.AudioSession.Pause(sfx);
            SourceScene.QueueSourceEntity(menu = new TextMenuPresentation(process));
            menu.Add(new TextMenuPresentation.Button(process.Text.Dialog.Clean("intro_vignette_resume"))
                .Pressed(CloseMenu));
            menu.Add(
                new TextMenuPresentation.Button(process.Text.Dialog.Clean("intro_vignette_skip")).Pressed(StartGame));
            menu.Add(new TextMenuPresentation.Button(process.Text.Dialog.Clean("intro_vignette_quit"))
                .Pressed(ReturnToMap));
            menu.OnCancel = menu.OnESC = menu.OnPause = CloseMenu;
        }

        private void CloseMenu()
        {
            process.AudioSession.Play("event:/ui/game/unpause");
            process.AudioSession.Resume(sfx);
            menu?.RemoveSelf();
            menu = null;
        }

        private void StartGame()
        {
            textCoroutine = null;
            StopSfx();
            session.Audio.Music.Event = areaMusic;
            if (menu != null)
            {
                menu.RemoveSelf();
                menu = null;
            }

            new FadeWipePresentation(this, false,
                () => process.Frame.Scenes.NextScene = process.LevelLoaders.CreateLevelLoader(session))
            {
                OnUpdate = f =>
                    textAlpha = ((ISourceExtremaEnvironment)process).ExtremaArithmetic.Min(textAlpha, 1f - f)
            };
            started = true;
            exiting = true;
        }

        private void ReturnToMap()
        {
            StopSfx();
            menu.RemoveSelf();
            menu = null;
            exiting = true;
            bool toAreaQuit = process.SaveCounters.GetAreasSafe(process.SaveContext.CurrentSave)[0].Modes[0].Completed
                              && ((IOriginalGamePlayModeEnvironment)process).PlayMode !=
                              GameRuntime.PlayModes.Event;
            new FadeWipePresentation(this, false, () => process.Frame.Scenes.NextScene =
                process.OverworldLoaders.CreateOverworldLoader(
                    toAreaQuit ? OverworldStartMode.AreaQuit : OverworldStartMode.Titlescreen, snow))
            {
                OnUpdate = f =>
                    textAlpha = ((ISourceExtremaEnvironment)process).ExtremaArithmetic.Min(textAlpha, 1f - f)
            };
            Renderers.UpdateLists();
            Renderers.MoveToFront(snow);
        }

        private void StopSfx() => process.AudioSession.Stop(sfx, false);

        public override void End()
        {
            StopSfx();
            base.End();
        }

        public override void Render()
        {
            base.Render();
            if (fade > 0f || textAlpha > 0f)
            {
                var context = SourceRenderContext;
                var batch = ((ISourceDrawScope)context).Draw.SpriteBatch;
                batch.Begin(SourceSpriteSortMode.Deferred, SourceBlendState.AlphaBlend, SourceSamplerState.LinearClamp,
                    null, SourceRasterizerState.CullNone, null,
                    ((IOriginalEngineGraphicsEnvironment)process).EngineGraphics.ScreenMatrix);
                if (fade > 0f)
                    SourcePrimitiveDrawing.Rect(context, this, -1f, -1f, 1922f, 1082f, PackedColor.Black * fade);
                if (textStart < text.Nodes.Count && textAlpha > 0f)
                    text.DrawJustifyPerLine(context, this, (ISourceRichTextDrawProcess)process,
                        new Vector2(1920f, 1080f) * .5f, new Vector2(.5f, .5f), Vector2.One,
                        textAlpha * (1f - pauseFade), textStart);
                batch.End();
            }
        }
    }
}
