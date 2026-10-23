using System;
using System.Numerics;
using Celeste.Physics.Collision;
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
            RightToLeft
        }

        private readonly global::Celeste.Core.Mathematics.Extrema.ISourceExtremaArithmetic extrema;
        public bool Triggered;

        bool ISourcePlayerTrigger<RoomPlayerSession>.Triggered
        {
            get => Triggered;
            set => Triggered = value;
        }

        public bool PlayerIsInside { get; private set; }

        protected SourceTriggerEntityState(
            global::Celeste.Core.Components.ISourceEntitySourceDataRegistration registration,
            Vector2 position, float width, float height,
            global::Celeste.Core.Mathematics.Extrema.ISourceExtremaArithmetic extrema) : base(registration, position)
        {
            this.extrema = extrema;
            Collider = new HitboxColliderGeometry(width, height);
            Visible = false;
        }

        public virtual void OnEnter(RoomPlayerSession player) => PlayerIsInside = true;

        public virtual void OnStay(RoomPlayerSession player)
        {
        }

        public virtual void OnLeave(RoomPlayerSession player) => PlayerIsInside = false;

        protected float GetPositionLerp(RoomPlayerSession player, PositionModes mode)
        {
            switch (mode)
            {
                case PositionModes.LeftToRight:
                    return global::Celeste.Core.Mathematics.ScalarMath.ClampedMap(player.CenterX, Left, Right);
                case PositionModes.RightToLeft:
                    return global::Celeste.Core.Mathematics.ScalarMath.ClampedMap(player.CenterX, Right, Left);
                case PositionModes.TopToBottom:
                    return global::Celeste.Core.Mathematics.ScalarMath.ClampedMap(player.CenterY, Top, Bottom);
                case PositionModes.BottomToTop:
                    return global::Celeste.Core.Mathematics.ScalarMath.ClampedMap(player.CenterY, Bottom, Top);
                case PositionModes.HorizontalCenter:
                    return extrema.Min(
                        global::Celeste.Core.Mathematics.ScalarMath.ClampedMap(player.CenterX, Left, CenterX),
                        global::Celeste.Core.Mathematics.ScalarMath.ClampedMap(player.CenterX, Right, CenterX));
                case PositionModes.VerticalCenter:
                    return extrema.Min(
                        global::Celeste.Core.Mathematics.ScalarMath.ClampedMap(player.CenterY, Top, CenterY),
                        global::Celeste.Core.Mathematics.ScalarMath.ClampedMap(player.CenterY, Bottom, CenterY));
                default:
                    return 1f;
            }
        }
    }
}
