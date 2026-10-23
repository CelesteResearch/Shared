using System;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Mathematics;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Execution.Levels;
using Celeste.Physics.Collision.Shapes;
using Celeste.Scene.Entities;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Platforms.StaticMovers;
using Celeste.Simulation.Gameplay.Player.Collision.Components;

namespace Celeste.Game.Gameplay.Hazards.Spinners.Moving
{
    public class OriginalRotateSpinnerState : SceneEntityState
    {
        protected readonly ISourceEngineContext Engine;
        public bool Moving = true;
        private Vector2 _center;
        private float _rotationPercent;
        protected ref float SourceRotationPercent => ref _rotationPercent;
        private readonly float _length;
        private bool _fallOutOfScreen;
        private readonly OriginalRotateSpinnerProfile _profile;
        private bool _fixAngle;
        private readonly Vector2 _startCenter;
        private readonly Vector2 _startPosition;

        public float Angle => _fixAngle
            ? ScalarMath.Lerp((float)Math.PI, -(float)Math.PI,
                Easer(_rotationPercent), ((ISourceScalarEnvironment)Engine).ScalarArithmetic)
            : ScalarMath.Lerp(4.712389f, -(float)Math.PI / 2f,
                Easer(_rotationPercent), ((ISourceScalarEnvironment)Engine).ScalarArithmetic);

        // ReSharper disable once AutoPropertyCanBeMadeGetOnly.Local
        public bool Clockwise { get; private set; }

        public OriginalRotateSpinnerState(EntityData data, Vector2 offset, ISourceEngineContext engine)
            : base(((ISourceEntitySourceDataEnvironment)engine)
                .EntitySourceDataRegistration)
        {
            Engine = engine;
            _profile = ((IOriginalRotateSpinnerEnvironment)engine).RotateSpinnerProfile;
            Position = data.Position + offset;
            Depth = -50;
            _center = data.Nodes[0] + offset;
            Clockwise = EntityAttributeReader.Bool(data.Values, "clockwise");
            Collider = new CircleColliderGeometry(((ISourceVectorEnvironment)engine).VectorArithmetic, 6f);
            OwnedComponents.Add(new PlayerColliderComponentState(OnPlayer));
            OwnedComponents.Add(new SourceStaticMoverState
            {
                SolidChecker = solid => solid.Collider != null && solid.Collider.Collide(_center),
                JumpThruChecker = jumpThru => jumpThru.Collider != null && jumpThru.Collider.Collide(_center),
                OnMove = amount =>
                {
                    _center += amount;
                    Position += amount;
                },
                OnDestroy = () => _fallOutOfScreen = true,
            });
            var angleRadians = Vector2Geometry.Angle(_center, Position);
            angleRadians = ScalarMath.WrapAngle(angleRadians);
            _rotationPercent = EaserInverse(ScalarMath.Percent(angleRadians, -(float)Math.PI / 2f, 4.712389f));
            _length = ((ISourceVectorEnvironment)engine).VectorArithmetic.Length(Position - _center);
            Position = _center + Vector2Geometry.AngleToVector(Angle, _length);
            if (_profile == OriginalRotateSpinnerProfile.Installed)
            {
                _startCenter = data.Nodes[0] + offset;
                _startPosition = data.Position + offset;
            }
        }

        public override void Awake(object actualScene)
        {
            base.Awake(actualScene);
            if (_profile != OriginalRotateSpinnerProfile.Installed) return;
            _fixAngle = ((OriginalLevelSceneRoot)Scene).AreaData.LevelSet != "Celeste";
            if (_fixAngle)
            {
                var angleRadians = Vector2Geometry.Angle(_startCenter, _startPosition);
                angleRadians = ScalarMath.WrapAngle(angleRadians);
                _rotationPercent = EaserInverse(ScalarMath.Percent(angleRadians,
                    (float)Math.PI, -(float)Math.PI));
                Position = _center + Vector2Geometry.AngleToVector(Angle, _length);
            }
        }

        private float Easer(float value)
        {
            return value;
        }

        private float EaserInverse(float value)
        {
            return value;
        }

        public override void Update()
        {
            base.Update();
            if (Moving)
            {
                if (Clockwise)
                {
                    _rotationPercent -= Engine.DeltaTime / 1.8f;
                    _rotationPercent += 1f;
                }
                else
                {
                    _rotationPercent += Engine.DeltaTime / 1.8f;
                }

                _rotationPercent %= 1f;
                Position = _center + Vector2Geometry.AngleToVector(Angle, _length);
            }

            if (_fallOutOfScreen)
            {
                _center.Y += 160f * Engine.DeltaTime;
                if (Y > ((OriginalLevelSceneRoot)Scene).Bounds.Bottom + 32) RemoveSelf();
            }
        }

        public virtual void OnPlayer(RoomPlayerSession player)
        {
            if (player.Die(
                    ((ISourceVectorEnvironment)Engine).VectorArithmetic.SafeNormalize(player.Position - Position)) !=
                null)
                Moving = false;
        }
    }
}
