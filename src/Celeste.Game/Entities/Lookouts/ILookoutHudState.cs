using Celeste.Core.Display;
using Celeste.Core.Components;
using Celeste.Game.Controls.Source;
using System;
using System.Numerics;
using Celeste.Core.Geometry;
using Celeste.Core.Mathematics;
using Celeste.Core.Rendering;
using Celeste.Input.Gameplay;
using Celeste.Graphics.Content.Atlas;
using Celeste.Game.Execution.Levels;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
using Celeste.Simulation.Gameplay.Collision;
using Celeste.Simulation;
using Celeste.Graphics.Display;
using Celeste.Graphics.Rendering;

namespace Celeste.Game.Entities.Lookouts
{
    public interface ILookoutHudState
    {
        SceneEntityState Entity { get; }
        IOriginalLookoutProcess Process { get; }
        void UpdateComponents();
        bool TrackMode { get; set; }
        float TrackPercent { get; set; }
        bool OnlyY { get; set; }
        float Easer { get; set; }
        float TimerUp { get; set; }
        float TimerDown { get; set; }
        float TimerLeft { get; set; }
        float TimerRight { get; set; }
        float MultUp { get; set; }
        float MultDown { get; set; }
        float MultLeft { get; set; }
        float MultRight { get; set; }
        float Left { get; set; }
        float Right { get; set; }
        float Up { get; set; }
        float Down { get; set; }
        Vector2 Aim { get; set; }
        AtlasEntry HalfDot { get; set; }
    }
}
