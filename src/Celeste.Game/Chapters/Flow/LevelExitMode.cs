using System;
using System.Collections;
using System.IO;
using System.Numerics;
using System.Xml;
using Celeste.Simulation.Rendering;
using Celeste.Simulation;

namespace Celeste.Game.Chapters.Flow
{
    public enum LevelExitMode
    {
        SaveAndQuit,
        GiveUp,
        Restart,
        GoldenBerryRestart,
        Completed,
        CompletedInterlude
    }
}
