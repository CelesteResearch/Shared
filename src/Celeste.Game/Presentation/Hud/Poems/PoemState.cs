using System;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Components.Rendering;
using Celeste.Core.Display;
using Celeste.Core.Mathematics;
using Celeste.Core.Randomness;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Game.Execution.Graphics;
using Celeste.Game.Execution.Startup;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content;
using Celeste.Graphics.Content.VirtualAssets;
using Celeste.Graphics.Display.Colors;
using Celeste.Graphics.Rendering;
using Celeste.Graphics.Text;
using Celeste.Scene.Entities;

namespace Celeste.Game.Presentation.Hud.Poems
{
    public partial class PoemState : SceneEntityState, IDisposable
    {
        private struct Particle
        {
            public Vector2 Direction;
            public float Percent;
            public float Duration;

            public void Reset(ISourceEngineContext engine, float percent)
            {
                Direction = Vector2Geometry.AngleToVector(SourceRandomMath.NextFloat(
                    ((ISourceRandomEnvironment)engine).Random, (float)Math.PI * 2f), 1f);
                Percent = percent;
                Duration = .5f + SourceRandomMath.NextFloat(((ISourceRandomEnvironment)engine).Random) * .5f;
            }
        }

        private static readonly PackedColor[] colors =
        [
            SourceHexColor.HexToColor("8cc7fa"),
            SourceHexColor.HexToColor("ff668a"),
            SourceHexColor.HexToColor("fffc24"),
            SourceHexColor.HexToColor("ffffff"),
        ];

        public float Alpha = 1f;
        public float TextAlpha = 1f;
        public Vector2 Offset;
        public Sprite Heart;
        public float ParticleSpeed = 1f;
        public float Shake;
        private float timer;
        private readonly string text;
        private bool disposed;
        private readonly VirtualRenderTarget poem;
        private readonly VirtualRenderTarget smoke;
        private readonly VirtualRenderTarget temp;
        private readonly Particle[] particles = new Particle[80];
        private readonly ISourceEngineContext engine;

        // ReSharper disable once AutoPropertyCanBeMadeGetOnly.Local
        public PackedColor Color { get; private set; }
        private ActiveBitmapFont ActiveFont => ((ISourceActiveFontScope)engine).ActiveFont;

        private OriginalGameGraphicsResources Graphics =>
            (OriginalGameGraphicsResources)((ISourceGameGraphicsEnvironment)engine).GameGraphics;

        public PoemState(ISourceEngineContext engine, string text, int heartIndex, float heartAlpha)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration)
        {
            this.engine = engine;
            if (text != null)
                this.text = ActiveFont.Font.Get(ActiveFont.BaseSize).AutoNewline(text, 1024);
            Color = colors[heartIndex];
            Heart = Graphics.GuiSpriteBank.Create("heartgem" + heartIndex);
            Heart.Play("spin");
            Heart.Position = new Vector2(1920f, 1080f) * .5f;
            Heart.Color = PackedColor.White * heartAlpha;
            var width = Math.Min(1920, ((ISourceRenderEnvironment)engine).CurrentContext.Graphics.ViewWidth);
            var height = Math.Min(1080, ((ISourceRenderEnvironment)engine).CurrentContext.Graphics.ViewHeight);
            poem = ((ISourceVirtualContentEnvironment)engine).VirtualContent
                .CreateRenderTarget("poem-a", width, height);
            smoke = ((ISourceVirtualContentEnvironment)engine).VirtualContent.CreateRenderTarget("poem-b", width / 2,
                height / 2);
            temp = ((ISourceVirtualContentEnvironment)engine).VirtualContent.CreateRenderTarget("poem-c", width / 2,
                height / 2);
            Tags = ((IOriginalGameTagsEnvironment)engine).Tags.HUD.Value |
                   ((IOriginalGameTagsEnvironment)engine).Tags.FrozenUpdate
                   .Value;
            Components.Add(new BeforeRenderCallbackComponentState(BeforeRender));
            for (var i = 0; i < particles.Length; i++)
                particles[i].Reset(engine, SourceRandomMath.NextFloat(((ISourceRandomEnvironment)engine).Random));
        }

        public void Dispose()
        {
            if (!disposed)
            {
                poem.Dispose();
                smoke.Dispose();
                temp.Dispose();
                RemoveSelf();
                disposed = true;
            }
        }

        private void DrawPoem(ISourceRenderContext context, Vector2 offset, PackedColor color)
        {
            var texture = Graphics.GuiAtlas["poemside"];
            var width = ActiveFont.Measure(text).X * 1.5f;
            var position = new Vector2(960f, 540f) + offset;
            SourceAtlasDrawing.DrawCentered(context, this, texture,
                position - Vector2.UnitX * (width / 2f + 64f), color);
            ActiveFont.Draw(context, this, text, position, new(.5f), Vector2.One * 1.5f, color);
            SourceAtlasDrawing.DrawCentered(context, this, texture,
                position + Vector2.UnitX * (width / 2f + 64f), color);
        }

        public override void Update()
        {
            timer += engine.Frame.DeltaTime;
            for (var i = 0; i < particles.Length; i++)
            {
                particles[i].Percent += engine.Frame.DeltaTime / particles[i].Duration * ParticleSpeed;
                if (particles[i].Percent > 1f)
                    particles[i].Reset(engine, 0f);
            }

            Heart.Update();
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
    }
}
