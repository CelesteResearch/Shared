using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Celeste.Formats.Save.Xml
{
    public sealed class Assists
    {
        public int GameSpeed = 10;
        public bool Invincible;
        public DashMode DashMode;

        public bool DashAssist,
            InfiniteStamina,
            MirrorMode,
            ThreeSixtyDashing,
            InvisibleMotion,
            NoGrabbing,
            LowFriction,
            SuperDashing,
            Hiccups,
            PlayAsBadeline;
    }
}
