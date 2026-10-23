using Celeste.Core.Components;
using Celeste.Scene.Tracking;

namespace Celeste.Scene.Scheduling
{
    public sealed partial class SceneUpdateScheduler
    {
        public void ForceAddSourceEntity(ISourceEntityUpdate entity)
        {
            if (!Entities.Contains(entity))
            {
                Entities.AddCommitted(entity);
                if (ActualSceneIdentity != null)
                {
                    TagAdded(entity);
                    Entities.Track(entity);
                    DispatchEntityAdded(entity);
                }
            }

            Entities.ForceSortCommittedDepth();
            if (ReferenceEquals(((ISceneEntityAssociation)entity).Scene, ActualSceneIdentity))
                DispatchEntityAwake(entity);
        }
    }
}
