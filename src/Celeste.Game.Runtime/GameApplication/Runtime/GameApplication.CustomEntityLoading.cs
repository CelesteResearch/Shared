using System;
using Celeste.Core.Threading;
using Celeste.Everest.Runtime.Levels.Loading.Entities;
using Celeste.Game.Profiles;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : IEverestLevelEntityLoadProcessEnvironment,
        IEverestLevelEntityLoadThreadEnvironment, IEverestLevelCustomEntityLoaderEnvironment
    {
        private SourceTypeInitialization<EverestLevelEntityLoadProcess> sourceLevelEntityLoad;
        private EverestLevelCustomEntityLoader sourceCustomEntities;

        public EverestLevelEntityLoadProcess EntityLoadProcess => (sourceLevelEntityLoad ??
                                                                   throw new InvalidOperationException(
                                                                       "The installed Level entity loading type owner is not constructed."))
            .Value;

        public EverestLevelEntityLoadThreadState CurrentEntityLoadState => EntityLoadProcess.Current;

        public EverestLevelCustomEntityLoader CustomEntities => sourceCustomEntities ??
                                                                throw new InvalidOperationException(
                                                                    "The installed custom entity loader is not constructed.");

        internal void ConstructSourceInstalledEntityLoadTypeOwner()
        {
            if (SourceProfile != GameProfile.InstalledEverest || sourceLevelEntityLoad != null)
                throw new InvalidOperationException(
                    "The installed Level entity loading type owner requires one installed birth.");
            sourceLevelEntityLoad = new(
                "Celeste.Level", new EverestLevelEntityLoadInitializationFactory());
        }

        private void ConstructSourceCustomEntityLoading()
        {
            if (SourceProfile != GameProfile.InstalledEverest || sourceCustomEntities != null)
                throw new InvalidOperationException("The installed custom entity loader requires one installed birth.");
            sourceCustomEntities = new(this, LevelUpdateEvents,
                new(), new(Logger));
        }
    }
}
