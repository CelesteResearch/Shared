using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Maps;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Graphics.Content.Tiles;
using Celeste.Physics.Collision.Shapes;
using Celeste.Scene.Entities;
using Celeste.Simulation.Gameplay.Tiles;
using Celeste.Simulation.Presentation.Lighting;

namespace Celeste.Simulation.Gameplay.Walls.Concealment
{
    public class FakeWallState : SceneEntityState, ISecretWallState
    {
        public readonly FakeWallMode Mode;
        public readonly MapEntityId EntityId;
        public readonly char TileType;
        private readonly SecretWallContext context;
        private readonly ISourceEngineContext engine;
        public TileGrid Tiles { get; protected set; }
        public EffectCutoutState Cutout { get; }
        public bool PlayTransitionReveal;
        public bool Fade { get; private set; }
        public bool TransitionFade { get; private set; }
        public float TransitionStartAlpha { get; private set; }
        private ISecretWallScene Level => (ISecretWallScene)Scene;

        public FakeWallState(MapEntityId entityId, Vector2 position, char tile, float width,
            float height, FakeWallMode mode, SecretWallContext context, ISourceEngineContext engine)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration)
        {
            Mode = mode;
            EntityId = entityId;
            TileType = tile;
            this.context = context;
            this.engine = engine;
            Position = position;
            Collider = new HitboxColliderGeometry(width, height);
            Depth = -13000;
            Cutout = new();
            OwnedComponents.Add(Cutout);
        }

        public override void Added(object actualScene)
        {
            base.Added(actualScene);
            var tilesX = (int)Width / 8;
            var tilesY = (int)Height / 8;
            if (Mode == FakeWallMode.Wall)
            {
                var level = Level;
                var tileBounds = level.TileBounds;
                var solidsData = level.SolidsData;
                var x = (int)X / 8 - tileBounds.Left;
                var y = (int)Y / 8 - tileBounds.Top;
                Tiles = level.ForegroundAutotiler.GenerateOverlay(TileType, x, y, tilesX, tilesY, solidsData).TileGrid;
            }
            else if (Mode == FakeWallMode.Block)
            {
                Tiles = Level.ForegroundAutotiler.GenerateBox(TileType, tilesX, tilesY).TileGrid;
            }

            OwnedComponents.Add(Tiles);
            OwnedComponents.Add(new TileInterceptorState(Tiles, false));
        }

        public override void Awake(object actualScene)
        {
            base.Awake(actualScene);
            if (CollideFirstPlayer() != null)
            {
                Tiles.Alpha = 0f;
                Fade = true;
                Cutout.Visible = false;
                if (PlayTransitionReveal)
                    context.PlaySound("event:/game/general/secret_revealed", Center);
                Level.AddDoNotLoad(EntityId);
            }
            else
            {
                var listener = new RoomTransitionListener();
                listener.OnOut = OnTransitionOut;
                listener.OnOutBegin = OnTransitionOutBegin;
                listener.OnIn = OnTransitionIn;
                listener.OnInBegin = OnTransitionInBegin;
                OwnedComponents.Add(listener);
            }
        }

        private RoomPlayerSession CollideFirstPlayer()
        {
            return SourceTrackedEntityCollision.First<RoomPlayerSession>(Level.SourceScene.Entities,
                typeof(RoomPlayerSession).FullName, this);
        }

        private void OnTransitionOutBegin()
        {
            if (Collider != null && Collider.Collide(Level.Bounds))
            {
                TransitionFade = true;
                TransitionStartAlpha = Tiles.Alpha;
            }
            else
            {
                TransitionFade = false;
            }
        }

        private void OnTransitionOut(float percent)
        {
            if (TransitionFade) Tiles.Alpha = TransitionStartAlpha * (1f - percent);
        }

        private void OnTransitionInBegin()
        {
            var level = Level;
            if (level.PreviousBounds.HasValue && Collider != null && Collider.Collide(level.PreviousBounds.Value))
            {
                TransitionFade = true;
                Tiles.Alpha = 0f;
            }
            else
            {
                TransitionFade = false;
            }
        }

        private void OnTransitionIn(float percent)
        {
            if (TransitionFade) Tiles.Alpha = percent;
        }

        public override void Update()
        {
            base.Update();
            if (Fade)
            {
                Tiles.Alpha = ScalarMath.Approach(Tiles.Alpha, 0f, 2f * engine.DeltaTime,
                    ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
                Cutout.Alpha = Tiles.Alpha;
                if (Tiles.Alpha <= 0f) RemoveSelf();
                return;
            }

            var player = CollideFirstPlayer();
            if (player != null && player.Machine.State != 9)
            {
                Level.AddDoNotLoad(EntityId);
                Fade = true;
                context.PlaySound("event:/game/general/secret_revealed", Center);
            }
        }

        public override void Render(ISourceRenderContext renderContext)
        {
            if (Mode == FakeWallMode.Wall) SecretWallDrawing.RenderShakeMargins(this, Tiles, Level, renderContext);

            base.Render(renderContext);
        }
    }
}
