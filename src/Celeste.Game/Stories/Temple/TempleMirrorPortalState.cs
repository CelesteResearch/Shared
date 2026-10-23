using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Audio;
using Celeste.Core.Components;
using Celeste.Core.Components.Rendering;
using Celeste.Core.Display;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Randomness;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Controls.Source;
using Celeste.Game.Execution.Graphics;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Processes;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Content.VirtualAssets;
using Celeste.Graphics.Display.Colors;
using Celeste.Graphics.Rendering;
using Celeste.Graphics.Rendering.Devices;
using Celeste.Graphics.Rendering.Drawing;
using Celeste.Physics.Collision.Shapes;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Platforms.Foundation;
using Celeste.Simulation.Gameplay.Player.Collision.Components;
using Celeste.Simulation.Presentation.Effects.Mirrors;
using Celeste.Simulation.Presentation.PostProcessing.Displacement;

namespace Celeste.Game.Stories.Temple
{
    public class TempleMirrorPortalState : SceneEntityState
    {
        private readonly ISourceEngineContext engine;

        private static OriginalGameGraphicsResources Graphics(ISourceEngineContext e)
        {
            return (OriginalGameGraphicsResources)((ISourceGameGraphicsEnvironment)e).GameGraphics;
        }

        private ISourceRenderContext Context => ((ISourceRenderEnvironment)engine).CurrentContext;

        private struct Debris
        {
            public Vector2 Direction;

            public float Percent;

            public float Duration;

            public bool Enabled;
        }

        private class Bg : SceneEntityState
        {
            private readonly ISourceEngineContext engine;

            private static OriginalGameGraphicsResources Graphics(ISourceEngineContext e)
            {
                return (OriginalGameGraphicsResources)((ISourceGameGraphicsEnvironment)e).GameGraphics;
            }

            private ISourceRenderContext Context => ((ISourceRenderEnvironment)engine).CurrentContext;

            private readonly MirrorSurfaceState surface;

            private readonly Vector2[] offsets;

            private readonly List<AtlasEntry> textures;

            public Bg(Vector2 position, ISourceEngineContext engine)
                : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration, position)
            {
                this.engine = engine;
                Depth = 9500;
                textures = Graphics(engine).GameAtlas.GetAtlasSubtextures("objects/temple/portal/reflection");
                var vector = new Vector2(10f, 4f);
                offsets = new Vector2[textures.Count];
                for (var i = 0; i < offsets.Length; i++)
                    offsets[i] = vector +
                                 new Vector2(SourceRandomMath.Range(((ISourceRandomEnvironment)engine).Random, -4, 4),
                                     SourceRandomMath.Range(((ISourceRandomEnvironment)engine).Random, -4, 4));

                Add(surface = new(((ISourceExtremaEnvironment)engine).ExtremaArithmetic));
                surface.OnRender = delegate
                {
                    for (var j = 0; j < textures.Count; j++)
                    {
                        surface.ReflectionOffset = offsets[j];
                        SourceAtlasDrawing.DrawCentered(Context, this, textures[j], Position, surface.ReflectionColor);
                    }
                };
            }

            public override void Render(ISourceRenderContext context)
            {
                SourceAtlasDrawing.DrawCentered(context, this,
                    Graphics(engine).GameAtlas["objects/temple/portal/surface"],
                    Position, PackedColor.White);
            }
        }

        private class Curtain : SourceSolidEntityState
        {
            public readonly Sprite Sprite;

            public Curtain(Vector2 position, ISourceSolidWorld world)
                : base(position, 140f, 12f, true, world)
            {
                Add(Sprite = Graphics(SourceWorld.EngineContext).SpriteBank.Create("temple_portal_curtain"));
                Depth = 1999;
                ((HitboxColliderGeometry)Collider).Position = new(-70f, 33f);
                Collidable = false;
                SurfaceSoundIndex = 17;
            }

            public override void Update()
            {
                base.Update();
                if (Collidable)
                {
                    RoomPlayerSession player;
                    if ((player = SourceTrackedEntityCollision.FirstAt<RoomPlayerSession>(
                            ((ISourceScene)Scene).SourceScene.Entities,
                            typeof(RoomPlayerSession).FullName, this,
                            Position + new Vector2(-1f, 0f))) != null && player.OnGround() &&
                        ((IOriginalGameInputProcessEnvironment)SourceWorld.EngineContext).InputSource.Aim.Value.X > 0f)
                    {
                        player.MoveV(Top - player.Bottom);
                        player.MoveH(1f);
                    }
                    else if ((player = SourceTrackedEntityCollision.FirstAt<RoomPlayerSession>(
                                 ((ISourceScene)Scene).SourceScene.Entities,
                                 typeof(RoomPlayerSession).FullName, this,
                                 Position + new Vector2(1f, 0f))) != null && player.OnGround() &&
                             ((IOriginalGameInputProcessEnvironment)SourceWorld.EngineContext).InputSource.Aim.Value.X <
                             0f)
                    {
                        player.MoveV(Top - player.Bottom);
                        player.MoveH(-1f);
                    }
                }
            }

