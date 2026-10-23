using Celeste.Core.Display;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Components.Rendering;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Randomness;
using Celeste.Core.Rendering;
using Celeste.Core.Rendering.States;
using Celeste.Core.Scheduling;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
using Celeste.Simulation;
using Celeste.Simulation.Presentation.Effects.Mirrors;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Content.VirtualAssets;
using Celeste.Graphics.Display;
using Celeste.Graphics.Rendering;
using Celeste.Graphics.Rendering.Devices;
using Celeste.Graphics.Rendering.Drawing;
using Celeste.Game.Execution.Graphics;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Entities.BadelineDummy;
using Celeste.Formats.Map.Entities.Structure;

namespace Celeste.Game.Entities.Npcs.Oshiro
{
    public class OriginalResortMirrorState : SceneEntityState
    {
        private readonly ISourceEngineContext engine;
        private OriginalLevelSceneRoot Level => (OriginalLevelSceneRoot)Scene;
        private ISourceExtremaArithmetic Extrema => ((ISourceExtremaEnvironment)engine).ExtremaArithmetic;
        private ISourceRandom Random => ((ISourceRandomEnvironment)engine).Random;

        private static OriginalGameGraphicsResources Graphics(ISourceEngineContext engine) =>
            (OriginalGameGraphicsResources)((ISourceGameGraphicsEnvironment)engine).GameGraphics;

        private void Rumble(int strength, int length) =>
            ((global::Celeste.Input.Gameplay.Feedback.ISourceRumbleEnvironment)engine).RumbleSession
            .Rumble(strength, length);

        private bool smashed;

        private SpriteImage bg;

        private SpriteImage frame;

        private AtlasEntry glassfg;

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
            base.Depth = 9500;
        }

