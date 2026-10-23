namespace Celeste.Simulation.Gameplay.Camera
{
    // Value-only camera configuration. A game supplies its viewport, movement constants and state roles once.
    public readonly struct CameraMotionProfile
    {
        public readonly int ViewWidth, ViewHeight;

        public readonly float CenterX,
            CenterY,
            DirectionBias,
            RiseBias,
            NoOffsetRise,
            LookAheadScale,
            FollowDamping,
            FastFollowFactor;

        public readonly CameraPlayerStateRoles States;

        public CameraMotionProfile(int viewWidth, int viewHeight, float centerX, float centerY,
            float directionBias, float riseBias, float noOffsetRise, float lookAheadScale,
            float followDamping, float fastFollowFactor, CameraPlayerStateRoles states)
        {
            ViewWidth = viewWidth;
            ViewHeight = viewHeight;
            CenterX = centerX;
            CenterY = centerY;
            DirectionBias = directionBias;
            RiseBias = riseBias;
            NoOffsetRise = noOffsetRise;
            LookAheadScale = lookAheadScale;
            FollowDamping = followDamping;
            FastFollowFactor = fastFollowFactor;
            States = states;
        }
    }
}
