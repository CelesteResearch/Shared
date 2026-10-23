using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Components.Rendering;
using Celeste.Core.Display;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Randomness;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Startup;
using Celeste.Graphics.Content.VirtualAssets;
using Celeste.Graphics.Display.Colors;
using Celeste.Graphics.Rendering.Devices;
using Celeste.Graphics.Rendering.Primitives;
using Celeste.Graphics.Rendering.Vertices;
using Celeste.Scene.Entities;

namespace Celeste.Game.Entities.StarJump
{
    public class OriginalStarClimbGraphicsControllerState : SceneEntityState
    {
        private const int RayCount = 100;

        private readonly ISourceEngineContext engine;
        private StarClimbGraphicsProcessState Process => ((IOriginalStarJumpEnvironment)engine).StarClimbGraphics;
        private ISourceRandom CurrentRandom => ((ISourceRandomEnvironment)engine).Random;

        private StarClimbGraphicsProcessState.Ray[] rays => Process.rays;

        private readonly SourceVertexPositionColor[] vertices = new SourceVertexPositionColor[600];

        private int vertexCount;

        private readonly PackedColor rayColor;

        private readonly PackedColor wipeColor;

        private OriginalLevelSceneRoot level;

        public OriginalStarClimbGraphicsControllerState(EntityData data, Vector2 offset,
            ISourceEngineContext engine)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration)
        {
            this.engine = engine;
            Tags = ((IOriginalGameTagsEnvironment)engine).Tags.TransitionUpdate.Value |
                   ((IOriginalGameTagsEnvironment)engine).Tags.FrozenUpdate.Value;
            rayColor = SourceHexColor.HexToColor(EntityAttributeReader.Attr(data.Values, "fgColor", "a3ffff")) *
                       0.25f;
            wipeColor = SourceHexColor.HexToColor(EntityAttributeReader.Attr(data.Values, "bgColor", "293E4B"));
        }

        public override void Added(object scene)
        {
            base.Added(scene);
            level = scene as OriginalLevelSceneRoot;
            if (!DetectOtherController()) InitBlockFill();

            Add(new BeforeRenderCallbackComponentState(BeforeRender));
        }

        public override void Update()
        {
            base.Update();
            UpdateBlockFill();
        }

        private bool DetectOtherController()
        {
            foreach (var entity in level.Scheduler.Entities.GetTrackedEntities(
                         "Celeste.Mod.Entities.StarClimbGraphicsController"))
                if (entity is OriginalStarClimbGraphicsControllerState starClimbGraphicsController &&
                    starClimbGraphicsController != this)
                    return true;

            return false;
        }

        private void InitBlockFill()
        {
            for (var i = 0; i < rays.Length; i++)
            {
                rays[i].Reset(CurrentRandom);
                rays[i].Percent = SourceRandomMath.NextFloat(CurrentRandom);
            }
        }

        private void UpdateBlockFill()
        {
            var vector = Vector2Geometry.AngleToVector(-1.670796f, 1f);
            var vector2 = new Vector2(0f - vector.Y, vector.X);
            var num = 0;
            for (var i = 0; i < rays.Length; i++)
            {
                if (rays[i].Percent >= 1.0) rays[i].Reset(CurrentRandom);

                rays[i].Percent += engine.DeltaTime / rays[i].Duration;
                rays[i].Y += 8f * engine.DeltaTime;
                var vector3 = new Vector2(mod(rays[i].X - level.Camera.X * 0.9f, 480f) - 80f,
                    mod(rays[i].Y - level.Camera.Y * 0.7f, 580f) - 200f);
                var width = rays[i].Width;
                var length = rays[i].Length;
                var color = rayColor *
                            ((ISourceEasingEnvironment)engine).EasingArithmetic.CubeInOut(
                                ScalarMath.YoYo(rays[i].Percent));
                var vertexPositionColor =
                    new SourceVertexPositionColor(new(vector3 + vector2 * width + vector * length, 0f), color);
                var vertexPositionColor2 =
                    new SourceVertexPositionColor(new(vector3 - vector2 * width, 0f), color);
                var vertexPositionColor3 =
                    new SourceVertexPositionColor(new(vector3 + vector2 * width, 0f), color);
                var vertexPositionColor4 =
                    new SourceVertexPositionColor(new(vector3 - vector2 * width - vector * length, 0f), color);
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
            if (Process.BlockFill == null)
                Process.BlockFill =
                    ((ISourceVirtualContentEnvironment)engine).VirtualContent
                    .CreateRenderTarget("block-fill", 320, 180);

            if (!(vertexCount > 0))
                return;
            ((ISourceGraphicsDeviceEnvironment)engine).GraphicsDevice.SetRenderTarget(
                Process.BlockFill.Target);
            ((ISourceGraphicsDeviceEnvironment)engine).GraphicsDevice.Clear(wipeColor);
            SourcePrimitiveGraphics.DrawVertices(((ISourcePrimitiveGraphicsEnvironment)engine).PrimitiveGraphics,
                Matrix4x4.Identity, vertices, vertexCount);
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
            if (!!DetectOtherController())
                return;
            if (Process.BlockFill != null) Process.BlockFill.Dispose();

            Process.BlockFill = null;
        }

        private static float mod(float x, float m)
        {
            return (x % m + m) % m;
        }
    }
}
