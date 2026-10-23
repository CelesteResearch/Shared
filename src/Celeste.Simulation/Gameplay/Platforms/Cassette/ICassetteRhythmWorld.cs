using System.Collections.Generic;

namespace Celeste.Simulation.Gameplay.Platforms.Cassette
{
    public interface ICassetteRhythmWorld
    {
        string SessionRoom { get; }
        string CassetteSong { get; }
        bool HasCassetteBlocks { get; }
        int MaxBeat { get; }
        float Tempo { get; }
        CassetteRhythmOptions Modifier { get; }
        IEnumerable<ICassetteRhythmBlock> Blocks { get; }
        void Rumble();
        void RemoveManager();
    }
}
