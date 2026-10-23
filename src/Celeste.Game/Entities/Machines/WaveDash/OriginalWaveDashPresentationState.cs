using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Numerics;
using System.Threading;
using Celeste.Audio.Fmod.Events;
using Celeste.Core.Components;
using Celeste.Core.Components.Rendering;
using Celeste.Core.Display;
using Celeste.Core.Geometry;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Mathematics.LinearAlgebra;
using Celeste.Core.Rendering;
using Celeste.Core.Rendering.States;
using Celeste.Core.Scheduling;
using Celeste.Formats.Graphics.Atlas;
using Celeste.Game.Entities.Machines.WaveDash.Pages;
using Celeste.Game.Execution.Graphics;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Execution.Startup;
using Celeste.Game.Execution.Threading;
using Celeste.Graphics.Content;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Content.VirtualAssets;
using Celeste.Graphics.Rendering;
using Celeste.Graphics.Rendering.Devices;
using Celeste.Graphics.Rendering.Drawing;
using Celeste.Graphics.Rendering.Textures;
using Celeste.Graphics.Rendering.Vertices;
using Celeste.Input.Gameplay;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;

namespace Celeste.Game.Entities.Machines.WaveDash
{
    public class OriginalWaveDashPresentationState : SceneEntityState
    {
        public readonly ISourceEngineContext Engine;
        private ISourceEngineContext engine => Engine;
        public Vector2 ScaleInPoint = new Vector2(1920f, 1080f) / 2f;

        public readonly int ScreenWidth = 1920;

        public readonly int ScreenHeight = 1080;

        private float ease;

        private bool loading;

        private float waitingForInputTime;

        private VirtualRenderTarget screenBuffer;

        private VirtualRenderTarget prevPageBuffer;

        private VirtualRenderTarget currPageBuffer;

        private int pageIndex;

        private readonly List<OriginalWaveDashPage> pages = [];

        private float pageEase;

        private bool pageTurning;

        private bool pageUpdating;

        private bool waitingForPageTurn;

        private readonly SourceVertexPositionColorTexture[] verts = new SourceVertexPositionColorTexture[6];

        private readonly FmodEventReference usingSfx;

        public bool Viewing { get; private set; }

        public AtlasData Gfx { get; private set; }

        public bool ShowInput
        {
            get
            {
                if (!waitingForPageTurn) return CurrPage != null ? CurrPage.WaitingForInput : false;

                return true;
            }
        }

        private OriginalWaveDashPage PrevPage => pageIndex <= 0 ? null : pages[pageIndex - 1];

        private OriginalWaveDashPage CurrPage => pageIndex >= pages.Count ? null : pages[pageIndex];

        public OriginalWaveDashPresentationState(ISourceEngineContext engine, FmodEventReference usingSfx = null)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration)
        {
            Engine = engine;
            Tags = ((IOriginalGameTagsEnvironment)engine).Tags.HUD.Value;
            Viewing = true;
            loading = true;
            Add(new SimulationCoroutine(engine, Routine()));
            this.usingSfx = usingSfx;
            ((IOriginalThreadEnvironment)engine).Threads.Start(LoadingThread, "Wave Dash Presentation Loading",
                true);
        }

        private void LoadingThread()
        {
            Gfx = SourceAtlasLoader.FromAtlas(Path.Combine("Graphics", "Atlases", "WaveDashing"),
                AtlasDataFormat.Packer,
                (ISourceAtlasLoaderEnvironment)engine);
            loading = false;
        }

