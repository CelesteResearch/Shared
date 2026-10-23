using Celeste.Graphics.Environment.Lighting;
using Celeste.Simulation.Audio;

namespace Celeste.Simulation
{
    public interface IRoomStateTriggerWorld
    {
        bool NoRefills { get; set; }
        string CurrentMusic { get; }
        IRoomAudioSession AudioSession { get; }
        IRoomLightingParameters Environment { get; }
    }
}
