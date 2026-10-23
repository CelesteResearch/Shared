using System;
using Celeste.Game.Profiles;
using Celeste.Game.Gameplay.Platforms.BounceBlocks;
using Celeste.Everest.Gameplay.Platforms.BounceBlocks;
using Celeste.Game.Gameplay.Enemies.AngryOshiro;
using Celeste.Everest.Gameplay.Enemies.AngryOshiro;
using Celeste.Game.Gameplay.Environment.Water;
using Celeste.Everest.Gameplay.Environment.Water;
using Celeste.Simulation.Gameplay.Environment.Water;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : IOriginalBounceBlockConstructionEnvironment,
        IOriginalAngryOshiroConstructorEnvironment, IOriginalAngryOshiroStateEventsEnvironment,
        IOriginalWaterConstructionEnvironment, IWaterInteractionConstructionEnvironment
    {
        private IOriginalBounceBlockConstructionPolicy sourceBounceBlockConstruction;
        private IOriginalAngryOshiroConstructors sourceAngryOshiroConstructors;
        private IOriginalAngryOshiroStateEvents sourceAngryOshiroStateEvents;
        private IOriginalWaterConstructionPolicy sourceWaterConstruction;
        private IWaterInteractionConstructionPolicy sourceWaterInteractions;

        public IOriginalBounceBlockConstructionPolicy BounceBlockConstruction => sourceBounceBlockConstruction ??
            throw new InvalidOperationException(
                "The source BounceBlock construction is not selected.");

        public IOriginalAngryOshiroConstructors AngryOshiroConstructors => sourceAngryOshiroConstructors ??
                                                                           throw new InvalidOperationException(
                                                                               "The source AngryOshiro construction is not selected.");

        public IOriginalAngryOshiroStateEvents AngryOshiroStateEvents => sourceAngryOshiroStateEvents ??
                                                                         throw new InvalidOperationException(
                                                                             "Actual installed AngryOshiro events are not published for this profile.");

        public IOriginalWaterConstructionPolicy WaterConstruction => sourceWaterConstruction ??
                                                                     throw new InvalidOperationException(
                                                                         "The source Water construction is not selected.");

        public IWaterInteractionConstructionPolicy WaterInteractions => sourceWaterInteractions ??
                                                                        throw new InvalidOperationException(
                                                                            "The source WaterInteraction construction is not selected.");

        public void ConstructSourceBounceAngryWaterConstruction()
        {
            if (sourceBounceBlockConstruction != null || sourceAngryOshiroConstructors != null ||
                sourceWaterConstruction != null)
                throw new InvalidOperationException("The source constructors are already selected.");
            if (SourceProfile == GameProfile.Original)
            {
                sourceBounceBlockConstruction = new OriginalBounceBlockConstructionPolicy();
                sourceAngryOshiroConstructors = new OriginalAngryOshiroConstructors();
                sourceWaterConstruction = OriginalWaterConstructionPolicy.Instance;
                sourceWaterInteractions = OriginalWaterInteractionConstructionPolicy.Instance;
            }
            else if (SourceProfile == GameProfile.InstalledEverest)
            {
                sourceBounceBlockConstruction = new EverestBounceBlockConstructionPolicy();
                sourceAngryOshiroConstructors = new EverestAngryOshiroConstructors();
                sourceAngryOshiroStateEvents = new EverestAngryOshiroStateEvents();
                sourceWaterConstruction = EverestWaterConstructionPolicy.Instance;
                sourceWaterInteractions = EverestWaterInteractionConstructionPolicy.Instance;
            }
            else throw new InvalidOperationException("A supported source profile is required.");
        }
    }
}
