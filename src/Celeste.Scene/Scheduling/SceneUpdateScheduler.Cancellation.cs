namespace Celeste.Scene.Scheduling
{
    public sealed partial class SceneUpdateScheduler
    {
        public bool CancelScheduledRemoval(object entity)
        {
            var scheduled = removing.Remove(entity);
            toRemove.Remove(entity);
            return scheduled;
        }
    }
}
