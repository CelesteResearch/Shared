namespace Celeste.Game.Gameplay.Decoration.MoonCreatures
{
    public readonly struct MoonCreatureMotionSettings
    {
        public readonly float Acceleration;
        public readonly float FollowAcceleration;
        public readonly float MaxSpeed;
        public readonly float MaxFollowSpeed;
        public readonly float MaxFollowDistance;
        public readonly float MinFollowTime;
        public readonly float MaxFollowTime;
        public readonly float TargetRangeRadius;
        public readonly float MinTargetTime;
        public readonly float MaxTargetTime;
        public readonly float MaxFollowTargetTime;

        public static MoonCreatureMotionSettings Original =>
            new MoonCreatureMotionSettings(90f, 120f, 40f, 70f, 200f, 6f, 12f, 32f, 0.8f, 4f, 2f);

        public MoonCreatureMotionSettings(float acceleration, float followAcceleration, float maxSpeed,
            float maxFollowSpeed, float maxFollowDistance, float minFollowTime, float maxFollowTime,
            float targetRangeRadius, float minTargetTime, float maxTargetTime, float maxFollowTargetTime)
        {
            Acceleration = acceleration;
            FollowAcceleration = followAcceleration;
            MaxSpeed = maxSpeed;
            MaxFollowSpeed = maxFollowSpeed;
            MaxFollowDistance = maxFollowDistance;
            MinFollowTime = minFollowTime;
            MaxFollowTime = maxFollowTime;
            TargetRangeRadius = targetRangeRadius;
            MinTargetTime = minTargetTime;
            MaxTargetTime = maxTargetTime;
            MaxFollowTargetTime = maxFollowTargetTime;
        }
    }
}
