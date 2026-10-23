using System.Collections.Generic;

namespace Celeste.Audio.Fmod.Mixing
{
    public sealed class FmodMixerSnapshot
    {
        private readonly struct BusState
        {
            public readonly float Volume;
            public readonly bool Paused, Muted;

            public BusState(global::Celeste.Audio.Fmod.Mixing.FmodBus bus)
            {
                Volume = bus.Volume;
                Paused = bus.Paused;
                Muted = bus.Muted;
            }

            public void Restore(global::Celeste.Audio.Fmod.Mixing.FmodBus bus)
            {
                bus.Volume = Volume;
                bus.Paused = Paused;
                bus.Muted = Muted;
            }
        }

        private readonly Dictionary<string, BusState> buses = new Dictionary<string, BusState>();
        private readonly Dictionary<string, float> vcas = new Dictionary<string, float>();

        public FmodMixerSnapshot(global::Celeste.Audio.Fmod.Runtime.FmodStudioRuntime runtime)
        {
            foreach (string path in runtime.Buses()) buses[path] = new BusState(runtime.GetBus(path));
            foreach (string path in runtime.Vcas()) vcas[path] = runtime.GetVca(path).Volume;
        }

        public void Restore(global::Celeste.Audio.Fmod.Runtime.FmodStudioRuntime runtime)
        {
            foreach (var entry in buses) entry.Value.Restore(runtime.GetBus(entry.Key));
            foreach (var entry in vcas) runtime.GetVca(entry.Key).Volume = entry.Value;
        }
    }
}
