namespace Celeste.Scene.Tracking
{
    public sealed partial class SceneEntityRegistry
    {
        internal void ForceSortCommittedDepth()
        {
            BeginCommittedRenderIndexSort();
            try
            {
                entities.Sort(entityListProcess.CompareDepth);
            }
            finally
            {
                EndCommittedRenderIndexSort();
            }
        }
    }
}
