using System;
using Celeste.Core.Scheduling;
using Celeste.Game.Audio.Runtime;
using Celeste.Game.Entities.Decoration.Decals;
using Celeste.Game.Entities.Platforms.Wood;
using Celeste.Game.Execution.Areas;
using Celeste.Game.Execution.Levels.Spawning;
using Celeste.Game.Execution.Levels.Update;
using Celeste.Game.Profiles;
using Celeste.Game.Save.Runtime;
using Celeste.Input.Gameplay.Feedback;
using Celeste.Simulation.Gameplay.Platforms.Foundation;

namespace Celeste.Game.Execution.Levels.Construction
{
    public sealed class OriginalLevelSceneConstruction
    {
        private readonly ISourceEngineContext engine;
        private readonly OriginalGameAudioSession audio;
        private readonly IOriginalGameSaveContext save;
        private readonly IPlatformTargetMotionPolicy targetMotion;
        private readonly IRumbleSession rumble;
        private readonly IOriginalAreaDataResolver areas;
        private readonly IWoodPlatformAddedPolicy woodPlatformPolicy;
        private readonly IOriginalLevelUpdatePolicy update;
        private readonly IOriginalLevelErrorPolicy errors;
        private readonly OriginalDecalFactory decals;
        private readonly IOriginalLevelSpawnPolicy spawn;

        public OriginalLevelSceneConstruction(ISourceEngineContext engine,
            OriginalGameAudioSession audio,
            IOriginalGameSaveContext save,
            IPlatformTargetMotionPolicy targetMotion, IRumbleSession rumble,
            IOriginalAreaDataResolver areas,
            IWoodPlatformAddedPolicy woodPlatformPolicy,
            IOriginalLevelUpdatePolicy update,
            IOriginalLevelErrorPolicy errors, OriginalDecalFactory decals, IOriginalLevelSpawnPolicy spawn)
        {
            this.engine = engine ?? throw new ArgumentNullException(nameof(engine));
            this.audio = audio ?? throw new ArgumentNullException(nameof(audio));
            this.save = save ?? throw new ArgumentNullException(nameof(save));
            this.targetMotion = targetMotion ?? throw new ArgumentNullException(nameof(targetMotion));
            this.rumble = rumble ?? throw new ArgumentNullException(nameof(rumble));
            this.areas = areas ?? throw new ArgumentNullException(nameof(areas));
            this.woodPlatformPolicy = woodPlatformPolicy ?? throw new ArgumentNullException(nameof(woodPlatformPolicy));
            this.update = update ?? throw new ArgumentNullException(nameof(update));
            if (((IGameProfileEnvironment)engine).SourceProfile ==
                GameProfile.InstalledEverest && errors == null)
                throw new ArgumentNullException(nameof(errors));
            if (((IGameProfileEnvironment)engine).SourceProfile == GameProfile.Original &&
                errors != null)
                throw new ArgumentException("Original source has no installed Level error policy.", nameof(errors));
            this.errors = errors;
            this.decals = decals ?? throw new ArgumentNullException(nameof(decals));
            this.spawn = spawn ?? throw new ArgumentNullException(nameof(spawn));
        }

        public OriginalLevelSceneRoot CreateLevel()
        {
            var level = new OriginalLevelSceneRoot(engine);
            level.BindSourceSpawnPolicy(spawn);
            level.BindSourcePlatformConstruction(audio, save,
                targetMotion,
                ((IGameProfileEnvironment)engine).SourceProfile == GameProfile.InstalledEverest
                    ? StaticMoverAttachmentCheckOrder.OwnerFirst
                    : StaticMoverAttachmentCheckOrder.CheckerFirst);
            level.BindSourceAreaDataResolver(areas);
            level.BindSourceWoodPlatformPolicy(woodPlatformPolicy);
            level.BindSourceLevelUpdatePolicy(update);
            if (((IGameProfileEnvironment)engine).SourceProfile == GameProfile.InstalledEverest)
                level.BindSourceErrorPolicy(errors);
            level.BindSourceDecalFactory(decals);
            return level;
        }
    }
}
