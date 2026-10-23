using System;
using System.Collections;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Components.Rendering;
using Celeste.Core.Display;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Randomness;
using Celeste.Core.Rendering;
using Celeste.Core.Rendering.States;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Entities.BadelineDummy;
using Celeste.Game.Execution.Graphics;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Processes;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Content.VirtualAssets;
using Celeste.Graphics.Rendering;
using Celeste.Graphics.Rendering.Devices;
using Celeste.Graphics.Rendering.Drawing;
using Celeste.Input.Gameplay.Feedback;
using Celeste.Scene.Entities;
using Celeste.Simulation;
using Celeste.Simulation.Presentation.Effects.Mirrors;

namespace Celeste.Game.Entities.Npcs.Oshiro
{
    public class OriginalResortMirrorState : SceneEntityState
    {
        private readonly ISourceEngineContext engine;
        private OriginalLevelSceneRoot Level => (OriginalLevelSceneRoot)Scene;
        private ISourceExtremaArithmetic Extrema => ((ISourceExtremaEnvironment)engine).ExtremaArithmetic;
        private ISourceRandom Random => ((ISourceRandomEnvironment)engine).Random;

        private static OriginalGameGraphicsResources Graphics(ISourceEngineContext engine)
        {
            return (OriginalGameGraphicsResources)((ISourceGameGraphicsEnvironment)engine).GameGraphics;
        }

        private void Rumble(int strength, int length)
        {
            ((ISourceRumbleEnvironment)engine).RumbleSession
                .Rumble(strength, length);
        }

        private bool smashed;

        private SpriteImage bg;

        private SpriteImage frame;

        private readonly AtlasEntry glassfg;

        private Sprite breakingGlass;

        private VirtualRenderTarget mirror;

        private float shineAlpha = 0.7f;

        private float mirrorAlpha = 0.7f;

        private BadelineDummyPresentation evil;

        private bool shardReflection;

        public OriginalResortMirrorState(EntityData data, Vector2 offset, ISourceEngineContext engine)
            : this(engine, data.Position + offset, Graphics(engine).GameAtlas["objects/mirror/glassfg"])
        {
        }

        private OriginalResortMirrorState(ISourceEngineContext engine, Vector2 position, AtlasEntry sourceGlass)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration, position)
        {
            this.engine = engine;
            glassfg = sourceGlass;
            OwnedComponents.Add(new BeforeRenderCallbackComponentState(BeforeRender));
            Depth = 9500;
        }

        public override void Added(object scene)
        {
            base.Added(scene);
            smashed = Level.Session.GetFlag("oshiro_resort_suite");
            var entity =
                new SceneEntityState(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration,
                    Position);
            entity.Depth = 9000;
            entity.OwnedComponents.Add(
                frame = new(Graphics(engine).GameAtlas["objects/mirror/resortframe"]));
            frame.JustifyOrigin(0.5f, 1f);
            Level.Scheduler.QueueSourceEntity(entity);
            var glassbg = Graphics(engine).GameAtlas["objects/mirror/glassbg"];
            var w = (int)frame.Width - 2;
            var h = (int)frame.Height - 12;
            if (!smashed)
                mirror = ((ISourceVirtualContentEnvironment)engine).VirtualContent
                    .CreateRenderTarget("resort-mirror", w, h);
            else
                glassbg = Graphics(engine).GameAtlas["objects/mirror/glassbreak09"];

            OwnedComponents.Add(bg =
                new(glassbg.GetSubtexture((glassbg.FrameWidth - w) / 2, glassbg.FrameHeight - h, w, h)));
            bg.JustifyOrigin(0.5f, 1f);
            var atlasSubtextures =
                Graphics(engine).GameAtlas.GetAtlasSubtextures("objects/mirror/mirrormask");
            var temp = new AtlasEntry();
            foreach (var shard in atlasSubtextures)
            {
                var surface = new MirrorSurfaceState(Extrema);
                surface.OnRender = delegate
                {
                    SourceAtlasDrawing.DrawJustified(Level.SourceRenderContext, this,
                        shard.GetSubtexture((glassbg.FrameWidth - w) / 2, glassbg.FrameHeight - h, w, h, temp),
                        Position, new(.5f, 1f), surface.ReflectionColor * (shardReflection ? 1 : 0));
                };
                surface.ReflectionOffset = new(9 + SourceRandomMath.Range(Random, -4, 4),
                    4 + SourceRandomMath.Range(Random, -2, 2));
                OwnedComponents.Add(surface);
            }
        }

        public void EvilAppear()
        {
            OwnedComponents.Add(new SimulationCoroutine(engine, EvilAppearRoutine()));
            OwnedComponents.Add(new SimulationCoroutine(engine, FadeLights()));
        }

        private IEnumerator EvilAppearRoutine()
        {
            evil = BadelineDummyPresentation.Create(Level, new(mirror.Width + 8, mirror.Height));
            yield return evil.WalkTo(mirror.Width / 2);
        }

        private IEnumerator FadeLights()
        {
            var level = Level;
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            while (level.Lighting.Alpha != 0.35f)
            {
                level.Lighting.Alpha =
                    ScalarMath.Approach(level.Lighting.Alpha, 0.35f, engine.DeltaTime * 0.1f, Extrema);
                yield return null;
            }
        }