        public override void Added(object scene)
        {
            base.Added(scene);
            smashed = Level.Session.GetFlag("oshiro_resort_suite");
            SceneEntityState entity =
                new SceneEntityState(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration,
                    Position);
            entity.Depth = 9000;
            entity.OwnedComponents.Add(
                frame = new SpriteImage(Graphics(engine).GameAtlas["objects/mirror/resortframe"]));
            frame.JustifyOrigin(0.5f, 1f);
            Level.Scheduler.QueueSourceEntity(entity);
            AtlasEntry glassbg = Graphics(engine).GameAtlas["objects/mirror/glassbg"];
            int w = (int)frame.Width - 2;
            int h = (int)frame.Height - 12;
            if (!smashed)
            {
                mirror = ((ISourceVirtualContentEnvironment)engine).VirtualContent
                    .CreateRenderTarget("resort-mirror", w, h);
            }
            else
            {
                glassbg = Graphics(engine).GameAtlas["objects/mirror/glassbreak09"];
            }

            OwnedComponents.Add(bg =
                new SpriteImage(glassbg.GetSubtexture((glassbg.FrameWidth - w) / 2, glassbg.FrameHeight - h, w, h)));
            bg.JustifyOrigin(0.5f, 1f);
            List<AtlasEntry> atlasSubtextures =
                Graphics(engine).GameAtlas.GetAtlasSubtextures("objects/mirror/mirrormask");
            AtlasEntry temp = new AtlasEntry();
            foreach (AtlasEntry shard in atlasSubtextures)
            {
                MirrorSurfaceState surface = new MirrorSurfaceState(Extrema);
                surface.OnRender = delegate
                {
                    SourceAtlasDrawing.DrawJustified(Level.SourceRenderContext, this,
                        shard.GetSubtexture((glassbg.FrameWidth - w) / 2, glassbg.FrameHeight - h, w, h, temp),
                        Position, new Vector2(.5f, 1f), surface.ReflectionColor * (shardReflection ? 1 : 0));
                };
                surface.ReflectionOffset = new Vector2(9 + SourceRandomMath.Range(Random, -4, 4),
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
            evil = BadelineDummyPresentation.Create(Level, new Vector2(mirror.Width + 8, mirror.Height));
            yield return evil.WalkTo(mirror.Width / 2);
        }

        private IEnumerator FadeLights()
        {
            OriginalLevelSceneRoot level = Level;
            while (level.Lighting.Alpha != 0.35f)
            {
                level.Lighting.Alpha =
                    ScalarMath.Approach(level.Lighting.Alpha, 0.35f, engine.DeltaTime * 0.1f, Extrema);
                yield return null;
            }
        }

        public IEnumerator SmashRoutine()
        {
            yield return evil.FloatTo(new Vector2(mirror.Width / 2, mirror.Height - 8));
            breakingGlass = Graphics(engine).SpriteFactory.Create("glass");
            breakingGlass.Position = new Vector2(mirror.Width / 2, mirror.Height);
            breakingGlass.Play("break");
            breakingGlass.Color = PackedColor.White * shineAlpha;
            Rumble(0, 3);
            while (breakingGlass.CurrentAnimationID == "break")
            {
                if (breakingGlass.CurrentAnimationFrame == 7)
                {
                    Level.Shake();
                }

                shineAlpha = ScalarMath.Approach(shineAlpha, 1f, engine.DeltaTime * 2f, Extrema);
                mirrorAlpha = ScalarMath.Approach(mirrorAlpha, 1f, engine.DeltaTime * 2f, Extrema);
                yield return null;
            }

            Level.Shake();
            Rumble(2, 1);
            for (float num = (0f - breakingGlass.Width) / 2f; num < breakingGlass.Width / 2f; num += 8f)
            {
                for (float num2 = 0f - breakingGlass.Height; num2 < 0f; num2 += 8f)
                {
                    if (SourceRandomMath.NextFloat(Random) < 0.5f)
                    {
                        Level.Particles.Emit(((IOriginalGameplayProcess)engine).ParticleTypes.DreamMirror.P_Shatter, 2,
                            Position + new Vector2(num + 4f, num2 + 4f), new Vector2(8f, 8f),
                            Vector2Geometry.Angle(new Vector2(num, num2)));
                    }
                }
            }

            shardReflection = true;
            evil = null;
        }

        public void Broken()
        {
            evil = null;
            smashed = true;
            shardReflection = true;
            AtlasEntry mTexture = Graphics(engine).GameAtlas["objects/mirror/glassbreak09"];
            bg.Texture = mTexture.GetSubtexture((int)((float)mTexture.FrameWidth - bg.Width) / 2,
                mTexture.FrameHeight - (int)bg.Height, (int)bg.Width, (int)bg.Height);
        }

        private void BeforeRender()
        {
            if (smashed || mirror == null)
            {
                return;
            }

            OriginalLevelSceneRoot level = Level;
            ((ISourceGraphicsDeviceEnvironment)engine).GraphicsDevice.SetRenderTarget(mirror.Target);
            ((ISourceGraphicsDeviceEnvironment)engine).GraphicsDevice.Clear(PackedColor.Transparent);
            ((ISourceDrawScope)engine).Draw.SpriteBatch.Begin(SourceSpriteSortMode.Deferred,
                SourceBlendState.AlphaBlend,
                SourceSamplerState.PointClamp, SourceDepthStencilState.None, SourceRasterizerState.CullNone, null,
                Matrix4x4.Identity);
            OriginalNpcState nPC = Level.SourceScene.Entities.FindFirst<OriginalNpcState>();
            if (nPC != null &&
                (((IOriginalResortMirrorEnvironment)engine).ResortMirrorProfile ==
                    OriginalResortMirrorRuntimeProfile.Original || nPC.Sprite != null))
            {
                Vector2 renderPosition = nPC.Sprite.RenderPosition;
                nPC.Sprite.RenderPosition = renderPosition - Position + new Vector2(mirror.Width / 2, mirror.Height) +
                                            new Vector2(8f, -4f);
                nPC.Sprite.Render(Level.SourceRenderContext);
                nPC.Sprite.RenderPosition = renderPosition;
            }

            RoomPlayerSession entity =
                Level.SourceScene.Entities.GetTrackedEntity<RoomPlayerSession>(
                    typeof(global::Celeste.Simulation.RoomPlayerSession).FullName);
            if (entity != null)
            {
                Vector2 position = entity.Position;
                entity.Position = position - Position + new Vector2(mirror.Width / 2, mirror.Height) +
                                  new Vector2(8f, 0f);
                Vector2 vector = entity.Position - position;
                for (int i = 0; i < entity.Hair.Nodes.Count; i++)
                {
                    entity.Hair.Nodes[i] += vector;
                }

                entity.Render(Level.SourceRenderContext);
                for (int j = 0; j < entity.Hair.Nodes.Count; j++)
                {
                    entity.Hair.Nodes[j] -= vector;
                }

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
                int num = -(int)(level.Camera.Y * 0.8f % (float)glassfg.FrameHeight);
                SourceAtlasDrawing.DrawJustified(Level.SourceRenderContext, this, glassfg,
                    new Vector2(mirror.Width / 2, num), new Vector2(.5f, 1f), PackedColor.White * shineAlpha);
                SourceAtlasDrawing.DrawJustified(Level.SourceRenderContext, this, glassfg,
                    new Vector2(mirror.Height / 2, num - glassfg.FrameHeight), new Vector2(.5f, 1f),
                    PackedColor.White * shineAlpha);
            }

            ((ISourceDrawScope)engine).Draw.SpriteBatch.End();
        }

        public override void Render(ISourceRenderContext context)
        {
            bg.Render(context);
            if (!smashed)
            {
                ((ISourceDrawScope)engine).Draw.SpriteBatch.Draw(mirror.Target,
                    Position + new Vector2(-mirror.Width / 2, -mirror.Height),
                    (PackedColor.White * mirrorAlpha).PackedValue);
            }

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
            if (mirror != null)
            {
                mirror.Dispose();
            }

            mirror = null;
        }
    }
}
