using System;
using System.Numerics;
using Celeste.Core.Mathematics;
using Celeste.Core.Rendering;
using Celeste.Physics.Collision;
using Celeste.Scene.Entities;
using Celeste.Simulation.Gameplay.Platforms.Foundation;
using Celeste.Simulation.Gameplay.Tiles;
using Celeste.Simulation.Presentation.Lighting;
using Celeste.Graphics.Content.Tiles;

namespace Celeste.Simulation.Gameplay.Walls.Concealment
{
    public class ExitBlockState : SourceSolidEntityState, ISecretWallState
    {
        public TileGrid Tiles { get; private set; }
        public RoomTransitionListener TransitionListener { get; }
        public EffectCutoutState Cutout { get; }
        public float TransitionStartAlpha { get; private set; }
        public readonly char TileType;
        private readonly SecretWallContext context;
        private ISecretWallScene Level => (ISecretWallScene)Scene;

        public ExitBlockState(Vector2 position, float width, float height, char tileType,
            ISourceSolidWorld world, SecretWallContext context)
            : base(position, width, height, true, world)
        {
            Depth = -13000;
            TileType = tileType;
            this.context = context;
            TransitionListener = new RoomTransitionListener();
            TransitionListener.OnOutBegin = OnTransitionOutBegin;
            TransitionListener.OnInBegin = OnTransitionInBegin;
            OwnedComponents.Add(TransitionListener);
            Cutout = new EffectCutoutState();
            OwnedComponents.Add(Cutout);
            SurfaceSoundIndex = context.TileToSurfaceSoundIndex(tileType);
            EnableAssistModeChecks = false;
        }

        private void OnTransitionOutBegin()
        {
            if (Collider != null && Collider.Collide(Level.Bounds))
            {
                TransitionListener.OnOut = OnTransitionOut;
                TransitionStartAlpha = Tiles.Alpha;
            }
        }

        private void OnTransitionOut(float percent)
        {
            Cutout.Alpha = (Tiles.Alpha = ScalarMath.Lerp(TransitionStartAlpha, 0f, percent,
                ((ISourceScalarEnvironment)SourceWorld.EngineContext).ScalarArithmetic));
            Cutout.Update();
        }

        private void OnTransitionInBegin()
        {
            if (Collider != null && Collider.Collide(Level.PreviousBounds.Value) && CollideFirstPlayer() == null)
            {
                Cutout.Alpha = 0f;
                Tiles.Alpha = 0f;
                TransitionListener.OnIn = OnTransitionIn;
            }
        }

        private void OnTransitionIn(float percent)
        {
            Cutout.Alpha = (Tiles.Alpha = percent);
            Cutout.Update();
        }

        public override void Added(object actualScene)
        {
            base.Added(actualScene);
            var level = Level;
            var tileBounds = level.TileBounds;
            var solidsData = level.SolidsData;
            int x = (int)(X / 8f) - tileBounds.Left;
            int y = (int)(Y / 8f) - tileBounds.Top;
            int tilesX = (int)Width / 8;
            int tilesY = (int)Height / 8;
            Tiles = level.ForegroundAutotiler.GenerateOverlay(TileType, x, y, tilesX, tilesY, solidsData).TileGrid;
            OwnedComponents.Add(Tiles);
            OwnedComponents.Add(new TileInterceptorState(Tiles, false));
        }

        public override void Awake(object actualScene)
        {
            base.Awake(actualScene);
            if (CollideFirstPlayer() != null)
            {
                Cutout.Alpha = (Tiles.Alpha = 0f);
                Collidable = false;
            }
        }

        protected void UpdateSolid() => base.Update();

        public override void Update()
        {
            base.Update();
            if (Collidable)
                Cutout.Alpha = (Tiles.Alpha = ScalarMath.Approach(Tiles.Alpha, 1f, SourceWorld.EngineContext.DeltaTime,
                    ((global::Celeste.Core.Mathematics.Extrema.ISourceExtremaEnvironment)SourceWorld.EngineContext)
                    .ExtremaArithmetic));
            else if (CollideFirstPlayer() == null)
            {
                Collidable = true;
                context.PlaySound("event:/game/general/passage_closed_behind", Center);
            }
        }

        private RoomPlayerSession CollideFirstPlayer() =>
            SourceTrackedEntityCollision.First<RoomPlayerSession>(Level.SourceScene.Entities,
                typeof(global::Celeste.Simulation.RoomPlayerSession).FullName, this);

        public override void Render(ISourceRenderContext renderContext)
        {
            if (Tiles.Alpha >= 1f)
            {
                var level = Level;
                if (level.ShakeVector.X < 0f && level.Camera.X <= level.Bounds.Left && X <= level.Bounds.Left)
                    Tiles.RenderAt(Position + new Vector2(-3f, 0f), renderContext);
                if (level.ShakeVector.X > 0f && level.Camera.X + 320f >= level.Bounds.Right &&
                    X + Width >= level.Bounds.Right)
                    Tiles.RenderAt(Position + new Vector2(3f, 0f), renderContext);
                if (level.ShakeVector.Y < 0f && level.Camera.Y <= level.Bounds.Top && Y <= level.Bounds.Top)
                    Tiles.RenderAt(Position + new Vector2(0f, -3f), renderContext);
                if (level.ShakeVector.Y > 0f && level.Camera.Y + 180f >= level.Bounds.Bottom &&
                    Y + Height >= level.Bounds.Bottom)
                    Tiles.RenderAt(Position + new Vector2(0f, 3f), renderContext);
            }

            base.Render(renderContext);
        }
    }
}
