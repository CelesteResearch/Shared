using System;
using Celeste.Core.Framework.GarbageCollection;
using Celeste.Core.Pooling;
using Celeste.Core.Scheduling;
using Celeste.Game.Presentation.PostProcessing.ColorGrading;
using Celeste.Game.Profiles;
using JetBrains.Annotations;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : ISourceEngineContext
    {
        private readonly ISourceEngineContext engine;

        [UsedImplicitly(ImplicitUseKindFlags.Access)]
        private readonly SourceEntityPoolRegistry sourceEntityPools = new();

        private bool sourcePoolerPublished;
        public GameProfile SourceProfile { get; }
        public SourceEngineEffectsState Effects { get; }
        public SourceEngineFrameState Frame { get; }
        public float DeltaTime => Frame.DeltaTime;
        public float RawDeltaTime => Frame.RawDeltaTime;

        public bool InputDisabled
        {
            get => MInput.Disabled;
            set => MInput.Disabled = value;
        }

        public SourceEntityPoolRegistry EntityPools => sourceEntityPools;

        public GameApplication(GameProfile profile,
            ISourceGarbageCollectionDevice garbageCollection = null)
        {
            if (profile != GameProfile.Original && profile != GameProfile.InstalledEverest)
                throw new ArgumentOutOfRangeException(nameof(profile));
            SourceProfile = profile;
            controlConfigs = CreateControlConfigs(profile);
            engine = this;
            ascendPolicy = CreateAscendPolicy();
            sourceClutterGeneratorInitialization = CreateSourceClutterGeneratorInitialization();
            sourceGarbageCollectionPolicy = CreateSourceGarbageCollectionPolicy(garbageCollection);
            Effects = new();
            Frame = new(Effects);
            originalColorGradeProcess =
                new(this,
                    new OriginalColorGradeTexturePolicy());
        }

        public void PublishSourcePooler(SourceEntityPoolRegistry actualPooler)
        {
            if (sourcePoolerPublished)
                throw new InvalidOperationException("The source Pooler is already published.");
            if (actualPooler == null) throw new ArgumentNullException(nameof(actualPooler));
            if (!ReferenceEquals(sourceEntityPools, actualPooler))
                throw new InvalidOperationException("The source Pooler must retain its engine owner.");
            sourcePoolerPublished = true;
        }
    }
}
