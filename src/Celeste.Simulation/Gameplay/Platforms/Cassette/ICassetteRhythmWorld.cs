using System.Collections.Generic;
using Celeste.Simulation;

namespace Celeste.Simulation.Gameplay.Platforms.Cassette
{
    public interface ICassetteRhythmWorld
    {
        string SessionRoom { get; }
        string CassetteSong { get; }
        bool HasCassetteBlocks { get; }
        int MaxBeat { get; }
        float Tempo { get; }
        global::Celeste.Simulation.Gameplay.Platforms.Cassette.CassetteRhythmOptions Modifier { get; }
        IEnumerable<global::Celeste.Simulation.Gameplay.Platforms.Cassette.ICassetteRhythmBlock> Blocks { get; }
        void Rumble();
        void RemoveManager();
    }
}
