using System;
using Celeste.Core.Scheduling;
using Celeste.Core.Pooling;
using Celeste.Game.Profiles;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : ISourceEngineContext
    {
        private readonly ISourceEngineContext engine;
        private readonly SourceEntityPoolRegistry sourceEntityPools = new SourceEntityPoolRegistry();
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
            global::Celeste.Core.Framework.GarbageCollection.ISourceGarbageCollectionDevice garbageCollection = null)
        {
            if (profile != GameProfile.Original && profile != GameProfile.InstalledEverest)
                throw new ArgumentOutOfRangeException(nameof(profile));
            SourceProfile = profile;
            controlConfigs = CreateControlConfigs(profile);
            engine = this;
            ascendPolicy = CreateAscendPolicy();
            sourceClutterGeneratorInitialization = CreateSourceClutterGeneratorInitialization();
            sourceGarbageCollectionPolicy = CreateSourceGarbageCollectionPolicy(garbageCollection);
            Effects = new SourceEngineEffectsState();
            Frame = new SourceEngineFrameState(Effects);
            originalColorGradeProcess =
                new global::Celeste.Game.Presentation.PostProcessing.ColorGrading.OriginalColorGradeProcess(this,
                    new global::Celeste.Game.Presentation.PostProcessing.ColorGrading.
                        OriginalColorGradeTexturePolicy());
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
