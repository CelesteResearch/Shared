using Celeste.Formats.Map.Entities.Attributes;
using System.Numerics;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Scheduling;
using Celeste.Game.Content.Maps.Entities;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Physics.Collision.Shapes;
using Celeste.Scene.Entities;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Hazards.Spinners.Dust;
using Celeste.Simulation.Gameplay.Player.Collision.Components;

namespace Celeste.Game.Gameplay.Hazards.Spinners.Moving
{
    public class OriginalTrackSpinnerState : SceneEntityState
    {
        public enum Speeds
        {
            Slow,
            Normal,
            Fast
        }

        public static readonly float[] PauseTimes = new float[] { .3f, .2f, .6f };
        public static readonly float[] MoveTimes = new float[] { .9f, .4f, .3f };
        protected readonly ISourceEngineContext Engine;
        public bool Up = true;
        public float PauseTimer;
        public Speeds Speed;
        public bool Moving = true;
        public float Angle;
        public Vector2 Start { get; private set; }
        public Vector2 End { get; private set; }
        public float Percent { get; private set; }

        public OriginalTrackSpinnerState(EntityData data, Vector2 offset, ISourceEngineContext engine)
            : base(((global::Celeste.Core.Components.ISourceEntitySourceDataEnvironment)engine)
                .EntitySourceDataRegistration)
        {
            Engine = engine;
            Collider = new ColliderListGeometry(
                new CircleColliderGeometry(((ISourceVectorEnvironment)engine).VectorArithmetic, 6f),
                new HitboxColliderGeometry(16f, 4f, -8f, -3f));
            OwnedComponents.Add(new PlayerColliderComponentState(OnPlayer));
            Start = data.Position + offset;
            End = data.Nodes[0] + offset;
            Speed = EntityAttributeReader.Enum(data.Values, "speed", Speeds.Normal);
            Angle = Vector2Geometry.Angle(Start - End);
            Percent = EntityAttributeReader.Bool(data.Values, "startCenter", false) ? .5f : 0f;
            if (Percent == 1f) Up = false;
            UpdatePosition();
        }

        public void UpdatePosition()
        {
            Position = Vector2Math.Lerp(Start, End,
                ((ISourceEasingEnvironment)Engine).EasingArithmetic.SineInOut(Percent),
                ((ISourceScalarEnvironment)Engine).ScalarArithmetic);
        }

        public override void Awake(object scene)
        {
            base.Awake(scene);
            OnTrackStart();
        }

        public override void Update()
        {
            base.Update();
            if (!Moving) return;
            if (PauseTimer > 0f)
            {
                PauseTimer -= Engine.DeltaTime;
                if (PauseTimer <= 0f) OnTrackStart();
                return;
            }

            Percent = ScalarMath.Approach(Percent, Up ? 1f : 0f,
                Engine.DeltaTime / MoveTimes[(int)Speed], ((ISourceExtremaEnvironment)Engine).ExtremaArithmetic);
            UpdatePosition();
            if ((Up && Percent == 1f) || (!Up && Percent == 0f))
            {
                Up = !Up;
                PauseTimer = PauseTimes[(int)Speed];
                OnTrackEnd();
            }
        }

        public virtual void OnPlayer(RoomPlayerSession player)
        {
            if (player.Die(
                    ((ISourceVectorEnvironment)Engine).VectorArithmetic.SafeNormalize(player.Position - Position)) !=
                null)
                Moving = false;
        }

        public virtual void OnTrackStart()
        {
        }

        public virtual void OnTrackEnd()
        {
        }
    }
}
