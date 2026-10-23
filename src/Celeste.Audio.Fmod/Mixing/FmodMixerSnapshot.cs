using System.Collections.Generic;
using Celeste.Audio.Fmod.Runtime;

namespace Celeste.Audio.Fmod.Mixing
{
    public sealed class FmodMixerSnapshot
    {
        private readonly struct BusState
        {
            public readonly float Volume;
            public readonly bool Paused, Muted;

            public BusState(FmodBus bus)
            {
                Volume = bus.Volume;
                Paused = bus.Paused;
                Muted = bus.Muted;
            }

            public void Restore(FmodBus bus)
            {
                bus.Volume = Volume;
                bus.Paused = Paused;
                bus.Muted = Muted;
            }
        }

        private readonly Dictionary<string, BusState> buses = new();
        private readonly Dictionary<string, float> vcas = new();

        public FmodMixerSnapshot(FmodStudioRuntime runtime)
        {
            foreach (var path in runtime.Buses()) buses[path] = new(runtime.GetBus(path));
            foreach (var path in runtime.Vcas()) vcas[path] = runtime.GetVca(path).Volume;
        }

        public void Restore(FmodStudioRuntime runtime)
        {
            foreach (var entry in buses) entry.Value.Restore(runtime.GetBus(entry.Key));
            foreach (var entry in vcas) runtime.GetVca(entry.Key).Volume = entry.Value;
        }
    }
}
