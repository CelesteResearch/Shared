using Celeste.Simulation.Audio.Sources;
using Celeste.Simulation.Gameplay.Platforms.DreamBlock;

// ReSharper disable once CheckNamespace
namespace Celeste.Simulation
{
    public sealed partial class RoomPlayerSession
    {
        // ReSharper disable once ConvertToAutoPropertyWithPrivateSetter
        // ReSharper disable once ConvertToAutoProperty
        public ISourceDreamBlock CurrentDreamBlock => dreamBlock;

        // ReSharper disable once ConvertToAutoPropertyWithPrivateSetter
        public SoundSourceComponentState DreamLoopSound => dreamSfxLoop;

        public SoundSourceComponentState EnsureDreamLoopSound(bool disposeOnTransition)
        {
            if (DreamLoopSound == null)
            {
                dreamSfxLoop = ((ISourceSoundSourceEnvironment)EngineContext).SoundSources.Create();
                DreamLoopSound.DisposeOnTransition = disposeOnTransition;
                Components.Add(DreamLoopSound);
            }

            return DreamLoopSound;
        }
    }
}
