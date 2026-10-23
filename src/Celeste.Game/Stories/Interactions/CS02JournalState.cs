using System.Collections;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Components.Rendering;
using Celeste.Core.Display;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Mathematics.LinearAlgebra;
using Celeste.Core.Rendering;
using Celeste.Core.Rendering.States;
using Celeste.Core.Scheduling;
using Celeste.Game.Content.Dialogs;
using Celeste.Game.Execution;
using Celeste.Game.Execution.Graphics;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Levels.Cutscenes;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Execution.Startup;
using Celeste.Game.UI.Dialogue.Textboxes;
using Celeste.Graphics.Content;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Content.VirtualAssets;
using Celeste.Graphics.Rendering;
using Celeste.Graphics.Rendering.Devices;
using Celeste.Graphics.Rendering.Drawing;
using Celeste.Graphics.Text.RichText.Drawing;
using Celeste.Graphics.Text.RichText.Layout;
using Celeste.Input.Gameplay;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
using Celeste.Simulation;

namespace Celeste.Game.Stories.Interactions
{
    public class CS02JournalState : OriginalCutsceneEntityState
    {
        private readonly ISourceEngineContext engine;

        private class PoemPage : SceneEntityState
        {
            private readonly ISourceEngineContext engine;
            private const float TextScale = 0.7f;

            private readonly AtlasEntry paper;

            private VirtualRenderTarget target;

            private readonly RichTextLayout text;

            private float alpha = 1f;

            private readonly float scale = 1f;

            private float rotation;

            private float timer;

            private bool easingOut;

            public PoemPage(ISourceEngineContext engine)
                : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration)
            {
                this.engine = engine;
                Tags = ((IOriginalGameTagsEnvironment)engine).Tags.HUD.Value;
                paper =
                    ((OriginalGameGraphicsResources)((ISourceGameGraphicsEnvironment)engine).GameGraphics).GuiAtlas[
                        "poempage"];
                text = OriginalFancyTextParser.Parse(((IOriginalFancyTextProcess)engine).Text.Dialog.Get("CH2_POEM"),
                    (int)((paper.FrameWidth - 120) / 0.7f), -1, 1f, PackedColor.Black * 0.6f,
                    OriginalFancyTextContext.Create((IOriginalFancyTextProcess)engine));
                OwnedComponents.Add(new BeforeRenderCallbackComponentState(BeforeRender));
            }

            public IEnumerator EaseIn()
            {
                ((IOriginalGameplayProcess)engine).AudioSession.Play("event:/game/03_resort/memo_in");
                var vector = new Vector2(EngineRuntime.Width, EngineRuntime.Height) / 2f;
                var from = vector + new Vector2(0f, 200f);
                var to = vector;
                var rFrom = -0.1f;
                var rTo = 0.05f;
                for (var p = 0f; p < 1f; p += engine.DeltaTime)
                {
                    Position = SourceVector2Math.Add(from,
                        SourceVector2Math.Multiply(SourceVector2Math.Subtract(to, from),
                            ((ISourceEasingEnvironment)engine).EasingArithmetic.CubeOut(p)));
                    alpha = ((ISourceEasingEnvironment)engine).EasingArithmetic.CubeOut(p);
                    rotation = rFrom + (rTo - rFrom) * ((ISourceEasingEnvironment)engine).EasingArithmetic.CubeOut(p);
                    yield return null;
                }
            }

            public IEnumerator EaseOut()
            {
                ((IOriginalGameplayProcess)engine).AudioSession.Play("event:/game/03_resort/memo_out");
                easingOut = true;
                var from = Position;
                var to = new Vector2(EngineRuntime.Width, EngineRuntime.Height) / 2f +
                         new Vector2(0f, -200f);
                var rFrom = rotation;
                var rTo = rotation + 0.1f;
                for (var p = 0f; p < 1f; p += engine.DeltaTime * 1.5f)
                {
                    Position = SourceVector2Math.Add(from,
                        SourceVector2Math.Multiply(SourceVector2Math.Subtract(to, from),
                            ((ISourceEasingEnvironment)engine).EasingArithmetic.CubeIn(p)));
                    alpha = 1f - ((ISourceEasingEnvironment)engine).EasingArithmetic.CubeIn(p);
                    rotation = rFrom + (rTo - rFrom) * ((ISourceEasingEnvironment)engine).EasingArithmetic.CubeIn(p);
                    yield return null;
                }

                RemoveSelf();
            }

