using Celeste.Core.Display;
using System;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Components.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Core.Randomness;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Easing;
using Celeste.Scene.Entities;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Audio;
using Celeste.Simulation;
using Celeste.Graphics.Content.VirtualAssets;
using Celeste.Graphics.Rendering.Vertices;
using Celeste.Graphics.Rendering.Primitives;
using Celeste.Graphics.Rendering.Devices;
using Celeste.Graphics.Rendering.Textures;
using Celeste.Graphics.Display;

namespace Celeste.Game.Entities.StarJump
{
    public class OriginalStarJumpControllerState : SceneEntityState
    {
        private struct Ray
        {
            public float X;

            public float Y;

            public float Percent;

            public float Duration;

            public float Width;

            public float Length;

            public void Reset(ISourceRandom random)
            {
                Percent = 0f;
                X = SourceRandomMath.NextFloat(random, 320f);
                Y = SourceRandomMath.NextFloat(random, 580f);
                Duration = 4f + SourceRandomMath.NextFloat(random) * 8f;
                Width = random.Next(8, 80);
                Length = random.Next(20, 200);
            }
        }

        private OriginalLevelSceneRoot level;

        private ISourceRandom random;

        private readonly ISourceEngineContext engine;
        private ISourceRandom CurrentRandom => ((ISourceRandomEnvironment)engine).Random;

        private float minY;

        private float maxY;

        private float minX;

        private float maxX;

        private float cameraOffsetMarker;

        private float cameraOffsetTimer;

        public VirtualRenderTarget BlockFill;

        private const int RayCount = 100;

        private SourceVertexPositionColor[] vertices = new SourceVertexPositionColor[600];

        private int vertexCount;

        private PackedColor rayColor = new PackedColor(163, 255, 255, 255) * 0.25f;

        private Ray[] rays = new Ray[100];

        public OriginalStarJumpControllerState(ISourceEngineContext engine)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration)
        {
            this.engine = engine;
            InitBlockFill();
        }

        public override void Added(object scene)
        {
            base.Added(scene);
            level = (OriginalLevelSceneRoot)Scene;
            minY = level.Bounds.Top + 80;
            maxY = level.Bounds.Top + 1800;
            minX = level.Bounds.Left + 80;
            maxX = level.Bounds.Right - 80;
            level.Session.Audio.Music.Event = "event:/music/lvl6/starjump";
            level.Session.Audio.Music.Layer(1, 1f);
            level.Session.Audio.Music.Layer(2, 0f);
            level.Session.Audio.Music.Layer(3, 0f);
            level.Session.Audio.Music.Layer(4, 0f);
            ApplyAudio();
            random = ((ISourceRandomProcessEnvironment)engine).RandomProcess.Factory.CreateSeeded(666);
            Add(new BeforeRenderCallbackComponentState(BeforeRender));
        }

        public override void Update()
        {
            base.Update();
            RoomPlayerSession entity =
                level.Scheduler.Entities.GetTrackedEntity<RoomPlayerSession>(
                    typeof(global::Celeste.Simulation.RoomPlayerSession).FullName);

            if (entity != null)
            {
                float centerY = entity.Center.Y;
                level.Session.Audio.Music.Layer(1, ScalarMath.ClampedMap(centerY, maxY, minY, 1f, 0f));
                level.Session.Audio.Music.Layer(2, ScalarMath.ClampedMap(centerY, maxY, minY));
                ApplyAudio();
                if (level.CameraOffset.Y == -38.4f)
                {
                    if (entity.Machine.State != 19)
                    {
                        cameraOffsetTimer += engine.DeltaTime;
                        if (cameraOffsetTimer >= 0.5f)
                        {
                            cameraOffsetTimer = 0f;
                            level.CameraOffset.Y = -12.8f;
                        }
                    }
                    else
                    {
                        cameraOffsetTimer = 0f;
                    }
                }
                else if (entity.Machine.State == 19)
                {
                    cameraOffsetTimer += engine.DeltaTime;
                    if (cameraOffsetTimer >= 0.1f)
                    {
                        cameraOffsetTimer = 0f;
                        level.CameraOffset.Y = -38.4f;
                    }
                }
                else
                {
                    cameraOffsetTimer = 0f;
                }

                cameraOffsetMarker = level.Camera.Y;
            }
            else
            {
                level.Session.Audio.Music.Layer(1, 1f);
                level.Session.Audio.Music.Layer(2, 0f);
                ApplyAudio();
            }

            UpdateBlockFill();
        }

