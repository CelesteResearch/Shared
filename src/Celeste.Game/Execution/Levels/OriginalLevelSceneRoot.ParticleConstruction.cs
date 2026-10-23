using Celeste.Core.Randomness;
using Celeste.Simulation.Presentation.Effects.Mirrors;
using Celeste.Simulation.Presentation.Particles;
using Celeste.Simulation.Presentation.Particles.Scene;
using Celeste.Graphics.Particles.Sources;

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
            Particles = new ParticleSystemPresentation(-8000, 400, EngineContext, sameEngineTextures);
            Particles.Tags = ((global::Celeste.Game.Execution.Startup.IOriginalGameTagsEnvironment)EngineContext).Tags
                .Global.Value;
            Scheduler.QueueSourceEntity(Particles);
            ParticlesBG = new ParticleSystemPresentation(8000, 400, EngineContext, sameEngineTextures);
            ParticlesBG.Tags = ((global::Celeste.Game.Execution.Startup.IOriginalGameTagsEnvironment)EngineContext)
                .Tags.Global.Value;
            Scheduler.QueueSourceEntity(ParticlesBG);
            ParticlesFG = new ParticleSystemPresentation(-50000, 800, EngineContext, sameEngineTextures);
            ParticlesFG.Tags = ((global::Celeste.Game.Execution.Startup.IOriginalGameTagsEnvironment)EngineContext)
                .Tags.Global.Value;
            ParticlesFG.OwnedComponents.Add(new MirrorReflectionState());
            Scheduler.QueueSourceEntity(ParticlesFG);
        }
    }
}
