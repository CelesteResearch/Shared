using Celeste.Core.Display;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Components.Rendering;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Randomness;
using Celeste.Core.Rendering;
using Celeste.Core.Rendering.States;
using Celeste.Core.Scheduling;
using Celeste.Game.Execution.Graphics;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Levels.Cutscenes;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Controls.Source;
using Celeste.Game.Entities.BadelineDummy;
using Celeste.Game.Entities.Platforms.Dream;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Scene.Entities;
using Celeste.Simulation;
using Celeste.Simulation.Audio.Sources;
using Celeste.Simulation.Gameplay.Player.Presentation.Sprites;
using Celeste.Simulation.Gameplay.Player.Presentation.Hair;
using Celeste.Simulation.Presentation.Effects.Mirrors;
using Celeste.Physics.Collision.Shapes;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Content.VirtualAssets;
using Celeste.Graphics.Display;
using Celeste.Graphics.Rendering;
using Celeste.Graphics.Rendering.Devices;
using Celeste.Graphics.Rendering.Drawing;

namespace Celeste.Game.Stories.OldSite.DreamMirror
{
    public class DreamMirrorState : SceneEntityState
    {
        private readonly ISourceEngineContext engine;
        private OriginalLevelSceneRoot Level => (OriginalLevelSceneRoot)Scene;

        private static OriginalGameGraphicsResources Graphics(ISourceEngineContext e)
            => (OriginalGameGraphicsResources)((ISourceGameGraphicsEnvironment)e).GameGraphics;

        private ISourceRandom Random => ((ISourceRandomEnvironment)engine).Random;
        private RoomPlayerSession FirstPlayer() => Level.SourceScene.Entities.FindFirst<RoomPlayerSession>();

        private SpriteImage frame;

        private AtlasEntry glassbg;

        private AtlasEntry glassfg;

        private Sprite breakingGlass;

        private HitboxColliderGeometry hitbox;

        private VirtualRenderTarget mirror;

        private float shineAlpha = 0.5f;

        private float shineOffset;

        private SceneEntityState reflection;

        private PlayerSprite reflectionSprite;

        private PlayerHair reflectionHair;

        private float reflectionAlpha = 0.7f;

        private bool autoUpdateReflection = true;

        private BadelineDummyPresentation badeline;

        private bool smashed;

        private bool smashEnded;

        private bool updateShine = true;

        private SimulationCoroutine smashCoroutine;

        private SoundSourceComponentState sfx;

        private SoundSourceComponentState sfxSting;

        public DreamMirrorState(EntityData data, Vector2 offset, ISourceEngineContext engine)
            : this(engine, data.Position + offset)
        {
        }

        public DreamMirrorState(ISourceEngineContext engine, Vector2 position)
            : this(engine, position, Graphics(engine).GameAtlas["objects/mirror/glassbg"],
                Graphics(engine).GameAtlas["objects/mirror/glassfg"])
        {
        }

