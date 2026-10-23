using System;
using System.Numerics;
using System.Runtime.InteropServices;

namespace Celeste.Simulation.Diagnostics.Frames
{
    public readonly struct FrameSnapshotKey
    {
        public readonly long FedInputIndex;
        public readonly FrameSamplePhase Phase;
        public readonly string AreaSid, Room;
        public readonly int SceneGeneration;

        public FrameSnapshotKey(long fedInputIndex, FrameSamplePhase phase,
            string areaSid, string room, int sceneGeneration)
        {
            if (fedInputIndex < 0) throw new ArgumentOutOfRangeException(nameof(fedInputIndex));
            if (sceneGeneration <= 0) throw new ArgumentOutOfRangeException(nameof(sceneGeneration));
            FedInputIndex = fedInputIndex;
            Phase = phase;
            AreaSid = areaSid ?? throw new ArgumentNullException(nameof(areaSid));
            Room = room ?? throw new ArgumentNullException(nameof(room));
            SceneGeneration = sceneGeneration;
        }
    }
}
