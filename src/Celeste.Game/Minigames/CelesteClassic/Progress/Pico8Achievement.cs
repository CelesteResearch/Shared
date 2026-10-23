using Celeste.Core.Geometry;
// ---------------------------------------------------------------------------------------------
// Port of Celeste.Pico8.Classic (Artifacts/Reference/Original/Celeste.Pico8/Classic.cs, 1943
// lines): the Celeste Classic cart that runs inside the Pico-8 fantasy console.
//
// This file is the original cart source mechanically rewritten at the engine boundary only (see
// tools/Transform-Classic.ps1); every statement, expression, literal, field, method, nested type
// and evaluation order is the original's:
//   Classic                  -> Pico8Classic
//   ClassicObject            -> Pico8ClassicObject
//   Emulator                 -> Pico8Emulator
//   Microsoft.Xna.Framework  -> System.Numerics (Vector2) + Celeste.Simulation.Rendering (IntRect)
//   XNA Rectangle            -> IntRect                       (same X/Y/Width/Height fields)
//   XNA Point                -> Pico8Point                    (same X/Y fields)
//   Stats.Increment(Stat.X)  -> G.IncrementStat(Pico8Stat.X)  (Celeste.Stats is a game-global)
//   Achievements.Register(..)-> G.UnlockAchievement(..)       (game-global unlock service)
//   Settings.Instance.ScreenShake -> E.ScreenShake (Pico8ShakeAmount, Celeste.ScreenshakeAmount)
// ---------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Simulation;
using Celeste.Simulation.Rendering;

namespace Celeste.Game.Minigames.CelesteClassic.Progress
{
    public enum Pico8Achievement
    {
        PICO8
    }
}
