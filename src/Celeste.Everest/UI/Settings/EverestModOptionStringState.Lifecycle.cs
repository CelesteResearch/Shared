using System;
using System.Collections;
using System.Numerics;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Core.Timing;
using Celeste.Everest.Runtime.Input;
using Celeste.Input.Gameplay;
using Celeste.Game.Content.Dialogs;
using Celeste.Game.Menus.Overworld;
using Celeste.Game.Execution.Startup;
using Celeste.Game.Execution.Processes;
using Celeste.Scene.Components.Oscillation;
using Celeste.Framework.Diagnostics.Commands;
using Celeste.Graphics.Display;
using Celeste.Graphics.Display.Colors;
using Celeste.Graphics.Rendering;
using Celeste.Graphics.Text;
using global::Celeste.Game.Execution;

namespace Celeste.Everest.UI.Settings
{
    public partial class EverestModOptionStringState
    {
        public override void SceneEnd(object scene)
        {
            base.Overworld.ShowInputUI = true;
            Commands.Enabled = ((IOriginalGamePlayModeEnvironment)engine).PlayMode ==
                               GameRuntime.PlayModes.Debug;
        }
    }
}
