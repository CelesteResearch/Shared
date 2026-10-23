using System.Numerics;
using System;

namespace Celeste.Input.Devices.Touch
{
    public struct SourceTouchLocation : IEquatable<SourceTouchLocation>
    {
        private Vector2 prevPosition;

        private SourceTouchLocationState prevState;

        public int Id { get; private set; }

        public Vector2 Position { get; private set; }

        public SourceTouchLocationState State { get; private set; }

        public SourceTouchLocation(int id, SourceTouchLocationState state, Vector2 position)
        {
            this = default(SourceTouchLocation);
            Id = id;
            State = state;
            Position = position;
            prevState = SourceTouchLocationState.Invalid;
            prevPosition = Vector2.Zero;
        }

        public SourceTouchLocation(int id, SourceTouchLocationState state, Vector2 position,
            SourceTouchLocationState previousState, Vector2 previousPosition)
        {
            this = default(SourceTouchLocation);
            Id = id;
            State = state;
            Position = position;
            prevState = previousState;
            prevPosition = previousPosition;
        }

        public bool Equals(SourceTouchLocation other)
        {
            if (Id == other.Id && Position == other.Position && State == other.State &&
                prevPosition == other.prevPosition)
            {
                return prevState == other.prevState;
            }

            return false;
        }

        public override bool Equals(object obj)
        {
            if (obj is SourceTouchLocation)
            {
                return Equals((SourceTouchLocation)obj);
            }

            return false;
        }

        public override int GetHashCode()
        {
            return unchecked(Id.GetHashCode() + unchecked(Position.X.GetHashCode() + Position.Y.GetHashCode()));
        }

        public override string ToString()
        {
            return "{Position:" + Celeste.Core.Mathematics.SourceVector2Formatting.Format(Position) + "}";
        }

        public bool TryGetPreviousLocation(out SourceTouchLocation previousLocation)
        {
            previousLocation = new SourceTouchLocation(Id, prevState, prevPosition);
            return previousLocation.State != SourceTouchLocationState.Invalid;
        }

        public static bool operator ==(SourceTouchLocation value1, SourceTouchLocation value2)
        {
            return value1.Equals(value2);
        }

        public static bool operator !=(SourceTouchLocation value1, SourceTouchLocation value2)
        {
            return !value1.Equals(value2);
        }
    }
}