        private void InitBlockFill()
        {
            for (int i = 0; i < rays.Length; i++)
            {
                rays[i].Reset(CurrentRandom);
                rays[i].Percent = SourceRandomMath.NextFloat(CurrentRandom);
            }
        }

        private void UpdateBlockFill()
        {
            OriginalLevelSceneRoot level = base.Scene as OriginalLevelSceneRoot;
            Vector2 vector = Vector2Geometry.AngleToVector(-1.6707964f, 1f);
            Vector2 vector2 = new Vector2(0f - vector.Y, vector.X);
            int num = 0;
            for (int i = 0; i < rays.Length; i++)
            {
                if (rays[i].Percent >= 1f)
                {
                    rays[i].Reset(CurrentRandom);
                }

                rays[i].Percent += engine.DeltaTime / rays[i].Duration;
                rays[i].Y += 8f * engine.DeltaTime;
                float percent = rays[i].Percent;
                float num2 = mod(rays[i].X - level.Camera.X * 0.9f, 320f);
                float num3 = -200f + mod(rays[i].Y - level.Camera.Y * 0.7f, 580f);
                float width = rays[i].Width;
                float length = rays[i].Length;
                Vector2 vector3 = new Vector2((int)num2, (int)num3);
                PackedColor color = rayColor *
                                    ((ISourceEasingEnvironment)engine).EasingArithmetic.CubeInOut(
                                        ScalarMath.YoYo(percent));
                SourceVertexPositionColor vertexPositionColor =
                    new SourceVertexPositionColor(new Vector3(vector3 + vector2 * width + vector * length, 0f), color);
                SourceVertexPositionColor vertexPositionColor2 =
                    new SourceVertexPositionColor(new Vector3(vector3 - vector2 * width, 0f), color);
                SourceVertexPositionColor vertexPositionColor3 =
                    new SourceVertexPositionColor(new Vector3(vector3 + vector2 * width, 0f), color);
                SourceVertexPositionColor vertexPositionColor4 =
                    new SourceVertexPositionColor(new Vector3(vector3 - vector2 * width - vector * length, 0f), color);
                vertices[num++] = vertexPositionColor;
                vertices[num++] = vertexPositionColor2;
                vertices[num++] = vertexPositionColor3;
                vertices[num++] = vertexPositionColor2;
                vertices[num++] = vertexPositionColor3;
                vertices[num++] = vertexPositionColor4;
            }

            vertexCount = num;
        }

        private void BeforeRender()
        {
            if (BlockFill == null)
            {
                BlockFill =
                    ((ISourceVirtualContentEnvironment)engine).VirtualContent
                    .CreateRenderTarget("block-fill", 320, 180);
            }

            if (vertexCount > 0)
            {
                ((ISourceGraphicsDeviceEnvironment)engine).GraphicsDevice.SetRenderTarget(
                    (SourceRenderTarget2DResource)BlockFill.Target);
                ((ISourceGraphicsDeviceEnvironment)engine).GraphicsDevice.Clear(PackedColor.Lerp(PackedColor.Black,
                    new PackedColor(135, 206, 250, 255), 0.3f));
                SourcePrimitiveGraphics.DrawVertices(((ISourcePrimitiveGraphicsEnvironment)engine).PrimitiveGraphics,
                    Matrix4x4.Identity, vertices, vertexCount);
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
            if (BlockFill != null)
            {
                BlockFill.Dispose();
            }

            BlockFill = null;
        }

        private void ApplyAudio()
        {
            var process = (IOriginalGameplayProcess)engine;
            OriginalAudioSession.Apply(level.Session.Audio, process.AudioSession.ChannelOutput,
                process.AudioApplyPolicy);
        }

        private float mod(float x, float m)
        {
            return (x % m + m) % m;
        }
    }
}
