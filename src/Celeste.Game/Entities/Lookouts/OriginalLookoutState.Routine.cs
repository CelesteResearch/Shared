using Celeste.Game.Controls.Source;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Mathematics;
using Celeste.Core.Scheduling;
using Celeste.Input.Gameplay;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Gameplay.Environment.Lava.Sandwich;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
using Celeste.Scene.Rendering;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Player.Presentation.Sprites;
using Celeste.Simulation.Gameplay.Player.Presentation.Hair;
using Celeste.Simulation.Presentation.Scene.Transitions;

namespace Celeste.Game.Entities.Lookouts
{
    public partial class OriginalLookoutState
    {
        private IEnumerator LookRoutine(RoomPlayerSession player)
            => LookoutInteractionRoutine.Run(this, player);
    }
}