            public void Drop()
            {
                Sprite.Play("fall");
                Depth = -8999;
                Collidable = true;
                var flag = false;
                RoomPlayerSession player;
                while ((player = SourceTrackedEntityCollision.FirstAt<RoomPlayerSession>(
                           ((ISourceScene)Scene).SourceScene.Entities,
                           typeof(RoomPlayerSession).FullName, this,
                           Position)) != null && !flag)
                {
                    Collidable = false;
                    flag = player.MoveV(-1f);
                    Collidable = true;
                }
            }
        }


        public float DistortionFade = 1f;

        private bool canTrigger;

        private int switchCounter;

        private VirtualRenderTarget buffer;

        private float bufferAlpha;

        private float bufferTimer;

        private readonly Debris[] debris = new Debris[50];

        private readonly PackedColor debrisColorFrom = SourceHexColor.HexToColor("f442d4");

        private readonly PackedColor debrisColorTo = SourceHexColor.HexToColor("000000");

        private readonly AtlasEntry debrisTexture;

        private Curtain curtain;

        private TemplePortalTorchState leftTorch;

        private TemplePortalTorchState rightTorch;

        public TempleMirrorPortalState(Vector2 position, ISourceEngineContext engine)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration, position)
        {
            this.engine = engine;
            debrisTexture = Graphics(engine).GameAtlas["particles/blob"];
            Depth = 2000;
            Collider = new HitboxColliderGeometry(120f, 64f, -60f, -32f);
            Add(new PlayerColliderComponentState(OnPlayer));
        }

        public TempleMirrorPortalState(EntityData data, Vector2 offset, ISourceEngineContext engine)
            : this(data.Position + offset, engine)
        {
        }

        public override void Added(object scene)
        {
            base.Added(scene);
            ((OriginalLevelSceneRoot)scene).Scheduler.QueueSourceEntity(curtain = new(Position,
                ((OriginalLevelSceneRoot)scene).SolidWorldFactory.Create(Position, true)));
            ((OriginalLevelSceneRoot)scene).Scheduler.QueueSourceEntity(new Bg(Position, engine));
            ((OriginalLevelSceneRoot)scene).Scheduler.QueueSourceEntity(leftTorch =
                new(Position + new Vector2(-90f, 0f), engine));
            ((OriginalLevelSceneRoot)scene).Scheduler.QueueSourceEntity(rightTorch =
                new(Position + new Vector2(90f, 0f), engine));
        }

        public void OnSwitchHit(int side)
        {
            Add(new SimulationCoroutine(engine, OnSwitchRoutine(side)));
        }

        private IEnumerator OnSwitchRoutine(int side)
        {
            yield return 0.4f;
            if (side < 0)
                leftTorch.Light(switchCounter);
            else
                rightTorch.Light(switchCounter);

            switchCounter++;
            if ((Scene as OriginalLevelSceneRoot).Session.Mode == 0)
            {
                var lighting =
                    (Scene as OriginalLevelSceneRoot).Lighting;
                var lightTarget =
                    ((ISourceExtremaEnvironment)engine).ExtremaArithmetic.Max(0f, lighting.Alpha - 0.2f);
                while ((lighting.Alpha -= engine.DeltaTime) > lightTarget) yield return null;
            }

            yield return 0.15f;
            if (switchCounter < 2) yield break;

            yield return 0.1f;
            ((ISourceSpatialAudioEnvironment)engine).SpatialAudio.Play(
                "event:/game/05_mirror_temple/mainmirror_reveal", Position);
            curtain.Drop();
            canTrigger = true;
            yield return 0.1f;
            var level = (OriginalLevelSceneRoot)Scene;
            for (var i = 0; i < 120; i += 12)
            for (var j = 0; j < 60; j += 6)
                level.Particles.Emit(
                    ((IOriginalGameplayProcess)engine).ParticleTypes.TempleMirrorPortal.P_CurtainDrop,
                    1, curtain.Position + new Vector2(-57 + i, -27 + j), new(6f, 3f));
        }

        public void Activate()
        {
            Add(new SimulationCoroutine(engine, ActivateRoutine()));
        }

        private IEnumerator ActivateRoutine()
        {
            var level = Scene as OriginalLevelSceneRoot;
            var light = level.Lighting;
            var debrisStart = 0f;
            Add(new BeforeRenderCallbackComponentState(BeforeRender));
            Add(new DisplacementRenderHookState(RenderDisplacement));
            while (true)
            {
                bufferAlpha = ScalarMath.Approach(bufferAlpha, 1f, engine.DeltaTime,
                    ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
                bufferTimer += 4f * engine.DeltaTime;
                light.Alpha = ScalarMath.Approach(light.Alpha, 0.2f, engine.DeltaTime * 0.25f,
                    ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
                if (debrisStart < debris.Length)
                {
                    var num = (int)debrisStart;
                    debris[num].Direction = Vector2Geometry.AngleToVector(
                        SourceRandomMath.NextFloat(((ISourceRandomEnvironment)engine).Random, (float)Math.PI * 2f), 1f);
                    debris[num].Enabled = true;
                    debris[num].Duration =
                        0.5f + SourceRandomMath.NextFloat(((ISourceRandomEnvironment)engine).Random, 0.7f);
                }

                debrisStart += engine.DeltaTime * 10f;
                for (var i = 0; i < debris.Length; i++)
                    if (debris[i].Enabled)
                    {
                        debris[i].Percent %= 1f;
                        debris[i].Percent += engine.DeltaTime / debris[i].Duration;
                    }

                yield return null;
            }
        }

        private void BeforeRender()
        {
            if (buffer == null)
                buffer = ((ISourceVirtualContentEnvironment)engine).VirtualContent.CreateRenderTarget("temple-portal",
                    120,
                    64);

            var position = new Vector2(buffer.Width, buffer.Height) / 2f;
            var mTexture = Graphics(engine).GameAtlas["objects/temple/portal/portal"];
            ((ISourceGraphicsDeviceEnvironment)engine).GraphicsDevice.SetRenderTarget(buffer.Target);
            ((ISourceGraphicsDeviceEnvironment)engine).GraphicsDevice.Clear(PackedColor.Black);
            ((ISourceDrawScope)Context).Draw.SpriteBatch.Begin();
            for (var i = 0; i < 10f; i++)
            {
                var num = bufferTimer % 1f * 0.1f + i / 10f;
                var color = SourceColorInterpolation.Lerp(PackedColor.Black, PackedColor.Purple, num,
                    ((ISourceScalarEnvironment)engine).ScalarArithmetic);
                var scale = num;
                var rotation = (float)Math.PI * 2f * num;
                SourceAtlasDrawing.DrawCentered(Context, this, mTexture, position, color, scale, rotation);
            }

            ((ISourceDrawScope)Context).Draw.SpriteBatch.End();
        }

        private void RenderDisplacement()
        {
            SourcePrimitiveDrawing.Rect(Context, this, X - 60f, Y - 32f, 120f, 64f,
                new(0.5f, 0.5f, 0.25f * DistortionFade * bufferAlpha, 1f));
        }

        public override void Render(ISourceRenderContext context)
        {
            base.Render(context);
            if (buffer != null)
                ((ISourceDrawScope)context).Draw.SpriteBatch.Draw(buffer.Target,
                    Position + new Vector2((0f - Collider.Width) / 2f, (0f - Collider.Height) / 2f),
                    (PackedColor.White * bufferAlpha).PackedValue);

            SourceAtlasDrawing.DrawCentered(context, this,
                Graphics(engine).GameAtlas["objects/temple/portal/portalframe"],
                Position, PackedColor.White);
            var level = Scene as OriginalLevelSceneRoot;
            for (var i = 0; i < this.debris.Length; i++)
            {
                var debris = this.debris[i];
                if (debris.Enabled)
                {
                    var num = ((ISourceEasingEnvironment)engine).EasingArithmetic.SineOut(debris.Percent);
                    var position = Position + debris.Direction * (1f - num) * (190f - level.Zoom * 30f);
                    var color = SourceColorInterpolation.Lerp(debrisColorFrom, debrisColorTo, num,
                        ((ISourceScalarEnvironment)engine).ScalarArithmetic);
                    var scale = ScalarMath.Lerp(1f, 0.2f, ScalarMath.Clamp(num, 0f, 1f),
                        ((ISourceScalarEnvironment)engine).ScalarArithmetic);
                    SourceAtlasDrawing.DrawCentered(context, this, debrisTexture, position, color, scale,
                        i * 0.05f);
                }
            }
        }

        private void OnPlayer(RoomPlayerSession player)
        {
            if (canTrigger)
            {
                canTrigger = false;
                ((ISourceScene)Scene).SourceScene.QueueSourceEntity(new MirrorPortalCutscene(player, this, engine));
            }
        }

        public override void Removed(object scene)
        {
            Dispose();
            base.Removed(scene);
        }

        public override void SceneEnd(object scene)
        {
            Dispose();
            base.SceneEnd(scene);
        }

        private void Dispose()
        {
            if (buffer != null) buffer.Dispose();

            buffer = null;
        }
    }
}
