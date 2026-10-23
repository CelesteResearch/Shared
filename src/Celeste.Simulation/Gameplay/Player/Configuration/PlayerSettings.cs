namespace Celeste.Simulation.Gameplay.Player.Configuration
{
    public sealed class PlayerSettings : IPlayerAssistSettings
    {
        public bool PlayAsBadeline;
        public bool DashAssist, SuperDashing, FullCircle, NoGrabbing, LowFriction;
        public bool InfiniteStamina, Invincible;

        /// <summary>SaveData.Assists.InvisibleMotion (Assists.cs:30), read by Player.cs:1362.</summary>
        public bool InvisibleMotion;

        /// <summary>SaveData.Assists.Hiccups (Assists.cs:38), read by Player.cs:1438.</summary>
        public bool Hiccups;

        public DashMode DashMode;
        public float TimeRate = 1f;

        bool IPlayerAssistSettings.PlayAsBadeline => PlayAsBadeline;
        bool IPlayerAssistSettings.DashAssist => DashAssist;
        bool IPlayerAssistSettings.SuperDashing => SuperDashing;
        bool IPlayerAssistSettings.FullCircle => FullCircle;
        bool IPlayerAssistSettings.NoGrabbing => NoGrabbing;
        bool IPlayerAssistSettings.LowFriction => LowFriction;
        bool IPlayerAssistSettings.InfiniteStamina => InfiniteStamina;
        bool IPlayerAssistSettings.Invincible => Invincible;
        bool IPlayerAssistSettings.InvisibleMotion => InvisibleMotion;
        bool IPlayerAssistSettings.Hiccups => Hiccups;
        DashMode IPlayerAssistSettings.DashMode => DashMode;
    }
}
