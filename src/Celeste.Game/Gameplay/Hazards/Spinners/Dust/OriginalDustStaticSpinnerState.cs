using System;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Mathematics;
using Celeste.Core.Randomness;
using Celeste.Core.Rendering.Diagnostics;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Execution.Levels;
using Celeste.Physics.Collision;
using Celeste.Physics.Collision.Shapes;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Collision.Blockers;
using Celeste.Simulation.Gameplay.Hazards.Spinners.Dust;
using Celeste.Simulation.Gameplay.Holdables;
using Celeste.Simulation.Gameplay.Platforms.Foundation;
using Celeste.Simulation.Gameplay.Platforms.StaticMovers;
using Celeste.Simulation.Gameplay.Player.Collision.Components;

namespace Celeste.Game.Gameplay.Hazards.Spinners.Dust
{
    public class OriginalDustStaticSpinnerState : SceneEntityState,
        ISourceCycleHitboxOffset
    {
        private readonly ISourceEngineContext _engine;
        private readonly float _offset;
        float ISourceCycleHitboxOffset.CycleHitboxOffset => _offset;
        public DustGraphicState Sprite;

        public OriginalDustStaticSpinnerState(ISourceEngineContext engine, Vector2 position,
            bool attachToSolid, bool ignoreSolids = false)
            : base(((ISourceEntitySourceDataEnvironment)engine)
                .EntitySourceDataRegistration)
        {
            _engine = engine ?? throw new ArgumentNullException(nameof(engine));
            _offset = SourceRandomMath.NextFloat(((ISourceRandomEnvironment)engine).Random);
            Position = position;
            Collider = new ColliderListGeometry(
                new CircleColliderGeometry(((ISourceVectorEnvironment)engine).VectorArithmetic, 6f),
                new HitboxColliderGeometry(16f, 4f, -8f, -3f));
            OwnedComponents.Add(new PlayerColliderComponentState(OnPlayer));
            OwnedComponents.Add(new HoldableColliderState(OnHoldable));
            OwnedComponents.Add(new LedgeBlockerState());
            OwnedComponents.Add(Sprite = new(engine, ignoreSolids, true, true));
            Depth = -50;
            if (attachToSolid)
                OwnedComponents.Add(new SourceStaticMoverState
                {
                    OnShake = OnShake,
                    SolidChecker = IsRiding,
                });
        }

        public OriginalDustStaticSpinnerState(EntityData data, Vector2 offset,
            ISourceEngineContext engine)
            : this(engine, data.Position + offset, EntityAttributeReader.Bool(data.Values, "attachToSolid"))
        {
        }

        public void ForceInstantiate()
        {
            Sprite.AddDustNodesIfInCamera();
        }

        public override void Update()
        {
            base.Update();
            if (((OriginalLevelSceneRoot)Scene).OnInterval(.05f, _offset) &&
                Sprite.Estableshed)
            {
                var player =
                    ((ISourceScene)Scene).SourceScene.Entities.GetTrackedEntity<RoomPlayerSession>(
                        typeof(RoomPlayerSession).FullName);

                if (player != null)
                    Collidable = Math.Abs(player.X - X) < 128f && Math.Abs(player.Y - Y) < 128f;
            }
        }

        private void OnShake(Vector2 position)
        {
            Sprite.Position = position;
        }

        private bool IsRiding(SourceSolidEntityState solid)
        {
            return SourceEntityCollision.Check(this, solid);
        }

        private void OnPlayer(RoomPlayerSession player)
        {
            player.Die(((ISourceVectorEnvironment)_engine).VectorArithmetic.SafeNormalize(player.Position - Position));
            Sprite.OnHitPlayer();
        }

        private void OnHoldable(HoldableState holdable)
        {
            holdable.HitSpinner(this);
        }
    }
}