        private IEnumerator Routine()
        {
            while (loading) yield return null;

            pages.Add(new OriginalWaveDashPage00(engine));
            pages.Add(new OriginalWaveDashPage01(engine));
            pages.Add(new OriginalWaveDashPage02(engine));
            pages.Add(new OriginalWaveDashPage03(engine));
            pages.Add(new OriginalWaveDashPage04(engine));
            pages.Add(new OriginalWaveDashPage05(engine));
            pages.Add(new OriginalWaveDashPage06(engine));
            foreach (var page in pages) page.Added(this);

            Add(new BeforeRenderCallbackComponentState(() =>
                BeforeRender(((ISourceRenderEnvironment)engine).CurrentContext)));
            while (ease < 1f)
            {
                ease = ScalarMath.Approach(ease, 1f, engine.DeltaTime * 2f,
                    ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
                yield return null;
            }

            while (pageIndex < pages.Count)
            {
                pageUpdating = true;
                yield return CurrPage.Routine();
                if (!CurrPage.AutoProgress)
                {
                    waitingForPageTurn = true;
                    while (!((ISourceGameInputEnvironment)engine).Input.MenuConfirm.Pressed) yield return null;

                    waitingForPageTurn = false;
                    ((IOriginalGameplayProcess)engine).AudioSession.Play(
                        "event:/new_content/game/10_farewell/ppt_mouseclick");
                }

                pageUpdating = false;
                pageIndex++;
                if (pageIndex < pages.Count)
                {
                    var num = 0.5f;
                    if (CurrPage.Transition == OriginalWaveDashPage.Transitions.Rotate3D)
                        num = 1.5f;
                    else if (CurrPage.Transition == OriginalWaveDashPage.Transitions.Blocky) num = 1f;

                    pageTurning = true;
                    pageEase = 0f;
                    Add(new SimulationCoroutine(engine, TurnPage(num)));
                    yield return num * 0.8f;
                }
            }

            if (usingSfx != null)
            {
                ((IOriginalGameplayProcess)engine).AudioSession.SetParameter(usingSfx, "end", 1f);
                usingSfx.Release();
            }

            ((IOriginalGameplayProcess)engine).AudioSession.Play(
                "event:/new_content/game/10_farewell/cafe_computer_off");
            while (ease > 0f)
            {
                ease = ScalarMath.Approach(ease, 0f, engine.DeltaTime * 2f,
                    ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
                yield return null;
            }

            Viewing = false;
            RemoveSelf();
        }

        private IEnumerator TurnPage(float duration)
        {
            if (CurrPage.Transition != OriginalWaveDashPage.Transitions.ScaleIn &&
                CurrPage.Transition != OriginalWaveDashPage.Transitions.FadeIn)
            {
                if (CurrPage.Transition == OriginalWaveDashPage.Transitions.Rotate3D)
                    ((IOriginalGameplayProcess)engine).AudioSession.Play(
                        "event:/new_content/game/10_farewell/ppt_cube_transition");
                else if (CurrPage.Transition == OriginalWaveDashPage.Transitions.Blocky)
                    ((IOriginalGameplayProcess)engine).AudioSession.Play(
                        "event:/new_content/game/10_farewell/ppt_dissolve_transition");
                else if (CurrPage.Transition == OriginalWaveDashPage.Transitions.Spiral)
                    ((IOriginalGameplayProcess)engine).AudioSession.Play(
                        "event:/new_content/game/10_farewell/ppt_spinning_transition");
            }

            while (pageEase < 1f)
            {
                pageEase += engine.DeltaTime / duration;
                yield return null;
            }

            pageTurning = false;
        }

        private void BeforeRender(ISourceRenderContext context)
        {
            if (loading) return;

            if (screenBuffer == null || screenBuffer.IsDisposed)
                screenBuffer =
                    ((ISourceAtlasLoaderEnvironment)engine).VirtualContent.CreateRenderTarget("WaveDash-Buffer",
                        ScreenWidth, ScreenHeight, true);

            if (prevPageBuffer == null || prevPageBuffer.IsDisposed)
                prevPageBuffer =
                    ((ISourceAtlasLoaderEnvironment)engine).VirtualContent.CreateRenderTarget("WaveDash-Screen1",
                        ScreenWidth, ScreenHeight);

            if (currPageBuffer == null || currPageBuffer.IsDisposed)
                currPageBuffer =
                    ((ISourceAtlasLoaderEnvironment)engine).VirtualContent.CreateRenderTarget("WaveDash-Screen2",
                        ScreenWidth, ScreenHeight);

            if (pageTurning && PrevPage != null)
            {
                ((ISourceGraphicsDeviceEnvironment)engine).GraphicsDevice.SetRenderTarget(
                    prevPageBuffer.Target);
                ((ISourceGraphicsDeviceEnvironment)engine).GraphicsDevice.Clear(PrevPage.ClearColor);
                ((ISourceDrawScope)engine).Draw.SpriteBatch.Begin();
                PrevPage.Render(context);
                ((ISourceDrawScope)engine).Draw.SpriteBatch.End();
            }

            if (CurrPage != null)
            {
                ((ISourceGraphicsDeviceEnvironment)engine).GraphicsDevice.SetRenderTarget(
                    currPageBuffer.Target);
                ((ISourceGraphicsDeviceEnvironment)engine).GraphicsDevice.Clear(CurrPage.ClearColor);
                ((ISourceDrawScope)engine).Draw.SpriteBatch.Begin();
                CurrPage.Render(context);
                ((ISourceDrawScope)engine).Draw.SpriteBatch.End();
            }

            ((ISourceGraphicsDeviceEnvironment)engine).GraphicsDevice.SetRenderTarget(
                screenBuffer.Target);
            ((ISourceGraphicsDeviceEnvironment)engine).GraphicsDevice.Clear(PackedColor.Black);
            if (pageTurning)
            {
                if (CurrPage.Transition == OriginalWaveDashPage.Transitions.ScaleIn)
                {
                    ((ISourceDrawScope)engine).Draw.SpriteBatch.Begin();
                    ((ISourceDrawScope)engine).Draw.SpriteBatch.Draw(
                        prevPageBuffer.Target,
                        Vector2.Zero, PackedColor.White.PackedValue);
                    var scale = Vector2.One * pageEase;
                    ((ISourceDrawScope)engine).Draw.SpriteBatch.Draw(
                        currPageBuffer.Target,
                        ScaleInPoint, currPageBuffer.Bounds, PackedColor.White.PackedValue, 0f, ScaleInPoint, scale,
                        SourceSpriteEffects.None, 0f);
                    ((ISourceDrawScope)engine).Draw.SpriteBatch.End();
                }
                else if (CurrPage.Transition == OriginalWaveDashPage.Transitions.FadeIn)
                {
                    ((ISourceDrawScope)engine).Draw.SpriteBatch.Begin();
                    ((ISourceDrawScope)engine).Draw.SpriteBatch.Draw(
                        prevPageBuffer.Target,
                        Vector2.Zero, PackedColor.White.PackedValue);
                    ((ISourceDrawScope)engine).Draw.SpriteBatch.Draw(
                        currPageBuffer.Target,
                        Vector2.Zero, (PackedColor.White * pageEase).PackedValue);
                    ((ISourceDrawScope)engine).Draw.SpriteBatch.End();
                }
                else if (CurrPage.Transition == OriginalWaveDashPage.Transitions.Rotate3D)
                {
                    var num = -(float)Math.PI / 2f * pageEase;
                    RenderQuad(prevPageBuffer.Target, pageEase, num);
                    RenderQuad(currPageBuffer.Target, pageEase,
                        (float)Math.PI / 2f + num);
                }
                else if (CurrPage.Transition == OriginalWaveDashPage.Transitions.Blocky)
                {
                    ((ISourceDrawScope)engine).Draw.SpriteBatch.Begin();
                    ((ISourceDrawScope)engine).Draw.SpriteBatch.Draw(
                        prevPageBuffer.Target,
                        Vector2.Zero, PackedColor.White.PackedValue);
                    var seed = 1u;
                    var num2 = ScreenWidth / 60;
                    for (var i = 0; i < ScreenWidth; i += num2)
                    for (var j = 0; j < ScreenHeight; j += num2)
                        if (PseudoRandRange(ref seed, 0f, 1f) <= pageEase)
                            ((ISourceDrawScope)engine).Draw.SpriteBatch.Draw(
                                currPageBuffer.Target, new IntRect(i, j, num2, num2),
                                new IntRect(i, j, num2, num2), PackedColor.White.PackedValue);

                    ((ISourceDrawScope)engine).Draw.SpriteBatch.End();
                }
                else if (CurrPage.Transition == OriginalWaveDashPage.Transitions.Spiral)
                {
                    ((ISourceDrawScope)engine).Draw.SpriteBatch.Begin();
                    ((ISourceDrawScope)engine).Draw.SpriteBatch.Draw(
                        prevPageBuffer.Target,
                        Vector2.Zero, PackedColor.White.PackedValue);
                    var scale2 = Vector2.One * pageEase;
                    var rotation = (1f - pageEase) * 12f;
                    ((ISourceDrawScope)engine).Draw.SpriteBatch.Draw(
                        currPageBuffer.Target,
                        new(960f, 540f), currPageBuffer.Bounds, PackedColor.White.PackedValue, rotation,
                        new(960f, 540f), scale2, SourceSpriteEffects.None, 0f);
                    ((ISourceDrawScope)engine).Draw.SpriteBatch.End();
                }
            }
            else
            {
                ((ISourceDrawScope)engine).Draw.SpriteBatch.Begin();
                ((ISourceDrawScope)engine).Draw.SpriteBatch.Draw(currPageBuffer.Target,
                    Vector2.Zero, PackedColor.White.PackedValue);
                ((ISourceDrawScope)engine).Draw.SpriteBatch.End();
            }
        }

        private void RenderQuad(SourceTexture2DResource texture, float ease, float rotation)
        {
            var num = screenBuffer.Width / (float)screenBuffer.Height;
            var num2 = num;
            var num3 = 1f;
            var position = new Vector3(0f - num2, num3, 0f);
            var position2 = new Vector3(num2, num3, 0f);
            var position3 = new Vector3(num2, 0f - num3, 0f);
            var position4 = new Vector3(0f - num2, 0f - num3, 0f);
            verts[0].Position = position;
            verts[0].TextureCoordinate = new(0f, 0f);
            verts[0].Color = PackedColor.White;
            verts[1].Position = position2;
            verts[1].TextureCoordinate = new(1f, 0f);
            verts[1].Color = PackedColor.White;
            verts[2].Position = position3;
            verts[2].TextureCoordinate = new(1f, 1f);
            verts[2].Color = PackedColor.White;
            verts[3].Position = position;
            verts[3].TextureCoordinate = new(0f, 0f);
            verts[3].Color = PackedColor.White;
            verts[4].Position = position3;
            verts[4].TextureCoordinate = new(1f, 1f);
            verts[4].Color = PackedColor.White;
            verts[5].Position = position4;
            verts[5].TextureCoordinate = new(0f, 1f);
            verts[5].Color = PackedColor.White;
            var num4 = 4.15f + ScalarMath.YoYo(ease) * 1.7f;
            var value = SourceMatrixMath.Multiply(
                SourceMatrixMath.Multiply(
                    SourceMatrixMath.Multiply(SourceMatrixMath.CreateTranslation(0f, 0f, num),
                        SourceMatrixMath.CreateRotationY(rotation)),
                    SourceMatrixMath.CreateTranslation(0f, 0f, 0f - num4)),
                SourceMatrixMath.CreatePerspectiveFieldOfView((float)Math.PI / 4f, num, 1f, 10f));
            ((ISourceGraphicsDeviceEnvironment)engine).GraphicsDevice.RasterizerState = SourceRasterizerState.CullNone;
            ((ISourceGraphicsDeviceEnvironment)engine).GraphicsDevice.BlendState = SourceBlendState.AlphaBlend;
            ((ISourceGraphicsDeviceEnvironment)engine).GraphicsDevice.DepthStencilState =
                SourceDepthStencilState.Default;
            ((ISourceGraphicsDeviceEnvironment)engine).GraphicsDevice.Textures[0] = texture;
            ((OriginalGameGraphicsResources)((ISourceGameGraphicsEnvironment)engine).GameGraphics).FxTexture
                .Parameters["World"].SetValue(value);
            foreach (var pass in ((OriginalGameGraphicsResources)((ISourceGameGraphicsEnvironment)engine)
                         .GameGraphics).FxTexture.CurrentTechnique.Passes)
            {
                pass.Apply();
                ((ISourceGraphicsDeviceEnvironment)engine).GraphicsDevice.DrawUserPrimitives(
                    SourcePrimitiveType.TriangleList, verts, 0, verts.Length / 3);
            }
        }

        public override void Update()
        {
            base.Update();
            if (ShowInput)
                waitingForInputTime += engine.DeltaTime;
            else
                waitingForInputTime = 0f;

            if (!loading && CurrPage != null && pageUpdating) CurrPage.Update();
        }

        public override void Render(ISourceRenderContext context)
        {
            if (!loading && screenBuffer != null && !screenBuffer.IsDisposed)
            {
                var num = ScreenWidth *
                          ((ISourceEasingEnvironment)engine).EasingArithmetic.CubeOut(
                              ScalarMath.ClampedMap(ease, 0f, 0.5f));
                var num2 = ScreenHeight *
                           ((ISourceEasingEnvironment)engine).EasingArithmetic.CubeInOut(
                               ScalarMath.ClampedMap(ease, 0.5f, 1f, 0.2f));
                var rectangle = new IntRect((int)((1920f - num) / 2f), (int)((1080f - num2) / 2f), (int)num,
                    (int)num2);
                ((ISourceDrawScope)engine).Draw.SpriteBatch.Draw(screenBuffer.Target,
                    rectangle, PackedColor.White.PackedValue);
                if (ShowInput && waitingForInputTime > 0.2f)
                    SourceAtlasDrawing.DrawCentered(context, this,
                        ((OriginalGameGraphicsResources)((ISourceGameGraphicsEnvironment)engine).GameGraphics).GuiAtlas[
                            "textboxbutton"],
                        new(1856f,
                            1016 + (((ISourceScene)Scene).SourceScene.Clock.TimeActive % 1f < 0.25f ? 6 : 0)),
                        PackedColor.Black);

                if ((Scene as OriginalLevelSceneRoot).Paused)
                    SourcePrimitiveDrawing.Rect((ISourceDrawScope)context, rectangle, PackedColor.Black * 0.7f);
            }
        }

        public override void Removed(object scene)
        {
            base.Removed(scene);
            Dispose();
        }

        public override void SceneEnd(object scene)
        {
            base.SceneEnd(scene);
            Dispose();
        }

        private void Dispose()
        {
            while (loading) Thread.Sleep(1);

            if (screenBuffer != null) screenBuffer.Dispose();

            screenBuffer = null;
            if (prevPageBuffer != null) prevPageBuffer.Dispose();

            prevPageBuffer = null;
            if (currPageBuffer != null) currPageBuffer.Dispose();

            currPageBuffer = null;
            Gfx.Dispose();
            Gfx = null;
        }

        private static uint PseudoRand(ref uint seed)
        {
            var num = seed;
            num ^= num << 13;
            num ^= num >> 17;
            return seed = num ^ (num << 5);
        }

        public static float PseudoRandRange(ref uint seed, float min, float max)
        {
            return min + PseudoRand(ref seed) % 1000 / 1000f * (max - min);
        }
    }
}
