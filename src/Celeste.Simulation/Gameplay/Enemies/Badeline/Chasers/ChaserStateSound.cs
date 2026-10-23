using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Simulation;

namespace Celeste.Simulation.Gameplay.Enemies.Badeline.Chasers
{
    public struct ChaserStateSound
    {
        public enum Actions
        {
            Oneshot,
            Loop,
            Stop
        }

        public string Event, Parameter;
        public float ParameterValue;
        public Actions Action;
    }
}
