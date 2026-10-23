using Celeste.Core.Display;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Geometry;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Mathematics.LinearAlgebra;
using Celeste.Core.Rendering;
using Celeste.Core.Rendering.States;
using Celeste.Core.Scheduling;
using Celeste.Input.Gameplay;
using Celeste.Game.Content.Dialogs;
using Celeste.Game.Content.Maps;
using Celeste.Game.Content.Maps.Levels;
using Celeste.Game.Content.Maps.Entities;
using Celeste.Game.Execution.Areas;
using Celeste.Game.Execution.Session;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.LevelLoader;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Save.Runtime;
using Celeste.Game.Save.IO;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Physics.Collision.Shapes;
using Celeste.Scene.Scenes;
using Celeste.Scene.Tracking;
using Celeste.Simulation.Runtime.Session;
using Celeste.Graphics.Display;
using Celeste.Graphics.Geometry.TwoD.Camera;
using Celeste.Graphics.Text;
using Celeste.Graphics.Rendering;
using Celeste.Graphics.Rendering.Drawing;

namespace Celeste.Game.Editor
{
    public sealed class OriginalLevelTemplateColorsState : LevelTemplateColorsState
    {
        public readonly PackedColor bgTilesColor = PackedColor.DarkSlateGray * 0.5f;
        public override PackedColor BgTilesColor => bgTilesColor;

        public readonly PackedColor[] fgTilesColor = new PackedColor[7]
        {
            PackedColor.White,
            PackedColor.FromHex("f6735e"),
            PackedColor.FromHex("85f65e"),
            PackedColor.FromHex("37d7e3"),
            PackedColor.FromHex("376be3"),
            PackedColor.FromHex("c337e3"),
            PackedColor.FromHex("e33773")
        };

        public override PackedColor[] FgTilesColor => fgTilesColor;
        public readonly PackedColor inactiveBorderColor = PackedColor.DarkSlateGray;
        public override PackedColor InactiveBorderColor => inactiveBorderColor;
        public readonly PackedColor selectedBorderColor = PackedColor.Red;
        public override PackedColor SelectedBorderColor => selectedBorderColor;
        public readonly PackedColor hoveredBorderColor = PackedColor.Yellow;
        public override PackedColor HoveredBorderColor => hoveredBorderColor;
        public readonly PackedColor dummyBgTilesColor = PackedColor.DarkSlateGray * 0.5f;
        public override PackedColor DummyBgTilesColor => dummyBgTilesColor;
        public readonly PackedColor dummyFgTilesColor = PackedColor.LightGray;
        public override PackedColor DummyFgTilesColor => dummyFgTilesColor;
        public readonly PackedColor dummyInactiveBorderColor = PackedColor.DarkOrange;
        public override PackedColor DummyInactiveBorderColor => dummyInactiveBorderColor;
        public readonly PackedColor firstBorderColor = PackedColor.Aqua;
        public override PackedColor FirstBorderColor => firstBorderColor;
    }
}
