using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Simulation.Rendering;
using Celeste.Simulation;

namespace Celeste.Simulation.Gameplay.Mechanisms.Switches
{
    public sealed class SwitchGroupState
    {
        public readonly List<global::Celeste.Simulation.Gameplay.Mechanisms.Switches.SwitchState> Switches =
            new List<global::Celeste.Simulation.Gameplay.Mechanisms.Switches.SwitchState>();

        public Func<string> SessionRoom;
        public Func<string, bool> GetFlag;
        public Action<string> SetFlag;
        public Func<bool> PlayerOnGround;
        public bool Check() => Switches.Count > 0 && Switches[0].Finished;
        public bool CheckLevelFlag() => GetFlag?.Invoke("switches_" + SessionRoom?.Invoke()) ?? false;
        public void SetLevelFlag() => SetFlag?.Invoke("switches_" + SessionRoom?.Invoke());

        public bool FinishedCheck()
        {
            foreach (var member in Switches)
                if (!member.Activated)
                    return false;
            foreach (var member in Switches) member.Finish();
            return true;
        }
    }
}
