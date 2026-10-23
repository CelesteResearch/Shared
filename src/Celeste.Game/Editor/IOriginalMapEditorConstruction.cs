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
    public interface IOriginalMapEditorConstruction
    {
        MapEditorState Create(ISourceEngineContext engine, OriginalAreaKey area, bool reloadMapData = true);
    }
}