        public IEnumerator SmashRoutine()
        {
            yield return evil.FloatTo(new(mirror.Width / 2, mirror.Height - 8));
            breakingGlass = Graphics(engine).SpriteFactory.Create("glass");
            breakingGlass.Position = new(mirror.Width / 2, mirror.Height);
            breakingGlass.Play("break");
            breakingGlass.Color = PackedColor.White * shineAlpha;
            Rumble(0, 3);
            while (breakingGlass.CurrentAnimationID == "break")
            {
                if (breakingGlass.CurrentAnimationFrame == 7) Level.Shake();

                shineAlpha = ScalarMath.Approach(shineAlpha, 1f, engine.DeltaTime * 2f, Extrema);
                mirrorAlpha = ScalarMath.Approach(mirrorAlpha, 1f, engine.DeltaTime * 2f, Extrema);
                yield return null;
            }

            Level.Shake();
            Rumble(2, 1);
            for (var num = (0f - breakingGlass.Width) / 2f; num < breakingGlass.Width / 2f; num += 8f)
            for (var num2 = 0f - breakingGlass.Height; num2 < 0f; num2 += 8f)
                if (SourceRandomMath.NextFloat(Random) < 0.5f)
                    Level.Particles.Emit(((IOriginalGameplayProcess)engine).ParticleTypes.DreamMirror.P_Shatter, 2,
                        Position + new Vector2(num + 4f, num2 + 4f), new(8f, 8f),
                        Vector2Geometry.Angle(new(num, num2)));

            shardReflection = true;
            evil = null;
        }

        public void Broken()
        {
            evil = null;
            smashed = true;
            shardReflection = true;
            var mTexture = Graphics(engine).GameAtlas["objects/mirror/glassbreak09"];
            bg.Texture = mTexture.GetSubtexture((int)(mTexture.FrameWidth - bg.Width) / 2,
                mTexture.FrameHeight - (int)bg.Height, (int)bg.Width, (int)bg.Height);
        }

        private void BeforeRender()
        {
            if (smashed || mirror == null) return;

            var level = Level;
            ((ISourceGraphicsDeviceEnvironment)engine).GraphicsDevice.SetRenderTarget(mirror.Target);
            ((ISourceGraphicsDeviceEnvironment)engine).GraphicsDevice.Clear(PackedColor.Transparent);
            ((ISourceDrawScope)engine).Draw.SpriteBatch.Begin(SourceSpriteSortMode.Deferred,
                SourceBlendState.AlphaBlend,
                SourceSamplerState.PointClamp, SourceDepthStencilState.None, SourceRasterizerState.CullNone, null,
                Matrix4x4.Identity);
            var nPc = Level.SourceScene.Entities.FindFirst<OriginalNpcState>();
            if (nPc != null &&
                (((IOriginalResortMirrorEnvironment)engine).ResortMirrorProfile ==
                    OriginalResortMirrorRuntimeProfile.Original || nPc.Sprite != null))
            {
                var renderPosition = nPc.Sprite.RenderPosition;
                nPc.Sprite.RenderPosition = renderPosition - Position + new Vector2(mirror.Width / 2, mirror.Height) +
                                            new Vector2(8f, -4f);
                nPc.Sprite.Render(Level.SourceRenderContext);
                nPc.Sprite.RenderPosition = renderPosition;
            }

            var entity =
                Level.SourceScene.Entities.GetTrackedEntity<RoomPlayerSession>(
                    typeof(RoomPlayerSession).FullName);
            if (entity != null)
            {
                var position = entity.Position;
                entity.Position = position - Position + new Vector2(mirror.Width / 2, mirror.Height) +
                                  new Vector2(8f, 0f);
                var vector = entity.Position - position;
                for (var i = 0; i < entity.Hair.Nodes.Count; i++) entity.Hair.Nodes[i] += vector;

                entity.Render(Level.SourceRenderContext);
                for (var j = 0; j < entity.Hair.Nodes.Count; j++) entity.Hair.Nodes[j] -= vector;

                entity.Position = position;
            }

            if (evil != null)
            {
                evil.Update();
                evil.Hair.Facing = Math.Sign(evil.Sprite.Scale.X);
                evil.Hair.AfterUpdate();
                evil.Render(Level.SourceRenderContext);
            }

            if (breakingGlass != null)
            {
                breakingGlass.Color = PackedColor.White * shineAlpha;
                breakingGlass.Update();
                breakingGlass.Render(Level.SourceRenderContext);
            }
            else
            {
                var num = -(int)(level.Camera.Y * 0.8f % glassfg.FrameHeight);
                SourceAtlasDrawing.DrawJustified(Level.SourceRenderContext, this, glassfg,
                    new(mirror.Width / 2, num), new(.5f, 1f), PackedColor.White * shineAlpha);
                SourceAtlasDrawing.DrawJustified(Level.SourceRenderContext, this, glassfg,
                    new(mirror.Height / 2, num - glassfg.FrameHeight), new(.5f, 1f),
                    PackedColor.White * shineAlpha);
            }

            ((ISourceDrawScope)engine).Draw.SpriteBatch.End();
        }

        public override void Render(ISourceRenderContext context)
        {
            bg.Render(context);
            if (!smashed)
                ((ISourceDrawScope)engine).Draw.SpriteBatch.Draw(mirror.Target,
                    Position + new Vector2(-mirror.Width / 2, -mirror.Height),
                    (PackedColor.White * mirrorAlpha).PackedValue);

            frame.Render(context);
        }

        public override void SceneEnd(object scene)
        {
            Dispose();
            base.SceneEnd(scene);
        }

        public override void Removed(object scene)
        {
            Dispose();
            base.Removed(scene);
        }

        private void Dispose()
        {
            if (mirror != null) mirror.Dispose();

            mirror = null;
        }
    }
}