        private DreamMirrorState(ISourceEngineContext engine, Vector2 position, AtlasEntry glassbg, AtlasEntry glassfg)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration, position)
        {
            this.engine = engine;
            this.glassbg = glassbg;
            this.glassfg = glassfg;
            base.Depth = 9500;
            Add(breakingGlass = Graphics(engine).SpriteFactory.Create("glass"));
            breakingGlass.Play("idle");
            Add(new BeforeRenderCallbackComponentState(BeforeRender));
            foreach (AtlasEntry shard in Graphics(engine).GameAtlas.GetAtlasSubtextures("objects/mirror/mirrormask"))
            {
                MirrorSurfaceState surface =
                    new MirrorSurfaceState(((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
                surface.OnRender = delegate
                {
                    SourceAtlasDrawing.DrawJustified(Level.SourceRenderContext, this, shard, Position,
                        new Vector2(0.5f, 1f), surface.ReflectionColor * (smashEnded ? 1 : 0));
                };
                surface.ReflectionOffset = new Vector2(9 + SourceRandomMath.Range(Random, -4, 4),
                    4 + SourceRandomMath.Range(Random, -2, 2));
                Add(surface);
            }
        }

        public override void Added(object scene)
        {
            base.Added(scene);
            smashed = Level.Session.Inventory.DreamDash;
            if (smashed)
            {
                breakingGlass.Play("broken");
                smashEnded = true;
            }
            else
            {
                reflection =
                    new SceneEntityState(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration);
                reflectionSprite = new PlayerSprite(engine, PlayerSpriteMode.Badeline);
                reflectionHair = new PlayerHair(reflectionSprite, engine);
                reflectionHair.Color = PlayerHairAppearance.NormalBadelineHairColor;
                reflectionHair.Border = PackedColor.Black;
                reflection.Add(reflectionHair);
                reflection.Add(reflectionSprite);
                reflectionHair.Start();
                reflectionSprite.OnFrameChange = delegate(string anim)
                {
                    if (!smashed && CollideCheck(typeof(global::Celeste.Simulation.RoomPlayerSession).FullName))
                    {
                        int currentAnimationFrame = reflectionSprite.CurrentAnimationFrame;
                        if ((anim == "walk" && (currentAnimationFrame == 0 || currentAnimationFrame == 6)) ||
                            (anim == "runSlow" && (currentAnimationFrame == 0 || currentAnimationFrame == 6)) ||
                            (anim == "runFast" && (currentAnimationFrame == 0 || currentAnimationFrame == 6)))
                        {
                            ((IOriginalGameplayProcess)engine).AudioSession.Play("event:/char/badeline/footstep",
                                base.Center, ((IOriginalGameplayProcess)engine).SaveContext);
                        }
                    }
                };
                Add(smashCoroutine = new SimulationCoroutine(engine, InteractRoutine()));
            }

            SceneEntityState entity =
                new SceneEntityState(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration,
                    Position);
            entity.Depth = 9000;
            entity.Add(frame = new SpriteImage(Graphics(engine).GameAtlas["objects/mirror/frame"]));
            frame.JustifyOrigin(0.5f, 1f);
            Level.SourceScene.QueueSourceEntity(entity);
            base.Collider = (hitbox = new HitboxColliderGeometry((int)frame.Width - 16, (int)frame.Height + 32,
                -(int)frame.Width / 2 + 8, -(int)frame.Height - 32));
        }

        public override void Update()
        {
            base.Update();
            if (reflection != null)
            {
                reflection.Update();
                reflectionHair.Facing = Math.Sign(reflectionSprite.Scale.X);
                reflectionHair.AfterUpdate();
            }
        }

        private void BeforeRender()
        {
            if (smashed)
            {
                return;
            }

            OriginalLevelSceneRoot level = (OriginalLevelSceneRoot)Scene;
            RoomPlayerSession entity = FirstPlayer();
            if (entity == null)
            {
                return;
            }

            if (autoUpdateReflection && reflection != null)
            {
                reflection.Position = new Vector2(base.X - entity.X, entity.Y - base.Y) + breakingGlass.Origin;
                reflectionSprite.Scale.X = (float)(0 - entity.Data.Facing) * Math.Abs(entity.Sprite.Scale.X);
                reflectionSprite.Scale.Y = entity.Sprite.Scale.Y;
                if (reflectionSprite.CurrentAnimationID != entity.Sprite.CurrentAnimationID &&
                    entity.Sprite.CurrentAnimationID != null && reflectionSprite.Has(entity.Sprite.CurrentAnimationID))
                {
                    reflectionSprite.Play(entity.Sprite.CurrentAnimationID);
                }
            }

            if (mirror == null)
            {
                mirror = ((ISourceVirtualContentEnvironment)engine).VirtualContent.CreateRenderTarget("dream-mirror",
                    glassbg.FrameWidth, glassbg.FrameHeight);
            }

            ((ISourceGraphicsDeviceEnvironment)engine).GraphicsDevice.SetRenderTarget(mirror.Target);
            ((ISourceGraphicsDeviceEnvironment)engine).GraphicsDevice.Clear(PackedColor.Transparent);
            ((ISourceDrawScope)engine).Draw.SpriteBatch.Begin(SourceSpriteSortMode.Deferred,
                SourceBlendState.AlphaBlend,
                SourceSamplerState.PointClamp, SourceDepthStencilState.None, SourceRasterizerState.CullNone, null,
                Matrix4x4.Identity);
            if (updateShine)
            {
                shineOffset = glassfg.FrameHeight - (int)(level.Camera.Position.Y * 0.8f % (float)glassfg.FrameHeight);
            }

            SourceAtlasDrawing.Draw(level.SourceRenderContext, this, glassbg, Vector2.Zero);
            if (reflection != null)
            {
                reflection.Render(level.SourceRenderContext);
            }

            SourceAtlasDrawing.Draw(level.SourceRenderContext, this, glassfg, new Vector2(0f, shineOffset),
                Vector2.Zero,
                PackedColor.White * shineAlpha);
            SourceAtlasDrawing.Draw(level.SourceRenderContext, this, glassfg,
                new Vector2(0f, shineOffset - (float)glassfg.FrameHeight), Vector2.Zero,
                PackedColor.White * shineAlpha);
            ((ISourceDrawScope)engine).Draw.SpriteBatch.End();
        }

        private IEnumerator InteractRoutine()
        {
            RoomPlayerSession player = null;
            while (player == null)
            {
                player = FirstPlayer();
                yield return null;
            }

            while (!hitbox.Collide(player.Collider))
            {
                yield return null;
            }

            hitbox.Width += 32f;
            hitbox.Position.X -= 16f;
            ((IOriginalGameplayProcess)engine).AudioSession.SetMusic(null);
            while (hitbox.Collide(player.Collider))
            {
                yield return null;
            }

            Level.SourceScene.QueueSourceEntity(new OriginalMirrorCutsceneState(engine, player, this));
        }

        public IEnumerator BreakRoutine(int direction)
        {
            autoUpdateReflection = false;
            reflectionSprite.Play("runFast");
            ((IOriginalGameInputProcessEnvironment)engine).InputSource.Rumble(RumbleStrength.Strong,
                RumbleLength.Short);
            while (Math.Abs(reflection.X - breakingGlass.Width / 2f) > 3f)
            {
                reflection.X += (float)(direction * 32) * engine.DeltaTime;
                yield return null;
            }

            reflectionSprite.Play("idle");
            yield return 0.65f;
            Add(sfx = ((ISourceSoundSourceEnvironment)engine).SoundSources.Create());
            sfx.Play("event:/game/02_old_site/sequence_mirror");
            yield return 0.15f;
            sfxSting = ((ISourceSoundSourceEnvironment)engine).SoundSources.Create();
            sfxSting.Play("event:/music/lvl2/dreamblock_sting_pt2");
            Add(sfxSting);
            ((IOriginalGameInputProcessEnvironment)engine).InputSource.Rumble(RumbleStrength.Light,
                RumbleLength.FullSecond);
            updateShine = false;
            while (shineOffset != 33f || shineAlpha < 1f)
            {
                shineOffset = ScalarMath.Approach(shineOffset, 33f, engine.DeltaTime * 120f,
                    ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
                shineAlpha = ScalarMath.Approach(shineAlpha, 1f, engine.DeltaTime * 4f,
                    ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
                yield return null;
            }

            smashed = true;
            breakingGlass.Play("break");
            yield return 0.6f;
            ((IOriginalGameInputProcessEnvironment)engine).InputSource.Rumble(RumbleStrength.Strong,
                RumbleLength.Medium);
            Level.Shake();
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

            smashEnded = true;
            badeline = BadelineDummyPresentation.Create(Level, reflection.Position + Position - breakingGlass.Origin);
            badeline.Floatness = 0f;
            for (int i = 0; i < badeline.Hair.Nodes.Count; i++)
            {
                badeline.Hair.Nodes[i] = reflectionHair.Nodes[i];
            }

            Level.SourceScene.QueueSourceEntity(badeline);
            badeline.Sprite.Play("idle");
            badeline.Sprite.Scale = reflectionSprite.Scale;
            reflection = null;
            yield return 1.2f;
            float speed = (float)(-direction) * 32f;
            badeline.Sprite.Scale.X = -direction;
            badeline.Sprite.Play("runFast");
            while (Math.Abs(badeline.X - base.X) < 60f)
            {
                speed += engine.DeltaTime * (float)(-direction) * 128f;
                badeline.X += speed * engine.DeltaTime;
                yield return null;
            }

            badeline.Sprite.Play("jumpFast");
            while (Math.Abs(badeline.X - base.X) < 128f)
            {
                speed += engine.DeltaTime * (float)(-direction) * 128f;
                badeline.X += speed * engine.DeltaTime;
                badeline.Y -= Math.Abs(speed) * engine.DeltaTime * 0.8f;
                yield return null;
            }

            badeline.RemoveSelf();
            badeline = null;
            yield return 1.5f;
        }

        public void Broken(bool wasSkipped)
        {
            updateShine = false;
            smashed = true;
            smashEnded = true;
            breakingGlass.Play("broken");
            if (wasSkipped && badeline != null)
            {
                badeline.RemoveSelf();
            }

            if (wasSkipped && sfx != null)
            {
                sfx.Stop();
            }

            if (wasSkipped && sfxSting != null)
            {
                sfxSting.Stop();
            }
        }

        public override void Render(ISourceRenderContext context)
        {
            if (smashed)
            {
                breakingGlass.Render(context);
            }
            else
            {
                ((ISourceDrawScope)engine).Draw.SpriteBatch.Draw(mirror.Target, Position - breakingGlass.Origin,
                    (PackedColor.White * reflectionAlpha).PackedValue);
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
