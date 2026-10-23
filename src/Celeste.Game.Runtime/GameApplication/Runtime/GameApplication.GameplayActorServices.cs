namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication
    {
        internal void ConstructSourceGameplayActorServices()
        {
            ConstructSourceBirdChaserBarrierFactories();
            ConstructSourceBadelineOldsiteStatics();
            ConstructSourceFlingBirdStatics();
            ConstructSourceWaterStatics();
            ConstructSourceCheckpointCloudCrumbleFactory();
            ConstructSourceBounceAngryWaterConstruction();
            ConstructSourceSeekerProcess();
            ConstructSourceFireBallProcess();
        }
    }
}
