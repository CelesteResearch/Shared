using System.Numerics;
using Celeste.Core.Display;

namespace Celeste.Simulation.Presentation.Backdrops.Godrays
{
    public readonly struct GodrayMotionConfiguration
    {
        public readonly Vector2 Direction, Scroll;
        public readonly float VerticalVelocity;
        public readonly float? HorizontalVelocity;
        public readonly PackedColor StartColor;
        public readonly PackedColor? EndColor;
        public readonly bool ExtendedBounds;
        public readonly GodrayPositionRounding PositionRounding;
        public readonly GodrayGeometrySampling GeometrySampling;

        public GodrayMotionConfiguration(Vector2 direction, Vector2 scroll, float verticalVelocity,
            PackedColor startColor,
            PackedColor? endColor = null, bool extendedBounds = false,
            GodrayPositionRounding positionRounding = GodrayPositionRounding.Truncate,
            GodrayGeometrySampling geometrySampling = GodrayGeometrySampling.AfterReset,
            float? horizontalVelocity = null)
        {
            Direction = direction;
            Scroll = scroll;
            VerticalVelocity = verticalVelocity;
            HorizontalVelocity = horizontalVelocity;
            StartColor = startColor;
            EndColor = endColor;
            ExtendedBounds = extendedBounds;
            PositionRounding = positionRounding;
            GeometrySampling = geometrySampling;
        }
    }
}
