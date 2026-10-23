namespace Celeste.Simulation.Gameplay.Player.Configuration
{
    public interface IPlayerAssistSettings
    {
        bool PlayAsBadeline { get; }
        bool DashAssist { get; }
        bool SuperDashing { get; }
        bool FullCircle { get; }
        bool NoGrabbing { get; }
        bool LowFriction { get; }
        bool InfiniteStamina { get; }
        bool Invincible { get; }
        bool InvisibleMotion { get; }
        bool Hiccups { get; }
        DashMode DashMode { get; }
    }
}
