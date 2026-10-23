namespace Celeste.Core.Framework.Timing
{
    public enum SourceLevelLoadPhase
    {
        Setup,
        MapEntity,
        MapRemainder,
        ActorPrepare,
        EntityCommit,
        ActorFinalize,
        ObjectTile,
        PostLoad,
        MapClutter,
        MapTriggers,
        MapDecals
    }
}
