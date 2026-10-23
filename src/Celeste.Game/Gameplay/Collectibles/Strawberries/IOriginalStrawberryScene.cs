using System.Numerics;
using Celeste.Scene.Tracking;
using Celeste.Core.Geometry;
using Celeste.Simulation.Presentation.Particles;

namespace Celeste.Game.Gameplay.Collectibles.Strawberries
{
    public interface IOriginalStrawberryScene : ISourceScene
    {
        IntRect Bounds { get; }
        int AreaMode { get; }
        bool Completed { get; }
        float BloomBaseAdd { get; }
        ParticleSystemPresentation Particles { get; }
        ParticleSystemPresentation ParticlesForeground { get; }
        bool GetSeedCollectionFlag(Celeste.Core.Maps.MapEntityId id);
        void SetSeedCollectionFlag(Celeste.Core.Maps.MapEntityId id);
        bool PlayerInGoldenCollectTrigger(Celeste.Simulation.RoomPlayerSession player);
        void SetGrabbedGolden();
        void RegisterCollectedStrawberry(OriginalStrawberryState strawberry);
        void QueueStrawberryPoints(Vector2 position, bool ghost, int collectIndex, bool moon);
        void QueueStrawberrySeedsCutscene(OriginalStrawberryState strawberry);

        void AddStrawberryDisplacementBurst(Vector2 position, float duration,
            float radiusFrom, float radiusTo, float alpha);
    }
}
