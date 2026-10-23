using Celeste.Game.Audio.Application;
using Celeste.Game.Audio.Runtime;
using Celeste.Game.Presentation.Particles;
using Celeste.Game.Save.Runtime;

namespace Celeste.Game.Execution.Processes
{
    public interface IOriginalGameplayProcess
    {
        OriginalAudioStateApplyPolicy AudioApplyPolicy { get; }
        OriginalParticleCatalog ParticleTypes { get; }
        OriginalGameAudioSession AudioSession { get; }
        IOriginalGameSaveContext SaveContext { get; }
    }
}
