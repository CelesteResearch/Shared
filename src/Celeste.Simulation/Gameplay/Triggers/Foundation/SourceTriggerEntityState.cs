using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Physics.Collision.Shapes;
using Celeste.Scene.Entities;
using Celeste.Scene.Triggers;

namespace Celeste.Simulation.Gameplay.Triggers.Foundation
{
    public abstract class SourceTriggerEntityState : SceneEntityState, ISourcePlayerTrigger<RoomPlayerSession>
    {
        public enum PositionModes
        {
            NoEffect,
            HorizontalCenter,
            VerticalCenter,
            TopToBottom,
            BottomToTop,
            LeftToRight,
            RightToLeft,
        }

        private readonly ISourceExtremaArithmetic extrema;
        public bool Triggered;

        bool ISourcePlayerTrigger<RoomPlayerSession>.Triggered
        {
            get => Triggered;
            set => Triggered = value;
        }

        public bool PlayerIsInside { get; private set; }

        protected SourceTriggerEntityState(
            ISourceEntitySourceDataRegistration registration,
            Vector2 position, float width, float height,
            ISourceExtremaArithmetic extrema) : base(registration, position)
        {
            this.extrema = extrema;
            Collider = new HitboxColliderGeometry(width, height);
            Visible = false;
        }

        public virtual void OnEnter(RoomPlayerSession player)
        {
            PlayerIsInside = true;
        }

        public virtual void OnStay(RoomPlayerSession player)
        {
        }

        public virtual void OnLeave(RoomPlayerSession player)
        {
            PlayerIsInside = false;
        }

        protected float GetPositionLerp(RoomPlayerSession player, PositionModes mode)
        {
            switch (mode)
            {
                case PositionModes.LeftToRight:
                    return ScalarMath.ClampedMap(player.CenterX, Left, Right);
                case PositionModes.RightToLeft:
                    return ScalarMath.ClampedMap(player.CenterX, Right, Left);
                case PositionModes.TopToBottom:
                    return ScalarMath.ClampedMap(player.CenterY, Top, Bottom);
                case PositionModes.BottomToTop:
                    return ScalarMath.ClampedMap(player.CenterY, Bottom, Top);
                case PositionModes.HorizontalCenter:
                    return extrema.Min(
                        ScalarMath.ClampedMap(player.CenterX, Left, CenterX),
                        ScalarMath.ClampedMap(player.CenterX, Right, CenterX));
                case PositionModes.VerticalCenter:
                    return extrema.Min(
                        ScalarMath.ClampedMap(player.CenterY, Top, CenterY),
                        ScalarMath.ClampedMap(player.CenterY, Bottom, CenterY));
                default:
                    return 1f;
            }
        }
    }
}
