using System;
using System.Collections;
using System.IO;
using System.Numerics;
using System.Xml;
using Celeste.Simulation.Rendering;
using Celeste.Simulation;

namespace Celeste.Game.Chapters.Flow
{
    // Mirrors Celeste/Overworld.cs's `StartMode` numbering, which GameFlow.cs:201 casts between:
    // Titlescreen, ReturnFromOptions, AreaComplete, AreaQuit, ReturnFromPico8, MainMenu. A level exit
    // itself only produces AreaComplete/AreaQuit/MainMenu (:83-85); Titlescreen is the mode the Pico-8
    // console's own exit uses (`Emulator.cs:412 Engine.Scene = new OverworldLoader(StartMode.Titlescreen)`
    // when it was opened with no return target), which the debug console's `pico` command reaches
    // through a ChapterSceneRequest of kind Overworld.
    public enum LevelExitOverworldMode
    {
        Titlescreen = 0,
        AreaComplete = 2,
        AreaQuit = 3,
        MainMenu = 5
    }
}
