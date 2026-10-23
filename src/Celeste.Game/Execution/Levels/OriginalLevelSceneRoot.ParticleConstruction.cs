using Celeste.Game.Execution.Startup;
using Celeste.Graphics.Particles.Sources;
using Celeste.Simulation.Presentation.Effects.Mirrors;
using Celeste.Simulation.Presentation.Particles;

namespace Celeste.Game.Execution.Levels
{
    public sealed partial class OriginalLevelSceneRoot : ISourceForegroundParticleScene
    {
        public ParticleSystemPresentation Particles;
        public ParticleSystemPresentation ParticlesBG;
        public ParticleSystemPresentation ParticlesFG;
        ParticleSystemPresentation ISourceForegroundParticleScene.ForegroundParticles => ParticlesFG;

        public void ConstructSourceParticleSystems(ISourceParticleTextureEnvironment sameEngineTextures)
        {
            Particles = new(-8000, 400, EngineContext, sameEngineTextures);
            Particles.Tags = ((IOriginalGameTagsEnvironment)EngineContext).Tags
                .Global.Value;
            Scheduler.QueueSourceEntity(Particles);
            ParticlesBG = new(8000, 400, EngineContext, sameEngineTextures);
            ParticlesBG.Tags = ((IOriginalGameTagsEnvironment)EngineContext)
                .Tags.Global.Value;
            Scheduler.QueueSourceEntity(ParticlesBG);
            ParticlesFG = new(-50000, 800, EngineContext, sameEngineTextures);
            ParticlesFG.Tags = ((IOriginalGameTagsEnvironment)EngineContext)
                .Tags.Global.Value;
            ParticlesFG.OwnedComponents.Add(new MirrorReflectionState());
            Scheduler.QueueSourceEntity(ParticlesFG);
        }
    }
}
