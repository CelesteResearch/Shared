using System;
using Celeste.Core.Mathematics;
using Celeste.Game.Profiles;
using Celeste.Game.Gameplay.Environment.Ridge;
using Celeste.Everest.Gameplay.Environment.Ridge;
using Celeste.Game.Entities.Lookouts;
using Celeste.Everest.Gameplay.Lookouts;
using Celeste.Game.Entities.Npcs.Oshiro;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : IOriginalRidgeClothEnvironment,
        IOriginalLookoutConstructionEnvironment, IOriginalResortMirrorEnvironment
    {
        private IOriginalRidgeClothResources sourceCliffFlags, sourceClothesline;
        private IOriginalFlaglineFactory sourceFlaglines;
        private IOriginalLookoutConstructionPolicy sourceLookouts;
        private OriginalResortMirrorRuntimeProfile? sourceResortMirrorProfile;

        public IOriginalRidgeClothResources CliffFlags => sourceCliffFlags ??
                                                          throw new InvalidOperationException(
                                                              "The source CliffFlags resources are not constructed.");

        public IOriginalRidgeClothResources Clothesline => sourceClothesline ??
                                                           throw new InvalidOperationException(
                                                               "The source Clothesline resources are not constructed.");

        public IOriginalFlaglineFactory Flaglines => sourceFlaglines ??
                                                     throw new InvalidOperationException(
                                                         "The source Flagline factory is not selected.");

        public IOriginalLookoutConstructionPolicy LookoutConstruction => sourceLookouts ??
                                                                         throw new InvalidOperationException(
                                                                             "The source Lookout construction is not selected.");

        public OriginalResortMirrorRuntimeProfile ResortMirrorProfile => sourceResortMirrorProfile ??
                                                                         throw new InvalidOperationException(
                                                                             "The source ResortMirror profile is not selected.");

        public void ConstructSourceRidgeLookoutAndMirror()
        {
            if (sourceCliffFlags != null || sourceLookouts != null || sourceResortMirrorProfile.HasValue)
                throw new InvalidOperationException(
                    "The source Ridge/Lookout/Mirror construction is already selected.");
            var scalar = ((ISourceScalarEnvironment)engine).ScalarArithmetic;
            if (SourceProfile == GameProfile.Original)
            {
                sourceCliffFlags = new OriginalCliffFlagsResources(scalar);
                sourceClothesline = new OriginalClotheslineResources(scalar);
                sourceFlaglines = new OriginalFlaglineFactory();
                sourceLookouts = new OriginalLookoutConstructionPolicy();
                sourceResortMirrorProfile = OriginalResortMirrorRuntimeProfile.Original;
            }
            else if (SourceProfile == GameProfile.InstalledEverest)
            {
                sourceCliffFlags = new EverestCliffFlagsResources(scalar);
                sourceClothesline = new EverestClotheslineResources(scalar);
                sourceFlaglines = new EverestFlaglineFactory();
                sourceLookouts = new EverestLookoutConstructionPolicy();
                sourceResortMirrorProfile = OriginalResortMirrorRuntimeProfile.Installed;
            }
            else throw new InvalidOperationException("A supported source profile is required.");
        }
    }
}
