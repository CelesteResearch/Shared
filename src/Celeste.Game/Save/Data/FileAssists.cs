using System;
using System.Runtime.Serialization;

namespace Celeste.Game.Save.Data
{
    [DataContract(Name = "FileAssists",
        Namespace = "http://schemas.datacontract.org/2004/07/Celeste.Simulation.Rendering")]
    public struct FileAssists
    {
        [DataMember] public int GameSpeed;
        [DataMember] public global::Celeste.Simulation.Gameplay.Player.Configuration.DashMode DashMode;

        [DataMember] public bool Invincible,
            DashAssist,
            InfiniteStamina,
            MirrorMode,
            ThreeSixtyDashing,
            InvisibleMotion,
            NoGrabbing,
            LowFriction,
            SuperDashing,
            Hiccups,
            PlayAsBadeline;

        public static FileAssists Default => new FileAssists { GameSpeed = 10 };

        public void EnforceAssistMode()
        {
            GameSpeed = Math.Max(5, Math.Min(10, GameSpeed));
            MirrorMode = ThreeSixtyDashing = InvisibleMotion =
                NoGrabbing = LowFriction = SuperDashing = Hiccups = PlayAsBadeline = false;
        }
    }
}
