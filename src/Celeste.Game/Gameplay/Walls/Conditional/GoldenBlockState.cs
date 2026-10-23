using System;
using System.Numerics;
using Celeste.Core.Display;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Rendering;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Gameplay.Collectibles.Strawberries;
using Celeste.Game.Profiles;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Rendering;
using Celeste.Scene.Tracking;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Platforms.Foundation;
using Celeste.Simulation.Presentation.Effects.Mirrors;
using Celeste.Simulation.Presentation.Lighting;

namespace Celeste.Game.Gameplay.Walls.Conditional
{
    public class GoldenBlockState : SourceSolidEntityState
    {
        private readonly AtlasEntry[,] nineSlice;
        private readonly SpriteImage berry;

        private bool UsesInstalledStaticMoverPatch =>
            ((IGameProfileEnvironment)SourceWorld.EngineContext).SourceProfile ==
            GameProfile.InstalledEverest;

        public readonly float StartY;
        public float YLerp, SinkTimer, RenderLerp;


        public GoldenBlockState(Vector2 position, float width, float height, ISourceSolidWorld world)
            : base(position, width, height, false, world)
        {
            StartY = Y;
            // The original manually rendered Image is not an Entity component.
            berry = new(
                ((ISourceGameGraphicsEnvironment)SourceWorld.EngineContext).GameGraphics.GameAtlas.Entries[
                    "collectables/goldberry/idle00"]);
            berry.CenterOrigin();
            berry.Position = new(width / 2f, height / 2f);
            var texture =
                ((ISourceGameGraphicsEnvironment)SourceWorld.EngineContext).GameGraphics.GameAtlas.Entries[
                    "objects/goldblock"];
            nineSlice = new AtlasEntry[3, 3];
            for (var i = 0; i < 3; i++)
            for (var j = 0; j < 3; j++)
                nineSlice[i, j] = texture.GetSubtexture(i * 8, j * 8, 8, 8);
            Depth = -10000;
            OwnedComponents.Add(new LightOccludeState());
            OwnedComponents.Add(
                new MirrorSurfaceState(((ISourceExtremaEnvironment)SourceWorld.EngineContext).ExtremaArithmetic));
            SurfaceSoundIndex = 32;
        }

        public override void Awake(object scene)
        {
            base.Awake(scene);
            if (UsesInstalledStaticMoverPatch) DisableStaticMovers();
            Visible = false;
            Collidable = false;
            RenderLerp = 1f;
            var found = false;
            foreach (var entity in ((ISourceScene)scene).SourceScene.Entities)
                if (entity is OriginalStrawberryState strawberry && strawberry.Golden &&
                    strawberry.Follower.Leader != null)
                {
                    found = true;
                    break;
                }

            if (!found)
            {
                if (UsesInstalledStaticMoverPatch) DestroyStaticMovers();
                RemoveSelf();
            }
        }

        public override void Update()
        {
            base.Update();
            if (!Visible)
            {
                var player =
                    ((ISourceScene)Scene).SourceScene.Entities.GetTrackedEntity<RoomPlayerSession>(
                        typeof(RoomPlayerSession).FullName);

                if (player != null && player.X > X - 80f)
                {
                    Visible = true;
                    Collidable = true;
                    RenderLerp = 1f;
                }
            }

            if (Visible)
                RenderLerp = ScalarMath.Approach(RenderLerp, 0f, SourceWorld.EngineContext.DeltaTime * 3f,
                    ((ISourceExtremaEnvironment)SourceWorld.EngineContext).ExtremaArithmetic);
            if (HasPlayerRider()) SinkTimer = .1f;
            else if (SinkTimer > 0f) SinkTimer -= SourceWorld.EngineContext.DeltaTime;
            if (SinkTimer > 0f)
                YLerp = ScalarMath.Approach(YLerp, 1f, 1f * SourceWorld.EngineContext.DeltaTime,
                    ((ISourceExtremaEnvironment)SourceWorld.EngineContext).ExtremaArithmetic);
            else
                YLerp = ScalarMath.Approach(YLerp, 0f, 1f * SourceWorld.EngineContext.DeltaTime,
                    ((ISourceExtremaEnvironment)SourceWorld.EngineContext).ExtremaArithmetic);
            var y = ScalarMath.Lerp(StartY, StartY + 12f,
                ((ISourceEasingEnvironment)SourceWorld.EngineContext).EasingArithmetic.SineInOut(YLerp),
                ((ISourceScalarEnvironment)SourceWorld.EngineContext).ScalarArithmetic);
            MoveToY(y);
            if (UsesInstalledStaticMoverPatch)
            {
                if (RenderLerp == 0f) EnableStaticMovers();
                else DisableStaticMovers();
            }
        }

        private void DrawBlock(ISourceRenderContext context, Vector2 offset, PackedColor color)
        {
            var lastColumn = Collider.Width / 8f - 1f;
            var lastRow = Collider.Height / 8f - 1f;
            for (var i = 0; i <= lastColumn; i++)
            for (var j = 0; j <= lastRow; j++)
            {
                var column = i < lastColumn ? Math.Min(i, 1) : 2;
                var row = j < lastRow ? Math.Min(j, 1) : 2;
                SourceAtlasDrawing.Draw(context, this, nineSlice[column, row],
                    Position + offset + Shake + new Vector2(i * 8, j * 8), Vector2.Zero, color);
            }
        }

        public override void Render(ISourceRenderContext context)
        {
            var cube = ((ISourceEasingEnvironment)SourceWorld.EngineContext).EasingArithmetic.CubeIn(RenderLerp);
            var offset = new Vector2(0f, (((OriginalLevelSceneRoot)Scene).Bounds.Bottom - StartY + 32f) * cube);
            var position = Position;
            Position += offset;
            DrawBlock(context, new(-1f, 0f), PackedColor.Black);
            DrawBlock(context, new(1f, 0f), PackedColor.Black);
            DrawBlock(context, new(0f, -1f), PackedColor.Black);
            DrawBlock(context, new(0f, 1f), PackedColor.Black);
            DrawBlock(context, Vector2.Zero, PackedColor.White);
            berry.Color = PackedColor.White;
            berry.RenderPosition = Center;
            berry.Render(context);
            Position = position;
        }
    }
}
