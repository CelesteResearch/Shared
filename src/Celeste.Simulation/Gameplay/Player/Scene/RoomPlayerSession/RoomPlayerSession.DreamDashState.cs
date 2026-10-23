using Celeste.Simulation.Audio.Sources;
using Celeste.Simulation.Gameplay.Platforms.DreamBlock;

namespace Celeste.Simulation
{
    public sealed partial class RoomPlayerSession
    {
        public ISourceDreamBlock CurrentDreamBlock => dreamBlock;
        public SoundSourceComponentState DreamLoopSound => dreamSfxLoop;

        public SoundSourceComponentState EnsureDreamLoopSound(bool disposeOnTransition)
        {
            if (dreamSfxLoop == null)
            {
                dreamSfxLoop = ((ISourceSoundSourceEnvironment)engineContext).SoundSources.Create();
                dreamSfxLoop.DisposeOnTransition = disposeOnTransition;
                Components.Add(dreamSfxLoop);
            }

            return dreamSfxLoop;
        }
    }
}
