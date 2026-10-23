using System;
using System.Numerics;
using Celeste.Simulation;

namespace Celeste.Simulation.Diagnostics.Console
{
    // Which flag set a flag command addresses. The original writes three of them:
    //   Session -> SaveData.Instance.CurrentSession.SetFlag      (Commands.cs:657)
    //   Save    -> SaveData.Instance.SetFlag / Flags.Remove      (Commands.cs:623)
    //   Level   -> SaveData.Instance.CurrentSession.LevelFlags   (Commands.cs:663)
    public enum DebugConsoleFlagKind
    {
        Session,
        Save,
        Level
    }
}
