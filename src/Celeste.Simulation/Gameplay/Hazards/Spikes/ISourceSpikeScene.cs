using System;
using Celeste.Core.Randomness;
using System.Numerics;
using Celeste.Core.Scheduling;
using Celeste.Scene.Tracking;

namespace Celeste.Simulation.Gameplay.Hazards.Spikes
{
    public interface ISourceSpikeScene : ISourceScene, ISourceEngineContextScene
    {
        string SpikeType { get; }
        Vector3[] DustEdgeColors { get; }
        ISourceRandom SpikeRandom { get; }
        void PlaySpikeSound(string path, Vector2 position);
    }
}
