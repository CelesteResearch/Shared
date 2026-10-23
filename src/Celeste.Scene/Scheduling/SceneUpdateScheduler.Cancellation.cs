namespace Celeste.Scene.Scheduling
{
    public sealed partial class SceneUpdateScheduler
    {
        public bool CancelScheduledRemoval(object entity)
        {
            bool scheduled = removing.Remove(entity);
            toRemove.Remove(entity);
            return scheduled;
        }
    }
}
