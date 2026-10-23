using Celeste.Core.Display;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Numerics;
using Celeste.Core.Audio;
using Celeste.Core.Components;
using Celeste.Core.Components.Rendering;
using Celeste.Core.Geometry;
using Celeste.Core.Scheduling;
using Celeste.Core.Rendering;
using Celeste.Core.Rendering.States;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Mathematics.LinearAlgebra;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
using Celeste.Physics.Collision.Shapes;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Formats.Graphics.Atlas;
using Celeste.Game.Components.Talking;
using Celeste.Game.Content.Dialogs;
using Celeste.Game.Entities.Npcs.Theo;
using Celeste.Game.Stories.Temple.Cutscenes;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Levels.Cutscenes;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Execution.Graphics;
using Celeste.Game.Execution.Engine;
using Celeste.Game.Execution.Startup;
using Celeste.Game.Settings;
using Celeste.Game.UI.Dialogue.Textboxes;
using Celeste.Graphics.Content;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Content.VirtualAssets;
using Celeste.Graphics.Display;
using Celeste.Graphics.Rendering;
using Celeste.Graphics.Rendering.Drawing;
using Celeste.Graphics.Rendering.Devices;
using Celeste.Graphics.Text.RichText.Layout;
using Celeste.Graphics.Text.RichText.Drawing;
using Celeste.Input.Gameplay;
using Celeste.Simulation;
using global::Celeste.Game.Execution;

namespace Celeste.Game.Stories.Interactions
{
    public class CS02JournalState : OriginalCutsceneEntityState
    {
        private readonly ISourceEngineContext engine;

        private class PoemPage : SceneEntityState
        {
            private readonly ISourceEngineContext engine;
            private const float TextScale = 0.7f;

            private AtlasEntry paper;

            private VirtualRenderTarget target;

            private RichTextLayout text;

            private float alpha = 1f;

            private float scale = 1f;

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
                    (int)((float)(paper.FrameWidth - 120) / 0.7f), -1, 1f, PackedColor.Black * 0.6f,
                    OriginalFancyTextContext.Create((IOriginalFancyTextProcess)engine));
                OwnedComponents.Add(new BeforeRenderCallbackComponentState(BeforeRender));
            }

            public IEnumerator EaseIn()
            {
                ((IOriginalGameplayProcess)engine).AudioSession.Play("event:/game/03_resort/memo_in");
                Vector2 vector = new Vector2(EngineRuntime.Width, EngineRuntime.Height) / 2f;
                Vector2 from = vector + new Vector2(0f, 200f);
                Vector2 to = vector;
                float rFrom = -0.1f;
                float rTo = 0.05f;
                for (float p = 0f; p < 1f; p += engine.DeltaTime)
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
                Vector2 from = Position;
                Vector2 to = new Vector2(EngineRuntime.Width, EngineRuntime.Height) / 2f +
                             new Vector2(0f, -200f);
                float rFrom = rotation;
                float rTo = rotation + 0.1f;
                for (float p = 0f; p < 1f; p += engine.DeltaTime * 1.5f)
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
                {
                    target = ((ISourceVirtualContentEnvironment)engine).VirtualContent.CreateRenderTarget(
                        "journal-poem",
                        paper.FrameWidth, paper.FrameHeight);
                }

                ((ISourceGraphicsDeviceEnvironment)engine).GraphicsDevice.SetRenderTarget(target.Target);
                ((ISourceGraphicsDeviceEnvironment)engine).GraphicsDevice.Clear(PackedColor.Transparent);
                var context = ((ISourceRenderContextScene)Scene).SourceRenderContext;
                ((ISourceDrawScope)context).Draw.SpriteBatch.Begin(new SourceRenderBatchState(
                    SourceSpriteSortMode.Deferred,
                    SourceBlendState.AlphaBlend, SourceSamplerState.LinearClamp, SourceDepthStencilState.None,
                    SourceRasterizerState.CullCounterClockwise, null, Matrix4x4.Identity));
                SourceAtlasDrawing.Draw(context, this, paper, Vector2.Zero);
                text.DrawJustifyPerLine(context, this, (ISourceRichTextDrawProcess)engine,
                    new Vector2(paper.FrameWidth, paper.FrameHeight) / 2f, new Vector2(0.5f, 0.5f), Vector2.One * 0.7f,
                    1f);
                ((ISourceDrawScope)context).Draw.SpriteBatch.End();
            }

            public override void Removed(object scene)
            {
                if (target != null)
                {
                    target.Dispose();
                }

                target = null;
                base.Removed(scene);
            }

            public override void SceneEnd(object scene)
            {
                if (target != null)
                {
                    target.Dispose();
                }

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
                if ((!(base.Scene is OriginalLevelSceneRoot level) ||
                     (!level.FrozenOrPaused && level.RetryPlayerCorpse == null && !level.SkippingCutscene)) &&
                    target != null)
                {
                    ((ISourceDrawScope)context).Draw.SpriteBatch.Draw(target.Target, Position, target.Bounds,
                        (PackedColor.White * alpha).PackedValue, rotation,
                        new Vector2(target.Width, target.Height) / 2f,
                        scale, SourceSpriteEffects.None, 0f);
                    if (!easingOut)
                    {
                        SourceAtlasDrawing.DrawCentered(context, this,
                            ((OriginalGameGraphicsResources)((ISourceGameGraphicsEnvironment)engine).GameGraphics)
                            .GuiAtlas[
                                "textboxbutton"],
                            Position + new Vector2(target.Width / 2 + 40,
                                target.Height / 2 + ((timer % 1f < 0.25f) ? 6 : 0)), PackedColor.White);
                    }
                }
            }
        }

        private const string ReadOnceFlag = "poem_read";

        private RoomPlayerSession player;

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

            poem = new PoemPage(engine);
            ((ISourceScene)Scene).SourceScene.QueueSourceEntity(poem);
            yield return poem.EaseIn();
            while (!((ISourceGameInputEnvironment)engine).Input.MenuConfirm.Pressed)
            {
                yield return null;
            }

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
            if (poem != null)
            {
                poem.RemoveSelf();
            }
        }
    }
}
