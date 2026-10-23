using Celeste.Formats.Map.Entities.Attributes;
using System.Numerics;
using Celeste.Core.Mathematics;
using Celeste.Core.Scheduling;
using Celeste.Game.Content.Maps.Entities;
using Celeste.Game.Execution.Levels;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Physics.Collision;
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
        private Vector2 center;
        private float rotationPercent;
        protected ref float SourceRotationPercent => ref rotationPercent;
        private float length;
        private bool fallOutOfScreen;
        private readonly OriginalRotateSpinnerProfile profile;
        private bool fixAngle;
        private Vector2 startCenter;
        private Vector2 startPosition;

        public float Angle => fixAngle
            ? ScalarMath.Lerp((float)System.Math.PI, -(float)System.Math.PI,
                Easer(rotationPercent), ((ISourceScalarEnvironment)Engine).ScalarArithmetic)
            : ScalarMath.Lerp(4.712389f, -(float)System.Math.PI / 2f,
                Easer(rotationPercent), ((ISourceScalarEnvironment)Engine).ScalarArithmetic);

        public bool Clockwise { get; private set; }

        public OriginalRotateSpinnerState(EntityData data, Vector2 offset, ISourceEngineContext engine)
            : base(((global::Celeste.Core.Components.ISourceEntitySourceDataEnvironment)engine)
                .EntitySourceDataRegistration)
        {
            Engine = engine;
            profile = ((IOriginalRotateSpinnerEnvironment)engine).RotateSpinnerProfile;
            Position = data.Position + offset;
            Depth = -50;
            center = data.Nodes[0] + offset;
            Clockwise = EntityAttributeReader.Bool(data.Values, "clockwise", false);
            Collider = new CircleColliderGeometry(((ISourceVectorEnvironment)engine).VectorArithmetic, 6f);
            OwnedComponents.Add(new PlayerColliderComponentState(OnPlayer));
            OwnedComponents.Add(new SourceStaticMoverState
            {
                SolidChecker = solid => solid.Collider != null && solid.Collider.Collide(center),
                JumpThruChecker = jumpThru => jumpThru.Collider != null && jumpThru.Collider.Collide(center),
                OnMove = amount =>
                {
                    center += amount;
                    Position += amount;
                },
                OnDestroy = () => fallOutOfScreen = true
            });
            float angleRadians = Vector2Geometry.Angle(center, Position);
            angleRadians = ScalarMath.WrapAngle(angleRadians);
            rotationPercent = EaserInverse(ScalarMath.Percent(angleRadians, -(float)System.Math.PI / 2f, 4.712389f));
            length = ((ISourceVectorEnvironment)engine).VectorArithmetic.Length(Position - center);
            Position = center + Vector2Geometry.AngleToVector(Angle, length);
            if (profile == OriginalRotateSpinnerProfile.Installed)
            {
                startCenter = data.Nodes[0] + offset;
                startPosition = data.Position + offset;
            }
        }

        public override void Awake(object actualScene)
        {
            base.Awake(actualScene);
            if (profile != OriginalRotateSpinnerProfile.Installed) return;
            fixAngle = ((OriginalLevelSceneRoot)Scene).AreaData.LevelSet != "Celeste";
            if (fixAngle)
            {
                float angleRadians = Vector2Geometry.Angle(startCenter, startPosition);
                angleRadians = ScalarMath.WrapAngle(angleRadians);
                rotationPercent = EaserInverse(ScalarMath.Percent(angleRadians,
                    (float)System.Math.PI, -(float)System.Math.PI));
                Position = center + Vector2Geometry.AngleToVector(Angle, length);
            }
        }

        private float Easer(float value) => value;
        private float EaserInverse(float value) => value;

        public override void Update()
        {
            base.Update();
            if (Moving)
            {
                if (Clockwise)
                {
                    rotationPercent -= Engine.DeltaTime / 1.8f;
                    rotationPercent += 1f;
                }
                else rotationPercent += Engine.DeltaTime / 1.8f;

                rotationPercent %= 1f;
                Position = center + Vector2Geometry.AngleToVector(Angle, length);
            }

            if (fallOutOfScreen)
            {
                center.Y += 160f * Engine.DeltaTime;
                if (Y > (float)(((OriginalLevelSceneRoot)Scene).Bounds.Bottom + 32)) RemoveSelf();
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