            public void BeforeRender()
            {
                if (target == null)
                    target = ((ISourceVirtualContentEnvironment)engine).VirtualContent.CreateRenderTarget(
                        "journal-poem",
                        paper.FrameWidth, paper.FrameHeight);

                ((ISourceGraphicsDeviceEnvironment)engine).GraphicsDevice.SetRenderTarget(target.Target);
                ((ISourceGraphicsDeviceEnvironment)engine).GraphicsDevice.Clear(PackedColor.Transparent);
                var context = ((ISourceRenderContextScene)Scene).SourceRenderContext;
                ((ISourceDrawScope)context).Draw.SpriteBatch.Begin(new(
                    SourceSpriteSortMode.Deferred,
                    SourceBlendState.AlphaBlend, SourceSamplerState.LinearClamp, SourceDepthStencilState.None,
                    SourceRasterizerState.CullCounterClockwise, null, Matrix4x4.Identity));
                SourceAtlasDrawing.Draw(context, this, paper, Vector2.Zero);
                text.DrawJustifyPerLine(context, this, (ISourceRichTextDrawProcess)engine,
                    new Vector2(paper.FrameWidth, paper.FrameHeight) / 2f, new(0.5f, 0.5f), Vector2.One * 0.7f,
                    1f);
                ((ISourceDrawScope)context).Draw.SpriteBatch.End();
            }

            public override void Removed(object scene)
            {
                if (target != null) target.Dispose();

                target = null;
                base.Removed(scene);
            }

            public override void SceneEnd(object scene)
            {
                if (target != null) target.Dispose();

                target = null;
                base.SceneEnd(scene);
            }

            public override void Update()
            {
                timer += engine.DeltaTime;
                base.Update();
            }

            public override void Render(ISourceRenderContext context)
            {
                if ((!(Scene is OriginalLevelSceneRoot level) ||
                     (!level.FrozenOrPaused && level.RetryPlayerCorpse == null && !level.SkippingCutscene)) &&
                    target != null)
                {
                    ((ISourceDrawScope)context).Draw.SpriteBatch.Draw(target.Target, Position, target.Bounds,
                        (PackedColor.White * alpha).PackedValue, rotation,
                        new Vector2(target.Width, target.Height) / 2f,
                        scale, SourceSpriteEffects.None, 0f);
                    if (!easingOut)
                        SourceAtlasDrawing.DrawCentered(context, this,
                            ((OriginalGameGraphicsResources)((ISourceGameGraphicsEnvironment)engine).GameGraphics)
                            .GuiAtlas[
                                "textboxbutton"],
                            Position + new Vector2(target.Width / 2 + 40,
                                target.Height / 2 + (timer % 1f < 0.25f ? 6 : 0)), PackedColor.White);
                }
            }
        }

        private const string ReadOnceFlag = "poem_read";

        private readonly RoomPlayerSession player;

        private PoemPage poem;

        public CS02JournalState(ISourceEngineContext engine, RoomPlayerSession player)
            : base(engine)
        {
            this.engine = engine;
            this.player = player;
        }

        public override void OnBegin(OriginalLevelSceneRoot level)
        {
            OwnedComponents.Add(new SimulationCoroutine(engine, Routine()));
        }

        private IEnumerator Routine()
        {
            player.Machine.State = 11;
            player.Machine.Locked = true;
            if (!Level.Session.GetFlag("poem_read"))
            {
                yield return TextboxState.Say("ch2_journal", engine);
                yield return 0.1f;
            }

            poem = new(engine);
            ((ISourceScene)Scene).SourceScene.QueueSourceEntity(poem);
            yield return poem.EaseIn();
            while (!((ISourceGameInputEnvironment)engine).Input.MenuConfirm.Pressed) yield return null;

            ((IOriginalGameplayProcess)engine).AudioSession.Play("event:/ui/main/button_lowkey");
            yield return poem.EaseOut();
            poem = null;
            EndCutscene(Level);
        }

        public override void OnEnd(OriginalLevelSceneRoot level)
        {
            player.Machine.Locked = false;
            player.Machine.State = 0;
            level.Session.SetFlag("poem_read");
            if (poem != null) poem.RemoveSelf();
        }
    }
}
