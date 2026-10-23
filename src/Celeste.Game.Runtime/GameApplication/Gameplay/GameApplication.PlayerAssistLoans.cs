using Celeste.Input.Gameplay;
using Celeste.Simulation.Gameplay.Player.Configuration;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : IPlayerAssistSettings, IGameInputEnvironment
    {
        bool IPlayerAssistSettings.PlayAsBadeline => SaveContext.CurrentSave.Assists.PlayAsBadeline;
        bool IPlayerAssistSettings.DashAssist => SaveContext.CurrentSave.Assists.DashAssist;
        bool IPlayerAssistSettings.SuperDashing => SaveContext.CurrentSave.Assists.SuperDashing;
        bool IPlayerAssistSettings.FullCircle => SaveContext.CurrentSave.Assists.ThreeSixtyDashing;
        bool IPlayerAssistSettings.NoGrabbing => SaveContext.CurrentSave.Assists.NoGrabbing;
        bool IPlayerAssistSettings.LowFriction => SaveContext.CurrentSave.Assists.LowFriction;
        bool IPlayerAssistSettings.InfiniteStamina => SaveContext.CurrentSave.Assists.InfiniteStamina;
        bool IPlayerAssistSettings.Invincible => SaveContext.CurrentSave.Assists.Invincible;
        bool IPlayerAssistSettings.InvisibleMotion => SaveContext.CurrentSave.Assists.InvisibleMotion;
        bool IPlayerAssistSettings.Hiccups => SaveContext.CurrentSave.Assists.Hiccups;
        DashMode IPlayerAssistSettings.DashMode => SaveContext.CurrentSave.Assists.DashMode;
    }
}
