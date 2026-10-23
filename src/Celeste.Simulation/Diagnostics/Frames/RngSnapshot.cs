using System;
using System.Numerics;
using System.Runtime.InteropServices;

namespace Celeste.Simulation.Diagnostics.Frames
{
    public readonly struct RngSnapshot
    {
        public readonly bool HasTasUpdateCounter;
        public readonly ulong TasUpdateCounter;
        public readonly RngStreamEvidence Room, Update, Runtime;

        public RngSnapshot(bool hasTasUpdateCounter, ulong tasUpdateCounter, RngStreamEvidence room,
            RngStreamEvidence update, RngStreamEvidence runtime)
        {
            HasTasUpdateCounter = hasTasUpdateCounter;
            TasUpdateCounter = tasUpdateCounter;
            Room = room;
            Update = update;
            Runtime = runtime;
        }
    }
}
