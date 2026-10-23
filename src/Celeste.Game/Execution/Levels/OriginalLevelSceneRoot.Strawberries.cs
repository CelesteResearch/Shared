using System.Numerics;
using Celeste.Core.Geometry;
using Celeste.Core.Maps;
using Celeste.Game.Gameplay.Collectibles.Strawberries;
using Celeste.Game.Gameplay.Collectibles.Strawberries.Points;
using Celeste.Game.Gameplay.Collectibles.Strawberries.Seeds;
using Celeste.Simulation;
using Celeste.Simulation.Presentation.Particles;
using Celeste.Simulation.Presentation.PostProcessing.Displacement;

namespace Celeste.Game.Execution.Levels
{
    public sealed partial class OriginalLevelSceneRoot : IOriginalStrawberryPointsScene
    {
        int IOriginalStrawberryScene.AreaMode => Session.Mode;
        bool IOriginalStrawberryScene.Completed => Completed;
        float IOriginalStrawberryScene.BloomBaseAdd => Session.BloomBaseAdd;
        ParticleSystemPresentation IOriginalStrawberryScene.Particles => Particles;
        ParticleSystemPresentation IOriginalStrawberryScene.ParticlesForeground => ParticlesFG;
        ISourceCameraBounds IOriginalStrawberryPointsScene.Camera => Camera;
        bool IOriginalStrawberryPointsScene.Frozen => Frozen;

        public bool GetSeedCollectionFlag(MapEntityId id)
        {
            return Session.GetFlag(OriginalStrawberryPersistencePolicy.Instance.GetSeedCollectionFlag(id));
        }

        public void SetSeedCollectionFlag(MapEntityId id)
        {
            Session.SetFlag(OriginalStrawberryPersistencePolicy.Instance.GetSeedCollectionFlag(id));
        }

        public bool PlayerInGoldenCollectTrigger(RoomPlayerSession player)
        {
            return player.CollideCheck("Celeste.GoldBerryCollectTrigger");
        }

        public void SetGrabbedGolden()
        {
            Session.GrabbedGolden = true;
        }

        public void RegisterCollectedStrawberry(OriginalStrawberryState strawberry)
        {
            ((IOriginalStrawberryProcess)EngineContext).SaveContext.AddStrawberry(strawberry.ID, strawberry.Golden);
            Session.DoNotLoad.Add(strawberry.ID);
            Session.Strawberries.Add(strawberry.ID);
            Session.UpdateLevelStartDashes();
        }

        public void QueueStrawberryPoints(Vector2 position, bool ghost, int collectIndex, bool moon)
        {
            Scheduler.QueueSourceEntity(new OriginalStrawberryPointsState(position, ghost, collectIndex, moon,
                (IOriginalStrawberryPointsProcess)EngineContext));
        }

        public void QueueStrawberrySeedsCutscene(OriginalStrawberryState strawberry)
        {
            Scheduler.QueueSourceEntity(new StrawberrySeedsCutsceneState(strawberry,
                (IOriginalStrawberryProcess)EngineContext));
        }

        public void AddStrawberryDisplacementBurst(Vector2 position, float duration,
            float radiusFrom, float radiusTo, float alpha)
        {
            Displacement.AddBurst(position, duration, radiusFrom, radiusTo, alpha);
        }

        public DisplacementBurst AddStrawberryPointsBurst(Vector2 position, float duration,
            float radiusFrom, float radiusTo, float alpha)
        {
            return Displacement.AddBurst(position, duration, radiusFrom, radiusTo, alpha);
        }
    }
}
